/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Radian : IQuantity<double>, IEquatable<Radian>, IComparable<Radian>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Radian.Sense; } }
        public int UnitFamily { get { return Radian.Family; } }
        public double UnitFactor { get { return Radian.Factor; } }
        public string UnitFormat { get { return Radian.Format; } }
        public SymbolCollection UnitSymbol { get { return Radian.Symbol; } }

        #endregion

        #region Constructor(s)
        public Radian(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Radian(double q) { return new Radian(q); }
        public static explicit operator Radian(Cycles q) { return new Radian((Radian.Factor / Cycles.Factor) * q.Value); }
        public static explicit operator Radian(Grad q) { return new Radian((Radian.Factor / Grad.Factor) * q.Value); }
        public static explicit operator Radian(Degree q) { return new Radian((Radian.Factor / Degree.Factor) * q.Value); }
        public static Radian From(IQuantity<double> q)
        {
            if (q.UnitSense != Radian.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Radian\"", q.GetType().Name));
            return new Radian((Radian.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Radian>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Radian) && Equals((Radian)obj); }
        public bool /* IEquatable<Radian> */ Equals(Radian other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Radian>
        public static bool operator ==(Radian lhs, Radian rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Radian lhs, Radian rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Radian lhs, Radian rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Radian lhs, Radian rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Radian lhs, Radian rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Radian lhs, Radian rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Radian> */ CompareTo(Radian other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Radian operator +(Radian lhs, Radian rhs) { return new Radian(lhs.Value + rhs.Value); }
        public static Radian operator -(Radian lhs, Radian rhs) { return new Radian(lhs.Value - rhs.Value); }
        public static Radian operator ++(Radian q) { return new Radian(q.Value + 1d); }
        public static Radian operator --(Radian q) { return new Radian(q.Value - 1d); }
        public static Radian operator -(Radian q) { return new Radian(-q.Value); }
        public static Radian operator *(double lhs, Radian rhs) { return new Radian(lhs * rhs.Value); }
        public static Radian operator *(Radian lhs, double rhs) { return new Radian(lhs.Value * rhs); }
        public static Radian operator /(Radian lhs, double rhs) { return new Radian(lhs.Value / rhs); }
        public static double operator /(Radian lhs, Radian rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Radian_Sec operator /(Radian lhs, Second rhs) { return new Radian_Sec(lhs.Value / rhs.Value); }
        public static Second operator /(Radian lhs, Radian_Sec rhs) { return new Second(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Radian.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Radian.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Radian.Format, Value, Radian.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.None;
        private static readonly int s_family = 8;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("rad");

        private static readonly Radian s_one = new Radian(1d);
        private static readonly Radian s_zero = new Radian(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Radian One { get { return s_one; } }
        public static Radian Zero { get { return s_zero; } }
        #endregion
    }
}
