/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Yard : IQuantity<double>, IEquatable<Yard>, IComparable<Yard>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Yard(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Yard(double q) { return new Yard(q); }
        public static explicit operator Yard(Mile q) { return new Yard((Yard.Factor / Mile.Factor) * q.Value); }
        public static explicit operator Yard(Kilometer q) { return new Yard((Yard.Factor / Kilometer.Factor) * q.Value); }
        public static explicit operator Yard(Millimeter q) { return new Yard((Yard.Factor / Millimeter.Factor) * q.Value); }
        public static explicit operator Yard(Centimeter q) { return new Yard((Yard.Factor / Centimeter.Factor) * q.Value); }
        public static explicit operator Yard(Meter q) { return new Yard((Yard.Factor / Meter.Factor) * q.Value); }
        public static explicit operator Yard(Inch q) { return new Yard((Yard.Factor / Inch.Factor) * q.Value); }
        public static explicit operator Yard(Foot q) { return new Yard((Yard.Factor / Foot.Factor) * q.Value); }
        public static Yard From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Yard.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Yard\"", q.GetType().Name));
            return new Yard((Yard.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Yard>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Yard) && Equals((Yard)obj); }
        public bool /* IEquatable<Yard> */ Equals(Yard other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Yard>
        public static bool operator ==(Yard lhs, Yard rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Yard lhs, Yard rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Yard lhs, Yard rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Yard lhs, Yard rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Yard lhs, Yard rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Yard lhs, Yard rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Yard> */ CompareTo(Yard other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Yard operator +(Yard lhs, Yard rhs) { return new Yard(lhs.Value + rhs.Value); }
        public static Yard operator -(Yard lhs, Yard rhs) { return new Yard(lhs.Value - rhs.Value); }
        public static Yard operator ++(Yard q) { return new Yard(q.Value + 1d); }
        public static Yard operator --(Yard q) { return new Yard(q.Value - 1d); }
        public static Yard operator -(Yard q) { return new Yard(-q.Value); }
        public static Yard operator *(double lhs, Yard rhs) { return new Yard(lhs * rhs.Value); }
        public static Yard operator *(Yard lhs, double rhs) { return new Yard(lhs.Value * rhs); }
        public static Yard operator /(Yard lhs, double rhs) { return new Yard(lhs.Value / rhs); }
        public static double operator /(Yard lhs, Yard rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Yard.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Yard.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Yard.Format, Value, Yard.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Foot.Sense;
        private static readonly int s_family = Meter.Family;
        private static double s_factor = Foot.Factor / 3d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("yd");

        private static readonly Yard s_one = new Yard(1d);
        private static readonly Yard s_zero = new Yard(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Yard One { get { return s_one; } }
        public static Yard Zero { get { return s_zero; } }
        #endregion
    }
}
