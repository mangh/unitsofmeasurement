/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct Newton : IQuantity<double>, IEquatable<Newton>, IComparable<Newton>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Newton.Sense; } }
        public int UnitFamily { get { return Newton.Family; } }
        public double UnitFactor { get { return Newton.Factor; } }
        public string UnitFormat { get { return Newton.Format; } }
        public SymbolCollection UnitSymbol { get { return Newton.Symbol; } }

        #endregion

        #region Constructor(s)
        public Newton(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Newton(double q) { return new Newton(q); }
        public static Newton From(IQuantity<double> q)
        {
            if (q.UnitSense != Newton.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Newton\"", q.GetType().Name));
            return new Newton((Newton.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Newton>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Newton) && Equals((Newton)obj); }
        public bool /* IEquatable<Newton> */ Equals(Newton other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Newton>
        public static bool operator ==(Newton lhs, Newton rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Newton lhs, Newton rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Newton lhs, Newton rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Newton lhs, Newton rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Newton lhs, Newton rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Newton lhs, Newton rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Newton> */ CompareTo(Newton other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Newton operator +(Newton lhs, Newton rhs) { return new Newton(lhs.Value + rhs.Value); }
        public static Newton operator -(Newton lhs, Newton rhs) { return new Newton(lhs.Value - rhs.Value); }
        public static Newton operator ++(Newton q) { return new Newton(q.Value + 1d); }
        public static Newton operator --(Newton q) { return new Newton(q.Value - 1d); }
        public static Newton operator -(Newton q) { return new Newton(-q.Value); }
        public static Newton operator *(double lhs, Newton rhs) { return new Newton(lhs * rhs.Value); }
        public static Newton operator *(Newton lhs, double rhs) { return new Newton(lhs.Value * rhs); }
        public static Newton operator /(Newton lhs, double rhs) { return new Newton(lhs.Value / rhs); }
        public static double operator /(Newton lhs, Newton rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Meter_Sec2 operator /(Newton lhs, Kilogram rhs) { return new Meter_Sec2(lhs.Value / rhs.Value); }
        public static Kilogram operator /(Newton lhs, Meter_Sec2 rhs) { return new Kilogram(lhs.Value / rhs.Value); }
        public static Joule operator *(Newton lhs, Meter rhs) { return new Joule(lhs.Value * rhs.Value); }
        public static Joule operator *(Meter lhs, Newton rhs) { return new Joule(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Newton.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Newton.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Newton.Format, Value, Newton.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Kilogram.Sense * Meter_Sec2.Sense;
        private static readonly int s_family = 10;
        private static double s_factor = Kilogram.Factor * Meter_Sec2.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("N");

        private static readonly Newton s_one = new Newton(1d);
        private static readonly Newton s_zero = new Newton(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Newton One { get { return s_one; } }
        public static Newton Zero { get { return s_zero; } }
        #endregion
    }
}
