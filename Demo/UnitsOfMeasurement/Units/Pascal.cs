/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Pascal : IQuantity<double>, IEquatable<Pascal>, IComparable<Pascal>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Pascal.Proxy; } }
        #endregion

        #region Constructor(s)
        public Pascal(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Pascal(double q) { return new Pascal(q); }
        public static explicit operator Pascal(MillimeterHg q) { return new Pascal((Pascal.Factor / MillimeterHg.Factor) * q.m_value); }
        public static explicit operator Pascal(AtmStandard q) { return new Pascal((Pascal.Factor / AtmStandard.Factor) * q.m_value); }
        public static explicit operator Pascal(AtmTechnical q) { return new Pascal((Pascal.Factor / AtmTechnical.Factor) * q.m_value); }
        public static explicit operator Pascal(Bar q) { return new Pascal((Pascal.Factor / Bar.Factor) * q.m_value); }
        public static Pascal From(IQuantity<double> q)
        {
            if (q.Unit.Family != Pascal.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Pascal\"", q.GetType().Name));
            return new Pascal((Pascal.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Pascal>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Pascal) && Equals((Pascal)obj); }
        public bool /* IEquatable<Pascal> */ Equals(Pascal other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Pascal>
        public static bool operator ==(Pascal lhs, Pascal rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Pascal lhs, Pascal rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Pascal lhs, Pascal rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Pascal lhs, Pascal rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Pascal lhs, Pascal rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Pascal lhs, Pascal rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Pascal> */ CompareTo(Pascal other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Pascal operator +(Pascal lhs, Pascal rhs) { return new Pascal(lhs.m_value + rhs.m_value); }
        public static Pascal operator -(Pascal lhs, Pascal rhs) { return new Pascal(lhs.m_value - rhs.m_value); }
        public static Pascal operator ++(Pascal q) { return new Pascal(q.m_value + 1d); }
        public static Pascal operator --(Pascal q) { return new Pascal(q.m_value - 1d); }
        public static Pascal operator -(Pascal q) { return new Pascal(-q.m_value); }
        public static Pascal operator *(double lhs, Pascal rhs) { return new Pascal(lhs * rhs.m_value); }
        public static Pascal operator *(Pascal lhs, double rhs) { return new Pascal(lhs.m_value * rhs); }
        public static Pascal operator /(Pascal lhs, double rhs) { return new Pascal(lhs.m_value / rhs); }
        public static double operator /(Pascal lhs, Pascal rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Newton operator *(Pascal lhs, SquareMeter rhs) { return new Newton(lhs.m_value * rhs.m_value); }
        public static Newton operator *(SquareMeter lhs, Pascal rhs) { return new Newton(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Pascal.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Pascal.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Pascal.Format, m_value, Pascal.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Newton.Sense / SquareMeter.Sense;
        private static readonly int s_family = 21;
        private static /*mutable*/ double s_factor = Newton.Factor / SquareMeter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("Pa");
        private static readonly Unit<double> s_proxy = new Pascal_Proxy();

        private static readonly Pascal s_one = new Pascal(1d);
        private static readonly Pascal s_zero = new Pascal(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Pascal One { get { return s_one; } }
        public static Pascal Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Pascal_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Pascal.Family; } }
        public override Dimension Sense { get { return Pascal.Sense; } }
        public override SymbolCollection Symbol { get { return Pascal.Symbol; } }
        public override double Factor { get { return Pascal.Factor; } set { Pascal.Factor = value; } }
        public override string Format { get { return Pascal.Format; } set { Pascal.Format = value; } }
        #endregion

        #region Constructor(s)
        public Pascal_Proxy() :
            base(typeof(Pascal))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Pascal(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Pascal.From(quantity);
        }
        #endregion
    }
}
