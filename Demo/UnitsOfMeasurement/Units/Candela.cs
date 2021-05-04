/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Candela : IQuantity<double>, IEquatable<Candela>, IComparable<Candela>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Candela.Proxy; } }
        #endregion

        #region Constructor(s)
        public Candela(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Candela(double q) { return new Candela(q); }
        public static Candela From(IQuantity<double> q)
        {
            if (q.Unit.Family != Candela.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Candela\"", q.GetType().Name));
            }
            return new Candela((Candela.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Candela>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Candela) && Equals((Candela)obj); }
        public bool /* IEquatable<Candela> */ Equals(Candela other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Candela>
        public static bool operator ==(Candela lhs, Candela rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Candela lhs, Candela rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Candela lhs, Candela rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Candela lhs, Candela rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Candela lhs, Candela rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Candela lhs, Candela rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Candela> */ CompareTo(Candela other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Candela operator +(Candela lhs, Candela rhs) { return new Candela(lhs.m_value + rhs.m_value); }
        public static Candela operator -(Candela lhs, Candela rhs) { return new Candela(lhs.m_value - rhs.m_value); }
        public static Candela operator ++(Candela q) { return new Candela(q.m_value + 1d); }
        public static Candela operator --(Candela q) { return new Candela(q.m_value - 1d); }
        public static Candela operator -(Candela q) { return new Candela(-q.m_value); }
        public static Candela operator *(double lhs, Candela rhs) { return new Candela(lhs * rhs.m_value); }
        public static Candela operator *(Candela lhs, double rhs) { return new Candela(lhs.m_value * rhs); }
        public static Candela operator /(Candela lhs, double rhs) { return new Candela(lhs.m_value / rhs); }
        public static double operator /(Candela lhs, Candela rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Candela.Format, q, Candela.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Dimension.LuminousIntensity;
        public const int Family = 6;
        public static readonly SymbolCollection Symbol = new SymbolCollection("cd");
        public static readonly Unit<double> Proxy = new Candela_Proxy();
        public const double Factor = 1d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Candela One = new Candela(1d);
        public static readonly Candela Zero = new Candela(0d);
        #endregion
    }

    public partial class Candela_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Candela.Sense; } }
        public override int Family { get { return Candela.Family; } }
        public override double Factor { get { return Candela.Factor; } }
        public override SymbolCollection Symbol { get { return Candela.Symbol; } }
        public override string Format { get { return Candela.Format; } set { Candela.Format = value; } }
        #endregion

        #region Constructor(s)
        public Candela_Proxy() :
            base(typeof(Candela))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Candela(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Candela.From(quantity);
        }
        #endregion
    }
}
