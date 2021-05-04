/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Joule_Kelvin : IQuantity<double>, IEquatable<Joule_Kelvin>, IComparable<Joule_Kelvin>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Joule_Kelvin.Proxy; } }
        #endregion

        #region Constructor(s)
        public Joule_Kelvin(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Joule_Kelvin(double q) { return new Joule_Kelvin(q); }
        public static Joule_Kelvin From(IQuantity<double> q)
        {
            if (q.Unit.Family != Joule_Kelvin.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Joule_Kelvin\"", q.GetType().Name));
            }
            return new Joule_Kelvin((Joule_Kelvin.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Joule_Kelvin>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Joule_Kelvin) && Equals((Joule_Kelvin)obj); }
        public bool /* IEquatable<Joule_Kelvin> */ Equals(Joule_Kelvin other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Joule_Kelvin>
        public static bool operator ==(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Joule_Kelvin> */ CompareTo(Joule_Kelvin other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Joule_Kelvin operator +(Joule_Kelvin lhs, Joule_Kelvin rhs) { return new Joule_Kelvin(lhs.m_value + rhs.m_value); }
        public static Joule_Kelvin operator -(Joule_Kelvin lhs, Joule_Kelvin rhs) { return new Joule_Kelvin(lhs.m_value - rhs.m_value); }
        public static Joule_Kelvin operator ++(Joule_Kelvin q) { return new Joule_Kelvin(q.m_value + 1d); }
        public static Joule_Kelvin operator --(Joule_Kelvin q) { return new Joule_Kelvin(q.m_value - 1d); }
        public static Joule_Kelvin operator -(Joule_Kelvin q) { return new Joule_Kelvin(-q.m_value); }
        public static Joule_Kelvin operator *(double lhs, Joule_Kelvin rhs) { return new Joule_Kelvin(lhs * rhs.m_value); }
        public static Joule_Kelvin operator *(Joule_Kelvin lhs, double rhs) { return new Joule_Kelvin(lhs.m_value * rhs); }
        public static Joule_Kelvin operator /(Joule_Kelvin lhs, double rhs) { return new Joule_Kelvin(lhs.m_value / rhs); }
        public static double operator /(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Joule operator *(Joule_Kelvin lhs, DegKelvin rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Joule operator *(DegKelvin lhs, Joule_Kelvin rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Joule_Kelvin_Kilogram operator /(Joule_Kelvin lhs, Kilogram rhs) { return new Joule_Kelvin_Kilogram(lhs.m_value / rhs.m_value); }
        public static Kilogram operator /(Joule_Kelvin lhs, Joule_Kelvin_Kilogram rhs) { return new Kilogram(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Joule_Kelvin.Format, q, Joule_Kelvin.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Joule.Sense / DegKelvin.Sense;
        public const int Family = 19;
        public static readonly SymbolCollection Symbol = new SymbolCollection("J/K");
        public static readonly Unit<double> Proxy = new Joule_Kelvin_Proxy();
        public const double Factor = Joule.Factor / DegKelvin.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Joule_Kelvin One = new Joule_Kelvin(1d);
        public static readonly Joule_Kelvin Zero = new Joule_Kelvin(0d);
        #endregion
    }

    public partial class Joule_Kelvin_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Joule_Kelvin.Sense; } }
        public override int Family { get { return Joule_Kelvin.Family; } }
        public override double Factor { get { return Joule_Kelvin.Factor; } }
        public override SymbolCollection Symbol { get { return Joule_Kelvin.Symbol; } }
        public override string Format { get { return Joule_Kelvin.Format; } set { Joule_Kelvin.Format = value; } }
        #endregion

        #region Constructor(s)
        public Joule_Kelvin_Proxy() :
            base(typeof(Joule_Kelvin))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Joule_Kelvin(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Joule_Kelvin.From(quantity);
        }
        #endregion
    }
}
