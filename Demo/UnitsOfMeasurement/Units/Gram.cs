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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Gram.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Gram\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Gram.Format, q, Gram.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Kilogram.Sense;
        public const int Family = Kilogram.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("g");
        public static readonly Unit<double> Proxy = new Gram_Proxy();
        public const double Factor = 1000d * Kilogram.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Gram One = new Gram(1d);
        public static readonly Gram Zero = new Gram(0d);
        #endregion
    }

    public partial class Gram_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Gram.Sense; } }
        public override int Family { get { return Gram.Family; } }
        public override double Factor { get { return Gram.Factor; } }
        public override SymbolCollection Symbol { get { return Gram.Symbol; } }
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
