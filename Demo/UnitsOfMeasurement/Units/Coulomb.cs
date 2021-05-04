/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Coulomb : IQuantity<double>, IEquatable<Coulomb>, IComparable<Coulomb>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Coulomb.Proxy; } }
        #endregion

        #region Constructor(s)
        public Coulomb(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Coulomb(double q) { return new Coulomb(q); }
        public static Coulomb From(IQuantity<double> q)
        {
            if (q.Unit.Family != Coulomb.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Coulomb\"", q.GetType().Name));
            }
            return new Coulomb((Coulomb.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Coulomb>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Coulomb) && Equals((Coulomb)obj); }
        public bool /* IEquatable<Coulomb> */ Equals(Coulomb other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Coulomb>
        public static bool operator ==(Coulomb lhs, Coulomb rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Coulomb lhs, Coulomb rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Coulomb lhs, Coulomb rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Coulomb lhs, Coulomb rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Coulomb lhs, Coulomb rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Coulomb lhs, Coulomb rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Coulomb> */ CompareTo(Coulomb other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Coulomb operator +(Coulomb lhs, Coulomb rhs) { return new Coulomb(lhs.m_value + rhs.m_value); }
        public static Coulomb operator -(Coulomb lhs, Coulomb rhs) { return new Coulomb(lhs.m_value - rhs.m_value); }
        public static Coulomb operator ++(Coulomb q) { return new Coulomb(q.m_value + 1d); }
        public static Coulomb operator --(Coulomb q) { return new Coulomb(q.m_value - 1d); }
        public static Coulomb operator -(Coulomb q) { return new Coulomb(-q.m_value); }
        public static Coulomb operator *(double lhs, Coulomb rhs) { return new Coulomb(lhs * rhs.m_value); }
        public static Coulomb operator *(Coulomb lhs, double rhs) { return new Coulomb(lhs.m_value * rhs); }
        public static Coulomb operator /(Coulomb lhs, double rhs) { return new Coulomb(lhs.m_value / rhs); }
        public static double operator /(Coulomb lhs, Coulomb rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Second operator /(Coulomb lhs, Ampere rhs) { return new Second(lhs.m_value / rhs.m_value); }
        public static Ampere operator /(Coulomb lhs, Second rhs) { return new Ampere(lhs.m_value / rhs.m_value); }
        public static Farad operator /(Coulomb lhs, Volt rhs) { return new Farad(lhs.m_value / rhs.m_value); }
        public static Volt operator /(Coulomb lhs, Farad rhs) { return new Volt(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Coulomb.Format, q, Coulomb.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Ampere.Sense * Second.Sense;
        public const int Family = 22;
        public static readonly SymbolCollection Symbol = new SymbolCollection("C");
        public static readonly Unit<double> Proxy = new Coulomb_Proxy();
        public const double Factor = Ampere.Factor * Second.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Coulomb One = new Coulomb(1d);
        public static readonly Coulomb Zero = new Coulomb(0d);
        #endregion
    }

    public partial class Coulomb_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Coulomb.Sense; } }
        public override int Family { get { return Coulomb.Family; } }
        public override double Factor { get { return Coulomb.Factor; } }
        public override SymbolCollection Symbol { get { return Coulomb.Symbol; } }
        public override string Format { get { return Coulomb.Format; } set { Coulomb.Format = value; } }
        #endregion

        #region Constructor(s)
        public Coulomb_Proxy() :
            base(typeof(Coulomb))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Coulomb(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Coulomb.From(quantity);
        }
        #endregion
    }
}
