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

        #region Properties
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
            if (q.Unit.Family != Coulomb.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Coulomb\"", q.GetType().Name));
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
        public override string ToString() { return ToString(Coulomb.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Coulomb.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Coulomb.Format, m_value, Coulomb.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Ampere.Sense * Second.Sense;
        private static readonly int s_family = 22;
        private static /*mutable*/ double s_factor = Ampere.Factor * Second.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("C");
        private static readonly Unit<double> s_proxy = new Coulomb_Proxy();

        private static readonly Coulomb s_one = new Coulomb(1d);
        private static readonly Coulomb s_zero = new Coulomb(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Coulomb One { get { return s_one; } }
        public static Coulomb Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Coulomb_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Coulomb.Family; } }
        public override Dimension Sense { get { return Coulomb.Sense; } }
        public override SymbolCollection Symbol { get { return Coulomb.Symbol; } }
        public override double Factor { get { return Coulomb.Factor; } set { Coulomb.Factor = value; } }
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
