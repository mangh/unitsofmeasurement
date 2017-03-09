/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Joule_Kelvin_Kilogram : IQuantity<double>, IEquatable<Joule_Kelvin_Kilogram>, IComparable<Joule_Kelvin_Kilogram>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Joule_Kelvin_Kilogram.Proxy; } }
        #endregion

        #region Constructor(s)
        public Joule_Kelvin_Kilogram(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Joule_Kelvin_Kilogram(double q) { return new Joule_Kelvin_Kilogram(q); }
        public static Joule_Kelvin_Kilogram From(IQuantity<double> q)
        {
            if (q.Unit.Family != Joule_Kelvin_Kilogram.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Joule_Kelvin_Kilogram\"", q.GetType().Name));
            return new Joule_Kelvin_Kilogram((Joule_Kelvin_Kilogram.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Joule_Kelvin_Kilogram>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Joule_Kelvin_Kilogram) && Equals((Joule_Kelvin_Kilogram)obj); }
        public bool /* IEquatable<Joule_Kelvin_Kilogram> */ Equals(Joule_Kelvin_Kilogram other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Joule_Kelvin_Kilogram>
        public static bool operator ==(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Joule_Kelvin_Kilogram> */ CompareTo(Joule_Kelvin_Kilogram other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Joule_Kelvin_Kilogram operator +(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return new Joule_Kelvin_Kilogram(lhs.m_value + rhs.m_value); }
        public static Joule_Kelvin_Kilogram operator -(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return new Joule_Kelvin_Kilogram(lhs.m_value - rhs.m_value); }
        public static Joule_Kelvin_Kilogram operator ++(Joule_Kelvin_Kilogram q) { return new Joule_Kelvin_Kilogram(q.m_value + 1d); }
        public static Joule_Kelvin_Kilogram operator --(Joule_Kelvin_Kilogram q) { return new Joule_Kelvin_Kilogram(q.m_value - 1d); }
        public static Joule_Kelvin_Kilogram operator -(Joule_Kelvin_Kilogram q) { return new Joule_Kelvin_Kilogram(-q.m_value); }
        public static Joule_Kelvin_Kilogram operator *(double lhs, Joule_Kelvin_Kilogram rhs) { return new Joule_Kelvin_Kilogram(lhs * rhs.m_value); }
        public static Joule_Kelvin_Kilogram operator *(Joule_Kelvin_Kilogram lhs, double rhs) { return new Joule_Kelvin_Kilogram(lhs.m_value * rhs); }
        public static Joule_Kelvin_Kilogram operator /(Joule_Kelvin_Kilogram lhs, double rhs) { return new Joule_Kelvin_Kilogram(lhs.m_value / rhs); }
        public static double operator /(Joule_Kelvin_Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Joule_Kelvin operator *(Joule_Kelvin_Kilogram lhs, Kilogram rhs) { return new Joule_Kelvin(lhs.m_value * rhs.m_value); }
        public static Joule_Kelvin operator *(Kilogram lhs, Joule_Kelvin_Kilogram rhs) { return new Joule_Kelvin(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Joule_Kelvin_Kilogram.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Joule_Kelvin_Kilogram.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Joule_Kelvin_Kilogram.Format, m_value, Joule_Kelvin_Kilogram.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Joule_Kelvin.Sense / Kilogram.Sense;
        private static readonly int s_family = 20;
        private static /*mutable*/ double s_factor = Joule_Kelvin.Factor / Kilogram.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("J/kg/K");
        private static readonly Unit<double> s_proxy = new Joule_Kelvin_Kilogram_Proxy();

        private static readonly Joule_Kelvin_Kilogram s_one = new Joule_Kelvin_Kilogram(1d);
        private static readonly Joule_Kelvin_Kilogram s_zero = new Joule_Kelvin_Kilogram(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Joule_Kelvin_Kilogram One { get { return s_one; } }
        public static Joule_Kelvin_Kilogram Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Joule_Kelvin_Kilogram_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Joule_Kelvin_Kilogram.Family; } }
        public override Dimension Sense { get { return Joule_Kelvin_Kilogram.Sense; } }
        public override SymbolCollection Symbol { get { return Joule_Kelvin_Kilogram.Symbol; } }
        public override double Factor { get { return Joule_Kelvin_Kilogram.Factor; } set { Joule_Kelvin_Kilogram.Factor = value; } }
        public override string Format { get { return Joule_Kelvin_Kilogram.Format; } set { Joule_Kelvin_Kilogram.Format = value; } }
        #endregion

        #region Constructor(s)
        public Joule_Kelvin_Kilogram_Proxy() :
            base(typeof(Joule_Kelvin_Kilogram))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Joule_Kelvin_Kilogram(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Joule_Kelvin_Kilogram.From(quantity);
        }
        #endregion
    }
}
