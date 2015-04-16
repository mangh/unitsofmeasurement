/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Steradian : IQuantity<double>, IEquatable<Steradian>, IComparable<Steradian>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Steradian(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Steradian(double q) { return new Steradian(q); }
        public static Steradian From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Steradian.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Steradian\"", q.GetType().Name));
            return new Steradian((Steradian.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Steradian>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Steradian) && Equals((Steradian)obj); }
        public bool /* IEquatable<Steradian> */ Equals(Steradian other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Steradian>
        public static bool operator ==(Steradian lhs, Steradian rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Steradian lhs, Steradian rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Steradian lhs, Steradian rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Steradian lhs, Steradian rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Steradian lhs, Steradian rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Steradian lhs, Steradian rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Steradian> */ CompareTo(Steradian other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Steradian operator +(Steradian lhs, Steradian rhs) { return new Steradian(lhs.Value + rhs.Value); }
        public static Steradian operator -(Steradian lhs, Steradian rhs) { return new Steradian(lhs.Value - rhs.Value); }
        public static Steradian operator ++(Steradian q) { return new Steradian(q.Value + 1d); }
        public static Steradian operator --(Steradian q) { return new Steradian(q.Value - 1d); }
        public static Steradian operator -(Steradian q) { return new Steradian(-q.Value); }
        public static Steradian operator *(double lhs, Steradian rhs) { return new Steradian(lhs * rhs.Value); }
        public static Steradian operator *(Steradian lhs, double rhs) { return new Steradian(lhs.Value * rhs); }
        public static Steradian operator /(Steradian lhs, double rhs) { return new Steradian(lhs.Value / rhs); }
        public static double operator /(Steradian lhs, Steradian rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Steradian.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Steradian.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Steradian.Format, Value, Steradian.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.None;
        private static readonly int s_family = 9;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("sr");

        private static readonly Steradian s_one = new Steradian(1d);
        private static readonly Steradian s_zero = new Steradian(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Steradian One { get { return s_one; } }
        public static Steradian Zero { get { return s_zero; } }
        #endregion
    }
}
