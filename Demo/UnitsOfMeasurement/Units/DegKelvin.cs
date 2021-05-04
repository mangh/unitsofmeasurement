/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct DegKelvin : IQuantity<double>, IEquatable<DegKelvin>, IComparable<DegKelvin>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return DegKelvin.Proxy; } }
        #endregion

        #region Constructor(s)
        public DegKelvin(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator DegKelvin(double q) { return new DegKelvin(q); }
        public static explicit operator DegKelvin(DegFahrenheit q) { return new DegKelvin((DegKelvin.Factor / DegFahrenheit.Factor) * q.m_value); }
        public static explicit operator DegKelvin(DegRankine q) { return new DegKelvin((DegKelvin.Factor / DegRankine.Factor) * q.m_value); }
        public static explicit operator DegKelvin(DegCelsius q) { return new DegKelvin((DegKelvin.Factor / DegCelsius.Factor) * q.m_value); }
        public static DegKelvin From(IQuantity<double> q)
        {
            if (q.Unit.Family != DegKelvin.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"DegKelvin\"", q.GetType().Name));
            }
            return new DegKelvin((DegKelvin.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<DegKelvin>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is DegKelvin) && Equals((DegKelvin)obj); }
        public bool /* IEquatable<DegKelvin> */ Equals(DegKelvin other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<DegKelvin>
        public static bool operator ==(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<DegKelvin> */ CompareTo(DegKelvin other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegKelvin operator +(DegKelvin lhs, DegKelvin rhs) { return new DegKelvin(lhs.m_value + rhs.m_value); }
        public static DegKelvin operator -(DegKelvin lhs, DegKelvin rhs) { return new DegKelvin(lhs.m_value - rhs.m_value); }
        public static DegKelvin operator ++(DegKelvin q) { return new DegKelvin(q.m_value + 1d); }
        public static DegKelvin operator --(DegKelvin q) { return new DegKelvin(q.m_value - 1d); }
        public static DegKelvin operator -(DegKelvin q) { return new DegKelvin(-q.m_value); }
        public static DegKelvin operator *(double lhs, DegKelvin rhs) { return new DegKelvin(lhs * rhs.m_value); }
        public static DegKelvin operator *(DegKelvin lhs, double rhs) { return new DegKelvin(lhs.m_value * rhs); }
        public static DegKelvin operator /(DegKelvin lhs, double rhs) { return new DegKelvin(lhs.m_value / rhs); }
        public static double operator /(DegKelvin lhs, DegKelvin rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? DegKelvin.Format, q, DegKelvin.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Dimension.Temperature;
        public const int Family = 3;
        public static readonly SymbolCollection Symbol = new SymbolCollection("K", "deg.K");
        public static readonly Unit<double> Proxy = new DegKelvin_Proxy();
        public const double Factor = 1d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly DegKelvin One = new DegKelvin(1d);
        public static readonly DegKelvin Zero = new DegKelvin(0d);
        #endregion
    }

    public partial class DegKelvin_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return DegKelvin.Sense; } }
        public override int Family { get { return DegKelvin.Family; } }
        public override double Factor { get { return DegKelvin.Factor; } }
        public override SymbolCollection Symbol { get { return DegKelvin.Symbol; } }
        public override string Format { get { return DegKelvin.Format; } set { DegKelvin.Format = value; } }
        #endregion

        #region Constructor(s)
        public DegKelvin_Proxy() :
            base(typeof(DegKelvin))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new DegKelvin(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return DegKelvin.From(quantity);
        }
        #endregion
    }
}
