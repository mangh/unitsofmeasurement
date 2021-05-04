/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Ohm : IQuantity<double>, IEquatable<Ohm>, IComparable<Ohm>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Ohm.Proxy; } }
        #endregion

        #region Constructor(s)
        public Ohm(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Ohm(double q) { return new Ohm(q); }
        public static Ohm From(IQuantity<double> q)
        {
            if (q.Unit.Family != Ohm.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Ohm\"", q.GetType().Name));
            }
            return new Ohm((Ohm.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Ohm>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Ohm) && Equals((Ohm)obj); }
        public bool /* IEquatable<Ohm> */ Equals(Ohm other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Ohm>
        public static bool operator ==(Ohm lhs, Ohm rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Ohm lhs, Ohm rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Ohm lhs, Ohm rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Ohm lhs, Ohm rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Ohm lhs, Ohm rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Ohm lhs, Ohm rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Ohm> */ CompareTo(Ohm other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Ohm operator +(Ohm lhs, Ohm rhs) { return new Ohm(lhs.m_value + rhs.m_value); }
        public static Ohm operator -(Ohm lhs, Ohm rhs) { return new Ohm(lhs.m_value - rhs.m_value); }
        public static Ohm operator ++(Ohm q) { return new Ohm(q.m_value + 1d); }
        public static Ohm operator --(Ohm q) { return new Ohm(q.m_value - 1d); }
        public static Ohm operator -(Ohm q) { return new Ohm(-q.m_value); }
        public static Ohm operator *(double lhs, Ohm rhs) { return new Ohm(lhs * rhs.m_value); }
        public static Ohm operator *(Ohm lhs, double rhs) { return new Ohm(lhs.m_value * rhs); }
        public static Ohm operator /(Ohm lhs, double rhs) { return new Ohm(lhs.m_value / rhs); }
        public static double operator /(Ohm lhs, Ohm rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Volt operator *(Ohm lhs, Ampere rhs) { return new Volt(lhs.m_value * rhs.m_value); }
        public static Volt operator *(Ampere lhs, Ohm rhs) { return new Volt(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Ohm.Format, q, Ohm.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Volt.Sense / Ampere.Sense;
        public const int Family = 24;
        public static readonly SymbolCollection Symbol = new SymbolCollection("\u03A9", "ohm");
        public static readonly Unit<double> Proxy = new Ohm_Proxy();
        public const double Factor = Volt.Factor / Ampere.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Ohm One = new Ohm(1d);
        public static readonly Ohm Zero = new Ohm(0d);
        #endregion
    }

    public partial class Ohm_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Ohm.Sense; } }
        public override int Family { get { return Ohm.Family; } }
        public override double Factor { get { return Ohm.Factor; } }
        public override SymbolCollection Symbol { get { return Ohm.Symbol; } }
        public override string Format { get { return Ohm.Format; } set { Ohm.Format = value; } }
        #endregion

        #region Constructor(s)
        public Ohm_Proxy() :
            base(typeof(Ohm))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Ohm(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Ohm.From(quantity);
        }
        #endregion
    }
}
