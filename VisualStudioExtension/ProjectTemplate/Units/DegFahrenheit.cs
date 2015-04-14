/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct DegFahrenheit : IQuantity<double>, IEquatable<DegFahrenheit>, IComparable<DegFahrenheit>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return DegFahrenheit.Sense; } }
        public int UnitFamily { get { return DegFahrenheit.Family; } }
        public double UnitFactor { get { return DegFahrenheit.Factor; } }
        public string UnitFormat { get { return DegFahrenheit.Format; } }
        public SymbolCollection UnitSymbol { get { return DegFahrenheit.Symbol; } }

        #endregion

        #region Constructor(s)
        public DegFahrenheit(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator DegFahrenheit(double q) { return new DegFahrenheit(q); }
        public static explicit operator DegFahrenheit(DegRankine q) { return new DegFahrenheit((DegFahrenheit.Factor / DegRankine.Factor) * q.Value); }
        public static explicit operator DegFahrenheit(DegCelsius q) { return new DegFahrenheit((DegFahrenheit.Factor / DegCelsius.Factor) * q.Value); }
        public static explicit operator DegFahrenheit(DegKelvin q) { return new DegFahrenheit((DegFahrenheit.Factor / DegKelvin.Factor) * q.Value); }
        public static DegFahrenheit From(IQuantity<double> q)
        {
            if (q.UnitSense != DegFahrenheit.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"DegFahrenheit\"", q.GetType().Name));
            return new DegFahrenheit((DegFahrenheit.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<DegFahrenheit>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is DegFahrenheit) && Equals((DegFahrenheit)obj); }
        public bool /* IEquatable<DegFahrenheit> */ Equals(DegFahrenheit other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<DegFahrenheit>
        public static bool operator ==(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<DegFahrenheit> */ CompareTo(DegFahrenheit other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegFahrenheit operator +(DegFahrenheit lhs, DegFahrenheit rhs) { return new DegFahrenheit(lhs.Value + rhs.Value); }
        public static DegFahrenheit operator -(DegFahrenheit lhs, DegFahrenheit rhs) { return new DegFahrenheit(lhs.Value - rhs.Value); }
        public static DegFahrenheit operator ++(DegFahrenheit q) { return new DegFahrenheit(q.Value + 1d); }
        public static DegFahrenheit operator --(DegFahrenheit q) { return new DegFahrenheit(q.Value - 1d); }
        public static DegFahrenheit operator -(DegFahrenheit q) { return new DegFahrenheit(-q.Value); }
        public static DegFahrenheit operator *(double lhs, DegFahrenheit rhs) { return new DegFahrenheit(lhs * rhs.Value); }
        public static DegFahrenheit operator *(DegFahrenheit lhs, double rhs) { return new DegFahrenheit(lhs.Value * rhs); }
        public static DegFahrenheit operator /(DegFahrenheit lhs, double rhs) { return new DegFahrenheit(lhs.Value / rhs); }
        public static double operator /(DegFahrenheit lhs, DegFahrenheit rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(DegFahrenheit.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegFahrenheit.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? DegFahrenheit.Format, Value, DegFahrenheit.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = DegKelvin.Sense;
        private static readonly int s_family = DegKelvin.Family;
        private static double s_factor = (9d / 5d) * DegKelvin.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("\u00B0F", "deg.F");

        private static readonly DegFahrenheit s_one = new DegFahrenheit(1d);
        private static readonly DegFahrenheit s_zero = new DegFahrenheit(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static DegFahrenheit One { get { return s_one; } }
        public static DegFahrenheit Zero { get { return s_zero; } }
        #endregion
    }
}
