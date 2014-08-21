/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct DegKelvin : IQuantity<double>, IEquatable<DegKelvin>, IComparable<DegKelvin>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return DegKelvin.Sense; } }
        public int UnitFamily { get { return DegKelvin.Family; } }
        public double UnitFactor { get { return DegKelvin.Factor; } }
        public string UnitFormat { get { return DegKelvin.Format; } }
        public SymbolCollection UnitSymbol { get { return DegKelvin.Symbol; } }

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
            if (q.UnitSense != DegKelvin.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"DegKelvin\"", q.GetType().Name));
            return new DegKelvin((DegKelvin.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is DegKelvin) && Equals((DegKelvin)obj); }
        public bool /* IEquatable<DegKelvin> */ Equals(DegKelvin other) { return this.Value == other.Value; }
        public int /* IComparable<DegKelvin> */ CompareTo(DegKelvin other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Comparison
        public static bool operator ==(DegKelvin lhs, DegKelvin rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(DegKelvin lhs, DegKelvin rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(DegKelvin lhs, DegKelvin rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(DegKelvin lhs, DegKelvin rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(DegKelvin lhs, DegKelvin rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(DegKelvin lhs, DegKelvin rhs) { return lhs.Value >= rhs.Value; }
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
        // Outer:
        public static double operator /(DegKelvin lhs, DegKelvin rhs) { return lhs.Value / rhs.Value; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, DegKelvin.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, DegKelvin.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, DegKelvin.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Temperature;
        private static readonly int s_family = 16;
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
