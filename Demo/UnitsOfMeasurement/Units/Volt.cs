/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Volt : IQuantity<double>, IEquatable<Volt>, IComparable<Volt>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Volt.Proxy; } }
        #endregion

        #region Constructor(s)
        public Volt(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Volt(double q) { return new Volt(q); }
        public static Volt From(IQuantity<double> q)
        {
            if (q.Unit.Family != Volt.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Volt\"", q.GetType().Name));
            return new Volt((Volt.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Volt>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Volt) && Equals((Volt)obj); }
        public bool /* IEquatable<Volt> */ Equals(Volt other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Volt>
        public static bool operator ==(Volt lhs, Volt rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Volt lhs, Volt rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Volt lhs, Volt rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Volt lhs, Volt rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Volt lhs, Volt rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Volt lhs, Volt rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Volt> */ CompareTo(Volt other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Volt operator +(Volt lhs, Volt rhs) { return new Volt(lhs.m_value + rhs.m_value); }
        public static Volt operator -(Volt lhs, Volt rhs) { return new Volt(lhs.m_value - rhs.m_value); }
        public static Volt operator ++(Volt q) { return new Volt(q.m_value + 1d); }
        public static Volt operator --(Volt q) { return new Volt(q.m_value - 1d); }
        public static Volt operator -(Volt q) { return new Volt(-q.m_value); }
        public static Volt operator *(double lhs, Volt rhs) { return new Volt(lhs * rhs.m_value); }
        public static Volt operator *(Volt lhs, double rhs) { return new Volt(lhs.m_value * rhs); }
        public static Volt operator /(Volt lhs, double rhs) { return new Volt(lhs.m_value / rhs); }
        public static double operator /(Volt lhs, Volt rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Joule operator *(Volt lhs, Coulomb rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Joule operator *(Coulomb lhs, Volt rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Watt operator *(Volt lhs, Ampere rhs) { return new Watt(lhs.m_value * rhs.m_value); }
        public static Watt operator *(Ampere lhs, Volt rhs) { return new Watt(lhs.m_value * rhs.m_value); }
        public static Ohm operator /(Volt lhs, Ampere rhs) { return new Ohm(lhs.m_value / rhs.m_value); }
        public static Ampere operator /(Volt lhs, Ohm rhs) { return new Ampere(lhs.m_value / rhs.m_value); }
        public static Weber operator *(Volt lhs, Second rhs) { return new Weber(lhs.m_value * rhs.m_value); }
        public static Weber operator *(Second lhs, Volt rhs) { return new Weber(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Volt.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Volt.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Volt.Format, m_value, Volt.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Joule.Sense / Coulomb.Sense;
        private static readonly int s_family = 23;
        private static /*mutable*/ double s_factor = Joule.Factor / Coulomb.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("V");
        private static readonly Unit<double> s_proxy = new Volt_Proxy();

        private static readonly Volt s_one = new Volt(1d);
        private static readonly Volt s_zero = new Volt(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Volt One { get { return s_one; } }
        public static Volt Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Volt_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Volt.Family; } }
        public override Dimension Sense { get { return Volt.Sense; } }
        public override SymbolCollection Symbol { get { return Volt.Symbol; } }
        public override double Factor { get { return Volt.Factor; } set { Volt.Factor = value; } }
        public override string Format { get { return Volt.Format; } set { Volt.Format = value; } }
        #endregion

        #region Constructor(s)
        public Volt_Proxy() :
            base(typeof(Volt))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Volt(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Volt.From(quantity);
        }
        #endregion
    }
}
