/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct DegCelsius : IQuantity<double>, IEquatable<DegCelsius>, IComparable<DegCelsius>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
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
        public static explicit operator DegCelsius(DegRankine q) { return new DegCelsius((DegCelsius.Factor / DegRankine.Factor) * q.m_value); }
        public static DegCelsius From(IQuantity<double> q)
        {
            if (q.Unit.Family != DegCelsius.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"DegCelsius\"", q.GetType().Name));
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
        public override string ToString() { return ToString(DegCelsius.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegCelsius.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? DegCelsius.Format, m_value, DegCelsius.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = DegKelvin.Sense;
        private static readonly int s_family = DegKelvin.Family;
        private static /*mutable*/ double s_factor = DegKelvin.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("\u00B0C", "deg.C");
        private static readonly Unit<double> s_proxy = new DegCelsius_Proxy();

        private static readonly DegCelsius s_one = new DegCelsius(1d);
        private static readonly DegCelsius s_zero = new DegCelsius(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static DegCelsius One { get { return s_one; } }
        public static DegCelsius Zero { get { return s_zero; } }
        #endregion
    }

    public partial class DegCelsius_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return DegCelsius.Family; } }
        public override Dimension Sense { get { return DegCelsius.Sense; } }
        public override SymbolCollection Symbol { get { return DegCelsius.Symbol; } }
        public override double Factor { get { return DegCelsius.Factor; } set { DegCelsius.Factor = value; } }
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
