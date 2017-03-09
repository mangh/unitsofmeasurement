/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct DegRankine : IQuantity<double>, IEquatable<DegRankine>, IComparable<DegRankine>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return DegRankine.Proxy; } }
        #endregion

        #region Constructor(s)
        public DegRankine(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator DegRankine(double q) { return new DegRankine(q); }
        public static explicit operator DegRankine(DegCelsius q) { return new DegRankine((DegRankine.Factor / DegCelsius.Factor) * q.m_value); }
        public static explicit operator DegRankine(DegKelvin q) { return new DegRankine((DegRankine.Factor / DegKelvin.Factor) * q.m_value); }
        public static explicit operator DegRankine(DegFahrenheit q) { return new DegRankine((DegRankine.Factor / DegFahrenheit.Factor) * q.m_value); }
        public static DegRankine From(IQuantity<double> q)
        {
            if (q.Unit.Family != DegRankine.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"DegRankine\"", q.GetType().Name));
            return new DegRankine((DegRankine.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<DegRankine>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is DegRankine) && Equals((DegRankine)obj); }
        public bool /* IEquatable<DegRankine> */ Equals(DegRankine other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<DegRankine>
        public static bool operator ==(DegRankine lhs, DegRankine rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(DegRankine lhs, DegRankine rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(DegRankine lhs, DegRankine rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(DegRankine lhs, DegRankine rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(DegRankine lhs, DegRankine rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(DegRankine lhs, DegRankine rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<DegRankine> */ CompareTo(DegRankine other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegRankine operator +(DegRankine lhs, DegRankine rhs) { return new DegRankine(lhs.m_value + rhs.m_value); }
        public static DegRankine operator -(DegRankine lhs, DegRankine rhs) { return new DegRankine(lhs.m_value - rhs.m_value); }
        public static DegRankine operator ++(DegRankine q) { return new DegRankine(q.m_value + 1d); }
        public static DegRankine operator --(DegRankine q) { return new DegRankine(q.m_value - 1d); }
        public static DegRankine operator -(DegRankine q) { return new DegRankine(-q.m_value); }
        public static DegRankine operator *(double lhs, DegRankine rhs) { return new DegRankine(lhs * rhs.m_value); }
        public static DegRankine operator *(DegRankine lhs, double rhs) { return new DegRankine(lhs.m_value * rhs); }
        public static DegRankine operator /(DegRankine lhs, double rhs) { return new DegRankine(lhs.m_value / rhs); }
        public static double operator /(DegRankine lhs, DegRankine rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(DegRankine.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegRankine.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? DegRankine.Format, m_value, DegRankine.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = DegKelvin.Sense;
        private static readonly int s_family = DegKelvin.Family;
        private static /*mutable*/ double s_factor = (9d / 5d) * DegKelvin.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("\u00B0R", "deg.R");
        private static readonly Unit<double> s_proxy = new DegRankine_Proxy();

        private static readonly DegRankine s_one = new DegRankine(1d);
        private static readonly DegRankine s_zero = new DegRankine(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static DegRankine One { get { return s_one; } }
        public static DegRankine Zero { get { return s_zero; } }
        #endregion
    }

    public partial class DegRankine_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return DegRankine.Family; } }
        public override Dimension Sense { get { return DegRankine.Sense; } }
        public override SymbolCollection Symbol { get { return DegRankine.Symbol; } }
        public override double Factor { get { return DegRankine.Factor; } set { DegRankine.Factor = value; } }
        public override string Format { get { return DegRankine.Format; } set { DegRankine.Format = value; } }
        #endregion

        #region Constructor(s)
        public DegRankine_Proxy() :
            base(typeof(DegRankine))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new DegRankine(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return DegRankine.From(quantity);
        }
        #endregion
    }
}
