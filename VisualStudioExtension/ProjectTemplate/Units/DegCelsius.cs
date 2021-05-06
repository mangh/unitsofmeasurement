/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct DegCelsius : IQuantity<double>, IEquatable<DegCelsius>, IComparable<DegCelsius>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return DegCelsius.Proxy; } }
        #endregion

        #region Constructor(s)
        public DegCelsius(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator DegCelsius(double q) { return new DegCelsius(q); }
        public static explicit operator DegCelsius(DegKelvin q) { return new DegCelsius((DegCelsius.Factor / DegKelvin.Factor) * q.m_value); }
        public static explicit operator DegCelsius(DegFahrenheit q) { return new DegCelsius((DegCelsius.Factor / DegFahrenheit.Factor) * q.m_value); }
        public static DegCelsius From(IQuantity<double> q)
        {
            if (q.Unit.Family != DegCelsius.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"DegCelsius\"", q.GetType().Name));
            }
            return new DegCelsius((DegCelsius.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<DegCelsius>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is DegCelsius) && Equals((DegCelsius)obj); }
        public bool /* IEquatable<DegCelsius> */ Equals(DegCelsius other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<DegCelsius>
        public static bool operator ==(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<DegCelsius> */ CompareTo(DegCelsius other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegCelsius operator +(DegCelsius lhs, DegCelsius rhs) { return new DegCelsius(lhs.m_value + rhs.m_value); }
        public static DegCelsius operator -(DegCelsius lhs, DegCelsius rhs) { return new DegCelsius(lhs.m_value - rhs.m_value); }
        public static DegCelsius operator ++(DegCelsius q) { return new DegCelsius(q.m_value + 1d); }
        public static DegCelsius operator --(DegCelsius q) { return new DegCelsius(q.m_value - 1d); }
        public static DegCelsius operator -(DegCelsius q) { return new DegCelsius(-q.m_value); }
        public static DegCelsius operator *(double lhs, DegCelsius rhs) { return new DegCelsius(lhs * rhs.m_value); }
        public static DegCelsius operator *(DegCelsius lhs, double rhs) { return new DegCelsius(lhs.m_value * rhs); }
        public static DegCelsius operator /(DegCelsius lhs, double rhs) { return new DegCelsius(lhs.m_value / rhs); }
        public static double operator /(DegCelsius lhs, DegCelsius rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? DegCelsius.Format, q, DegCelsius.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = DegKelvin.Sense;
        public const int Family = DegKelvin.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("\u00B0C", "deg.C");
        public static readonly Unit<double> Proxy = new DegCelsius_Proxy();
        public const double Factor = DegKelvin.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly DegCelsius One = new DegCelsius(1d);
        public static readonly DegCelsius Zero = new DegCelsius(0d);
        #endregion
    }

    public partial class DegCelsius_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return DegCelsius.Sense; } }
        public override int Family { get { return DegCelsius.Family; } }
        public override double Factor { get { return DegCelsius.Factor; } }
        public override SymbolCollection Symbol { get { return DegCelsius.Symbol; } }
        public override string Format { get { return DegCelsius.Format; } set { DegCelsius.Format = value; } }
        #endregion

        #region Constructor(s)
        public DegCelsius_Proxy() :
            base(typeof(DegCelsius))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new DegCelsius(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return DegCelsius.From(quantity);
        }
        #endregion
    }
}
