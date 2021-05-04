/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demo.UnitsOfMeasurement
{
    [TestClass]
    public class DimensionTests
    {

#if DIMENSION_UINT64
        private static readonly int MAXEXP = 127;   // exponent max value
        private static readonly int MINEXP = -128;  // exponent min value
#else
        private static readonly int MAXEXP = 7;     // exponent max value
        private static readonly int MINEXP = -8;    // exponent min value
#endif

        [TestClass]
        public class Constructor
        {
            // Valid range of dimension exponent, for any single magnitude is [-8,7],
            // (or [-128,127] for exponents encoded in UInt64).
            [TestMethod]
            [ExpectedException(typeof(System.OverflowException))]
            public void TooLargeExponentsThrowException()
            {
#if DIMENSION_UINT64
                Dimension a = new Dimension(0, -130, 0, 0, 0, 0, 0, 0);
#else
                Dimension a = new Dimension(8, 0, 0, 0, 0, 0, 0, 0);
#endif
            }
        }

        [TestClass]
        public class Operators
        {
            [TestMethod]
            public void Equality()
            {
                Dimension length1 = new Dimension(Magnitude.Length);
                Dimension length2 = new Dimension(1, 0, 0, 0, 0, 0, 0, 0);

                Dimension temperature1 = new Dimension(Magnitude.Temperature);
                Dimension temperature2 = new Dimension(0, 0, 0, 1, 0, 0, 0, 0);

                Assert.IsTrue(
                    (length1 == length2) &&
                    (temperature1 == temperature2) &&
                    (length1 != temperature1)
                );
            }

            [TestMethod]
            public void Product()
            {
                Dimension length = new Dimension(Magnitude.Length);
                Dimension lengthSquared = length * length;
                Assert.IsTrue(lengthSquared[Magnitude.Length] == 2);
            }

            [TestMethod]
            [ExpectedException(typeof(System.OverflowException))]
            public void ProductGivingTooLargeExponentsThrowsException()
            {
#if DIMENSION_UINT64
                Dimension a = new Dimension(65, 0, 0, 0, 0, 0, 0, 0);
                Dimension b = new Dimension(65, 0, 0, 0, 0, 0, 0, 0);
#else
                Dimension a = new Dimension(5, 0, 0, 0, 0, 0, 0, 0);
                Dimension b = new Dimension(5, 0, 0, 0, 0, 0, 0, 0);
#endif
                Dimension product = a * b;
            }

            [TestMethod]
            public void AllProducts()
            {
                VerifyForAllExponents(Product, (a, b) => a + b);
            }

            [TestMethod]
            public void Quotient()
            {
                Dimension length = new Dimension(Magnitude.Length);
                Dimension time = new Dimension(Magnitude.Time);
                Dimension velocity = length / time;

                Assert.IsTrue((velocity[Magnitude.Length] == 1) && (velocity[Magnitude.Time] == -1));
            }

            [TestMethod]
            [ExpectedException(typeof(System.OverflowException))]
            public void QuotienGivingTooLargeExponentsThrowsException()
            {
#if DIMENSION_UINT64
                Dimension a = new Dimension(-65, 0, 0, 0, 0, 0, 0, 0);
                Dimension b = new Dimension(65, 0, 0, 0, 0, 0, 0, 0);
#else
                Dimension a = new Dimension(-5, 0, 0, 0, 0, 0, 0, 0);
                Dimension b = new Dimension(5, 0, 0, 0, 0, 0, 0, 0);
#endif
                Dimension quotient = a / b;
            }

            [TestMethod]
            public void AllQuotients()
            {
                VerifyForAllExponents(Quotient, (a, b) => a - b);
            }

            private void VerifyForAllExponents(Func<Dimension, Dimension, object> operation, Func<int, int, int> expected)
            {
                int[] a = { 0, 0, 0, 0, 0, 0, 0, 0 };
                int[] b = { 0, 0, 0, 0, 0, 0, 0, 0 };

                for (int i = MINEXP; i <= MAXEXP; i++)
                {
                    int magnitude = (i < 0 ? -i : i) % 8;
                    a[magnitude] = i;
                    Dimension A = new Dimension(a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7]);

                    for (int j = MINEXP; j <= MAXEXP; j++)
                    {
                        int bgood = b[magnitude];
                        b[magnitude] = j;
                        Dimension B = new Dimension(b[0], b[1], b[2], b[3], b[4], b[5], b[6], b[7]);

                        object objresult = operation(A, B);
                        if (objresult == null)
                        {
                            Assert.IsFalse(
                                MINEXP <= expected(a[magnitude], b[magnitude]) && expected(a[magnitude], b[magnitude]) <= MAXEXP,
                                "OverflowException for exponent " + magnitude.ToString()
                            );
                            b[magnitude] = bgood;   // restore last good exponent value
                        }
                        else
                        {
                            Dimension result = (Dimension)objresult;
                            for (int m = 0; m < 8; m++)
                            {
                                Assert.IsTrue(
                                    result[(Magnitude)m] == expected(a[m], b[m]) &&
                                    MINEXP <= expected(a[m], b[m]) && expected(a[m], b[m]) <= MAXEXP,
                                    "Unexpected result for exponent " + m.ToString()
                                );
                            }
                        }
                    }
                }
            }

            private object Quotient(Dimension A, Dimension B)
            {
                object quotient = null;
                try { quotient = A / B; }
                catch (System.OverflowException) { ; }
                return quotient;
            }

            private object Product(Dimension A, Dimension B)
            {
                object product = null;
                try { product = A * B; }
                catch (System.OverflowException) { ; }
                return product;
            }

            [TestMethod]
            [ExpectedException(typeof(System.ArgumentException))]
            public void PowerGivingFractionalExponentsThrowException()
            {
                Dimension a = new Dimension(Magnitude.Length);
                Dimension a23 = Dimension.Pow(a, 2, 3); // {2/3, 0, 0, 0, 0, 0, 0, 0} -> a23 -> exception
            }

            [TestMethod]
            public void PowerGivingIntegralExponentsIsOK()
            {
                Dimension a = new Dimension(Magnitude.Length);
                Dimension a3 = a * a * a;
                Dimension a2 = Dimension.Pow(a3, 2, 3); // {3*(2/3), 0, 0, 0, 0, 0, 0, 0} -> a2 -> OK

                Assert.IsTrue(a2[Magnitude.Length] == 2);
            }

            [TestMethod]
            [ExpectedException(typeof(System.OverflowException))]
            public void PowerGivingTooLargeExponentsThrowsException()
            {
#if DIMENSION_UINT64
                Dimension a = new Dimension(65, 0, 0, 0, 0, 0, 0, 0);
#else
                Dimension a = new Dimension(5, 0, 0, 0, 0, 0, 0, 0);
#endif
                Dimension power = Dimension.Pow(a, 2);
            }
        }
    }
}
