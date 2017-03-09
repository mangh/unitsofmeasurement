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

        #region Properties
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
            if (q.Unit.Family != GBP.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"GBP\"", q.GetType().Name));
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
        public override string ToString() { return ToString(GBP.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(GBP.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? GBP.Format, m_value, GBP.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = EUR.Sense;
        private static readonly int s_family = EUR.Family;
        private static /*mutable*/ decimal s_factor = 0.79055m * EUR.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("GBP");
        private static readonly Unit<decimal> s_proxy = new GBP_Proxy();

        private static readonly GBP s_one = new GBP(decimal.One);
        private static readonly GBP s_zero = new GBP(decimal.Zero);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<decimal> Proxy { get { return s_proxy; } }

        public static GBP One { get { return s_one; } }
        public static GBP Zero { get { return s_zero; } }
        #endregion
    }

    public partial class GBP_Proxy : Unit<decimal>
    {
        #region Properties
        public override int Family { get { return GBP.Family; } }
        public override Dimension Sense { get { return GBP.Sense; } }
        public override SymbolCollection Symbol { get { return GBP.Symbol; } }
        public override decimal Factor { get { return GBP.Factor; } set { GBP.Factor = value; } }
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
