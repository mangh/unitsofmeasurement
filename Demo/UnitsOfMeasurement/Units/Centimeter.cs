/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Centimeter : IQuantity<double>, IEquatable<Centimeter>, IComparable<Centimeter>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Centimeter.Sense; } }
        public int UnitFamily { get { return Centimeter.Family; } }
        public double UnitFactor { get { return Centimeter.Factor; } }
        public string UnitFormat { get { return Centimeter.Format; } }
        public SymbolCollection UnitSymbol { get { return Centimeter.Symbol; } }

        #endregion

        #region Constructor(s)
        public Centimeter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Centimeter(double q) { return new Centimeter(q); }
        public static explicit operator Centimeter(Meter q) { return new Centimeter((Centimeter.Factor / Meter.Factor) * q.Value); }
        public static explicit operator Centimeter(Inch q) { return new Centimeter((Centimeter.Factor / Inch.Factor) * q.Value); }
        public static explicit operator Centimeter(Foot q) { return new Centimeter((Centimeter.Factor / Foot.Factor) * q.Value); }
        public static explicit operator Centimeter(Yard q) { return new Centimeter((Centimeter.Factor / Yard.Factor) * q.Value); }
        public static explicit operator Centimeter(Mile q) { return new Centimeter((Centimeter.Factor / Mile.Factor) * q.Value); }
        public static explicit operator Centimeter(Kilometer q) { return new Centimeter((Centimeter.Factor / Kilometer.Factor) * q.Value); }
        public static explicit operator Centimeter(Millimeter q) { return new Centimeter((Centimeter.Factor / Millimeter.Factor) * q.Value); }
        public static Centimeter From(IQuantity<double> q)
        {
            if (q.UnitSense != Centimeter.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Centimeter\"", q.GetType().Name));
            return new Centimeter((Centimeter.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Centimeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Centimeter) && Equals((Centimeter)obj); }
        public bool /* IEquatable<Centimeter> */ Equals(Centimeter other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Centimeter>
        public static bool operator ==(Centimeter lhs, Centimeter rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Centimeter lhs, Centimeter rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Centimeter lhs, Centimeter rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Centimeter lhs, Centimeter rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Centimeter lhs, Centimeter rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Centimeter lhs, Centimeter rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Centimeter> */ CompareTo(Centimeter other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Centimeter operator +(Centimeter lhs, Centimeter rhs) { return new Centimeter(lhs.Value + rhs.Value); }
        public static Centimeter operator -(Centimeter lhs, Centimeter rhs) { return new Centimeter(lhs.Value - rhs.Value); }
        public static Centimeter operator ++(Centimeter q) { return new Centimeter(q.Value + 1d); }
        public static Centimeter operator --(Centimeter q) { return new Centimeter(q.Value - 1d); }
        public static Centimeter operator -(Centimeter q) { return new Centimeter(-q.Value); }
        public static Centimeter operator *(double lhs, Centimeter rhs) { return new Centimeter(lhs * rhs.Value); }
        public static Centimeter operator *(Centimeter lhs, double rhs) { return new Centimeter(lhs.Value * rhs); }
        public static Centimeter operator /(Centimeter lhs, double rhs) { return new Centimeter(lhs.Value / rhs); }
        public static double operator /(Centimeter lhs, Centimeter rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Centimeter.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Centimeter.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Centimeter.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense;
        private static readonly int s_family = Meter.Family;
        private static double s_factor = 100d * Meter.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("cm");

        private static readonly Centimeter s_one = new Centimeter(1d);
        private static readonly Centimeter s_zero = new Centimeter(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Centimeter One { get { return s_one; } }
        public static Centimeter Zero { get { return s_zero; } }
        #endregion
    }
}
