/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Joule : IQuantity<double>, IEquatable<Joule>, IComparable<Joule>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Joule.Proxy; } }
        #endregion

        #region Constructor(s)
        public Joule(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Joule(double q) { return new Joule(q); }
        public static Joule From(IQuantity<double> q)
        {
            if (q.Unit.Family != Joule.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Joule\"", q.GetType().Name));
            }
            return new Joule((Joule.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Joule>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Joule) && Equals((Joule)obj); }
        public bool /* IEquatable<Joule> */ Equals(Joule other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Joule>
        public static bool operator ==(Joule lhs, Joule rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Joule lhs, Joule rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Joule lhs, Joule rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Joule lhs, Joule rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Joule lhs, Joule rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Joule lhs, Joule rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Joule> */ CompareTo(Joule other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Joule operator +(Joule lhs, Joule rhs) { return new Joule(lhs.m_value + rhs.m_value); }
        public static Joule operator -(Joule lhs, Joule rhs) { return new Joule(lhs.m_value - rhs.m_value); }
        public static Joule operator ++(Joule q) { return new Joule(q.m_value + 1d); }
        public static Joule operator --(Joule q) { return new Joule(q.m_value - 1d); }
        public static Joule operator -(Joule q) { return new Joule(-q.m_value); }
        public static Joule operator *(double lhs, Joule rhs) { return new Joule(lhs * rhs.m_value); }
        public static Joule operator *(Joule lhs, double rhs) { return new Joule(lhs.m_value * rhs); }
        public static Joule operator /(Joule lhs, double rhs) { return new Joule(lhs.m_value / rhs); }
        public static double operator /(Joule lhs, Joule rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter operator /(Joule lhs, Newton rhs) { return new Meter(lhs.m_value / rhs.m_value); }
        public static Newton operator /(Joule lhs, Meter rhs) { return new Newton(lhs.m_value / rhs.m_value); }
        public static Watt operator /(Joule lhs, Second rhs) { return new Watt(lhs.m_value / rhs.m_value); }
        public static Second operator /(Joule lhs, Watt rhs) { return new Second(lhs.m_value / rhs.m_value); }
        public static Joule_Kelvin operator /(Joule lhs, DegKelvin rhs) { return new Joule_Kelvin(lhs.m_value / rhs.m_value); }
        public static DegKelvin operator /(Joule lhs, Joule_Kelvin rhs) { return new DegKelvin(lhs.m_value / rhs.m_value); }
        public static Volt operator /(Joule lhs, Coulomb rhs) { return new Volt(lhs.m_value / rhs.m_value); }
        public static Coulomb operator /(Joule lhs, Volt rhs) { return new Coulomb(lhs.m_value / rhs.m_value); }
        public static Weber operator /(Joule lhs, Ampere rhs) { return new Weber(lhs.m_value / rhs.m_value); }
        public static Ampere operator /(Joule lhs, Weber rhs) { return new Ampere(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Joule.Format, q, Joule.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Newton.Sense * Meter.Sense;
        public const int Family = 16;
        public static readonly SymbolCollection Symbol = new SymbolCollection("J");
        public static readonly Unit<double> Proxy = new Joule_Proxy();
        public const double Factor = Newton.Factor * Meter.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Joule One = new Joule(1d);
        public static readonly Joule Zero = new Joule(0d);
        #endregion
    }

    public partial class Joule_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Joule.Sense; } }
        public override int Family { get { return Joule.Family; } }
        public override double Factor { get { return Joule.Factor; } }
        public override SymbolCollection Symbol { get { return Joule.Symbol; } }
        public override string Format { get { return Joule.Format; } set { Joule.Format = value; } }
        #endregion

        #region Constructor(s)
        public Joule_Proxy() :
            base(typeof(Joule))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Joule(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Joule.From(quantity);
        }
        #endregion
    }
}
