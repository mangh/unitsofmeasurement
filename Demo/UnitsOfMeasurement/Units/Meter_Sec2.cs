/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Meter_Sec2 : IQuantity<double>, IEquatable<Meter_Sec2>, IComparable<Meter_Sec2>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Meter_Sec2(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Meter_Sec2(double q) { return new Meter_Sec2(q); }
        public static Meter_Sec2 From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Meter_Sec2.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Meter_Sec2\"", q.GetType().Name));
            return new Meter_Sec2((Meter_Sec2.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Meter_Sec2>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Meter_Sec2) && Equals((Meter_Sec2)obj); }
        public bool /* IEquatable<Meter_Sec2> */ Equals(Meter_Sec2 other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Meter_Sec2>
        public static bool operator ==(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Meter_Sec2> */ CompareTo(Meter_Sec2 other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter_Sec2 operator +(Meter_Sec2 lhs, Meter_Sec2 rhs) { return new Meter_Sec2(lhs.Value + rhs.Value); }
        public static Meter_Sec2 operator -(Meter_Sec2 lhs, Meter_Sec2 rhs) { return new Meter_Sec2(lhs.Value - rhs.Value); }
        public static Meter_Sec2 operator ++(Meter_Sec2 q) { return new Meter_Sec2(q.Value + 1d); }
        public static Meter_Sec2 operator --(Meter_Sec2 q) { return new Meter_Sec2(q.Value - 1d); }
        public static Meter_Sec2 operator -(Meter_Sec2 q) { return new Meter_Sec2(-q.Value); }
        public static Meter_Sec2 operator *(double lhs, Meter_Sec2 rhs) { return new Meter_Sec2(lhs * rhs.Value); }
        public static Meter_Sec2 operator *(Meter_Sec2 lhs, double rhs) { return new Meter_Sec2(lhs.Value * rhs); }
        public static Meter_Sec2 operator /(Meter_Sec2 lhs, double rhs) { return new Meter_Sec2(lhs.Value / rhs); }
        public static double operator /(Meter_Sec2 lhs, Meter_Sec2 rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Meter_Sec operator *(Meter_Sec2 lhs, Second rhs) { return new Meter_Sec(lhs.Value * rhs.Value); }
        public static Meter_Sec operator *(Second lhs, Meter_Sec2 rhs) { return new Meter_Sec(lhs.Value * rhs.Value); }
        public static Meter2_Sec2 operator *(Meter_Sec2 lhs, Meter rhs) { return new Meter2_Sec2(lhs.Value * rhs.Value); }
        public static Meter2_Sec2 operator *(Meter lhs, Meter_Sec2 rhs) { return new Meter2_Sec2(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter_Sec2.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter_Sec2.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Meter_Sec2.Format, Value, Meter_Sec2.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter_Sec.Sense / Second.Sense;
        private static readonly int s_family = 14;
        private static double s_factor = Meter_Sec.Factor / Second.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m/s2");

        private static readonly Meter_Sec2 s_one = new Meter_Sec2(1d);
        private static readonly Meter_Sec2 s_zero = new Meter_Sec2(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Meter_Sec2 One { get { return s_one; } }
        public static Meter_Sec2 Zero { get { return s_zero; } }
        #endregion
    }
}
