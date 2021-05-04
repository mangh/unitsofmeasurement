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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Hour.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Hour\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Hour.Format, q, Hour.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Minute.Sense;
        public const int Family = Second.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("h");
        public static readonly Unit<double> Proxy = new Hour_Proxy();
        public const double Factor = Minute.Factor / 60d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Hour One = new Hour(1d);
        public static readonly Hour Zero = new Hour(0d);
        #endregion
    }

    public partial class Hour_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Hour.Sense; } }
        public override int Family { get { return Hour.Family; } }
        public override double Factor { get { return Hour.Factor; } }
        public override SymbolCollection Symbol { get { return Hour.Symbol; } }
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
