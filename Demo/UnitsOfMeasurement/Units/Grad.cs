/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Grad : IQuantity<double>, IEquatable<Grad>, IComparable<Grad>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Grad.Sense; } }
        public int UnitFamily { get { return Grad.Family; } }
        public double UnitFactor { get { return Grad.Factor; } }
        public string UnitFormat { get { return Grad.Format; } }
        public SymbolCollection UnitSymbol { get { return Grad.Symbol; } }

        #endregion

        #region Constructor(s)
        public Grad(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Grad(double q) { return new Grad(q); }
        public static explicit operator Grad(Degree q) { return new Grad((Grad.Factor / Degree.Factor) * q.Value); }
        public static explicit operator Grad(Radian q) { return new Grad((Grad.Factor / Radian.Factor) * q.Value); }
        public static explicit operator Grad(Cycles q) { return new Grad((Grad.Factor / Cycles.Factor) * q.Value); }
        public static Grad From(IQuantity<double> q)
        {
            if (q.UnitSense != Grad.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Grad\"", q.GetType().Name));
            return new Grad((Grad.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Grad) && Equals((Grad)obj); }
        public bool /* IEquatable<Grad> */ Equals(Grad other) { return this.Value == other.Value; }
        public int /* IComparable<Grad> */ CompareTo(Grad other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Comparison
        public static bool operator ==(Grad lhs, Grad rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Grad lhs, Grad rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Grad lhs, Grad rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Grad lhs, Grad rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Grad lhs, Grad rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Grad lhs, Grad rhs) { return lhs.Value >= rhs.Value; }
        #endregion

        #region Arithmetic
        // Inner:
        public static Grad operator +(Grad lhs, Grad rhs) { return new Grad(lhs.Value + rhs.Value); }
        public static Grad operator -(Grad lhs, Grad rhs) { return new Grad(lhs.Value - rhs.Value); }
        public static Grad operator ++(Grad q) { return new Grad(q.Value + 1d); }
        public static Grad operator --(Grad q) { return new Grad(q.Value - 1d); }
        public static Grad operator -(Grad q) { return new Grad(-q.Value); }
        public static Grad operator *(double lhs, Grad rhs) { return new Grad(lhs * rhs.Value); }
        public static Grad operator *(Grad lhs, double rhs) { return new Grad(lhs.Value * rhs); }
        public static Grad operator /(Grad lhs, double rhs) { return new Grad(lhs.Value / rhs); }
        // Outer:
        public static double operator /(Grad lhs, Grad rhs) { return lhs.Value / rhs.Value; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Grad.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Grad.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Grad.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Radian.Sense;
        private static readonly int s_family = 27;
        private static double s_factor = (200d / Math.PI) * Radian.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("grad");

        private static readonly Grad s_one = new Grad(1d);
        private static readonly Grad s_zero = new Grad(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Grad One { get { return s_one; } }
        public static Grad Zero { get { return s_zero; } }
        #endregion
    }
}
