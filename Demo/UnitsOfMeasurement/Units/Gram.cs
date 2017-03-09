/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Gram : IQuantity<double>, IEquatable<Gram>, IComparable<Gram>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Gram.Proxy; } }
        #endregion

        #region Constructor(s)
        public Gram(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Gram(double q) { return new Gram(q); }
        public static explicit operator Gram(Kilogram q) { return new Gram((Gram.Factor / Kilogram.Factor) * q.m_value); }
        public static explicit operator Gram(Pound q) { return new Gram((Gram.Factor / Pound.Factor) * q.m_value); }
        public static explicit operator Gram(Ounce q) { return new Gram((Gram.Factor / Ounce.Factor) * q.m_value); }
        public static explicit operator Gram(Tonne q) { return new Gram((Gram.Factor / Tonne.Factor) * q.m_value); }
        public static Gram From(IQuantity<double> q)
        {
            if (q.Unit.Family != Gram.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Gram\"", q.GetType().Name));
            return new Gram((Gram.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Gram>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Gram) && Equals((Gram)obj); }
        public bool /* IEquatable<Gram> */ Equals(Gram other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Gram>
        public static bool operator ==(Gram lhs, Gram rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Gram lhs, Gram rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Gram lhs, Gram rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Gram lhs, Gram rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Gram lhs, Gram rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Gram lhs, Gram rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Gram> */ CompareTo(Gram other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Gram operator +(Gram lhs, Gram rhs) { return new Gram(lhs.m_value + rhs.m_value); }
        public static Gram operator -(Gram lhs, Gram rhs) { return new Gram(lhs.m_value - rhs.m_value); }
        public static Gram operator ++(Gram q) { return new Gram(q.m_value + 1d); }
        public static Gram operator --(Gram q) { return new Gram(q.m_value - 1d); }
        public static Gram operator -(Gram q) { return new Gram(-q.m_value); }
        public static Gram operator *(double lhs, Gram rhs) { return new Gram(lhs * rhs.m_value); }
        public static Gram operator *(Gram lhs, double rhs) { return new Gram(lhs.m_value * rhs); }
        public static Gram operator /(Gram lhs, double rhs) { return new Gram(lhs.m_value / rhs); }
        public static double operator /(Gram lhs, Gram rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Gram.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Gram.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Gram.Format, m_value, Gram.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Kilogram.Sense;
        private static readonly int s_family = Kilogram.Family;
        private static /*mutable*/ double s_factor = 1000d * Kilogram.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("g");
        private static readonly Unit<double> s_proxy = new Gram_Proxy();

        private static readonly Gram s_one = new Gram(1d);
        private static readonly Gram s_zero = new Gram(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Gram One { get { return s_one; } }
        public static Gram Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Gram_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Gram.Family; } }
        public override Dimension Sense { get { return Gram.Sense; } }
        public override SymbolCollection Symbol { get { return Gram.Symbol; } }
        public override double Factor { get { return Gram.Factor; } set { Gram.Factor = value; } }
        public override string Format { get { return Gram.Format; } set { Gram.Format = value; } }
        #endregion

        #region Constructor(s)
        public Gram_Proxy() :
            base(typeof(Gram))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Gram(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Gram.From(quantity);
        }
        #endregion
    }
}
