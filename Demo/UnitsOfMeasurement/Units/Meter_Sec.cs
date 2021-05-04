/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Meter_Sec : IQuantity<double>, IEquatable<Meter_Sec>, IComparable<Meter_Sec>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Meter_Sec.Proxy; } }
        #endregion

        #region Constructor(s)
        public Meter_Sec(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Meter_Sec(double q) { return new Meter_Sec(q); }
        public static explicit operator Meter_Sec(MPH q) { return new Meter_Sec((Meter_Sec.Factor / MPH.Factor) * q.m_value); }
        public static explicit operator Meter_Sec(Kilometer_Hour q) { return new Meter_Sec((Meter_Sec.Factor / Kilometer_Hour.Factor) * q.m_value); }
        public static Meter_Sec From(IQuantity<double> q)
        {
            if (q.Unit.Family != Meter_Sec.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Meter_Sec\"", q.GetType().Name));
            }
            return new Meter_Sec((Meter_Sec.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Meter_Sec>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Meter_Sec) && Equals((Meter_Sec)obj); }
        public bool /* IEquatable<Meter_Sec> */ Equals(Meter_Sec other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Meter_Sec>
        public static bool operator ==(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Meter_Sec> */ CompareTo(Meter_Sec other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter_Sec operator +(Meter_Sec lhs, Meter_Sec rhs) { return new Meter_Sec(lhs.m_value + rhs.m_value); }
        public static Meter_Sec operator -(Meter_Sec lhs, Meter_Sec rhs) { return new Meter_Sec(lhs.m_value - rhs.m_value); }
        public static Meter_Sec operator ++(Meter_Sec q) { return new Meter_Sec(q.m_value + 1d); }
        public static Meter_Sec operator --(Meter_Sec q) { return new Meter_Sec(q.m_value - 1d); }
        public static Meter_Sec operator -(Meter_Sec q) { return new Meter_Sec(-q.m_value); }
        public static Meter_Sec operator *(double lhs, Meter_Sec rhs) { return new Meter_Sec(lhs * rhs.m_value); }
        public static Meter_Sec operator *(Meter_Sec lhs, double rhs) { return new Meter_Sec(lhs.m_value * rhs); }
        public static Meter_Sec operator /(Meter_Sec lhs, double rhs) { return new Meter_Sec(lhs.m_value / rhs); }
        public static double operator /(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter operator *(Meter_Sec lhs, Second rhs) { return new Meter(lhs.m_value * rhs.m_value); }
        public static Meter operator *(Second lhs, Meter_Sec rhs) { return new Meter(lhs.m_value * rhs.m_value); }
        public static Meter_Sec2 operator /(Meter_Sec lhs, Second rhs) { return new Meter_Sec2(lhs.m_value / rhs.m_value); }
        public static Second operator /(Meter_Sec lhs, Meter_Sec2 rhs) { return new Second(lhs.m_value / rhs.m_value); }
        public static Meter2_Sec2 operator *(Meter_Sec lhs, Meter_Sec rhs) { return new Meter2_Sec2(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Meter_Sec.Format, q, Meter_Sec.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Meter.Sense / Second.Sense;
        public const int Family = 13;
        public static readonly SymbolCollection Symbol = new SymbolCollection("m/s");
        public static readonly Unit<double> Proxy = new Meter_Sec_Proxy();
        public const double Factor = Meter.Factor / Second.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Meter_Sec One = new Meter_Sec(1d);
        public static readonly Meter_Sec Zero = new Meter_Sec(0d);
        #endregion
    }

    public partial class Meter_Sec_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Meter_Sec.Sense; } }
        public override int Family { get { return Meter_Sec.Family; } }
        public override double Factor { get { return Meter_Sec.Factor; } }
        public override SymbolCollection Symbol { get { return Meter_Sec.Symbol; } }
        public override string Format { get { return Meter_Sec.Format; } set { Meter_Sec.Format = value; } }
        #endregion

        #region Constructor(s)
        public Meter_Sec_Proxy() :
            base(typeof(Meter_Sec))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Meter_Sec(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Meter_Sec.From(quantity);
        }
        #endregion
    }
}
