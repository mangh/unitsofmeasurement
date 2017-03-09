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

        #region Properties
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
            if (q.Unit.Family != Candela.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Candela\"", q.GetType().Name));
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
        public override string ToString() { return ToString(Candela.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Candela.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Candela.Format, m_value, Candela.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Dimension.LuminousIntensity;
        private static readonly int s_family = 6;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("cd");
        private static readonly Unit<double> s_proxy = new Candela_Proxy();

        private static readonly Candela s_one = new Candela(1d);
        private static readonly Candela s_zero = new Candela(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Candela One { get { return s_one; } }
        public static Candela Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Candela_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Candela.Family; } }
        public override Dimension Sense { get { return Candela.Sense; } }
        public override SymbolCollection Symbol { get { return Candela.Symbol; } }
        public override double Factor { get { return Candela.Factor; } set { Candela.Factor = value; } }
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
