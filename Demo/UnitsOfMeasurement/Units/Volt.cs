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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Volt.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Volt\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Volt.Format, q, Volt.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Joule.Sense / Coulomb.Sense;
        public const int Family = 23;
        public static readonly SymbolCollection Symbol = new SymbolCollection("V");
        public static readonly Unit<double> Proxy = new Volt_Proxy();
        public const double Factor = Joule.Factor / Coulomb.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Volt One = new Volt(1d);
        public static readonly Volt Zero = new Volt(0d);
        #endregion
    }

    public partial class Volt_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Volt.Sense; } }
        public override int Family { get { return Volt.Family; } }
        public override double Factor { get { return Volt.Factor; } }
        public override SymbolCollection Symbol { get { return Volt.Symbol; } }
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
