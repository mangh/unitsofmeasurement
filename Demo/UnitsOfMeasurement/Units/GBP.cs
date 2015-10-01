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
        private readonly decimal m_value;
        #endregion

        #region Properties
        public decimal Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public GBP(decimal value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator GBP(decimal q) { return new GBP(q); }
        public static explicit operator GBP(USD q) { return new GBP((GBP.Factor / USD.Factor) * q.Value); }
        public static explicit operator GBP(EUR q) { return new GBP((GBP.Factor / EUR.Factor) * q.Value); }
        public static explicit operator GBP(PLN q) { return new GBP((GBP.Factor / PLN.Factor) * q.Value); }
        public static GBP From(IQuantity<decimal> q)
        {
            Unit<decimal> source = new Unit<decimal>(q);
            if (source.Family != GBP.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"GBP\"", q.GetType().Name));
            return new GBP((GBP.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<GBP>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is GBP) && Equals((GBP)obj); }
        public bool /* IEquatable<GBP> */ Equals(GBP other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<GBP>
        public static bool operator ==(GBP lhs, GBP rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(GBP lhs, GBP rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(GBP lhs, GBP rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(GBP lhs, GBP rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(GBP lhs, GBP rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(GBP lhs, GBP rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<GBP> */ CompareTo(GBP other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static GBP operator +(GBP lhs, GBP rhs) { return new GBP(lhs.Value + rhs.Value); }
        public static GBP operator -(GBP lhs, GBP rhs) { return new GBP(lhs.Value - rhs.Value); }
        public static GBP operator ++(GBP q) { return new GBP(q.Value + decimal.One); }
        public static GBP operator --(GBP q) { return new GBP(q.Value - decimal.One); }
        public static GBP operator -(GBP q) { return new GBP(-q.Value); }
        public static GBP operator *(decimal lhs, GBP rhs) { return new GBP(lhs * rhs.Value); }
        public static GBP operator *(GBP lhs, decimal rhs) { return new GBP(lhs.Value * rhs); }
        public static GBP operator /(GBP lhs, decimal rhs) { return new GBP(lhs.Value / rhs); }
        public static decimal operator /(GBP lhs, GBP rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(GBP.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(GBP.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? GBP.Format, Value, GBP.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = EUR.Sense;
        private static readonly int s_family = EUR.Family;
        private static decimal s_factor = 0.79055m * EUR.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("GBP");

        private static readonly GBP s_one = new GBP(decimal.One);
        private static readonly GBP s_zero = new GBP(decimal.Zero);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static GBP One { get { return s_one; } }
        public static GBP Zero { get { return s_zero; } }
        #endregion
    }
}
