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

        #region Properties
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
            if (q.Unit.Family != Kilometer_Hour.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Kilometer_Hour\"", q.GetType().Name));
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
        public override string ToString() { return ToString(Kilometer_Hour.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Kilometer_Hour.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Kilometer_Hour.Format, m_value, Kilometer_Hour.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Kilometer.Sense / Hour.Sense;
        private static readonly int s_family = Meter_Sec.Family;
        private static /*mutable*/ double s_factor = Kilometer.Factor / Hour.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("km/h");
        private static readonly Unit<double> s_proxy = new Kilometer_Hour_Proxy();

        private static readonly Kilometer_Hour s_one = new Kilometer_Hour(1d);
        private static readonly Kilometer_Hour s_zero = new Kilometer_Hour(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Kilometer_Hour One { get { return s_one; } }
        public static Kilometer_Hour Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Kilometer_Hour_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Kilometer_Hour.Family; } }
        public override Dimension Sense { get { return Kilometer_Hour.Sense; } }
        public override SymbolCollection Symbol { get { return Kilometer_Hour.Symbol; } }
        public override double Factor { get { return Kilometer_Hour.Factor; } set { Kilometer_Hour.Factor = value; } }
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
