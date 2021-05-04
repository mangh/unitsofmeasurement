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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Joule_Kelvin_Kilogram.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Joule_Kelvin_Kilogram\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Joule_Kelvin_Kilogram.Format, q, Joule_Kelvin_Kilogram.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Joule_Kelvin.Sense / Kilogram.Sense;
        public const int Family = 20;
        public static readonly SymbolCollection Symbol = new SymbolCollection("J/kg/K");
        public static readonly Unit<double> Proxy = new Joule_Kelvin_Kilogram_Proxy();
        public const double Factor = Joule_Kelvin.Factor / Kilogram.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Joule_Kelvin_Kilogram One = new Joule_Kelvin_Kilogram(1d);
        public static readonly Joule_Kelvin_Kilogram Zero = new Joule_Kelvin_Kilogram(0d);
        #endregion
    }

    public partial class Joule_Kelvin_Kilogram_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Joule_Kelvin_Kilogram.Sense; } }
        public override int Family { get { return Joule_Kelvin_Kilogram.Family; } }
        public override double Factor { get { return Joule_Kelvin_Kilogram.Factor; } }
        public override SymbolCollection Symbol { get { return Joule_Kelvin_Kilogram.Symbol; } }
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
