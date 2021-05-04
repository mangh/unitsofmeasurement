/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct PLN : IQuantity<decimal>, IEquatable<PLN>, IComparable<PLN>, IFormattable
    {
        #region Fields
        internal readonly decimal m_value;
        #endregion

        #region Properties / IQuantity<decimal>
        public decimal Value { get { return m_value; } }
        Unit<decimal> IQuantity<decimal>.Unit { get { return PLN.Proxy; } }
        #endregion

        #region Constructor(s)
        public PLN(decimal value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator PLN(decimal q) { return new PLN(q); }
        public static explicit operator PLN(GBP q) { return new PLN((PLN.Factor / GBP.Factor) * q.m_value); }
        public static explicit operator PLN(USD q) { return new PLN((PLN.Factor / USD.Factor) * q.m_value); }
        public static explicit operator PLN(EUR q) { return new PLN((PLN.Factor / EUR.Factor) * q.m_value); }
        public static PLN From(IQuantity<decimal> q)
        {
            if (q.Unit.Family != PLN.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"PLN\"", q.GetType().Name));
            }
            return new PLN((PLN.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<PLN>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is PLN) && Equals((PLN)obj); }
        public bool /* IEquatable<PLN> */ Equals(PLN other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<PLN>
        public static bool operator ==(PLN lhs, PLN rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(PLN lhs, PLN rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(PLN lhs, PLN rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(PLN lhs, PLN rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(PLN lhs, PLN rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(PLN lhs, PLN rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<PLN> */ CompareTo(PLN other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static PLN operator +(PLN lhs, PLN rhs) { return new PLN(lhs.m_value + rhs.m_value); }
        public static PLN operator -(PLN lhs, PLN rhs) { return new PLN(lhs.m_value - rhs.m_value); }
        public static PLN operator ++(PLN q) { return new PLN(q.m_value + decimal.One); }
        public static PLN operator --(PLN q) { return new PLN(q.m_value - decimal.One); }
        public static PLN operator -(PLN q) { return new PLN(-q.m_value); }
        public static PLN operator *(decimal lhs, PLN rhs) { return new PLN(lhs * rhs.m_value); }
        public static PLN operator *(PLN lhs, decimal rhs) { return new PLN(lhs.m_value * rhs); }
        public static PLN operator /(PLN lhs, decimal rhs) { return new PLN(lhs.m_value / rhs); }
        public static decimal operator /(PLN lhs, PLN rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(decimal q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? PLN.Format, q, PLN.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = EUR.Sense;
        public const int Family = EUR.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("PLN");
        public static readonly Unit<decimal> Proxy = new PLN_Proxy();
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        private static decimal s_factor = 4.1437m * EUR.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly PLN One = new PLN(decimal.One);
        public static readonly PLN Zero = new PLN(decimal.Zero);
        #endregion
    }

    public partial class PLN_Proxy : Unit<decimal>
    {
        #region Properties
        public override Dimension Sense { get { return PLN.Sense; } }
        public override int Family { get { return PLN.Family; } }
        public override decimal Factor { get { return PLN.Factor; } set { PLN.Factor = value; } }
        public override SymbolCollection Symbol { get { return PLN.Symbol; } }
        public override string Format { get { return PLN.Format; } set { PLN.Format = value; } }
        #endregion

        #region Constructor(s)
        public PLN_Proxy() :
            base(typeof(PLN))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<decimal> Create(decimal value)
        {
            return new PLN(value);
        }
        public override IQuantity<decimal> From(IQuantity<decimal> quantity)
        {
            return PLN.From(quantity);
        }
        #endregion
    }
}
