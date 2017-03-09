/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct MPH : IQuantity<double>, IEquatable<MPH>, IComparable<MPH>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return MPH.Proxy; } }
        #endregion

        #region Constructor(s)
        public MPH(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator MPH(double q) { return new MPH(q); }
        public static explicit operator MPH(Kilometer_Hour q) { return new MPH((MPH.Factor / Kilometer_Hour.Factor) * q.m_value); }
        public static explicit operator MPH(Meter_Sec q) { return new MPH((MPH.Factor / Meter_Sec.Factor) * q.m_value); }
        public static MPH From(IQuantity<double> q)
        {
            if (q.Unit.Family != MPH.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"MPH\"", q.GetType().Name));
            return new MPH((MPH.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<MPH>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is MPH) && Equals((MPH)obj); }
        public bool /* IEquatable<MPH> */ Equals(MPH other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<MPH>
        public static bool operator ==(MPH lhs, MPH rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(MPH lhs, MPH rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(MPH lhs, MPH rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(MPH lhs, MPH rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(MPH lhs, MPH rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(MPH lhs, MPH rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<MPH> */ CompareTo(MPH other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static MPH operator +(MPH lhs, MPH rhs) { return new MPH(lhs.m_value + rhs.m_value); }
        public static MPH operator -(MPH lhs, MPH rhs) { return new MPH(lhs.m_value - rhs.m_value); }
        public static MPH operator ++(MPH q) { return new MPH(q.m_value + 1d); }
        public static MPH operator --(MPH q) { return new MPH(q.m_value - 1d); }
        public static MPH operator -(MPH q) { return new MPH(-q.m_value); }
        public static MPH operator *(double lhs, MPH rhs) { return new MPH(lhs * rhs.m_value); }
        public static MPH operator *(MPH lhs, double rhs) { return new MPH(lhs.m_value * rhs); }
        public static MPH operator /(MPH lhs, double rhs) { return new MPH(lhs.m_value / rhs); }
        public static double operator /(MPH lhs, MPH rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Mile operator *(MPH lhs, Hour rhs) { return new Mile(lhs.m_value * rhs.m_value); }
        public static Mile operator *(Hour lhs, MPH rhs) { return new Mile(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(MPH.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(MPH.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? MPH.Format, m_value, MPH.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Mile.Sense / Hour.Sense;
        private static readonly int s_family = Meter_Sec.Family;
        private static /*mutable*/ double s_factor = Mile.Factor / Hour.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mph", "mi/h");
        private static readonly Unit<double> s_proxy = new MPH_Proxy();

        private static readonly MPH s_one = new MPH(1d);
        private static readonly MPH s_zero = new MPH(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static MPH One { get { return s_one; } }
        public static MPH Zero { get { return s_zero; } }
        #endregion
    }

    public partial class MPH_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return MPH.Family; } }
        public override Dimension Sense { get { return MPH.Sense; } }
        public override SymbolCollection Symbol { get { return MPH.Symbol; } }
        public override double Factor { get { return MPH.Factor; } set { MPH.Factor = value; } }
        public override string Format { get { return MPH.Format; } set { MPH.Format = value; } }
        #endregion

        #region Constructor(s)
        public MPH_Proxy() :
            base(typeof(MPH))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new MPH(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return MPH.From(quantity);
        }
        #endregion
    }
}
