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
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return CubicMeter.Proxy; } }
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
            if (q.Unit.Family != CubicMeter.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"CubicMeter\"", q.GetType().Name));
            return new CubicMeter((CubicMeter.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<CubicMeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is CubicMeter) && Equals((CubicMeter)obj); }
        public bool /* IEquatable<CubicMeter> */ Equals(CubicMeter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<CubicMeter>
        public static bool operator ==(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<CubicMeter> */ CompareTo(CubicMeter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static CubicMeter operator +(CubicMeter lhs, CubicMeter rhs) { return new CubicMeter(lhs.m_value + rhs.m_value); }
        public static CubicMeter operator -(CubicMeter lhs, CubicMeter rhs) { return new CubicMeter(lhs.m_value - rhs.m_value); }
        public static CubicMeter operator ++(CubicMeter q) { return new CubicMeter(q.m_value + 1d); }
        public static CubicMeter operator --(CubicMeter q) { return new CubicMeter(q.m_value - 1d); }
        public static CubicMeter operator -(CubicMeter q) { return new CubicMeter(-q.m_value); }
        public static CubicMeter operator *(double lhs, CubicMeter rhs) { return new CubicMeter(lhs * rhs.m_value); }
        public static CubicMeter operator *(CubicMeter lhs, double rhs) { return new CubicMeter(lhs.m_value * rhs); }
        public static CubicMeter operator /(CubicMeter lhs, double rhs) { return new CubicMeter(lhs.m_value / rhs); }
        public static double operator /(CubicMeter lhs, CubicMeter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter operator /(CubicMeter lhs, SquareMeter rhs) { return new Meter(lhs.m_value / rhs.m_value); }
        public static SquareMeter operator /(CubicMeter lhs, Meter rhs) { return new SquareMeter(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(CubicMeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(CubicMeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? CubicMeter.Format, m_value, CubicMeter.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = SquareMeter.Sense * Meter.Sense;
        private static readonly int s_family = 12;
        private static /*mutable*/ double s_factor = SquareMeter.Factor * Meter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m\u00B3", "m3");
        private static readonly Unit<double> s_proxy = new CubicMeter_Proxy();

        private static readonly CubicMeter s_one = new CubicMeter(1d);
        private static readonly CubicMeter s_zero = new CubicMeter(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static CubicMeter One { get { return s_one; } }
        public static CubicMeter Zero { get { return s_zero; } }
        #endregion
    }

    public partial class CubicMeter_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return CubicMeter.Family; } }
        public override Dimension Sense { get { return CubicMeter.Sense; } }
        public override SymbolCollection Symbol { get { return CubicMeter.Symbol; } }
        public override double Factor { get { return CubicMeter.Factor; } set { CubicMeter.Factor = value; } }
        public override string Format { get { return CubicMeter.Format; } set { CubicMeter.Format = value; } }
        #endregion

        #region Constructor(s)
        public CubicMeter_Proxy() :
            base(typeof(CubicMeter))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new CubicMeter(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return CubicMeter.From(quantity);
        }
        #endregion
    }
}
