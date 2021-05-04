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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Watt.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Watt\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Watt.Format, q, Watt.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Joule.Sense / Second.Sense;
        public const int Family = 17;
        public static readonly SymbolCollection Symbol = new SymbolCollection("W");
        public static readonly Unit<double> Proxy = new Watt_Proxy();
        public const double Factor = Joule.Factor / Second.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Watt One = new Watt(1d);
        public static readonly Watt Zero = new Watt(0d);
        #endregion
    }

    public partial class Watt_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Watt.Sense; } }
        public override int Family { get { return Watt.Family; } }
        public override double Factor { get { return Watt.Factor; } }
        public override SymbolCollection Symbol { get { return Watt.Symbol; } }
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
