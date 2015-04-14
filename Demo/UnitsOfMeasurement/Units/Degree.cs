/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Degree : IQuantity<double>, IEquatable<Degree>, IComparable<Degree>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Degree.Sense; } }
        public int UnitFamily { get { return Degree.Family; } }
        public double UnitFactor { get { return Degree.Factor; } }
        public string UnitFormat { get { return Degree.Format; } }
        public SymbolCollection UnitSymbol { get { return Degree.Symbol; } }

        #endregion

        #region Constructor(s)
        public Degree(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Degree(double q) { return new Degree(q); }
        public static explicit operator Degree(Radian q) { return new Degree((Degree.Factor / Radian.Factor) * q.Value); }
        public static explicit operator Degree(Cycles q) { return new Degree((Degree.Factor / Cycles.Factor) * q.Value); }
        public static explicit operator Degree(Grad q) { return new Degree((Degree.Factor / Grad.Factor) * q.Value); }
        public static Degree From(IQuantity<double> q)
        {
            if (q.UnitSense != Degree.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Degree\"", q.GetType().Name));
            return new Degree((Degree.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Degree>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Degree) && Equals((Degree)obj); }
        public bool /* IEquatable<Degree> */ Equals(Degree other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Degree>
        public static bool operator ==(Degree lhs, Degree rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Degree lhs, Degree rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Degree lhs, Degree rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Degree lhs, Degree rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Degree lhs, Degree rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Degree lhs, Degree rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Degree> */ CompareTo(Degree other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Degree operator +(Degree lhs, Degree rhs) { return new Degree(lhs.Value + rhs.Value); }
        public static Degree operator -(Degree lhs, Degree rhs) { return new Degree(lhs.Value - rhs.Value); }
        public static Degree operator ++(Degree q) { return new Degree(q.Value + 1d); }
        public static Degree operator --(Degree q) { return new Degree(q.Value - 1d); }
        public static Degree operator -(Degree q) { return new Degree(-q.Value); }
        public static Degree operator *(double lhs, Degree rhs) { return new Degree(lhs * rhs.Value); }
        public static Degree operator *(Degree lhs, double rhs) { return new Degree(lhs.Value * rhs); }
        public static Degree operator /(Degree lhs, double rhs) { return new Degree(lhs.Value / rhs); }
        public static double operator /(Degree lhs, Degree rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Degree.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Degree.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Degree.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Radian.Sense;
        private static readonly int s_family = Radian.Family;
        private static double s_factor = (180d / Math.PI) * Radian.Factor;
        private static string s_format = "{0}{1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("\u00B0", "deg");

        private static readonly Degree s_one = new Degree(1d);
        private static readonly Degree s_zero = new Degree(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Degree One { get { return s_one; } }
        public static Degree Zero { get { return s_zero; } }
        #endregion
    }
}
