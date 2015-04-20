/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Cycles : IQuantity<double>, IEquatable<Cycles>, IComparable<Cycles>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Cycles(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Cycles(double q) { return new Cycles(q); }
        public static explicit operator Cycles(Grad q) { return new Cycles((Cycles.Factor / Grad.Factor) * q.Value); }
        public static explicit operator Cycles(Degree q) { return new Cycles((Cycles.Factor / Degree.Factor) * q.Value); }
        public static explicit operator Cycles(Radian q) { return new Cycles((Cycles.Factor / Radian.Factor) * q.Value); }
        public static Cycles From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Cycles.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Cycles\"", q.GetType().Name));
            return new Cycles((Cycles.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Cycles>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Cycles) && Equals((Cycles)obj); }
        public bool /* IEquatable<Cycles> */ Equals(Cycles other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Cycles>
        public static bool operator ==(Cycles lhs, Cycles rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Cycles lhs, Cycles rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Cycles lhs, Cycles rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Cycles lhs, Cycles rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Cycles lhs, Cycles rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Cycles lhs, Cycles rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Cycles> */ CompareTo(Cycles other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Cycles operator +(Cycles lhs, Cycles rhs) { return new Cycles(lhs.Value + rhs.Value); }
        public static Cycles operator -(Cycles lhs, Cycles rhs) { return new Cycles(lhs.Value - rhs.Value); }
        public static Cycles operator ++(Cycles q) { return new Cycles(q.Value + 1d); }
        public static Cycles operator --(Cycles q) { return new Cycles(q.Value - 1d); }
        public static Cycles operator -(Cycles q) { return new Cycles(-q.Value); }
        public static Cycles operator *(double lhs, Cycles rhs) { return new Cycles(lhs * rhs.Value); }
        public static Cycles operator *(Cycles lhs, double rhs) { return new Cycles(lhs.Value * rhs); }
        public static Cycles operator /(Cycles lhs, double rhs) { return new Cycles(lhs.Value / rhs); }
        public static double operator /(Cycles lhs, Cycles rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Hertz operator /(Cycles lhs, Second rhs) { return new Hertz(lhs.Value / rhs.Value); }
        public static Second operator /(Cycles lhs, Hertz rhs) { return new Second(lhs.Value / rhs.Value); }
        public static RPM operator /(Cycles lhs, Minute rhs) { return new RPM(lhs.Value / rhs.Value); }
        public static Minute operator /(Cycles lhs, RPM rhs) { return new Minute(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Cycles.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Cycles.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Cycles.Format, Value, Cycles.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Radian.Sense;
        private static readonly int s_family = Radian.Family;
        private static double s_factor = Radian.Factor / (2d * Math.PI);
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("c");

        private static readonly Cycles s_one = new Cycles(1d);
        private static readonly Cycles s_zero = new Cycles(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Cycles One { get { return s_one; } }
        public static Cycles Zero { get { return s_zero; } }
        #endregion
    }
}
