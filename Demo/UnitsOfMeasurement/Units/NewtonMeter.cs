/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct NewtonMeter : IQuantity<double>, IEquatable<NewtonMeter>, IComparable<NewtonMeter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return NewtonMeter.Proxy; } }
        #endregion

        #region Constructor(s)
        public NewtonMeter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator NewtonMeter(double q) { return new NewtonMeter(q); }
        public static NewtonMeter From(IQuantity<double> q)
        {
            if (q.Unit.Family != NewtonMeter.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"NewtonMeter\"", q.GetType().Name));
            }
            return new NewtonMeter((NewtonMeter.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<NewtonMeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is NewtonMeter) && Equals((NewtonMeter)obj); }
        public bool /* IEquatable<NewtonMeter> */ Equals(NewtonMeter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<NewtonMeter>
        public static bool operator ==(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<NewtonMeter> */ CompareTo(NewtonMeter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static NewtonMeter operator +(NewtonMeter lhs, NewtonMeter rhs) { return new NewtonMeter(lhs.m_value + rhs.m_value); }
        public static NewtonMeter operator -(NewtonMeter lhs, NewtonMeter rhs) { return new NewtonMeter(lhs.m_value - rhs.m_value); }
        public static NewtonMeter operator ++(NewtonMeter q) { return new NewtonMeter(q.m_value + 1d); }
        public static NewtonMeter operator --(NewtonMeter q) { return new NewtonMeter(q.m_value - 1d); }
        public static NewtonMeter operator -(NewtonMeter q) { return new NewtonMeter(-q.m_value); }
        public static NewtonMeter operator *(double lhs, NewtonMeter rhs) { return new NewtonMeter(lhs * rhs.m_value); }
        public static NewtonMeter operator *(NewtonMeter lhs, double rhs) { return new NewtonMeter(lhs.m_value * rhs); }
        public static NewtonMeter operator /(NewtonMeter lhs, double rhs) { return new NewtonMeter(lhs.m_value / rhs); }
        public static double operator /(NewtonMeter lhs, NewtonMeter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter operator /(NewtonMeter lhs, Newton rhs) { return new Meter(lhs.m_value / rhs.m_value); }
        public static Newton operator /(NewtonMeter lhs, Meter rhs) { return new Newton(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? NewtonMeter.Format, q, NewtonMeter.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Newton.Sense * Meter.Sense;
        public const int Family = 18;
        public static readonly SymbolCollection Symbol = new SymbolCollection("N\u00B7m", "N*m");
        public static readonly Unit<double> Proxy = new NewtonMeter_Proxy();
        public const double Factor = Newton.Factor * Meter.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly NewtonMeter One = new NewtonMeter(1d);
        public static readonly NewtonMeter Zero = new NewtonMeter(0d);
        #endregion
    }

    public partial class NewtonMeter_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return NewtonMeter.Sense; } }
        public override int Family { get { return NewtonMeter.Family; } }
        public override double Factor { get { return NewtonMeter.Factor; } }
        public override SymbolCollection Symbol { get { return NewtonMeter.Symbol; } }
        public override string Format { get { return NewtonMeter.Format; } set { NewtonMeter.Format = value; } }
        #endregion

        #region Constructor(s)
        public NewtonMeter_Proxy() :
            base(typeof(NewtonMeter))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new NewtonMeter(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return NewtonMeter.From(quantity);
        }
        #endregion
    }
}
