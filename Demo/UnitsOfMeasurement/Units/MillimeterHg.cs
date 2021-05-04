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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != MillimeterHg.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"MillimeterHg\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? MillimeterHg.Format, q, MillimeterHg.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Pascal.Sense;
        public const int Family = Pascal.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("mmHg");
        public static readonly Unit<double> Proxy = new MillimeterHg_Proxy();
        public const double Factor = Pascal.Factor * (13.5951d * 9.80665d);
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly MillimeterHg One = new MillimeterHg(1d);
        public static readonly MillimeterHg Zero = new MillimeterHg(0d);
        #endregion
    }

    public partial class MillimeterHg_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return MillimeterHg.Sense; } }
        public override int Family { get { return MillimeterHg.Family; } }
        public override double Factor { get { return MillimeterHg.Factor; } }
        public override SymbolCollection Symbol { get { return MillimeterHg.Symbol; } }
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
