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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Pascal.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Pascal\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Pascal.Format, q, Pascal.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Newton.Sense / SquareMeter.Sense;
        public const int Family = 21;
        public static readonly SymbolCollection Symbol = new SymbolCollection("Pa");
        public static readonly Unit<double> Proxy = new Pascal_Proxy();
        public const double Factor = Newton.Factor / SquareMeter.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Pascal One = new Pascal(1d);
        public static readonly Pascal Zero = new Pascal(0d);
        #endregion
    }

    public partial class Pascal_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Pascal.Sense; } }
        public override int Family { get { return Pascal.Family; } }
        public override double Factor { get { return Pascal.Factor; } }
        public override SymbolCollection Symbol { get { return Pascal.Symbol; } }
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
