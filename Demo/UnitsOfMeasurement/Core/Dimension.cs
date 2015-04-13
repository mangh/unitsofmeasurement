/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license

    N O T E
    -------
    This file have to be consistent with that used in parser,
    therefore YOU SHOULD NOT MODIFY IT unless you know what you're doing!

********************************************************************************/

using System;

#if DIMENSION_UINT64 
    using DIMENSION = System.UInt64;
#else
    using DIMENSION = System.UInt32;
#endif

namespace Demo.UnitsOfMeasurement
{
    public enum Magnitude : int
    {
        Length = 0,
        Time = 1,
        Mass = 2,
        Temperature = 3,
        ElectricCurrent = 4,
        AmountOfSubstance = 5,
        LuminousIntensity = 6,
        Other = 7,
        Money = Other,
    }

    public struct Dimension : IEquatable<Dimension>
    {
        #region Constants
        // Constants for exponent fields within UInt64/32 dimension structure:
#if DIMENSION_UINT64 
        private const int COMPLEMENT = 256;   // 2's complement base
        private const int MAXEXP = 127;   // exponent max value
        private const int MINEXP = -128;  // exponent min value
        private const int LOGWIDTH = 3;   // exponent bit-width = 2^LOGWIDTH
        private const byte EXPMASK = 0xFF;    // exponent bit mask
#if !STANDARD_ARITHMETIC
        private const DIMENSION CARRY = 0x7F7F7F7F7F7F7F7F;   // carry/borrow bits for binary addition/subtraction
#endif
#else
        private const int COMPLEMENT = 16;    // 2's complement base
        private const int MAXEXP = 7; // exponent max value
        private const int MINEXP = -8;    // exponent min value
        private const int LOGWIDTH = 2;   // exponent bit-width = 2^LOGWIDTH
        private const byte EXPMASK = 0x0F;    // exponent bit mask
#if !STANDARD_ARITHMETIC
        private const DIMENSION CARRY = 0x77777777;   // carry/borrow bits for binary addition/subtraction
#endif
#endif

        // Dimensional constants
        public static readonly Dimension None = new Dimension();    // new Dimension(0, 0, 0, 0, 0, 0, 0, 0);
        public static readonly Dimension Length = new Dimension(Magnitude.Length);
        public static readonly Dimension Time = new Dimension(Magnitude.Time);
        public static readonly Dimension Mass = new Dimension(Magnitude.Mass);
        public static readonly Dimension Temperature = new Dimension(Magnitude.Temperature);
        public static readonly Dimension ElectricCurrent = new Dimension(Magnitude.ElectricCurrent);
        public static readonly Dimension AmountOfSubstance = new Dimension(Magnitude.AmountOfSubstance);
        public static readonly Dimension LuminousIntensity = new Dimension(Magnitude.LuminousIntensity);
        public static readonly Dimension Other = new Dimension(Magnitude.Money);
        public static readonly Dimension Money = new Dimension(Magnitude.Other);

        private static readonly string[] s_symbol = 
        { 
            "L",        /* Length */
            "T",        /* Time */
            "M",        /* Mass */
            "\u03F4"    /* Temperature (Θ - greek capital letter theta) */,
            "I",        /* Electric Current */
            "N",        /* Amount of Substance */
            "J",        /* Luminous Intensity */
            "\u00A4"    /* Money (¤ - generic currency sign) */
        };
        #endregion

        #region Properties
        private DIMENSION m_exponents;
        public DIMENSION Exponents { get { return m_exponents; } }
        #endregion

        #region Constructor(s)
        // Base unit
        public Dimension(Magnitude magnitude)
        {
            m_exponents = 0;
            this[magnitude] = 1;
        }

        // Complex unit
        public Dimension(int length, int time, int mass, int temperature, int current, int substance, int intensity, int other)
        {
            m_exponents = 0;

            this[Magnitude.Length] = length;
            this[Magnitude.Time] = time;
            this[Magnitude.Mass] = mass;
            this[Magnitude.Temperature] = temperature;
            this[Magnitude.ElectricCurrent] = current;
            this[Magnitude.AmountOfSubstance] = substance;
            this[Magnitude.LuminousIntensity] = intensity;
            this[Magnitude.Other] = other;
        }

