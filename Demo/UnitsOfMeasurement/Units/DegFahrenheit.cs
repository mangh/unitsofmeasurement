/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct DegFahrenheit : IQuantity<double>, IEquatable<DegFahrenheit>, IComparable<DegFahrenheit>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return DegFahrenheit.Proxy; } }
        #endregion

        #region Constructor(s)
        public DegFahrenheit(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator DegFahrenheit(double q) { return new DegFahrenheit(q); }
        public static explicit operator DegFahrenheit(DegRankine q) { return new DegFahrenheit((DegFahrenheit.Factor / DegRankine.Factor) * q.m_value); }
        public static explicit operator DegFahrenheit(DegCelsius q) { return new DegFahrenheit((DegFahrenheit.Factor / DegCelsius.Factor) * q.m_value); }
        public static explicit operator DegFahrenheit(DegKelvin q) { return new DegFahrenheit((DegFahrenheit.Factor / DegKelvin.Factor) * q.m_value); }
        public static DegFahrenheit From(IQuantity<double> q)
        {
            if (q.Unit.Family != DegFahrenheit.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"DegFahrenheit\"", q.GetType().Name));
            }
            return new DegFahrenheit((DegFahrenheit.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<DegFahrenheit>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is DegFahrenheit) && Equals((DegFahrenheit)obj); }
        public bool /* IEquatable<DegFahrenheit> */ Equals(DegFahrenheit other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<DegFahrenheit>
        public static bool operator ==(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<DegFahrenheit> */ CompareTo(DegFahrenheit other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegFahrenheit operator +(DegFahrenheit lhs, DegFahrenheit rhs) { return new DegFahrenheit(lhs.m_value + rhs.m_value); }
        public static DegFahrenheit operator -(DegFahrenheit lhs, DegFahrenheit rhs) { return new DegFahrenheit(lhs.m_value - rhs.m_value); }
        public static DegFahrenheit operator ++(DegFahrenheit q) { return new DegFahrenheit(q.m_value + 1d); }
        public static DegFahrenheit operator --(DegFahrenheit q) { return new DegFahrenheit(q.m_value - 1d); }
        public static DegFahrenheit operator -(DegFahrenheit q) { return new DegFahrenheit(-q.m_value); }
        public static DegFahrenheit operator *(double lhs, DegFahrenheit rhs) { return new DegFahrenheit(lhs * rhs.m_value); }
        public static DegFahrenheit operator *(DegFahrenheit lhs, double rhs) { return new DegFahrenheit(lhs.m_value * rhs); }
        public static DegFahrenheit operator /(DegFahrenheit lhs, double rhs) { return new DegFahrenheit(lhs.m_value / rhs); }
        public static double operator /(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? DegFahrenheit.Format, q, DegFahrenheit.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = DegKelvin.Sense;
        public const int Family = DegKelvin.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("\u00B0F", "deg.F");
        public static readonly Unit<double> Proxy = new DegFahrenheit_Proxy();
        public const double Factor = (9d / 5d) * DegKelvin.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly DegFahrenheit One = new DegFahrenheit(1d);
        public static readonly DegFahrenheit Zero = new DegFahrenheit(0d);
        #endregion
    }

    public partial class DegFahrenheit_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return DegFahrenheit.Sense; } }
        public override int Family { get { return DegFahrenheit.Family; } }
        public override double Factor { get { return DegFahrenheit.Factor; } }
        public override SymbolCollection Symbol { get { return DegFahrenheit.Symbol; } }
        public override string Format { get { return DegFahrenheit.Format; } set { DegFahrenheit.Format = value; } }
        #endregion

        #region Constructor(s)
        public DegFahrenheit_Proxy() :
            base(typeof(DegFahrenheit))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new DegFahrenheit(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return DegFahrenheit.From(quantity);
        }
        #endregion
    }
}
