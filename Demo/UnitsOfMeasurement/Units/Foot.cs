/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Foot : IQuantity<double>, IEquatable<Foot>, IComparable<Foot>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Foot(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Foot(double q) { return new Foot(q); }
        public static explicit operator Foot(Yard q) { return new Foot((Foot.Factor / Yard.Factor) * q.Value); }
        public static explicit operator Foot(Mile q) { return new Foot((Foot.Factor / Mile.Factor) * q.Value); }
        public static explicit operator Foot(Kilometer q) { return new Foot((Foot.Factor / Kilometer.Factor) * q.Value); }
        public static explicit operator Foot(Millimeter q) { return new Foot((Foot.Factor / Millimeter.Factor) * q.Value); }
        public static explicit operator Foot(Centimeter q) { return new Foot((Foot.Factor / Centimeter.Factor) * q.Value); }
        public static explicit operator Foot(Meter q) { return new Foot((Foot.Factor / Meter.Factor) * q.Value); }
        public static explicit operator Foot(Inch q) { return new Foot((Foot.Factor / Inch.Factor) * q.Value); }
        public static Foot From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Foot.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Foot\"", q.GetType().Name));
            return new Foot((Foot.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Foot>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Foot) && Equals((Foot)obj); }
        public bool /* IEquatable<Foot> */ Equals(Foot other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Foot>
        public static bool operator ==(Foot lhs, Foot rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Foot lhs, Foot rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Foot lhs, Foot rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Foot lhs, Foot rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Foot lhs, Foot rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Foot lhs, Foot rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Foot> */ CompareTo(Foot other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Foot operator +(Foot lhs, Foot rhs) { return new Foot(lhs.Value + rhs.Value); }
        public static Foot operator -(Foot lhs, Foot rhs) { return new Foot(lhs.Value - rhs.Value); }
        public static Foot operator ++(Foot q) { return new Foot(q.Value + 1d); }
        public static Foot operator --(Foot q) { return new Foot(q.Value - 1d); }
        public static Foot operator -(Foot q) { return new Foot(-q.Value); }
        public static Foot operator *(double lhs, Foot rhs) { return new Foot(lhs * rhs.Value); }
        public static Foot operator *(Foot lhs, double rhs) { return new Foot(lhs.Value * rhs); }
        public static Foot operator /(Foot lhs, double rhs) { return new Foot(lhs.Value / rhs); }
        public static double operator /(Foot lhs, Foot rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static SquareFoot operator *(Foot lhs, Foot rhs) { return new SquareFoot(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Foot.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Foot.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Foot.Format, Value, Foot.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Inch.Sense;
        private static readonly int s_family = Meter.Family;
        private static double s_factor = Inch.Factor / 12d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("ft");

        private static readonly Foot s_one = new Foot(1d);
        private static readonly Foot s_zero = new Foot(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Foot One { get { return s_one; } }
        public static Foot Zero { get { return s_zero; } }
        #endregion
    }
}
