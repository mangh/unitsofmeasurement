/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct EUR : IQuantity<decimal>, IEquatable<EUR>, IComparable<EUR>, IFormattable
    {
        #region Fields
        internal readonly decimal m_value;
        #endregion

        #region Properties
        public decimal Value { get { return m_value; } }
        Unit<decimal> IQuantity<decimal>.Unit { get { return EUR.Proxy; } }
        #endregion

        #region Constructor(s)
        public EUR(decimal value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator EUR(decimal q) { return new EUR(q); }
        public static explicit operator EUR(PLN q) { return new EUR((EUR.Factor / PLN.Factor) * q.m_value); }
        public static EUR From(IQuantity<decimal> q)
        {
            if (q.Unit.Family != EUR.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"EUR\"", q.GetType().Name));
            return new EUR((EUR.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<EUR>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is EUR) && Equals((EUR)obj); }
        public bool /* IEquatable<EUR> */ Equals(EUR other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<EUR>
        public static bool operator ==(EUR lhs, EUR rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(EUR lhs, EUR rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(EUR lhs, EUR rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(EUR lhs, EUR rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(EUR lhs, EUR rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(EUR lhs, EUR rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<EUR> */ CompareTo(EUR other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static EUR operator +(EUR lhs, EUR rhs) { return new EUR(lhs.m_value + rhs.m_value); }
        public static EUR operator -(EUR lhs, EUR rhs) { return new EUR(lhs.m_value - rhs.m_value); }
        public static EUR operator ++(EUR q) { return new EUR(q.m_value + decimal.One); }
        public static EUR operator --(EUR q) { return new EUR(q.m_value - decimal.One); }
        public static EUR operator -(EUR q) { return new EUR(-q.m_value); }
        public static EUR operator *(decimal lhs, EUR rhs) { return new EUR(lhs * rhs.m_value); }
        public static EUR operator *(EUR lhs, decimal rhs) { return new EUR(lhs.m_value * rhs); }
        public static EUR operator /(EUR lhs, decimal rhs) { return new EUR(lhs.m_value / rhs); }
        public static decimal operator /(EUR lhs, EUR rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(EUR.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(EUR.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? EUR.Format, m_value, EUR.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Dimension.Other;
        private static readonly int s_family = 4;
        private static /*mutable*/ decimal s_factor = decimal.One;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("EUR");
        private static readonly Unit<decimal> s_proxy = new EUR_Proxy();

        private static readonly EUR s_one = new EUR(decimal.One);
        private static readonly EUR s_zero = new EUR(decimal.Zero);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<decimal> Proxy { get { return s_proxy; } }

        public static EUR One { get { return s_one; } }
        public static EUR Zero { get { return s_zero; } }
        #endregion
    }

    public partial class EUR_Proxy : Unit<decimal>
    {
        #region Properties
        public override int Family { get { return EUR.Family; } }
        public override Dimension Sense { get { return EUR.Sense; } }
        public override SymbolCollection Symbol { get { return EUR.Symbol; } }
        public override decimal Factor { get { return EUR.Factor; } set { EUR.Factor = value; } }
        public override string Format { get { return EUR.Format; } set { EUR.Format = value; } }
        #endregion

        #region Constructor(s)
        public EUR_Proxy() :
            base(typeof(EUR))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<decimal> Create(decimal value)
        {
            return new EUR(value);
        }
        public override IQuantity<decimal> From(IQuantity<decimal> quantity)
        {
            return EUR.From(quantity);
        }
        #endregion
    }
}
