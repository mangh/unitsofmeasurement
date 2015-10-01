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
        private readonly decimal m_value;
        #endregion

        #region Properties
        public decimal Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public EUR(decimal value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator EUR(decimal q) { return new EUR(q); }
        public static explicit operator EUR(PLN q) { return new EUR((EUR.Factor / PLN.Factor) * q.Value); }
        public static explicit operator EUR(USD q) { return new EUR((EUR.Factor / USD.Factor) * q.Value); }
        public static EUR From(IQuantity<decimal> q)
        {
            Unit<decimal> source = new Unit<decimal>(q);
            if (source.Family != EUR.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"EUR\"", q.GetType().Name));
            return new EUR((EUR.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<EUR>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is EUR) && Equals((EUR)obj); }
        public bool /* IEquatable<EUR> */ Equals(EUR other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<EUR>
        public static bool operator ==(EUR lhs, EUR rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(EUR lhs, EUR rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(EUR lhs, EUR rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(EUR lhs, EUR rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(EUR lhs, EUR rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(EUR lhs, EUR rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<EUR> */ CompareTo(EUR other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static EUR operator +(EUR lhs, EUR rhs) { return new EUR(lhs.Value + rhs.Value); }
        public static EUR operator -(EUR lhs, EUR rhs) { return new EUR(lhs.Value - rhs.Value); }
        public static EUR operator ++(EUR q) { return new EUR(q.Value + decimal.One); }
        public static EUR operator --(EUR q) { return new EUR(q.Value - decimal.One); }
        public static EUR operator -(EUR q) { return new EUR(-q.Value); }
        public static EUR operator *(decimal lhs, EUR rhs) { return new EUR(lhs * rhs.Value); }
        public static EUR operator *(EUR lhs, decimal rhs) { return new EUR(lhs.Value * rhs); }
        public static EUR operator /(EUR lhs, decimal rhs) { return new EUR(lhs.Value / rhs); }
        public static decimal operator /(EUR lhs, EUR rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(EUR.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(EUR.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? EUR.Format, Value, EUR.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Other;
        private static readonly int s_family = 4;
        private static decimal s_factor = decimal.One;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("EUR");

        private static readonly EUR s_one = new EUR(decimal.One);
        private static readonly EUR s_zero = new EUR(decimal.Zero);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static EUR One { get { return s_one; } }
        public static EUR Zero { get { return s_zero; } }
        #endregion
    }
}
