/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct AtmStandard : IQuantity<double>, IEquatable<AtmStandard>, IComparable<AtmStandard>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return AtmStandard.Proxy; } }
        #endregion

        #region Constructor(s)
        public AtmStandard(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator AtmStandard(double q) { return new AtmStandard(q); }
        public static explicit operator AtmStandard(AtmTechnical q) { return new AtmStandard((AtmStandard.Factor / AtmTechnical.Factor) * q.m_value); }
        public static explicit operator AtmStandard(Bar q) { return new AtmStandard((AtmStandard.Factor / Bar.Factor) * q.m_value); }
        public static explicit operator AtmStandard(Pascal q) { return new AtmStandard((AtmStandard.Factor / Pascal.Factor) * q.m_value); }
        public static explicit operator AtmStandard(MillimeterHg q) { return new AtmStandard((AtmStandard.Factor / MillimeterHg.Factor) * q.m_value); }
        public static AtmStandard From(IQuantity<double> q)
        {
            if (q.Unit.Family != AtmStandard.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"AtmStandard\"", q.GetType().Name));
            return new AtmStandard((AtmStandard.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<AtmStandard>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is AtmStandard) && Equals((AtmStandard)obj); }
        public bool /* IEquatable<AtmStandard> */ Equals(AtmStandard other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<AtmStandard>
        public static bool operator ==(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<AtmStandard> */ CompareTo(AtmStandard other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static AtmStandard operator +(AtmStandard lhs, AtmStandard rhs) { return new AtmStandard(lhs.m_value + rhs.m_value); }
        public static AtmStandard operator -(AtmStandard lhs, AtmStandard rhs) { return new AtmStandard(lhs.m_value - rhs.m_value); }
        public static AtmStandard operator ++(AtmStandard q) { return new AtmStandard(q.m_value + 1d); }
        public static AtmStandard operator --(AtmStandard q) { return new AtmStandard(q.m_value - 1d); }
        public static AtmStandard operator -(AtmStandard q) { return new AtmStandard(-q.m_value); }
        public static AtmStandard operator *(double lhs, AtmStandard rhs) { return new AtmStandard(lhs * rhs.m_value); }
        public static AtmStandard operator *(AtmStandard lhs, double rhs) { return new AtmStandard(lhs.m_value * rhs); }
        public static AtmStandard operator /(AtmStandard lhs, double rhs) { return new AtmStandard(lhs.m_value / rhs); }
        public static double operator /(AtmStandard lhs, AtmStandard rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(AtmStandard.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(AtmStandard.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? AtmStandard.Format, m_value, AtmStandard.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Pascal.Sense;
        private static readonly int s_family = Pascal.Family;
        private static /*mutable*/ double s_factor = Pascal.Factor / 101325d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("atm");
        private static readonly Unit<double> s_proxy = new AtmStandard_Proxy();

        private static readonly AtmStandard s_one = new AtmStandard(1d);
        private static readonly AtmStandard s_zero = new AtmStandard(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static AtmStandard One { get { return s_one; } }
        public static AtmStandard Zero { get { return s_zero; } }
        #endregion
    }

    public partial class AtmStandard_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return AtmStandard.Family; } }
        public override Dimension Sense { get { return AtmStandard.Sense; } }
        public override SymbolCollection Symbol { get { return AtmStandard.Symbol; } }
        public override double Factor { get { return AtmStandard.Factor; } set { AtmStandard.Factor = value; } }
        public override string Format { get { return AtmStandard.Format; } set { AtmStandard.Format = value; } }
        #endregion

        #region Constructor(s)
        public AtmStandard_Proxy() :
            base(typeof(AtmStandard))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new AtmStandard(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return AtmStandard.From(quantity);
        }
        #endregion
    }
}
