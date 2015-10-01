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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public MPH(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator MPH(double q) { return new MPH(q); }
        public static explicit operator MPH(Kilometer_Hour q) { return new MPH((MPH.Factor / Kilometer_Hour.Factor) * q.Value); }
        public static explicit operator MPH(Meter_Sec q) { return new MPH((MPH.Factor / Meter_Sec.Factor) * q.Value); }
        public static MPH From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != MPH.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"MPH\"", q.GetType().Name));
            return new MPH((MPH.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<MPH>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is MPH) && Equals((MPH)obj); }
        public bool /* IEquatable<MPH> */ Equals(MPH other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<MPH>
        public static bool operator ==(MPH lhs, MPH rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(MPH lhs, MPH rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(MPH lhs, MPH rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(MPH lhs, MPH rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(MPH lhs, MPH rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(MPH lhs, MPH rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<MPH> */ CompareTo(MPH other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static MPH operator +(MPH lhs, MPH rhs) { return new MPH(lhs.Value + rhs.Value); }
        public static MPH operator -(MPH lhs, MPH rhs) { return new MPH(lhs.Value - rhs.Value); }
        public static MPH operator ++(MPH q) { return new MPH(q.Value + 1d); }
        public static MPH operator --(MPH q) { return new MPH(q.Value - 1d); }
        public static MPH operator -(MPH q) { return new MPH(-q.Value); }
        public static MPH operator *(double lhs, MPH rhs) { return new MPH(lhs * rhs.Value); }
        public static MPH operator *(MPH lhs, double rhs) { return new MPH(lhs.Value * rhs); }
        public static MPH operator /(MPH lhs, double rhs) { return new MPH(lhs.Value / rhs); }
        public static double operator /(MPH lhs, MPH rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Mile operator *(MPH lhs, Hour rhs) { return new Mile(lhs.Value * rhs.Value); }
        public static Mile operator *(Hour lhs, MPH rhs) { return new Mile(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(MPH.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(MPH.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? MPH.Format, Value, MPH.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Mile.Sense / Hour.Sense;
        private static readonly int s_family = Meter_Sec.Family;
        private static double s_factor = Mile.Factor / Hour.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mph", "mi/h");

        private static readonly MPH s_one = new MPH(1d);
        private static readonly MPH s_zero = new MPH(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static MPH One { get { return s_one; } }
        public static MPH Zero { get { return s_zero; } }
        #endregion
    }
}
