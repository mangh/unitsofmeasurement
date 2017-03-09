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

        #region Properties
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
            if (q.Unit.Family != Tonne.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Tonne\"", q.GetType().Name));
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
        public override string ToString() { return ToString(Tonne.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Tonne.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Tonne.Format, m_value, Tonne.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Kilogram.Sense;
        private static readonly int s_family = Kilogram.Family;
        private static /*mutable*/ double s_factor = Kilogram.Factor / 1000d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("t");
        private static readonly Unit<double> s_proxy = new Tonne_Proxy();

        private static readonly Tonne s_one = new Tonne(1d);
        private static readonly Tonne s_zero = new Tonne(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Tonne One { get { return s_one; } }
        public static Tonne Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Tonne_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Tonne.Family; } }
        public override Dimension Sense { get { return Tonne.Sense; } }
        public override SymbolCollection Symbol { get { return Tonne.Symbol; } }
        public override double Factor { get { return Tonne.Factor; } set { Tonne.Factor = value; } }
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
