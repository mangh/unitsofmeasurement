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

        #region Properties
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
            if (q.Unit.Family != Bar.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Bar\"", q.GetType().Name));
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
        public override string ToString() { return ToString(Bar.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Bar.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Bar.Format, m_value, Bar.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Pascal.Sense;
        private static readonly int s_family = Pascal.Family;
        private static /*mutable*/ double s_factor = Pascal.Factor / 100000d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("bar");
        private static readonly Unit<double> s_proxy = new Bar_Proxy();

        private static readonly Bar s_one = new Bar(1d);
        private static readonly Bar s_zero = new Bar(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Bar One { get { return s_one; } }
        public static Bar Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Bar_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Bar.Family; } }
        public override Dimension Sense { get { return Bar.Sense; } }
        public override SymbolCollection Symbol { get { return Bar.Symbol; } }
        public override double Factor { get { return Bar.Factor; } set { Bar.Factor = value; } }
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
