/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Hour : IQuantity<double>, IEquatable<Hour>, IComparable<Hour>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Hour.Proxy; } }
        #endregion

        #region Constructor(s)
        public Hour(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Hour(double q) { return new Hour(q); }
        public static explicit operator Hour(Second q) { return new Hour((Hour.Factor / Second.Factor) * q.m_value); }
        public static explicit operator Hour(Minute q) { return new Hour((Hour.Factor / Minute.Factor) * q.m_value); }
        public static Hour From(IQuantity<double> q)
        {
            if (q.Unit.Family != Hour.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Hour\"", q.GetType().Name));
            return new Hour((Hour.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Hour>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Hour) && Equals((Hour)obj); }
        public bool /* IEquatable<Hour> */ Equals(Hour other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Hour>
        public static bool operator ==(Hour lhs, Hour rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Hour lhs, Hour rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Hour lhs, Hour rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Hour lhs, Hour rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Hour lhs, Hour rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Hour lhs, Hour rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Hour> */ CompareTo(Hour other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Hour operator +(Hour lhs, Hour rhs) { return new Hour(lhs.m_value + rhs.m_value); }
        public static Hour operator -(Hour lhs, Hour rhs) { return new Hour(lhs.m_value - rhs.m_value); }
        public static Hour operator ++(Hour q) { return new Hour(q.m_value + 1d); }
        public static Hour operator --(Hour q) { return new Hour(q.m_value - 1d); }
        public static Hour operator -(Hour q) { return new Hour(-q.m_value); }
        public static Hour operator *(double lhs, Hour rhs) { return new Hour(lhs * rhs.m_value); }
        public static Hour operator *(Hour lhs, double rhs) { return new Hour(lhs.m_value * rhs); }
        public static Hour operator /(Hour lhs, double rhs) { return new Hour(lhs.m_value / rhs); }
        public static double operator /(Hour lhs, Hour rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Hour.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Hour.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Hour.Format, m_value, Hour.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Minute.Sense;
        private static readonly int s_family = Second.Family;
        private static /*mutable*/ double s_factor = Minute.Factor / 60d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("h");
        private static readonly Unit<double> s_proxy = new Hour_Proxy();

        private static readonly Hour s_one = new Hour(1d);
        private static readonly Hour s_zero = new Hour(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Hour One { get { return s_one; } }
        public static Hour Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Hour_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Hour.Family; } }
        public override Dimension Sense { get { return Hour.Sense; } }
        public override SymbolCollection Symbol { get { return Hour.Symbol; } }
        public override double Factor { get { return Hour.Factor; } set { Hour.Factor = value; } }
        public override string Format { get { return Hour.Format; } set { Hour.Format = value; } }
        #endregion

        #region Constructor(s)
        public Hour_Proxy() :
            base(typeof(Hour))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Hour(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Hour.From(quantity);
        }
        #endregion
    }
}
