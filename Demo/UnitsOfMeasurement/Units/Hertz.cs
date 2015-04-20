/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Hertz : IQuantity<double>, IEquatable<Hertz>, IComparable<Hertz>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Hertz(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Hertz(double q) { return new Hertz(q); }
        public static explicit operator Hertz(Radian_Sec q) { return new Hertz((Hertz.Factor / Radian_Sec.Factor) * q.Value); }
        public static explicit operator Hertz(RPM q) { return new Hertz((Hertz.Factor / RPM.Factor) * q.Value); }
        public static Hertz From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Hertz.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Hertz\"", q.GetType().Name));
            return new Hertz((Hertz.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Hertz>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Hertz) && Equals((Hertz)obj); }
        public bool /* IEquatable<Hertz> */ Equals(Hertz other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Hertz>
        public static bool operator ==(Hertz lhs, Hertz rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Hertz lhs, Hertz rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Hertz lhs, Hertz rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Hertz lhs, Hertz rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Hertz lhs, Hertz rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Hertz lhs, Hertz rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Hertz> */ CompareTo(Hertz other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Hertz operator +(Hertz lhs, Hertz rhs) { return new Hertz(lhs.Value + rhs.Value); }
        public static Hertz operator -(Hertz lhs, Hertz rhs) { return new Hertz(lhs.Value - rhs.Value); }
        public static Hertz operator ++(Hertz q) { return new Hertz(q.Value + 1d); }
        public static Hertz operator --(Hertz q) { return new Hertz(q.Value - 1d); }
        public static Hertz operator -(Hertz q) { return new Hertz(-q.Value); }
        public static Hertz operator *(double lhs, Hertz rhs) { return new Hertz(lhs * rhs.Value); }
        public static Hertz operator *(Hertz lhs, double rhs) { return new Hertz(lhs.Value * rhs); }
        public static Hertz operator /(Hertz lhs, double rhs) { return new Hertz(lhs.Value / rhs); }
        public static double operator /(Hertz lhs, Hertz rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Cycles operator *(Hertz lhs, Second rhs) { return new Cycles(lhs.Value * rhs.Value); }
        public static Cycles operator *(Second lhs, Hertz rhs) { return new Cycles(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Hertz.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Hertz.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Hertz.Format, Value, Hertz.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Cycles.Sense / Second.Sense;
        private static readonly int s_family = 10;
        private static double s_factor = Cycles.Factor / Second.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("Hz");

        private static readonly Hertz s_one = new Hertz(1d);
        private static readonly Hertz s_zero = new Hertz(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Hertz One { get { return s_one; } }
        public static Hertz Zero { get { return s_zero; } }
        #endregion
    }
}
