/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct DegRankine : IQuantity<double>, IEquatable<DegRankine>, IComparable<DegRankine>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return DegRankine.Sense; } }
        public int UnitFamily { get { return DegRankine.Family; } }
        public double UnitFactor { get { return DegRankine.Factor; } }
        public string UnitFormat { get { return DegRankine.Format; } }
        public SymbolCollection UnitSymbol { get { return DegRankine.Symbol; } }

        #endregion

        #region Constructor(s)
        public DegRankine(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator DegRankine(double q) { return new DegRankine(q); }
        public static explicit operator DegRankine(DegCelsius q) { return new DegRankine((DegRankine.Factor / DegCelsius.Factor) * q.Value); }
        public static explicit operator DegRankine(DegKelvin q) { return new DegRankine((DegRankine.Factor / DegKelvin.Factor) * q.Value); }
        public static explicit operator DegRankine(DegFahrenheit q) { return new DegRankine((DegRankine.Factor / DegFahrenheit.Factor) * q.Value); }
        public static DegRankine From(IQuantity<double> q)
        {
            if (q.UnitSense != DegRankine.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"DegRankine\"", q.GetType().Name));
            return new DegRankine((DegRankine.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<DegRankine>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is DegRankine) && Equals((DegRankine)obj); }
        public bool /* IEquatable<DegRankine> */ Equals(DegRankine other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<DegRankine>
        public static bool operator ==(DegRankine lhs, DegRankine rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(DegRankine lhs, DegRankine rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(DegRankine lhs, DegRankine rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(DegRankine lhs, DegRankine rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(DegRankine lhs, DegRankine rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(DegRankine lhs, DegRankine rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<DegRankine> */ CompareTo(DegRankine other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegRankine operator +(DegRankine lhs, DegRankine rhs) { return new DegRankine(lhs.Value + rhs.Value); }
        public static DegRankine operator -(DegRankine lhs, DegRankine rhs) { return new DegRankine(lhs.Value - rhs.Value); }
        public static DegRankine operator ++(DegRankine q) { return new DegRankine(q.Value + 1d); }
        public static DegRankine operator --(DegRankine q) { return new DegRankine(q.Value - 1d); }
        public static DegRankine operator -(DegRankine q) { return new DegRankine(-q.Value); }
        public static DegRankine operator *(double lhs, DegRankine rhs) { return new DegRankine(lhs * rhs.Value); }
        public static DegRankine operator *(DegRankine lhs, double rhs) { return new DegRankine(lhs.Value * rhs); }
        public static DegRankine operator /(DegRankine lhs, double rhs) { return new DegRankine(lhs.Value / rhs); }
        public static double operator /(DegRankine lhs, DegRankine rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(DegRankine.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegRankine.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? DegRankine.Format, Value, DegRankine.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = DegKelvin.Sense;
        private static readonly int s_family = DegKelvin.Family;
        private static double s_factor = (9d / 5d) * DegKelvin.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("\u00B0R", "deg.R");

        private static readonly DegRankine s_one = new DegRankine(1d);
        private static readonly DegRankine s_zero = new DegRankine(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static DegRankine One { get { return s_one; } }
        public static DegRankine Zero { get { return s_zero; } }
        #endregion
    }
}
