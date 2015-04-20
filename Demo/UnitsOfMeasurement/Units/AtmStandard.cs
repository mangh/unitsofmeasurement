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
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public AtmStandard(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator AtmStandard(double q) { return new AtmStandard(q); }
        public static explicit operator AtmStandard(AtmTechnical q) { return new AtmStandard((AtmStandard.Factor / AtmTechnical.Factor) * q.Value); }
        public static explicit operator AtmStandard(Bar q) { return new AtmStandard((AtmStandard.Factor / Bar.Factor) * q.Value); }
        public static explicit operator AtmStandard(Pascal q) { return new AtmStandard((AtmStandard.Factor / Pascal.Factor) * q.Value); }
        public static explicit operator AtmStandard(MillimeterHg q) { return new AtmStandard((AtmStandard.Factor / MillimeterHg.Factor) * q.Value); }
        public static AtmStandard From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != AtmStandard.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"AtmStandard\"", q.GetType().Name));
            return new AtmStandard((AtmStandard.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<AtmStandard>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is AtmStandard) && Equals((AtmStandard)obj); }
        public bool /* IEquatable<AtmStandard> */ Equals(AtmStandard other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<AtmStandard>
        public static bool operator ==(AtmStandard lhs, AtmStandard rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(AtmStandard lhs, AtmStandard rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(AtmStandard lhs, AtmStandard rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(AtmStandard lhs, AtmStandard rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(AtmStandard lhs, AtmStandard rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(AtmStandard lhs, AtmStandard rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<AtmStandard> */ CompareTo(AtmStandard other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static AtmStandard operator +(AtmStandard lhs, AtmStandard rhs) { return new AtmStandard(lhs.Value + rhs.Value); }
        public static AtmStandard operator -(AtmStandard lhs, AtmStandard rhs) { return new AtmStandard(lhs.Value - rhs.Value); }
        public static AtmStandard operator ++(AtmStandard q) { return new AtmStandard(q.Value + 1d); }
        public static AtmStandard operator --(AtmStandard q) { return new AtmStandard(q.Value - 1d); }
        public static AtmStandard operator -(AtmStandard q) { return new AtmStandard(-q.Value); }
        public static AtmStandard operator *(double lhs, AtmStandard rhs) { return new AtmStandard(lhs * rhs.Value); }
        public static AtmStandard operator *(AtmStandard lhs, double rhs) { return new AtmStandard(lhs.Value * rhs); }
        public static AtmStandard operator /(AtmStandard lhs, double rhs) { return new AtmStandard(lhs.Value / rhs); }
        public static double operator /(AtmStandard lhs, AtmStandard rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(AtmStandard.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(AtmStandard.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? AtmStandard.Format, Value, AtmStandard.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Pascal.Sense;
        private static readonly int s_family = Pascal.Family;
        private static double s_factor = Pascal.Factor / 101325d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("atm");

        private static readonly AtmStandard s_one = new AtmStandard(1d);
        private static readonly AtmStandard s_zero = new AtmStandard(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static AtmStandard One { get { return s_one; } }
        public static AtmStandard Zero { get { return s_zero; } }
        #endregion
    }
}
