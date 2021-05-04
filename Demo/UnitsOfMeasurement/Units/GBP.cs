/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct GBP : IQuantity<decimal>, IEquatable<GBP>, IComparable<GBP>, IFormattable
    {
        #region Fields
        internal readonly decimal m_value;
        #endregion

        #region Properties / IQuantity<decimal>
        public decimal Value { get { return m_value; } }
        Unit<decimal> IQuantity<decimal>.Unit { get { return GBP.Proxy; } }
        #endregion

        #region Constructor(s)
        public GBP(decimal value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator GBP(decimal q) { return new GBP(q); }
        public static explicit operator GBP(USD q) { return new GBP((GBP.Factor / USD.Factor) * q.m_value); }
        public static explicit operator GBP(EUR q) { return new GBP((GBP.Factor / EUR.Factor) * q.m_value); }
        public static explicit operator GBP(PLN q) { return new GBP((GBP.Factor / PLN.Factor) * q.m_value); }
        public static GBP From(IQuantity<decimal> q)
        {
            if (q.Unit.Family != GBP.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"GBP\"", q.GetType().Name));
            }
            return new GBP((GBP.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<GBP>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is GBP) && Equals((GBP)obj); }
        public bool /* IEquatable<GBP> */ Equals(GBP other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<GBP>
        public static bool operator ==(GBP lhs, GBP rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(GBP lhs, GBP rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(GBP lhs, GBP rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(GBP lhs, GBP rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(GBP lhs, GBP rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(GBP lhs, GBP rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<GBP> */ CompareTo(GBP other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static GBP operator +(GBP lhs, GBP rhs) { return new GBP(lhs.m_value + rhs.m_value); }
        public static GBP operator -(GBP lhs, GBP rhs) { return new GBP(lhs.m_value - rhs.m_value); }
        public static GBP operator ++(GBP q) { return new GBP(q.m_value + decimal.One); }
        public static GBP operator --(GBP q) { return new GBP(q.m_value - decimal.One); }
        public static GBP operator -(GBP q) { return new GBP(-q.m_value); }
        public static GBP operator *(decimal lhs, GBP rhs) { return new GBP(lhs * rhs.m_value); }
        public static GBP operator *(GBP lhs, decimal rhs) { return new GBP(lhs.m_value * rhs); }
        public static GBP operator /(GBP lhs, decimal rhs) { return new GBP(lhs.m_value / rhs); }
        public static decimal operator /(GBP lhs, GBP rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(decimal q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? GBP.Format, q, GBP.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = EUR.Sense;
        public const int Family = EUR.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("GBP");
        public static readonly Unit<decimal> Proxy = new GBP_Proxy();
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        private static decimal s_factor = 0.79055m * EUR.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly GBP One = new GBP(decimal.One);
        public static readonly GBP Zero = new GBP(decimal.Zero);
        #endregion
    }

    public partial class GBP_Proxy : Unit<decimal>
    {
        #region Properties
        public override Dimension Sense { get { return GBP.Sense; } }
        public override int Family { get { return GBP.Family; } }
        public override decimal Factor { get { return GBP.Factor; } set { GBP.Factor = value; } }
        public override SymbolCollection Symbol { get { return GBP.Symbol; } }
        public override string Format { get { return GBP.Format; } set { GBP.Format = value; } }
        #endregion

        #region Constructor(s)
        public GBP_Proxy() :
            base(typeof(GBP))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<decimal> Create(decimal value)
        {
            return new GBP(value);
        }
        public override IQuantity<decimal> From(IQuantity<decimal> quantity)
        {
            return GBP.From(quantity);
        }
        #endregion
    }
}
