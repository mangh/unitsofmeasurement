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
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return MillimeterHg.Proxy; } }
        #endregion

        #region Constructor(s)
        public MillimeterHg(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator MillimeterHg(double q) { return new MillimeterHg(q); }
        public static explicit operator MillimeterHg(AtmStandard q) { return new MillimeterHg((MillimeterHg.Factor / AtmStandard.Factor) * q.m_value); }
        public static explicit operator MillimeterHg(AtmTechnical q) { return new MillimeterHg((MillimeterHg.Factor / AtmTechnical.Factor) * q.m_value); }
        public static explicit operator MillimeterHg(Bar q) { return new MillimeterHg((MillimeterHg.Factor / Bar.Factor) * q.m_value); }
        public static explicit operator MillimeterHg(Pascal q) { return new MillimeterHg((MillimeterHg.Factor / Pascal.Factor) * q.m_value); }
        public static MillimeterHg From(IQuantity<double> q)
        {
            if (q.Unit.Family != MillimeterHg.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"MillimeterHg\"", q.GetType().Name));
            return new MillimeterHg((MillimeterHg.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<MillimeterHg>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is MillimeterHg) && Equals((MillimeterHg)obj); }
        public bool /* IEquatable<MillimeterHg> */ Equals(MillimeterHg other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<MillimeterHg>
        public static bool operator ==(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<MillimeterHg> */ CompareTo(MillimeterHg other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static MillimeterHg operator +(MillimeterHg lhs, MillimeterHg rhs) { return new MillimeterHg(lhs.m_value + rhs.m_value); }
        public static MillimeterHg operator -(MillimeterHg lhs, MillimeterHg rhs) { return new MillimeterHg(lhs.m_value - rhs.m_value); }
        public static MillimeterHg operator ++(MillimeterHg q) { return new MillimeterHg(q.m_value + 1d); }
        public static MillimeterHg operator --(MillimeterHg q) { return new MillimeterHg(q.m_value - 1d); }
        public static MillimeterHg operator -(MillimeterHg q) { return new MillimeterHg(-q.m_value); }
        public static MillimeterHg operator *(double lhs, MillimeterHg rhs) { return new MillimeterHg(lhs * rhs.m_value); }
        public static MillimeterHg operator *(MillimeterHg lhs, double rhs) { return new MillimeterHg(lhs.m_value * rhs); }
        public static MillimeterHg operator /(MillimeterHg lhs, double rhs) { return new MillimeterHg(lhs.m_value / rhs); }
        public static double operator /(MillimeterHg lhs, MillimeterHg rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(MillimeterHg.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(MillimeterHg.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? MillimeterHg.Format, m_value, MillimeterHg.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Pascal.Sense;
        private static readonly int s_family = Pascal.Family;
        private static /*mutable*/ double s_factor = Pascal.Factor * (13.5951d * 9.80665d);
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mmHg");
        private static readonly Unit<double> s_proxy = new MillimeterHg_Proxy();

        private static readonly MillimeterHg s_one = new MillimeterHg(1d);
        private static readonly MillimeterHg s_zero = new MillimeterHg(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static MillimeterHg One { get { return s_one; } }
        public static MillimeterHg Zero { get { return s_zero; } }
        #endregion
    }

    public partial class MillimeterHg_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return MillimeterHg.Family; } }
        public override Dimension Sense { get { return MillimeterHg.Sense; } }
        public override SymbolCollection Symbol { get { return MillimeterHg.Symbol; } }
        public override double Factor { get { return MillimeterHg.Factor; } set { MillimeterHg.Factor = value; } }
        public override string Format { get { return MillimeterHg.Format; } set { MillimeterHg.Format = value; } }
        #endregion

        #region Constructor(s)
        public MillimeterHg_Proxy() :
            base(typeof(MillimeterHg))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new MillimeterHg(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return MillimeterHg.From(quantity);
        }
        #endregion
    }
}
