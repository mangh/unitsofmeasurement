/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Weber : IQuantity<double>, IEquatable<Weber>, IComparable<Weber>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Weber(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Weber(double q) { return new Weber(q); }
        public static Weber From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Weber.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Weber\"", q.GetType().Name));
            return new Weber((Weber.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Weber>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Weber) && Equals((Weber)obj); }
        public bool /* IEquatable<Weber> */ Equals(Weber other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Weber>
        public static bool operator ==(Weber lhs, Weber rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Weber lhs, Weber rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Weber lhs, Weber rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Weber lhs, Weber rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Weber lhs, Weber rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Weber lhs, Weber rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Weber> */ CompareTo(Weber other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Weber operator +(Weber lhs, Weber rhs) { return new Weber(lhs.Value + rhs.Value); }
        public static Weber operator -(Weber lhs, Weber rhs) { return new Weber(lhs.Value - rhs.Value); }
        public static Weber operator ++(Weber q) { return new Weber(q.Value + 1d); }
        public static Weber operator --(Weber q) { return new Weber(q.Value - 1d); }
        public static Weber operator -(Weber q) { return new Weber(-q.Value); }
        public static Weber operator *(double lhs, Weber rhs) { return new Weber(lhs * rhs.Value); }
        public static Weber operator *(Weber lhs, double rhs) { return new Weber(lhs.Value * rhs); }
        public static Weber operator /(Weber lhs, double rhs) { return new Weber(lhs.Value / rhs); }
        public static double operator /(Weber lhs, Weber rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Joule operator *(Weber lhs, Ampere rhs) { return new Joule(lhs.Value * rhs.Value); }
        public static Joule operator *(Ampere lhs, Weber rhs) { return new Joule(lhs.Value * rhs.Value); }
        public static Second operator /(Weber lhs, Volt rhs) { return new Second(lhs.Value / rhs.Value); }
        public static Volt operator /(Weber lhs, Second rhs) { return new Volt(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Weber.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Weber.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Weber.Format, Value, Weber.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Joule.Sense / Ampere.Sense;
        private static readonly int s_family = 27;
        private static double s_factor = Joule.Factor / Ampere.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("Wb");

        private static readonly Weber s_one = new Weber(1d);
        private static readonly Weber s_zero = new Weber(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Weber One { get { return s_one; } }
        public static Weber Zero { get { return s_zero; } }
        #endregion
    }
}
