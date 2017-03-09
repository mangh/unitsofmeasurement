/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Ampere : IQuantity<double>, IEquatable<Ampere>, IComparable<Ampere>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Ampere.Proxy; } }
        #endregion

        #region Constructor(s)
        public Ampere(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Ampere(double q) { return new Ampere(q); }
        public static Ampere From(IQuantity<double> q)
        {
            if (q.Unit.Family != Ampere.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Ampere\"", q.GetType().Name));
            return new Ampere((Ampere.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Ampere>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Ampere) && Equals((Ampere)obj); }
        public bool /* IEquatable<Ampere> */ Equals(Ampere other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Ampere>
        public static bool operator ==(Ampere lhs, Ampere rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Ampere lhs, Ampere rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Ampere lhs, Ampere rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Ampere lhs, Ampere rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Ampere lhs, Ampere rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Ampere lhs, Ampere rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Ampere> */ CompareTo(Ampere other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Ampere operator +(Ampere lhs, Ampere rhs) { return new Ampere(lhs.m_value + rhs.m_value); }
        public static Ampere operator -(Ampere lhs, Ampere rhs) { return new Ampere(lhs.m_value - rhs.m_value); }
        public static Ampere operator ++(Ampere q) { return new Ampere(q.m_value + 1d); }
        public static Ampere operator --(Ampere q) { return new Ampere(q.m_value - 1d); }
        public static Ampere operator -(Ampere q) { return new Ampere(-q.m_value); }
        public static Ampere operator *(double lhs, Ampere rhs) { return new Ampere(lhs * rhs.m_value); }
        public static Ampere operator *(Ampere lhs, double rhs) { return new Ampere(lhs.m_value * rhs); }
        public static Ampere operator /(Ampere lhs, double rhs) { return new Ampere(lhs.m_value / rhs); }
        public static double operator /(Ampere lhs, Ampere rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Coulomb operator *(Ampere lhs, Second rhs) { return new Coulomb(lhs.m_value * rhs.m_value); }
        public static Coulomb operator *(Second lhs, Ampere rhs) { return new Coulomb(lhs.m_value * rhs.m_value); }
        public static Siemens operator /(Ampere lhs, Volt rhs) { return new Siemens(lhs.m_value / rhs.m_value); }
        public static Volt operator /(Ampere lhs, Siemens rhs) { return new Volt(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Ampere.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Ampere.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Ampere.Format, m_value, Ampere.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Dimension.ElectricCurrent;
        private static readonly int s_family = 4;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("A");
        private static readonly Unit<double> s_proxy = new Ampere_Proxy();

        private static readonly Ampere s_one = new Ampere(1d);
        private static readonly Ampere s_zero = new Ampere(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Ampere One { get { return s_one; } }
        public static Ampere Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Ampere_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Ampere.Family; } }
        public override Dimension Sense { get { return Ampere.Sense; } }
        public override SymbolCollection Symbol { get { return Ampere.Symbol; } }
        public override double Factor { get { return Ampere.Factor; } set { Ampere.Factor = value; } }
        public override string Format { get { return Ampere.Format; } set { Ampere.Format = value; } }
        #endregion

        #region Constructor(s)
        public Ampere_Proxy() :
            base(typeof(Ampere))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Ampere(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Ampere.From(quantity);
        }
        #endregion
    }
}
