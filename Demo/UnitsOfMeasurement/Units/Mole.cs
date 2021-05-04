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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Mole.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Mole\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Mole.Format, q, Mole.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Dimension.AmountOfSubstance;
        public const int Family = 5;
        public static readonly SymbolCollection Symbol = new SymbolCollection("mol");
        public static readonly Unit<double> Proxy = new Mole_Proxy();
        public const double Factor = 1d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Mole One = new Mole(1d);
        public static readonly Mole Zero = new Mole(0d);
        #endregion
    }

    public partial class Mole_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Mole.Sense; } }
        public override int Family { get { return Mole.Family; } }
        public override double Factor { get { return Mole.Factor; } }
        public override SymbolCollection Symbol { get { return Mole.Symbol; } }
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
