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

        #region Properties
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
            if (q.Unit.Family != DegKelvin.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"DegKelvin\"", q.GetType().Name));
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
        public override string ToString() { return ToString(DegKelvin.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegKelvin.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? DegKelvin.Format, m_value, DegKelvin.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Dimension.Temperature;
        private static readonly int s_family = 3;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("K", "deg.K");
        private static readonly Unit<double> s_proxy = new DegKelvin_Proxy();

        private static readonly DegKelvin s_one = new DegKelvin(1d);
        private static readonly DegKelvin s_zero = new DegKelvin(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static DegKelvin One { get { return s_one; } }
        public static DegKelvin Zero { get { return s_zero; } }
        #endregion
    }

    public partial class DegKelvin_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return DegKelvin.Family; } }
        public override Dimension Sense { get { return DegKelvin.Sense; } }
        public override SymbolCollection Symbol { get { return DegKelvin.Symbol; } }
        public override double Factor { get { return DegKelvin.Factor; } set { DegKelvin.Factor = value; } }
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
