/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct MillimeterHg : IQuantity<double>, IEquatable<MillimeterHg>, IComparable<MillimeterHg>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public MillimeterHg(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator MillimeterHg(double q) { return new MillimeterHg(q); }
        public static explicit operator MillimeterHg(AtmStandard q) { return new MillimeterHg((MillimeterHg.Factor / AtmStandard.Factor) * q.Value); }
        public static explicit operator MillimeterHg(AtmTechnical q) { return new MillimeterHg((MillimeterHg.Factor / AtmTechnical.Factor) * q.Value); }
        public static explicit operator MillimeterHg(Bar q) { return new MillimeterHg((MillimeterHg.Factor / Bar.Factor) * q.Value); }
        public static explicit operator MillimeterHg(Pascal q) { return new MillimeterHg((MillimeterHg.Factor / Pascal.Factor) * q.Value); }
        public static MillimeterHg From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != MillimeterHg.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"MillimeterHg\"", q.GetType().Name));
            return new MillimeterHg((MillimeterHg.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<MillimeterHg>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is MillimeterHg) && Equals((MillimeterHg)obj); }
        public bool /* IEquatable<MillimeterHg> */ Equals(MillimeterHg other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<MillimeterHg>
        public static bool operator ==(MillimeterHg lhs, MillimeterHg rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(MillimeterHg lhs, MillimeterHg rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(MillimeterHg lhs, MillimeterHg rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(MillimeterHg lhs, MillimeterHg rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(MillimeterHg lhs, MillimeterHg rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(MillimeterHg lhs, MillimeterHg rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<MillimeterHg> */ CompareTo(MillimeterHg other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static MillimeterHg operator +(MillimeterHg lhs, MillimeterHg rhs) { return new MillimeterHg(lhs.Value + rhs.Value); }
        public static MillimeterHg operator -(MillimeterHg lhs, MillimeterHg rhs) { return new MillimeterHg(lhs.Value - rhs.Value); }
        public static MillimeterHg operator ++(MillimeterHg q) { return new MillimeterHg(q.Value + 1d); }
        public static MillimeterHg operator --(MillimeterHg q) { return new MillimeterHg(q.Value - 1d); }
        public static MillimeterHg operator -(MillimeterHg q) { return new MillimeterHg(-q.Value); }
        public static MillimeterHg operator *(double lhs, MillimeterHg rhs) { return new MillimeterHg(lhs * rhs.Value); }
        public static MillimeterHg operator *(MillimeterHg lhs, double rhs) { return new MillimeterHg(lhs.Value * rhs); }
        public static MillimeterHg operator /(MillimeterHg lhs, double rhs) { return new MillimeterHg(lhs.Value / rhs); }
        public static double operator /(MillimeterHg lhs, MillimeterHg rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(MillimeterHg.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(MillimeterHg.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? MillimeterHg.Format, Value, MillimeterHg.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Pascal.Sense;
        private static readonly int s_family = Pascal.Family;
        private static double s_factor = Pascal.Factor * (13.5951d * 9.80665d);
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mmHg");

        private static readonly MillimeterHg s_one = new MillimeterHg(1d);
        private static readonly MillimeterHg s_zero = new MillimeterHg(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static MillimeterHg One { get { return s_one; } }
        public static MillimeterHg Zero { get { return s_zero; } }
        #endregion
    }
}
