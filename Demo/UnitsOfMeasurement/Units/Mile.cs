/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Mile : IQuantity<double>, IEquatable<Mile>, IComparable<Mile>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Mile.Proxy; } }
        #endregion

        #region Constructor(s)
        public Mile(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Mile(double q) { return new Mile(q); }
        public static explicit operator Mile(Kilometer q) { return new Mile((Mile.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Mile(Millimeter q) { return new Mile((Mile.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Mile(Centimeter q) { return new Mile((Mile.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Mile(Meter q) { return new Mile((Mile.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Mile(Inch q) { return new Mile((Mile.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Mile(Foot q) { return new Mile((Mile.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Mile(Yard q) { return new Mile((Mile.Factor / Yard.Factor) * q.m_value); }
        public static Mile From(IQuantity<double> q)
        {
            if (q.Unit.Family != Mile.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Mile\"", q.GetType().Name));
            }
            return new Mile((Mile.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Mile>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Mile) && Equals((Mile)obj); }
        public bool /* IEquatable<Mile> */ Equals(Mile other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Mile>
        public static bool operator ==(Mile lhs, Mile rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Mile lhs, Mile rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Mile lhs, Mile rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Mile lhs, Mile rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Mile lhs, Mile rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Mile lhs, Mile rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Mile> */ CompareTo(Mile other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Mile operator +(Mile lhs, Mile rhs) { return new Mile(lhs.m_value + rhs.m_value); }
        public static Mile operator -(Mile lhs, Mile rhs) { return new Mile(lhs.m_value - rhs.m_value); }
        public static Mile operator ++(Mile q) { return new Mile(q.m_value + 1d); }
        public static Mile operator --(Mile q) { return new Mile(q.m_value - 1d); }
        public static Mile operator -(Mile q) { return new Mile(-q.m_value); }
        public static Mile operator *(double lhs, Mile rhs) { return new Mile(lhs * rhs.m_value); }
        public static Mile operator *(Mile lhs, double rhs) { return new Mile(lhs.m_value * rhs); }
        public static Mile operator /(Mile lhs, double rhs) { return new Mile(lhs.m_value / rhs); }
        public static double operator /(Mile lhs, Mile rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static MPH operator /(Mile lhs, Hour rhs) { return new MPH(lhs.m_value / rhs.m_value); }
        public static Hour operator /(Mile lhs, MPH rhs) { return new Hour(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Mile.Format, q, Mile.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Yard.Sense;
        public const int Family = Meter.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("mil");
        public static readonly Unit<double> Proxy = new Mile_Proxy();
        public const double Factor = Yard.Factor / 1760d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Mile One = new Mile(1d);
        public static readonly Mile Zero = new Mile(0d);
        #endregion
    }

    public partial class Mile_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Mile.Sense; } }
        public override int Family { get { return Mile.Family; } }
        public override double Factor { get { return Mile.Factor; } }
        public override SymbolCollection Symbol { get { return Mile.Symbol; } }
        public override string Format { get { return Mile.Format; } set { Mile.Format = value; } }
        #endregion

        #region Constructor(s)
        public Mile_Proxy() :
            base(typeof(Mile))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Mile(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Mile.From(quantity);
        }
        #endregion
    }
}
