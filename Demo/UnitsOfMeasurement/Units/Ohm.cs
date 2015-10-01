/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Ohm : IQuantity<double>, IEquatable<Ohm>, IComparable<Ohm>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Ohm(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Ohm(double q) { return new Ohm(q); }
        public static Ohm From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Ohm.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Ohm\"", q.GetType().Name));
            return new Ohm((Ohm.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Ohm>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Ohm) && Equals((Ohm)obj); }
        public bool /* IEquatable<Ohm> */ Equals(Ohm other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Ohm>
        public static bool operator ==(Ohm lhs, Ohm rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Ohm lhs, Ohm rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Ohm lhs, Ohm rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Ohm lhs, Ohm rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Ohm lhs, Ohm rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Ohm lhs, Ohm rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Ohm> */ CompareTo(Ohm other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Ohm operator +(Ohm lhs, Ohm rhs) { return new Ohm(lhs.Value + rhs.Value); }
        public static Ohm operator -(Ohm lhs, Ohm rhs) { return new Ohm(lhs.Value - rhs.Value); }
        public static Ohm operator ++(Ohm q) { return new Ohm(q.Value + 1d); }
        public static Ohm operator --(Ohm q) { return new Ohm(q.Value - 1d); }
        public static Ohm operator -(Ohm q) { return new Ohm(-q.Value); }
        public static Ohm operator *(double lhs, Ohm rhs) { return new Ohm(lhs * rhs.Value); }
        public static Ohm operator *(Ohm lhs, double rhs) { return new Ohm(lhs.Value * rhs); }
        public static Ohm operator /(Ohm lhs, double rhs) { return new Ohm(lhs.Value / rhs); }
        public static double operator /(Ohm lhs, Ohm rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Volt operator *(Ohm lhs, Ampere rhs) { return new Volt(lhs.Value * rhs.Value); }
        public static Volt operator *(Ampere lhs, Ohm rhs) { return new Volt(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Ohm.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Ohm.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Ohm.Format, Value, Ohm.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Volt.Sense / Ampere.Sense;
        private static readonly int s_family = 24;
        private static double s_factor = Volt.Factor / Ampere.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("\u03A9", "ohm");

        private static readonly Ohm s_one = new Ohm(1d);
        private static readonly Ohm s_zero = new Ohm(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Ohm One { get { return s_one; } }
        public static Ohm Zero { get { return s_zero; } }
        #endregion
    }
}
