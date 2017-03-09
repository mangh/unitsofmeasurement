/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct SquareMeter : IQuantity<double>, IEquatable<SquareMeter>, IComparable<SquareMeter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return SquareMeter.Proxy; } }
        #endregion

        #region Constructor(s)
        public SquareMeter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator SquareMeter(double q) { return new SquareMeter(q); }
        public static explicit operator SquareMeter(SquareFoot q) { return new SquareMeter((SquareMeter.Factor / SquareFoot.Factor) * q.m_value); }
        public static SquareMeter From(IQuantity<double> q)
        {
            if (q.Unit.Family != SquareMeter.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"SquareMeter\"", q.GetType().Name));
            return new SquareMeter((SquareMeter.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<SquareMeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is SquareMeter) && Equals((SquareMeter)obj); }
        public bool /* IEquatable<SquareMeter> */ Equals(SquareMeter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<SquareMeter>
        public static bool operator ==(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<SquareMeter> */ CompareTo(SquareMeter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static SquareMeter operator +(SquareMeter lhs, SquareMeter rhs) { return new SquareMeter(lhs.m_value + rhs.m_value); }
        public static SquareMeter operator -(SquareMeter lhs, SquareMeter rhs) { return new SquareMeter(lhs.m_value - rhs.m_value); }
        public static SquareMeter operator ++(SquareMeter q) { return new SquareMeter(q.m_value + 1d); }
        public static SquareMeter operator --(SquareMeter q) { return new SquareMeter(q.m_value - 1d); }
        public static SquareMeter operator -(SquareMeter q) { return new SquareMeter(-q.m_value); }
        public static SquareMeter operator *(double lhs, SquareMeter rhs) { return new SquareMeter(lhs * rhs.m_value); }
        public static SquareMeter operator *(SquareMeter lhs, double rhs) { return new SquareMeter(lhs.m_value * rhs); }
        public static SquareMeter operator /(SquareMeter lhs, double rhs) { return new SquareMeter(lhs.m_value / rhs); }
        public static double operator /(SquareMeter lhs, SquareMeter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter operator /(SquareMeter lhs, Meter rhs) { return new Meter(lhs.m_value / rhs.m_value); }
        public static CubicMeter operator *(SquareMeter lhs, Meter rhs) { return new CubicMeter(lhs.m_value * rhs.m_value); }
        public static CubicMeter operator *(Meter lhs, SquareMeter rhs) { return new CubicMeter(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(SquareMeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(SquareMeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? SquareMeter.Format, m_value, SquareMeter.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Meter.Sense * Meter.Sense;
        private static readonly int s_family = 11;
        private static /*mutable*/ double s_factor = Meter.Factor * Meter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m\u00B2", "m2");
        private static readonly Unit<double> s_proxy = new SquareMeter_Proxy();

        private static readonly SquareMeter s_one = new SquareMeter(1d);
        private static readonly SquareMeter s_zero = new SquareMeter(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static SquareMeter One { get { return s_one; } }
        public static SquareMeter Zero { get { return s_zero; } }
        #endregion
    }

    public partial class SquareMeter_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return SquareMeter.Family; } }
        public override Dimension Sense { get { return SquareMeter.Sense; } }
        public override SymbolCollection Symbol { get { return SquareMeter.Symbol; } }
        public override double Factor { get { return SquareMeter.Factor; } set { SquareMeter.Factor = value; } }
        public override string Format { get { return SquareMeter.Format; } set { SquareMeter.Format = value; } }
        #endregion

        #region Constructor(s)
        public SquareMeter_Proxy() :
            base(typeof(SquareMeter))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new SquareMeter(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return SquareMeter.From(quantity);
        }
        #endregion
    }
}