        private Dimension(DIMENSION exponents)
        {
            m_exponents = exponents;
        }

        #endregion Constructor(s)

        #region Indexer(s)
        public int this[Magnitude magnitude]
        {
            get
            {
                int exponent = (int)magnitude;
                byte x = (byte)((m_exponents >> (exponent << LOGWIDTH)) & EXPMASK);
                return (x > MAXEXP) ? ((int)x - COMPLEMENT) : (int)x;
            }
            private set
            {
                int exponent = (int)magnitude;
                if ((value < MINEXP) || (MAXEXP < value))
                    throw new OverflowException(String.Format("Dimension \"{0}\": exponent value \"{1}\" out of range [{2},{3}].", magnitude.ToString(), value, MINEXP, MAXEXP));
                m_exponents |= ((DIMENSION)(value & EXPMASK)) << (exponent << LOGWIDTH);
            }
        }
        #endregion Indexer(s)

        #region IEquatable<Dimension>
        public bool Equals(Dimension other)
        {
            return m_exponents == other.Exponents;
        }
        public override bool Equals(object obj)
        {
            return (obj != null) && (obj is Dimension) && Equals((Dimension)obj);
        }
        public override int GetHashCode()
        {
            return m_exponents.GetHashCode();
        }
        #endregion IEquatable<Dimension>

        #region Operators
        public static bool operator ==(Dimension A, Dimension B) { return A.Equals(B); }
        public static bool operator !=(Dimension A, Dimension B) { return !A.Equals(B); }

        public static Dimension operator *(Dimension x, Dimension y)
        {
#if STANDARD_ARITHMETIC
            return new Dimension(
                x[Magnitude.Length] + y[Magnitude.Length],
                x[Magnitude.Time] + y[Magnitude.Time],
                x[Magnitude.Mass] + y[Magnitude.Mass],
                x[Magnitude.Temperature] + y[Magnitude.Temperature],
                x[Magnitude.ElectricCurrent] + y[Magnitude.ElectricCurrent],
                x[Magnitude.AmountOfSubstance] + y[Magnitude.AmountOfSubstance],
                x[Magnitude.LuminousIntensity] + y[Magnitude.LuminousIntensity],
                x[Magnitude.Other] + y[Magnitude.Other]
            );
#else
            // The algoritm below is a modified binary addition of two's complement integers.
            // It performs parallel addition of 8 exponents numbers packed within dimension structure.
            // The addition is performed in UP TO 5 iterations (for 4-bit exponents) or 9 iteration (for 8-bit exponents).
            // This is significantly faster than old algorithm (above) that always requires 16 unpacks, 8 additions and 8 packs.
            // However it's very ugly (in that it's hard to see what is it doing) and that's why I left the old one as an option.
            DIMENSION sum = x.Exponents ^ y.Exponents;
            DIMENSION summed;
            DIMENSION carry = x.Exponents & y.Exponents;
            DIMENSION carried = 0;
            while (carry != 0)
            {
                carried |= carry;
                carry &= CARRY; // no bit can be carried over between adjacent exponent numbers
                carry <<= 1;
                summed = sum;
                sum = summed ^ carry;
                carry = summed & carry;
            }
            // Check overflow condition:
            if (((carried ^ (carried << 1)) & ~CARRY) != 0)
                throw new OverflowException(String.Format("Dimension product \"{0} * {1}\" out of range [{2},{3}]", x.ToString(), y.ToString(), MINEXP, MAXEXP));

            return new Dimension(sum);
#endif
        }

