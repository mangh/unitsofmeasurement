/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Bar : IQuantity<double>, IEquatable<Bar>, IComparable<Bar>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Bar.Sense; } }
        public int UnitFamily { get { return Bar.Family; } }
        public double UnitFactor { get { return Bar.Factor; } }
        public string UnitFormat { get { return Bar.Format; } }
        public SymbolCollection UnitSymbol { get { return Bar.Symbol; } }

        #endregion

        #region Constructor(s)
        public Bar(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Bar(double q) { return new Bar(q); }
        public static explicit operator Bar(Pascal q) { return new Bar((Bar.Factor / Pascal.Factor) * q.Value); }
        public static explicit operator Bar(MillimeterHg q) { return new Bar((Bar.Factor / MillimeterHg.Factor) * q.Value); }
        public static explicit operator Bar(AtmStandard q) { return new Bar((Bar.Factor / AtmStandard.Factor) * q.Value); }
        public static explicit operator Bar(AtmTechnical q) { return new Bar((Bar.Factor / AtmTechnical.Factor) * q.Value); }
        public static Bar From(IQuantity<double> q)
        {
            if (q.UnitSense != Bar.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Bar\"", q.GetType().Name));
            return new Bar((Bar.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Bar>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Bar) && Equals((Bar)obj); }
        public bool /* IEquatable<Bar> */ Equals(Bar other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Bar>
        public static bool operator ==(Bar lhs, Bar rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Bar lhs, Bar rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Bar lhs, Bar rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Bar lhs, Bar rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Bar lhs, Bar rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Bar lhs, Bar rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Bar> */ CompareTo(Bar other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Bar operator +(Bar lhs, Bar rhs) { return new Bar(lhs.Value + rhs.Value); }
        public static Bar operator -(Bar lhs, Bar rhs) { return new Bar(lhs.Value - rhs.Value); }
        public static Bar operator ++(Bar q) { return new Bar(q.Value + 1d); }
        public static Bar operator --(Bar q) { return new Bar(q.Value - 1d); }
        public static Bar operator -(Bar q) { return new Bar(-q.Value); }
        public static Bar operator *(double lhs, Bar rhs) { return new Bar(lhs * rhs.Value); }
        public static Bar operator *(Bar lhs, double rhs) { return new Bar(lhs.Value * rhs); }
        public static Bar operator /(Bar lhs, double rhs) { return new Bar(lhs.Value / rhs); }
        public static double operator /(Bar lhs, Bar rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Bar.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Bar.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Bar.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Pascal.Sense;
        private static readonly int s_family = Pascal.Family;
        private static double s_factor = Pascal.Factor / 100000d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("bar");

        private static readonly Bar s_one = new Bar(1d);
        private static readonly Bar s_zero = new Bar(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Bar One { get { return s_one; } }
        public static Bar Zero { get { return s_zero; } }
        #endregion
    }
}
