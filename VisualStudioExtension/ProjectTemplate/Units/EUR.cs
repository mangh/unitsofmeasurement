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

        #region Properties / IQuantity<decimal>
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
            if (q.Unit.Family != EUR.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"EUR\"", q.GetType().Name));
            }
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
        public static string String(decimal q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? EUR.Format, q, EUR.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Dimension.Other;
        public const int Family = 4;
        public static readonly SymbolCollection Symbol = new SymbolCollection("EUR");
        public static readonly Unit<decimal> Proxy = new EUR_Proxy();
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        private static decimal s_factor = decimal.One;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly EUR One = new EUR(decimal.One);
        public static readonly EUR Zero = new EUR(decimal.Zero);
        #endregion
    }

    public partial class EUR_Proxy : Unit<decimal>
    {
        #region Properties
        public override Dimension Sense { get { return EUR.Sense; } }
        public override int Family { get { return EUR.Family; } }
        public override decimal Factor { get { return EUR.Factor; } set { EUR.Factor = value; } }
        public override SymbolCollection Symbol { get { return EUR.Symbol; } }
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
