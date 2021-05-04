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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != DegRankine.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"DegRankine\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? DegRankine.Format, q, DegRankine.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = DegKelvin.Sense;
        public const int Family = DegKelvin.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("\u00B0R", "deg.R");
        public static readonly Unit<double> Proxy = new DegRankine_Proxy();
        public const double Factor = (9d / 5d) * DegKelvin.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly DegRankine One = new DegRankine(1d);
        public static readonly DegRankine Zero = new DegRankine(0d);
        #endregion
    }

    public partial class DegRankine_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return DegRankine.Sense; } }
        public override int Family { get { return DegRankine.Family; } }
        public override double Factor { get { return DegRankine.Factor; } }
        public override SymbolCollection Symbol { get { return DegRankine.Symbol; } }
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