        public static Dimension operator /(Dimension x, Dimension y)
        {
#if STANDARD_ARITHMETIC
            return new Dimension(
                x[Magnitude.Length] - y[Magnitude.Length],
                x[Magnitude.Time] - y[Magnitude.Time],
                x[Magnitude.Mass] - y[Magnitude.Mass],
                x[Magnitude.Temperature] - y[Magnitude.Temperature],
                x[Magnitude.ElectricCurrent] - y[Magnitude.ElectricCurrent],
                x[Magnitude.AmountOfSubstance] - y[Magnitude.AmountOfSubstance],
                x[Magnitude.LuminousIntensity] - y[Magnitude.LuminousIntensity],
                x[Magnitude.Other] - y[Magnitude.Other]
            );
#else
            // The algoritm below is a modified binary subtraction of two's complement integers.
            // It performs parallel subtraction of 8 exponents numbers packed within dimension structure.
            // The subtraction is performed in UP TO 5 iterations (for 4-bit exponents) or 9 iteration (for 8-bit exponents).
            // This is significantly faster than old algorithm (above) that always requires 16 unpacks, 8 subtractions and 8 packs.
            // However it's very ugly (in that it's hard to see what is it doing) and that's why I left the old one as an option.
            DIMENSION difference = x.Exponents ^ y.Exponents;
            DIMENSION borrow = difference & y.Exponents;
            DIMENSION borrowed = 0;
            while (borrow != 0)
            {
                borrowed |= borrow;
                borrow &= CARRY;    // no bit can be carried over between adjacent exponent numbers
                borrow <<= 1;
                difference ^= borrow;
                borrow &= difference;
            }
            // Check overflow condition:                
            if (((borrowed ^ (borrowed << 1)) & ~CARRY) != 0)
                throw new OverflowException(String.Format("Dimension quotient \"{0} / {1}\" out of range [{2},{3}]", x.ToString(), y.ToString(), MINEXP, MAXEXP));

            return new Dimension(difference);
#endif
        }

        public static Dimension Pow(Dimension x, int num, int den)
        {
            int xLength = x[Magnitude.Length];
            int xTime = x[Magnitude.Time];
            int xMass = x[Magnitude.Mass];
            int xTemperature = x[Magnitude.Temperature];
            int xCurrent = x[Magnitude.ElectricCurrent];
            int xSubstance = x[Magnitude.AmountOfSubstance];
            int xIntensity = x[Magnitude.LuminousIntensity];
            int xOther = x[Magnitude.Other];

            if ((den != 1) &&
                (((xLength % den) != 0) ||
                ((xTime % den) != 0) ||
                ((xMass % den) != 0) ||
                ((xTemperature % den) != 0) ||
                ((xCurrent % den) != 0) ||
                ((xSubstance % den) != 0) ||
                ((xIntensity % den) != 0) ||
                ((xOther % den) != 0)))
                throw new ArgumentException(String.Format("Pow({0},{1},{2}): cannot create dimension with fractional exponent(s)", x, num, den));

            return new Dimension(
                (xLength / den) * num,
                (xTime / den) * num,
                (xMass / den) * num,
                (xTemperature / den) * num,
                (xCurrent / den) * num,
                (xSubstance / den) * num,
                (xIntensity / den) * num,
                (xOther / den) * num
            );
        }

        public static Dimension Pow(Dimension x, int num)
        {
            return Pow(x, num, 1);
        }

        public static Dimension Sqrt(Dimension x)
        {
            return Pow(x, 1, 2);
        }
        #endregion Operators

        #region Formatting
        public override string ToString()
        {
            string ret = ExponentToString(Magnitude.Length) +
                        ExponentToString(Magnitude.Time) +
                        ExponentToString(Magnitude.Mass) +
                        ExponentToString(Magnitude.Temperature) +
                        ExponentToString(Magnitude.ElectricCurrent) +
                        ExponentToString(Magnitude.AmountOfSubstance) +
                        ExponentToString(Magnitude.LuminousIntensity) +
                        ExponentToString(Magnitude.Other);

            return String.IsNullOrWhiteSpace(ret) ? "1" : ret;
        }

        private string ExponentToString(Magnitude magnitude)
        {
            int exponent = this[magnitude];
            return (exponent == 0) ? String.Empty :
                ((exponent == 1) ? s_symbol[(int)magnitude] : s_symbol[(int)magnitude] + /* "^" + */ exponent.ToString());
        }
        #endregion Formatting
    }
}
