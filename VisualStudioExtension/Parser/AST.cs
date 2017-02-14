/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/

using System;

namespace Man.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    internal interface IASTEncoder
    {
        void Encode(ASTNumber number);
        void Encode(ASTLiteral literal);
        void Encode(ASTMagnitude magnitude);
        void Encode(ASTUnit unit);
        void Encode(ASTUnary term);
        void Encode(ASTParenthesized term);
        void Encode(ASTProduct product);
        void Encode(ASTQuotient quotient);
        void Encode(ASTSum sum);
        void Encode(ASTDifference difference);
    }

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    internal abstract class ASTNode
    {
        #region Properties
        public virtual bool IsNumeric { get { return false; } }
        public virtual UnitType Unit { get { return null; } }
        public virtual bool IsWedgeCompatible { get { return false; } }
        #endregion

        #region Constructor(s)
        //protected ASTNode()
        //{
        //}
        #endregion

        #region Methods
        /// <summary>
        /// Encoder entry
        /// </summary>
        public abstract void Accept(IASTEncoder encoder);

        /// <summary>
        /// Rearrange unit expression tree into one of the following canonical forms:
        ///     x * u, u * x, x / u, u / x, u * v, u / v,
        /// to get clear picture of units involved, and bind them in the target source code.
        /// </summary>
        /// <remarks>u, v - units. x - numeric expression (made of numbers and/or literals only)</remarks>
        /// <returns>Canonical expression or null in case no rearrangement could be made</returns>
        /// <example>(180.0 * Radian) / "Math.PI" --> (180.0 / "Math.PI") * Radian</example>
        public virtual ASTNode TryNormalize() { return null; }

        /// <summary>
        /// Move numeric argument, by means of product, down the expression tree.
        /// </summary>
        /// <param name="number">numeric argument found at the upper level of the expression tree</param>
        /// <returns>New expression or null in case no product could be applied</returns>
        public virtual ASTNode TryMultiply(ASTNode number) { return null; }

        /// <summary>
        /// Move numeric argument, by means of quotient, down the expression tree.
        /// </summary>
        /// <param name="number">numeric argument found at the upper level of the expression tree</param>
        /// <returns>New expression or null in case no quotient could be applied</returns>
        public virtual ASTNode TryDivide(ASTNode number) { return null; }

        /// <summary>
        /// Normalized
        /// </summary>
        /// <returns></returns>
        public virtual ASTNode Normalized() { ASTNode normalized = TryNormalize(); return (normalized == null) ? this : normalized; }

        /// <summary>
        /// Bind result unit (the one being currently developed) to the units embedded in 
        /// the underlying (normalized) expression. Depending on the expression, the binding
        /// would be implemented as:
        ///     - conversion operators, for expressions: x * u, u * x, u / x;
        ///     - binary operators, for expressions: u * v, u / v, x / u;
        ///     - not implemented (no binding), for any other expressions.
        /// </summary>
        /// <remarks>u, v - units. x - numeric expression (made of numbers and/or literals only)</remarks>
        public virtual void Bind(UnitType candidate) { }

        #endregion
    }

    internal class ASTNumber : ASTNode
    {
        public Number Number { get; private set; }

        public override bool IsNumeric { get { return true; } }

        public ASTNumber(Number number) :
            base()
        {
            Number = number;
        }

        public override void Accept(IASTEncoder encoder) { encoder.Encode(this); }

        public override string ToString() { return Number.ToString(); }
    }

    internal class ASTLiteral : ASTNode
    {
        public string Literal { get; private set; }

        public override bool IsNumeric { get { return true; } }

        public ASTLiteral(string literal) :
            base()
        {
            Literal = literal;
        }

        public override void Accept(IASTEncoder encoder) { encoder.Encode(this); }

        public override string ToString() { return string.Format("\"{0}\"", Literal); }
    }

    internal class ASTMagnitude : ASTNode
    {
        public int Exponent { get; private set; }

        public ASTMagnitude(Magnitude magnitude) :
            base()
        {
            Exponent = (int)magnitude;
        }
        public ASTMagnitude() :
            base()
        {
            Exponent = -1;
        }

        public override void Accept(IASTEncoder encoder) { encoder.Encode(this); }

        public override string ToString() { return string.Format("<{0}>", Exponent == -1 ? string.Empty : ((Magnitude)Exponent).ToString()); }
    }

    internal class ASTUnit : ASTNode
    {
        private UnitType m_unit;
        public override UnitType Unit { get { return m_unit; } }
        public override bool IsWedgeCompatible { get { return true; } }

        public ASTUnit(UnitType unit) :
            base()
        {
            m_unit = unit;
        }

        public override void Accept(IASTEncoder encoder) { encoder.Encode(this); }

        public override void Bind(UnitType candidate) { m_unit.AddRelative(candidate); }

        public override string ToString() { return m_unit.Name; }
    }

    internal class ASTUnary : ASTNode
    {
        public bool Plus { get; private set; }
        public ASTNode Expr { get; private set; }

        public override bool IsNumeric { get { return Expr.IsNumeric; } }

        public ASTUnary(bool plus, ASTNode expr) :
            base()
        {
            Plus = plus;
            Expr = expr;
        }

        public override void Accept(IASTEncoder encoder) { Expr.Accept(encoder); encoder.Encode(this); }

        public override string ToString() { return string.Format("{0}{1}", Plus ? "+" : "-", Expr.ToString()); }
    }

    internal class ASTParenthesized : ASTNode
    {
        public ASTNode Expr { get; private set; }

        public override bool IsNumeric { get { return Expr.IsNumeric; } }
        public override UnitType Unit { get { return Expr.Unit; } }
        public override bool IsWedgeCompatible { get { return Expr.IsWedgeCompatible; } }

        public ASTParenthesized(ASTNode expr) :
            base()
        {
            Expr = expr;
        }

        public override void Accept(IASTEncoder encoder) { Expr.Accept(encoder); encoder.Encode(this); }

        public override ASTNode TryNormalize()
        {
            ASTNode normalized = Expr.TryNormalize();
            return (normalized != null) ? new ASTParenthesized(normalized) : null;
        }
        public override ASTNode TryMultiply(ASTNode number)
        {
            ASTNode normalized = Expr.TryMultiply(number);
            return (normalized != null) ? new ASTParenthesized(normalized) : null;
        }
        public override ASTNode TryDivide(ASTNode number)
        {
            ASTNode normalized = Expr.TryDivide(number);
            return (normalized != null) ? new ASTParenthesized(normalized) : null;
        }

        public override void Bind(UnitType candidate) { Expr.Bind(candidate); }

        public override string ToString() { return string.Format("({0})", Expr.ToString()); }
    }

    internal class ASTProduct : ASTNode
    {
        private bool m_iswedgeproduct;

        public ASTNode Lhs { get; private set; }
        public ASTNode Rhs { get; private set; }
        public string Operation { get { return m_iswedgeproduct ? "^" : "*"; } }

        public override bool IsNumeric { get { return Lhs.IsNumeric && Rhs.IsNumeric; } }
        public override bool IsWedgeCompatible
        {
            get
            { 
                return m_iswedgeproduct ||
                    (Lhs.IsNumeric && Rhs.IsWedgeCompatible) ||
                    (Lhs.IsWedgeCompatible && Rhs.IsNumeric);
            }
        }

        public ASTProduct(ASTNode lhs, ASTNode rhs, bool iswedgeproduct) :
            base()
        {
            if (iswedgeproduct && (!lhs.IsWedgeCompatible || !rhs.IsWedgeCompatible))
                throw new ArgumentException("Wedge product requires wedge-compatible factors.");

            Lhs = lhs;
            Rhs = rhs;
            m_iswedgeproduct = iswedgeproduct;
        }
        public ASTProduct(ASTNode lhs, ASTNode rhs) :
            this(lhs, rhs, false)
        {
        }

        public override void Accept(IASTEncoder encoder) { Lhs.Accept(encoder); Rhs.Accept(encoder); encoder.Encode(this); }

        public override ASTNode TryNormalize()
        {
            return Lhs.IsNumeric ? Rhs.TryMultiply(Lhs) : (Rhs.IsNumeric ? Lhs.TryMultiply(Rhs) : null);
        }

        // [Lhs * Rhs] / number
        public override ASTNode TryDivide(ASTNode number)
        {
            if (Lhs.IsNumeric)
            {
                // [Lhs * Rhs] / number --> [Lhs / number] * Rhs
                ASTNode quotient = new ASTQuotient(Lhs, number);
                ASTNode normalized = Rhs.TryMultiply(quotient);
                return (normalized != null) ? normalized : new ASTProduct(quotient, Rhs);
            }
            if (Rhs.IsNumeric)
            {
                // [Lhs * Rhs] / number --> Lhs * [Rhs / number]
                ASTNode quotient = new ASTQuotient(Rhs, number);
                ASTNode normalized = Lhs.TryMultiply(quotient);
                return (normalized != null) ? normalized : new ASTProduct(Lhs, quotient);
            }
            return null;
        }

        // [Lhs * Rhs] * number
        public override ASTNode TryMultiply(ASTNode number)
        {
            if (Lhs.IsNumeric)
            {
                // [Lhs * Rhs] * number --> [Lhs * number] * Rhs
                ASTNode product = new ASTProduct(Lhs, number);
                ASTNode normalized = Rhs.TryMultiply(product);
                return (normalized != null) ? normalized : new ASTProduct(product, Rhs);
            }
            if (Rhs.IsNumeric)
            {
                // [Lhs * Rhs] * number --> Lhs * [Rhs * number]
                ASTNode product = new ASTProduct(Rhs, number);
                ASTNode normalized = Lhs.TryMultiply(product);
                return (normalized != null) ? normalized : new ASTProduct(Lhs, product);
            }
            return null;
        }

        public override void Bind(UnitType candidate)
        {
            UnitType L = Lhs.Unit;
            UnitType R = Rhs.Unit;

            if ((L != null) && (R != null))
            {
                // result = unitL * unitR (definition)

                // E.g.: Joule = Newton * Meter
                // Newton.cs (or Meter.cs): 
                //      public static Joule operator *(Newton lhs, Meter rhs) { return new Joule(lhs.Value * rhs.Value); }
                //      public static Joule operator *(Meter lhs, Newton rhs) { return new Joule(lhs.Value * rhs.Value); }
                L.AddOuterOperation(candidate, Operation, L, R);
                if (L.Name != R.Name) L.AddOuterOperation(candidate, Operation, R, L);

                // => result / unitL = unitR
                // => result / unitR = unitL
                //
                // Joule.cs: 
                //      public static Newton operator /(Joule lhs, Meter rhs) { return new Newton(lhs.Value / rhs.Value); }
                //      public static Meter operator /(Joule lhs, Newton rhs) { return new Meter(lhs.Value / rhs.Value); }
                candidate.AddOuterOperation(R, "/", candidate, L);
                if (L.Name != R.Name) candidate.AddOuterOperation(L, "/", candidate, R);
            }
            else if ((L != null) && (Rhs.IsNumeric))
            {
                // result = unit * number (conversion)
                //
                // E.g. Centimeter = Meter * 100.0
                // Meter.cs:
                //      public static explicit operator Meter(Centimeter q) { return new Meter((Meter.Factor / Centimeter.Factor) * q.Value); }
                // Centimeter.cs:
                //      public static explicit operator Centimeter(Meter q) { return new Centimeter((Centimeter.Factor / Meter.Factor) * q.Value); }
                //
                Lhs.Bind(candidate);
            }
            else if ((Lhs.IsNumeric) && (R != null))
            {
                // result = number * unit (conversion)

                // E.g. Centimeter = 100.0 * Meter
                //  Meter.cs:
                //      public static explicit operator Meter(Centimeter q) { return new Meter((Meter.Factor / Centimeter.Factor) * q.Value); }
                //  Centimeter.cs:
                //      public static explicit operator Centimeter(Meter q) { return new Centimeter((Centimeter.Factor / Meter.Factor) * q.Value); }
                //
                Rhs.Bind(candidate);
            }
        }

        public override string ToString() { return string.Format("{0}{1}{2}", Lhs.ToString(), Operation, Rhs.ToString()); }
    }

    internal class ASTQuotient : ASTNode
    {
        public ASTNode Lhs { get; private set; }
        public ASTNode Rhs { get; private set; }

        public override bool IsNumeric { get { return Lhs.IsNumeric && Rhs.IsNumeric; } }
        public override bool IsWedgeCompatible
        {
            get
            {
                return
                    (Lhs.IsWedgeCompatible && Rhs.IsWedgeCompatible) ||
                    (Lhs.IsNumeric && Rhs.IsWedgeCompatible) ||
                    (Lhs.IsWedgeCompatible && Rhs.IsNumeric);
            }
        }

        public ASTQuotient(ASTNode lhs, ASTNode rhs) :
            base()
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public override void Accept(IASTEncoder encoder) { Lhs.Accept(encoder); Rhs.Accept(encoder); encoder.Encode(this); }

        public override ASTNode TryNormalize()
        {
            return Rhs.IsNumeric ? Lhs.TryDivide(Rhs) : null;
        }

        // [Lhs / Rhs] / number
        public override ASTNode TryDivide(ASTNode number)
        {
            if (Lhs.IsNumeric)
            {
                // [Lhs / Rhs] / number --> [Lhs / number] / Rhs
                return new ASTQuotient(new ASTQuotient(Lhs, number), Rhs);
            }
            if (Rhs.IsNumeric)
            {
                // [Lhs / Rhs] / number --> Lhs / [Rhs * number]
                ASTNode product = new ASTParenthesized( new ASTProduct(Rhs, number));
                ASTNode normalized = Lhs.TryDivide(product);
                return (normalized != null) ? normalized : new ASTQuotient(Lhs, product);
            }
            return null;
        }

        // [Lhs / Rhs] * number
        public override ASTNode TryMultiply(ASTNode number)
        {
            if (Lhs.IsNumeric)
            {
                // [Lhs / Rhs] * number --> [Lhs * number] / Rhs
                return new ASTQuotient(new ASTProduct(Lhs, number), Rhs);
            }
            else if (Rhs.IsNumeric)
            {
                // [Lhs / Rhs] * number --> Lhs * [number / Rhs]
                ASTNode quotient = new ASTQuotient(number, Rhs);
                ASTNode normalized = Lhs.TryDivide(quotient);
                return (normalized != null) ? normalized : new ASTQuotient(Lhs, quotient);
            }
            return null;
        }

        public override void Bind(UnitType candidate)
        {
            UnitType L = Lhs.Unit;
            UnitType R = Rhs.Unit;

            if ((L != null) && (R != null))
            {
                // result = unitL / unitR (definition)

                // Quotient of the same unit is always included in the list of outer operations,
                // so we have to avoid to enroll it twice:
                if (String.Equals(L.Name,R.Name)) return;

                // E.g.: MPH = Mile / Hour
                // Mile.cs (or Hour.cs): 
                //      public static MPH operator *(Mile lhs, Hour rhs) { return new MPH(lhs.Value / rhs.Value); }
                L.AddOuterOperation(candidate, "/", L, R);

                // => unitL / result = unitR
                // Mile.cs (or MPH.cs): 
                //      public static Hour operator /(Mile lhs, MPH rhs) { return new Hour(lhs.Value / rhs.Value); }
                L.AddOuterOperation(R, "/", L, candidate);

                // => result * unitR = unitL
                // Hour.cs (or MPH.cs): 
                //      public static Mile operator *(MPH lhs, Hour rhs) { return new Mile(lhs.Value / rhs.Value); }
                candidate.AddOuterOperation(L, "*", candidate, R);
                candidate.AddOuterOperation(L, "*", R, candidate);
            }
            else if ((L != null) && (Rhs.IsNumeric))
            {
                // result = unit / real (conversion)
                //
                // E.g. Meter = Centimeter / 100.0
                // Meter.cs:
                //      public static explicit operator Meter(Centimeter q) { return new Meter((Meter.Factor / Centimeter.Factor) * q.Value); }
                // Centimeter.cs:
                //      public static explicit operator Centimeter(Meter q) { return new Centimeter((Centimeter.Factor / Meter.Factor) * q.Value); }
                //
                Lhs.Bind(candidate);
            }
            else if ((Lhs.IsNumeric) && (R != null))
            {
                // result = real / unit (definition)
                NumericType numType = R.Factor.Value.Type;

                // E.g. Hertz "Hz" = 1.0 / Second
                // Second.cs
                //      public static Hertz operator /(double lhs, Second rhs) { return new Hertz(lhs / rhs.Value); }
                R.AddOuterOperation(candidate, "/", numType, R);

                // Hertz.cs
                //      public static Second operator /(double lhs, Hertz rhs) { return new Second(lhs / rhs.Value); }
                candidate.AddOuterOperation(R, "/", numType, candidate);

                // Hertz.cs (or Second.cs)
                //      public static double operator *(Hertz lhs, Second rhs) { return lhs.Value * rhs.Value; }
                //      public static double operator *(Second lhs, Hertz rhs) { return lhs.Value * rhs.Value; }
                candidate.AddOuterOperation(numType, "*", candidate, R);
                candidate.AddOuterOperation(numType, "*", R, candidate);
            }
        }

        public override string ToString() { return string.Format("{0}/{1}", Lhs.ToString(), Rhs.ToString()); }
    }

    internal class ASTSum : ASTNode
    {
        public ASTNode Lhs { get; private set; }
        public ASTNode Rhs { get; private set; }

        public override bool IsNumeric { get { return Lhs.IsNumeric && Rhs.IsNumeric; } }

        public ASTSum(ASTNode lhs, ASTNode rhs) :
            base()
        {
            Lhs = lhs;
            Rhs = rhs;
        }
        public override void Accept(IASTEncoder encoder) { Lhs.Accept(encoder); Rhs.Accept(encoder); encoder.Encode(this); }

        public override string ToString() { return string.Format("{0}+{1}", Lhs.ToString(), Rhs.ToString()); }
    }

    internal class ASTDifference : ASTNode
    {
        public ASTNode Lhs { get; private set; }
        public ASTNode Rhs { get; private set; }

        public override bool IsNumeric { get { return Lhs.IsNumeric && Rhs.IsNumeric; } }

        public ASTDifference(ASTNode lhs, ASTNode rhs) :
            base()
        {
            Lhs = lhs;
            Rhs = rhs;
        }
        public override void Accept(IASTEncoder encoder) { Lhs.Accept(encoder); Rhs.Accept(encoder); encoder.Encode(this); }

        public override string ToString() { return string.Format("{0}-{1}", Lhs.ToString(), Rhs.ToString()); }
    }
}
