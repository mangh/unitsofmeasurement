/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct USD : IQuantity<decimal>, IEquatable<USD>, IComparable<USD>, IFormattable
    {
        #region Fields
        internal readonly decimal m_value;
        #endregion

        #region Properties
        public decimal Value { get { return m_value; } }
        Unit<decimal> IQuantity<decimal>.Unit { get { return USD.Proxy; } }
        #endregion

        #region Constructor(s)
        public USD(decimal value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator USD(decimal q) { return new USD(q); }
        public static explicit operator USD(EUR q) { return new USD((USD.Factor / EUR.Factor) * q.m_value); }
        public static explicit operator USD(PLN q) { return new USD((USD.Factor / PLN.Factor) * q.m_value); }
        public static explicit operator USD(GBP q) { return new USD((USD.Factor / GBP.Factor) * q.m_value); }
        public static USD From(IQuantity<decimal> q)
        {
            if (q.Unit.Family != USD.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"USD\"", q.GetType().Name));
            return new USD((USD.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<USD>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is USD) && Equals((USD)obj); }
        public bool /* IEquatable<USD> */ Equals(USD other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<USD>
        public static bool operator ==(USD lhs, USD rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(USD lhs, USD rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(USD lhs, USD rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(USD lhs, USD rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(USD lhs, USD rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(USD lhs, USD rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<USD> */ CompareTo(USD other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static USD operator +(USD lhs, USD rhs) { return new USD(lhs.m_value + rhs.m_value); }
        public static USD operator -(USD lhs, USD rhs) { return new USD(lhs.m_value - rhs.m_value); }
        public static USD operator ++(USD q) { return new USD(q.m_value + decimal.One); }
        public static USD operator --(USD q) { return new USD(q.m_value - decimal.One); }
        public static USD operator -(USD q) { return new USD(-q.m_value); }
        public static USD operator *(decimal lhs, USD rhs) { return new USD(lhs * rhs.m_value); }
        public static USD operator *(USD lhs, decimal rhs) { return new USD(lhs.m_value * rhs); }
        public static USD operator /(USD lhs, decimal rhs) { return new USD(lhs.m_value / rhs); }
        public static decimal operator /(USD lhs, USD rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(USD.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(USD.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? USD.Format, m_value, USD.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = EUR.Sense;
        private static readonly int s_family = EUR.Family;
        private static /*mutable*/ decimal s_factor = 1.3433m * EUR.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("USD");
        private static readonly Unit<decimal> s_proxy = new USD_Proxy();

        private static readonly USD s_one = new USD(decimal.One);
        private static readonly USD s_zero = new USD(decimal.Zero);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<decimal> Proxy { get { return s_proxy; } }

        public static USD One { get { return s_one; } }
        public static USD Zero { get { return s_zero; } }
        #endregion
    }

    public partial class USD_Proxy : Unit<decimal>
    {
        #region Properties
        public override int Family { get { return USD.Family; } }
        public override Dimension Sense { get { return USD.Sense; } }
        public override SymbolCollection Symbol { get { return USD.Symbol; } }
        public override decimal Factor { get { return USD.Factor; } set { USD.Factor = value; } }
        public override string Format { get { return USD.Format; } set { USD.Format = value; } }
        #endregion

        #region Constructor(s)
        public USD_Proxy() :
            base(typeof(USD))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<decimal> Create(decimal value)
        {
            return new USD(value);
        }
        public override IQuantity<decimal> From(IQuantity<decimal> quantity)
        {
            return USD.From(quantity);
        }
        #endregion
    }
}
