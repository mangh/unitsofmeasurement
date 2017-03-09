/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Ounce : IQuantity<double>, IEquatable<Ounce>, IComparable<Ounce>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Ounce.Proxy; } }
        #endregion

        #region Constructor(s)
        public Ounce(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Ounce(double q) { return new Ounce(q); }
        public static explicit operator Ounce(Tonne q) { return new Ounce((Ounce.Factor / Tonne.Factor) * q.m_value); }
        public static explicit operator Ounce(Gram q) { return new Ounce((Ounce.Factor / Gram.Factor) * q.m_value); }
        public static explicit operator Ounce(Kilogram q) { return new Ounce((Ounce.Factor / Kilogram.Factor) * q.m_value); }
        public static explicit operator Ounce(Pound q) { return new Ounce((Ounce.Factor / Pound.Factor) * q.m_value); }
        public static Ounce From(IQuantity<double> q)
        {
            if (q.Unit.Family != Ounce.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Ounce\"", q.GetType().Name));
            return new Ounce((Ounce.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Ounce>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Ounce) && Equals((Ounce)obj); }
        public bool /* IEquatable<Ounce> */ Equals(Ounce other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Ounce>
        public static bool operator ==(Ounce lhs, Ounce rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Ounce lhs, Ounce rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Ounce lhs, Ounce rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Ounce lhs, Ounce rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Ounce lhs, Ounce rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Ounce lhs, Ounce rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Ounce> */ CompareTo(Ounce other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Ounce operator +(Ounce lhs, Ounce rhs) { return new Ounce(lhs.m_value + rhs.m_value); }
        public static Ounce operator -(Ounce lhs, Ounce rhs) { return new Ounce(lhs.m_value - rhs.m_value); }
        public static Ounce operator ++(Ounce q) { return new Ounce(q.m_value + 1d); }
        public static Ounce operator --(Ounce q) { return new Ounce(q.m_value - 1d); }
        public static Ounce operator -(Ounce q) { return new Ounce(-q.m_value); }
        public static Ounce operator *(double lhs, Ounce rhs) { return new Ounce(lhs * rhs.m_value); }
        public static Ounce operator *(Ounce lhs, double rhs) { return new Ounce(lhs.m_value * rhs); }
        public static Ounce operator /(Ounce lhs, double rhs) { return new Ounce(lhs.m_value / rhs); }
        public static double operator /(Ounce lhs, Ounce rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Ounce.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Ounce.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Ounce.Format, m_value, Ounce.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Pound.Sense;
        private static readonly int s_family = Kilogram.Family;
        private static /*mutable*/ double s_factor = Pound.Factor * 16d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("ou");
        private static readonly Unit<double> s_proxy = new Ounce_Proxy();

        private static readonly Ounce s_one = new Ounce(1d);
        private static readonly Ounce s_zero = new Ounce(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Ounce One { get { return s_one; } }
        public static Ounce Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Ounce_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Ounce.Family; } }
        public override Dimension Sense { get { return Ounce.Sense; } }
        public override SymbolCollection Symbol { get { return Ounce.Symbol; } }
        public override double Factor { get { return Ounce.Factor; } set { Ounce.Factor = value; } }
        public override string Format { get { return Ounce.Format; } set { Ounce.Format = value; } }
        #endregion

        #region Constructor(s)
        public Ounce_Proxy() :
            base(typeof(Ounce))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Ounce(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Ounce.From(quantity);
        }
        #endregion
    }
}
