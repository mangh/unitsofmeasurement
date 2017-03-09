/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Mole : IQuantity<double>, IEquatable<Mole>, IComparable<Mole>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Mole.Proxy; } }
        #endregion

        #region Constructor(s)
        public Mole(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Mole(double q) { return new Mole(q); }
        public static Mole From(IQuantity<double> q)
        {
            if (q.Unit.Family != Mole.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Mole\"", q.GetType().Name));
            return new Mole((Mole.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Mole>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Mole) && Equals((Mole)obj); }
        public bool /* IEquatable<Mole> */ Equals(Mole other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Mole>
        public static bool operator ==(Mole lhs, Mole rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Mole lhs, Mole rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Mole lhs, Mole rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Mole lhs, Mole rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Mole lhs, Mole rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Mole lhs, Mole rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Mole> */ CompareTo(Mole other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Mole operator +(Mole lhs, Mole rhs) { return new Mole(lhs.m_value + rhs.m_value); }
        public static Mole operator -(Mole lhs, Mole rhs) { return new Mole(lhs.m_value - rhs.m_value); }
        public static Mole operator ++(Mole q) { return new Mole(q.m_value + 1d); }
        public static Mole operator --(Mole q) { return new Mole(q.m_value - 1d); }
        public static Mole operator -(Mole q) { return new Mole(-q.m_value); }
        public static Mole operator *(double lhs, Mole rhs) { return new Mole(lhs * rhs.m_value); }
        public static Mole operator *(Mole lhs, double rhs) { return new Mole(lhs.m_value * rhs); }
        public static Mole operator /(Mole lhs, double rhs) { return new Mole(lhs.m_value / rhs); }
        public static double operator /(Mole lhs, Mole rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Mole.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Mole.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Mole.Format, m_value, Mole.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Dimension.AmountOfSubstance;
        private static readonly int s_family = 5;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mol");
        private static readonly Unit<double> s_proxy = new Mole_Proxy();

        private static readonly Mole s_one = new Mole(1d);
        private static readonly Mole s_zero = new Mole(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Mole One { get { return s_one; } }
        public static Mole Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Mole_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Mole.Family; } }
        public override Dimension Sense { get { return Mole.Sense; } }
        public override SymbolCollection Symbol { get { return Mole.Symbol; } }
        public override double Factor { get { return Mole.Factor; } set { Mole.Factor = value; } }
        public override string Format { get { return Mole.Format; } set { Mole.Format = value; } }
        #endregion

        #region Constructor(s)
        public Mole_Proxy() :
            base(typeof(Mole))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Mole(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Mole.From(quantity);
        }
        #endregion
    }
}
