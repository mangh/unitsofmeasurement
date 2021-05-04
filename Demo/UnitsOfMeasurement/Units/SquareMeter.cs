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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != SquareMeter.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"SquareMeter\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? SquareMeter.Format, q, SquareMeter.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Meter.Sense * Meter.Sense;
        public const int Family = 11;
        public static readonly SymbolCollection Symbol = new SymbolCollection("m\u00B2", "m2");
        public static readonly Unit<double> Proxy = new SquareMeter_Proxy();
        public const double Factor = Meter.Factor * Meter.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly SquareMeter One = new SquareMeter(1d);
        public static readonly SquareMeter Zero = new SquareMeter(0d);
        #endregion
    }

    public partial class SquareMeter_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return SquareMeter.Sense; } }
        public override int Family { get { return SquareMeter.Family; } }
        public override double Factor { get { return SquareMeter.Factor; } }
        public override SymbolCollection Symbol { get { return SquareMeter.Symbol; } }
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
