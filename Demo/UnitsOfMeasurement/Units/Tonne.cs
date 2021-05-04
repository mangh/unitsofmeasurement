/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Tonne : IQuantity<double>, IEquatable<Tonne>, IComparable<Tonne>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Tonne.Proxy; } }
        #endregion

        #region Constructor(s)
        public Tonne(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Tonne(double q) { return new Tonne(q); }
        public static explicit operator Tonne(Gram q) { return new Tonne((Tonne.Factor / Gram.Factor) * q.m_value); }
        public static explicit operator Tonne(Kilogram q) { return new Tonne((Tonne.Factor / Kilogram.Factor) * q.m_value); }
        public static explicit operator Tonne(Pound q) { return new Tonne((Tonne.Factor / Pound.Factor) * q.m_value); }
        public static explicit operator Tonne(Ounce q) { return new Tonne((Tonne.Factor / Ounce.Factor) * q.m_value); }
        public static Tonne From(IQuantity<double> q)
        {
            if (q.Unit.Family != Tonne.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Tonne\"", q.GetType().Name));
            }
            return new Tonne((Tonne.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Tonne>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Tonne) && Equals((Tonne)obj); }
        public bool /* IEquatable<Tonne> */ Equals(Tonne other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Tonne>
        public static bool operator ==(Tonne lhs, Tonne rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Tonne lhs, Tonne rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Tonne lhs, Tonne rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Tonne lhs, Tonne rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Tonne lhs, Tonne rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Tonne lhs, Tonne rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Tonne> */ CompareTo(Tonne other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Tonne operator +(Tonne lhs, Tonne rhs) { return new Tonne(lhs.m_value + rhs.m_value); }
        public static Tonne operator -(Tonne lhs, Tonne rhs) { return new Tonne(lhs.m_value - rhs.m_value); }
        public static Tonne operator ++(Tonne q) { return new Tonne(q.m_value + 1d); }
        public static Tonne operator --(Tonne q) { return new Tonne(q.m_value - 1d); }
        public static Tonne operator -(Tonne q) { return new Tonne(-q.m_value); }
        public static Tonne operator *(double lhs, Tonne rhs) { return new Tonne(lhs * rhs.m_value); }
        public static Tonne operator *(Tonne lhs, double rhs) { return new Tonne(lhs.m_value * rhs); }
        public static Tonne operator /(Tonne lhs, double rhs) { return new Tonne(lhs.m_value / rhs); }
        public static double operator /(Tonne lhs, Tonne rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Tonne.Format, q, Tonne.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Kilogram.Sense;
        public const int Family = Kilogram.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("t");
        public static readonly Unit<double> Proxy = new Tonne_Proxy();
        public const double Factor = Kilogram.Factor / 1000d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Tonne One = new Tonne(1d);
        public static readonly Tonne Zero = new Tonne(0d);
        #endregion
    }

    public partial class Tonne_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Tonne.Sense; } }
        public override int Family { get { return Tonne.Family; } }
        public override double Factor { get { return Tonne.Factor; } }
        public override SymbolCollection Symbol { get { return Tonne.Symbol; } }
        public override string Format { get { return Tonne.Format; } set { Tonne.Format = value; } }
        #endregion

        #region Constructor(s)
        public Tonne_Proxy() :
            base(typeof(Tonne))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Tonne(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Tonne.From(quantity);
        }
        #endregion
    }
}
