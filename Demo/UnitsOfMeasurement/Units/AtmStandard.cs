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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != AtmStandard.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"AtmStandard\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? AtmStandard.Format, q, AtmStandard.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Pascal.Sense;
        public const int Family = Pascal.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("atm");
        public static readonly Unit<double> Proxy = new AtmStandard_Proxy();
        public const double Factor = Pascal.Factor / 101325d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly AtmStandard One = new AtmStandard(1d);
        public static readonly AtmStandard Zero = new AtmStandard(0d);
        #endregion
    }

    public partial class AtmStandard_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return AtmStandard.Sense; } }
        public override int Family { get { return AtmStandard.Family; } }
        public override double Factor { get { return AtmStandard.Factor; } }
        public override SymbolCollection Symbol { get { return AtmStandard.Symbol; } }
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
