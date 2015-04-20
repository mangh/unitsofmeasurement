/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct DegKelvin : IQuantity<double>, IEquatable<DegKelvin>, IComparable<DegKelvin>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public DegKelvin(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator DegKelvin(double q) { return new DegKelvin(q); }
        public static explicit operator DegKelvin(DegFahrenheit q) { return new DegKelvin((DegKelvin.Factor / DegFahrenheit.Factor) * q.Value); }
        public static explicit operator DegKelvin(DegRankine q) { return new DegKelvin((DegKelvin.Factor / DegRankine.Factor) * q.Value); }
        public static explicit operator DegKelvin(DegCelsius q) { return new DegKelvin((DegKelvin.Factor / DegCelsius.Factor) * q.Value); }
        public static DegKelvin From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != DegKelvin.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"DegKelvin\"", q.GetType().Name));
            return new DegKelvin((DegKelvin.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<DegKelvin>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is DegKelvin) && Equals((DegKelvin)obj); }
        public bool /* IEquatable<DegKelvin> */ Equals(DegKelvin other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<DegKelvin>
        public static bool operator ==(DegKelvin lhs, DegKelvin rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(DegKelvin lhs, DegKelvin rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(DegKelvin lhs, DegKelvin rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(DegKelvin lhs, DegKelvin rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(DegKelvin lhs, DegKelvin rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(DegKelvin lhs, DegKelvin rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<DegKelvin> */ CompareTo(DegKelvin other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static DegKelvin operator +(DegKelvin lhs, DegKelvin rhs) { return new DegKelvin(lhs.Value + rhs.Value); }
        public static DegKelvin operator -(DegKelvin lhs, DegKelvin rhs) { return new DegKelvin(lhs.Value - rhs.Value); }
        public static DegKelvin operator ++(DegKelvin q) { return new DegKelvin(q.Value + 1d); }
        public static DegKelvin operator --(DegKelvin q) { return new DegKelvin(q.Value - 1d); }
        public static DegKelvin operator -(DegKelvin q) { return new DegKelvin(-q.Value); }
        public static DegKelvin operator *(double lhs, DegKelvin rhs) { return new DegKelvin(lhs * rhs.Value); }
        public static DegKelvin operator *(DegKelvin lhs, double rhs) { return new DegKelvin(lhs.Value * rhs); }
        public static DegKelvin operator /(DegKelvin lhs, double rhs) { return new DegKelvin(lhs.Value / rhs); }
        public static double operator /(DegKelvin lhs, DegKelvin rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(DegKelvin.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(DegKelvin.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? DegKelvin.Format, Value, DegKelvin.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Temperature;
        private static readonly int s_family = 3;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("K", "deg.K");

        private static readonly DegKelvin s_one = new DegKelvin(1d);
        private static readonly DegKelvin s_zero = new DegKelvin(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static DegKelvin One { get { return s_one; } }
        public static DegKelvin Zero { get { return s_zero; } }
        #endregion
    }
}
