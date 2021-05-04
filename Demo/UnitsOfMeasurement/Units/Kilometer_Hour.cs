/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Kilometer_Hour : IQuantity<double>, IEquatable<Kilometer_Hour>, IComparable<Kilometer_Hour>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Kilometer_Hour.Proxy; } }
        #endregion

        #region Constructor(s)
        public Kilometer_Hour(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Kilometer_Hour(double q) { return new Kilometer_Hour(q); }
        public static explicit operator Kilometer_Hour(Meter_Sec q) { return new Kilometer_Hour((Kilometer_Hour.Factor / Meter_Sec.Factor) * q.m_value); }
        public static explicit operator Kilometer_Hour(MPH q) { return new Kilometer_Hour((Kilometer_Hour.Factor / MPH.Factor) * q.m_value); }
        public static Kilometer_Hour From(IQuantity<double> q)
        {
            if (q.Unit.Family != Kilometer_Hour.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Kilometer_Hour\"", q.GetType().Name));
            }
            return new Kilometer_Hour((Kilometer_Hour.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Kilometer_Hour>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Kilometer_Hour) && Equals((Kilometer_Hour)obj); }
        public bool /* IEquatable<Kilometer_Hour> */ Equals(Kilometer_Hour other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Kilometer_Hour>
        public static bool operator ==(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Kilometer_Hour> */ CompareTo(Kilometer_Hour other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Kilometer_Hour operator +(Kilometer_Hour lhs, Kilometer_Hour rhs) { return new Kilometer_Hour(lhs.m_value + rhs.m_value); }
        public static Kilometer_Hour operator -(Kilometer_Hour lhs, Kilometer_Hour rhs) { return new Kilometer_Hour(lhs.m_value - rhs.m_value); }
        public static Kilometer_Hour operator ++(Kilometer_Hour q) { return new Kilometer_Hour(q.m_value + 1d); }
        public static Kilometer_Hour operator --(Kilometer_Hour q) { return new Kilometer_Hour(q.m_value - 1d); }
        public static Kilometer_Hour operator -(Kilometer_Hour q) { return new Kilometer_Hour(-q.m_value); }
        public static Kilometer_Hour operator *(double lhs, Kilometer_Hour rhs) { return new Kilometer_Hour(lhs * rhs.m_value); }
        public static Kilometer_Hour operator *(Kilometer_Hour lhs, double rhs) { return new Kilometer_Hour(lhs.m_value * rhs); }
        public static Kilometer_Hour operator /(Kilometer_Hour lhs, double rhs) { return new Kilometer_Hour(lhs.m_value / rhs); }
        public static double operator /(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Kilometer operator *(Kilometer_Hour lhs, Hour rhs) { return new Kilometer(lhs.m_value * rhs.m_value); }
        public static Kilometer operator *(Hour lhs, Kilometer_Hour rhs) { return new Kilometer(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Kilometer_Hour.Format, q, Kilometer_Hour.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Kilometer.Sense / Hour.Sense;
        public const int Family = Meter_Sec.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("km/h");
        public static readonly Unit<double> Proxy = new Kilometer_Hour_Proxy();
        public const double Factor = Kilometer.Factor / Hour.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Kilometer_Hour One = new Kilometer_Hour(1d);
        public static readonly Kilometer_Hour Zero = new Kilometer_Hour(0d);
        #endregion
    }

    public partial class Kilometer_Hour_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Kilometer_Hour.Sense; } }
        public override int Family { get { return Kilometer_Hour.Family; } }
        public override double Factor { get { return Kilometer_Hour.Factor; } }
        public override SymbolCollection Symbol { get { return Kilometer_Hour.Symbol; } }
        public override string Format { get { return Kilometer_Hour.Format; } set { Kilometer_Hour.Format = value; } }
        #endregion

        #region Constructor(s)
        public Kilometer_Hour_Proxy() :
            base(typeof(Kilometer_Hour))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Kilometer_Hour(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Kilometer_Hour.From(quantity);
        }
        #endregion
    }
}
