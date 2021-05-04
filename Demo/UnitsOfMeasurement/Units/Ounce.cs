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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Ounce.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Ounce\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Ounce.Format, q, Ounce.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Pound.Sense;
        public const int Family = Kilogram.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("ou");
        public static readonly Unit<double> Proxy = new Ounce_Proxy();
        public const double Factor = Pound.Factor * 16d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Ounce One = new Ounce(1d);
        public static readonly Ounce Zero = new Ounce(0d);
        #endregion
    }

    public partial class Ounce_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Ounce.Sense; } }
        public override int Family { get { return Ounce.Family; } }
        public override double Factor { get { return Ounce.Factor; } }
        public override SymbolCollection Symbol { get { return Ounce.Symbol; } }
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
