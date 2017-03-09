/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Watt : IQuantity<double>, IEquatable<Watt>, IComparable<Watt>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Watt.Proxy; } }
        #endregion

        #region Constructor(s)
        public Watt(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Watt(double q) { return new Watt(q); }
        public static Watt From(IQuantity<double> q)
        {
            if (q.Unit.Family != Watt.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Watt\"", q.GetType().Name));
            return new Watt((Watt.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Watt>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Watt) && Equals((Watt)obj); }
        public bool /* IEquatable<Watt> */ Equals(Watt other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Watt>
        public static bool operator ==(Watt lhs, Watt rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Watt lhs, Watt rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Watt lhs, Watt rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Watt lhs, Watt rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Watt lhs, Watt rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Watt lhs, Watt rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Watt> */ CompareTo(Watt other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Watt operator +(Watt lhs, Watt rhs) { return new Watt(lhs.m_value + rhs.m_value); }
        public static Watt operator -(Watt lhs, Watt rhs) { return new Watt(lhs.m_value - rhs.m_value); }
        public static Watt operator ++(Watt q) { return new Watt(q.m_value + 1d); }
        public static Watt operator --(Watt q) { return new Watt(q.m_value - 1d); }
        public static Watt operator -(Watt q) { return new Watt(-q.m_value); }
        public static Watt operator *(double lhs, Watt rhs) { return new Watt(lhs * rhs.m_value); }
        public static Watt operator *(Watt lhs, double rhs) { return new Watt(lhs.m_value * rhs); }
        public static Watt operator /(Watt lhs, double rhs) { return new Watt(lhs.m_value / rhs); }
        public static double operator /(Watt lhs, Watt rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Joule operator *(Watt lhs, Second rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Joule operator *(Second lhs, Watt rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Volt operator /(Watt lhs, Ampere rhs) { return new Volt(lhs.m_value / rhs.m_value); }
        public static Ampere operator /(Watt lhs, Volt rhs) { return new Ampere(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Watt.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Watt.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Watt.Format, m_value, Watt.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Joule.Sense / Second.Sense;
        private static readonly int s_family = 17;
        private static /*mutable*/ double s_factor = Joule.Factor / Second.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("W");
        private static readonly Unit<double> s_proxy = new Watt_Proxy();

        private static readonly Watt s_one = new Watt(1d);
        private static readonly Watt s_zero = new Watt(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Watt One { get { return s_one; } }
        public static Watt Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Watt_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Watt.Family; } }
        public override Dimension Sense { get { return Watt.Sense; } }
        public override SymbolCollection Symbol { get { return Watt.Symbol; } }
        public override double Factor { get { return Watt.Factor; } set { Watt.Factor = value; } }
        public override string Format { get { return Watt.Format; } set { Watt.Format = value; } }
        #endregion

        #region Constructor(s)
        public Watt_Proxy() :
            base(typeof(Watt))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Watt(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Watt.From(quantity);
        }
        #endregion
    }
}
