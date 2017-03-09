/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Farad : IQuantity<double>, IEquatable<Farad>, IComparable<Farad>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Farad.Proxy; } }
        #endregion

        #region Constructor(s)
        public Farad(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Farad(double q) { return new Farad(q); }
        public static Farad From(IQuantity<double> q)
        {
            if (q.Unit.Family != Farad.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Farad\"", q.GetType().Name));
            return new Farad((Farad.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Farad>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Farad) && Equals((Farad)obj); }
        public bool /* IEquatable<Farad> */ Equals(Farad other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Farad>
        public static bool operator ==(Farad lhs, Farad rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Farad lhs, Farad rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Farad lhs, Farad rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Farad lhs, Farad rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Farad lhs, Farad rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Farad lhs, Farad rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Farad> */ CompareTo(Farad other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Farad operator +(Farad lhs, Farad rhs) { return new Farad(lhs.m_value + rhs.m_value); }
        public static Farad operator -(Farad lhs, Farad rhs) { return new Farad(lhs.m_value - rhs.m_value); }
        public static Farad operator ++(Farad q) { return new Farad(q.m_value + 1d); }
        public static Farad operator --(Farad q) { return new Farad(q.m_value - 1d); }
        public static Farad operator -(Farad q) { return new Farad(-q.m_value); }
        public static Farad operator *(double lhs, Farad rhs) { return new Farad(lhs * rhs.m_value); }
        public static Farad operator *(Farad lhs, double rhs) { return new Farad(lhs.m_value * rhs); }
        public static Farad operator /(Farad lhs, double rhs) { return new Farad(lhs.m_value / rhs); }
        public static double operator /(Farad lhs, Farad rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Coulomb operator *(Farad lhs, Volt rhs) { return new Coulomb(lhs.m_value * rhs.m_value); }
        public static Coulomb operator *(Volt lhs, Farad rhs) { return new Coulomb(lhs.m_value * rhs.m_value); }
        public static Second operator *(Farad lhs, Ohm rhs) { return new Second(lhs.m_value * rhs.m_value); }
        public static Second operator *(Ohm lhs, Farad rhs) { return new Second(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Farad.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Farad.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Farad.Format, m_value, Farad.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Coulomb.Sense / Volt.Sense;
        private static readonly int s_family = 26;
        private static /*mutable*/ double s_factor = Coulomb.Factor / Volt.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("F");
        private static readonly Unit<double> s_proxy = new Farad_Proxy();

        private static readonly Farad s_one = new Farad(1d);
        private static readonly Farad s_zero = new Farad(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Farad One { get { return s_one; } }
        public static Farad Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Farad_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Farad.Family; } }
        public override Dimension Sense { get { return Farad.Sense; } }
        public override SymbolCollection Symbol { get { return Farad.Symbol; } }
        public override double Factor { get { return Farad.Factor; } set { Farad.Factor = value; } }
        public override string Format { get { return Farad.Format; } set { Farad.Format = value; } }
        #endregion

        #region Constructor(s)
        public Farad_Proxy() :
            base(typeof(Farad))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Farad(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Farad.From(quantity);
        }
        #endregion
    }
}
