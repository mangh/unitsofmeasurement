/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Bar : IQuantity<double>, IEquatable<Bar>, IComparable<Bar>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Bar.Proxy; } }
        #endregion

        #region Constructor(s)
        public Bar(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Bar(double q) { return new Bar(q); }
        public static explicit operator Bar(Pascal q) { return new Bar((Bar.Factor / Pascal.Factor) * q.m_value); }
        public static explicit operator Bar(MillimeterHg q) { return new Bar((Bar.Factor / MillimeterHg.Factor) * q.m_value); }
        public static explicit operator Bar(AtmStandard q) { return new Bar((Bar.Factor / AtmStandard.Factor) * q.m_value); }
        public static explicit operator Bar(AtmTechnical q) { return new Bar((Bar.Factor / AtmTechnical.Factor) * q.m_value); }
        public static Bar From(IQuantity<double> q)
        {
            if (q.Unit.Family != Bar.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Bar\"", q.GetType().Name));
            }
            return new Bar((Bar.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Bar>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Bar) && Equals((Bar)obj); }
        public bool /* IEquatable<Bar> */ Equals(Bar other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Bar>
        public static bool operator ==(Bar lhs, Bar rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Bar lhs, Bar rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Bar lhs, Bar rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Bar lhs, Bar rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Bar lhs, Bar rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Bar lhs, Bar rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Bar> */ CompareTo(Bar other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Bar operator +(Bar lhs, Bar rhs) { return new Bar(lhs.m_value + rhs.m_value); }
        public static Bar operator -(Bar lhs, Bar rhs) { return new Bar(lhs.m_value - rhs.m_value); }
        public static Bar operator ++(Bar q) { return new Bar(q.m_value + 1d); }
        public static Bar operator --(Bar q) { return new Bar(q.m_value - 1d); }
        public static Bar operator -(Bar q) { return new Bar(-q.m_value); }
        public static Bar operator *(double lhs, Bar rhs) { return new Bar(lhs * rhs.m_value); }
        public static Bar operator *(Bar lhs, double rhs) { return new Bar(lhs.m_value * rhs); }
        public static Bar operator /(Bar lhs, double rhs) { return new Bar(lhs.m_value / rhs); }
        public static double operator /(Bar lhs, Bar rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Bar.Format, q, Bar.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Pascal.Sense;
        public const int Family = Pascal.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("bar");
        public static readonly Unit<double> Proxy = new Bar_Proxy();
        public const double Factor = Pascal.Factor / 100000d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Bar One = new Bar(1d);
        public static readonly Bar Zero = new Bar(0d);
        #endregion
    }

    public partial class Bar_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Bar.Sense; } }
        public override int Family { get { return Bar.Family; } }
        public override double Factor { get { return Bar.Factor; } }
        public override SymbolCollection Symbol { get { return Bar.Symbol; } }
        public override string Format { get { return Bar.Format; } set { Bar.Format = value; } }
        #endregion

        #region Constructor(s)
        public Bar_Proxy() :
            base(typeof(Bar))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Bar(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Bar.From(quantity);
        }
        #endregion
    }
}
