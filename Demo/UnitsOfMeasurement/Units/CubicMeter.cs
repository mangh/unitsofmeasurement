/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct CubicMeter : IQuantity<double>, IEquatable<CubicMeter>, IComparable<CubicMeter>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public CubicMeter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator CubicMeter(double q) { return new CubicMeter(q); }
        public static CubicMeter From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != CubicMeter.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"CubicMeter\"", q.GetType().Name));
            return new CubicMeter((CubicMeter.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<CubicMeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is CubicMeter) && Equals((CubicMeter)obj); }
        public bool /* IEquatable<CubicMeter> */ Equals(CubicMeter other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<CubicMeter>
        public static bool operator ==(CubicMeter lhs, CubicMeter rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(CubicMeter lhs, CubicMeter rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(CubicMeter lhs, CubicMeter rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(CubicMeter lhs, CubicMeter rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(CubicMeter lhs, CubicMeter rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(CubicMeter lhs, CubicMeter rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<CubicMeter> */ CompareTo(CubicMeter other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static CubicMeter operator +(CubicMeter lhs, CubicMeter rhs) { return new CubicMeter(lhs.Value + rhs.Value); }
        public static CubicMeter operator -(CubicMeter lhs, CubicMeter rhs) { return new CubicMeter(lhs.Value - rhs.Value); }
        public static CubicMeter operator ++(CubicMeter q) { return new CubicMeter(q.Value + 1d); }
        public static CubicMeter operator --(CubicMeter q) { return new CubicMeter(q.Value - 1d); }
        public static CubicMeter operator -(CubicMeter q) { return new CubicMeter(-q.Value); }
        public static CubicMeter operator *(double lhs, CubicMeter rhs) { return new CubicMeter(lhs * rhs.Value); }
        public static CubicMeter operator *(CubicMeter lhs, double rhs) { return new CubicMeter(lhs.Value * rhs); }
        public static CubicMeter operator /(CubicMeter lhs, double rhs) { return new CubicMeter(lhs.Value / rhs); }
        public static double operator /(CubicMeter lhs, CubicMeter rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Meter operator /(CubicMeter lhs, SquareMeter rhs) { return new Meter(lhs.Value / rhs.Value); }
        public static SquareMeter operator /(CubicMeter lhs, Meter rhs) { return new SquareMeter(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(CubicMeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(CubicMeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? CubicMeter.Format, Value, CubicMeter.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = SquareMeter.Sense * Meter.Sense;
        private static readonly int s_family = 12;
        private static double s_factor = SquareMeter.Factor * Meter.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m\u00B3", "m3");

        private static readonly CubicMeter s_one = new CubicMeter(1d);
        private static readonly CubicMeter s_zero = new CubicMeter(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static CubicMeter One { get { return s_one; } }
        public static CubicMeter Zero { get { return s_zero; } }
        #endregion
    }
}
