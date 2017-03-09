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

        #region Properties
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
            if (q.Unit.Family != Mile.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Mile\"", q.GetType().Name));
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
        public override string ToString() { return ToString(Mile.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Mile.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Mile.Format, m_value, Mile.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Yard.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = Yard.Factor / 1760d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mil");
        private static readonly Unit<double> s_proxy = new Mile_Proxy();

        private static readonly Mile s_one = new Mile(1d);
        private static readonly Mile s_zero = new Mile(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Mile One { get { return s_one; } }
        public static Mile Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Mile_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Mile.Family; } }
        public override Dimension Sense { get { return Mile.Sense; } }
        public override SymbolCollection Symbol { get { return Mile.Symbol; } }
        public override double Factor { get { return Mile.Factor; } set { Mile.Factor = value; } }
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
