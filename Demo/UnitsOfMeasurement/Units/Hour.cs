/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Hour : IQuantity<double>, IEquatable<Hour>, IComparable<Hour>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Hour.Sense; } }
        public int UnitFamily { get { return Hour.Family; } }
        public double UnitFactor { get { return Hour.Factor; } }
        public string UnitFormat { get { return Hour.Format; } }
        public SymbolCollection UnitSymbol { get { return Hour.Symbol; } }

        #endregion

        #region Constructor(s)
        public Hour(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Hour(double q) { return new Hour(q); }
        public static explicit operator Hour(Second q) { return new Hour((Hour.Factor / Second.Factor) * q.Value); }
        public static explicit operator Hour(Minute q) { return new Hour((Hour.Factor / Minute.Factor) * q.Value); }
        public static Hour From(IQuantity<double> q)
        {
            if (q.UnitSense != Hour.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Hour\"", q.GetType().Name));
            return new Hour((Hour.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Hour>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Hour) && Equals((Hour)obj); }
        public bool /* IEquatable<Hour> */ Equals(Hour other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Hour>
        public static bool operator ==(Hour lhs, Hour rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Hour lhs, Hour rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Hour lhs, Hour rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Hour lhs, Hour rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Hour lhs, Hour rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Hour lhs, Hour rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Hour> */ CompareTo(Hour other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Hour operator +(Hour lhs, Hour rhs) { return new Hour(lhs.Value + rhs.Value); }
        public static Hour operator -(Hour lhs, Hour rhs) { return new Hour(lhs.Value - rhs.Value); }
        public static Hour operator ++(Hour q) { return new Hour(q.Value + 1d); }
        public static Hour operator --(Hour q) { return new Hour(q.Value - 1d); }
        public static Hour operator -(Hour q) { return new Hour(-q.Value); }
        public static Hour operator *(double lhs, Hour rhs) { return new Hour(lhs * rhs.Value); }
        public static Hour operator *(Hour lhs, double rhs) { return new Hour(lhs.Value * rhs); }
        public static Hour operator /(Hour lhs, double rhs) { return new Hour(lhs.Value / rhs); }
        public static double operator /(Hour lhs, Hour rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Hour.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Hour.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Hour.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Minute.Sense;
        private static readonly int s_family = Second.Family;
        private static double s_factor = Minute.Factor / 60d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("h");

        private static readonly Hour s_one = new Hour(1d);
        private static readonly Hour s_zero = new Hour(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Hour One { get { return s_one; } }
        public static Hour Zero { get { return s_zero; } }
        #endregion
    }
}
