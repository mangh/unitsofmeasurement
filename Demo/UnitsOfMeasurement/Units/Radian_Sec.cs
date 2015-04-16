/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Radian_Sec : IQuantity<double>, IEquatable<Radian_Sec>, IComparable<Radian_Sec>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Radian_Sec(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Radian_Sec(double q) { return new Radian_Sec(q); }
        public static explicit operator Radian_Sec(RPM q) { return new Radian_Sec((Radian_Sec.Factor / RPM.Factor) * q.Value); }
        public static explicit operator Radian_Sec(Hertz q) { return new Radian_Sec((Radian_Sec.Factor / Hertz.Factor) * q.Value); }
        public static Radian_Sec From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Radian_Sec.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Radian_Sec\"", q.GetType().Name));
            return new Radian_Sec((Radian_Sec.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Radian_Sec>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Radian_Sec) && Equals((Radian_Sec)obj); }
        public bool /* IEquatable<Radian_Sec> */ Equals(Radian_Sec other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Radian_Sec>
        public static bool operator ==(Radian_Sec lhs, Radian_Sec rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Radian_Sec lhs, Radian_Sec rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Radian_Sec lhs, Radian_Sec rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Radian_Sec lhs, Radian_Sec rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Radian_Sec lhs, Radian_Sec rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Radian_Sec lhs, Radian_Sec rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Radian_Sec> */ CompareTo(Radian_Sec other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Radian_Sec operator +(Radian_Sec lhs, Radian_Sec rhs) { return new Radian_Sec(lhs.Value + rhs.Value); }
        public static Radian_Sec operator -(Radian_Sec lhs, Radian_Sec rhs) { return new Radian_Sec(lhs.Value - rhs.Value); }
        public static Radian_Sec operator ++(Radian_Sec q) { return new Radian_Sec(q.Value + 1d); }
        public static Radian_Sec operator --(Radian_Sec q) { return new Radian_Sec(q.Value - 1d); }
        public static Radian_Sec operator -(Radian_Sec q) { return new Radian_Sec(-q.Value); }
        public static Radian_Sec operator *(double lhs, Radian_Sec rhs) { return new Radian_Sec(lhs * rhs.Value); }
        public static Radian_Sec operator *(Radian_Sec lhs, double rhs) { return new Radian_Sec(lhs.Value * rhs); }
        public static Radian_Sec operator /(Radian_Sec lhs, double rhs) { return new Radian_Sec(lhs.Value / rhs); }
        public static double operator /(Radian_Sec lhs, Radian_Sec rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Radian operator *(Radian_Sec lhs, Second rhs) { return new Radian(lhs.Value * rhs.Value); }
        public static Radian operator *(Second lhs, Radian_Sec rhs) { return new Radian(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Radian_Sec.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Radian_Sec.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Radian_Sec.Format, Value, Radian_Sec.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Radian.Sense / Second.Sense;
        private static readonly int s_family = Hertz.Family;
        private static double s_factor = Radian.Factor / Second.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("rad/s");

        private static readonly Radian_Sec s_one = new Radian_Sec(1d);
        private static readonly Radian_Sec s_zero = new Radian_Sec(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Radian_Sec One { get { return s_one; } }
        public static Radian_Sec Zero { get { return s_zero; } }
        #endregion
    }
}
