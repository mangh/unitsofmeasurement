/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Meter_Sec : IQuantity<double>, IEquatable<Meter_Sec>, IComparable<Meter_Sec>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Meter_Sec.Sense; } }
        public int UnitFamily { get { return Meter_Sec.Family; } }
        public double UnitFactor { get { return Meter_Sec.Factor; } }
        public string UnitFormat { get { return Meter_Sec.Format; } }
        public SymbolCollection UnitSymbol { get { return Meter_Sec.Symbol; } }

        #endregion

        #region Constructor(s)
        public Meter_Sec(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Meter_Sec(double q) { return new Meter_Sec(q); }
        public static explicit operator Meter_Sec(MPH q) { return new Meter_Sec((Meter_Sec.Factor / MPH.Factor) * q.Value); }
        public static explicit operator Meter_Sec(Kilometer_Hour q) { return new Meter_Sec((Meter_Sec.Factor / Kilometer_Hour.Factor) * q.Value); }
        public static Meter_Sec From(IQuantity<double> q)
        {
            if (q.UnitSense != Meter_Sec.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Meter_Sec\"", q.GetType().Name));
            return new Meter_Sec((Meter_Sec.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Meter_Sec>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Meter_Sec) && Equals((Meter_Sec)obj); }
        public bool /* IEquatable<Meter_Sec> */ Equals(Meter_Sec other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Meter_Sec>
        public static bool operator ==(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Meter_Sec> */ CompareTo(Meter_Sec other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter_Sec operator +(Meter_Sec lhs, Meter_Sec rhs) { return new Meter_Sec(lhs.Value + rhs.Value); }
        public static Meter_Sec operator -(Meter_Sec lhs, Meter_Sec rhs) { return new Meter_Sec(lhs.Value - rhs.Value); }
        public static Meter_Sec operator ++(Meter_Sec q) { return new Meter_Sec(q.Value + 1d); }
        public static Meter_Sec operator --(Meter_Sec q) { return new Meter_Sec(q.Value - 1d); }
        public static Meter_Sec operator -(Meter_Sec q) { return new Meter_Sec(-q.Value); }
        public static Meter_Sec operator *(double lhs, Meter_Sec rhs) { return new Meter_Sec(lhs * rhs.Value); }
        public static Meter_Sec operator *(Meter_Sec lhs, double rhs) { return new Meter_Sec(lhs.Value * rhs); }
        public static Meter_Sec operator /(Meter_Sec lhs, double rhs) { return new Meter_Sec(lhs.Value / rhs); }
        public static double operator /(Meter_Sec lhs, Meter_Sec rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Meter operator *(Meter_Sec lhs, Second rhs) { return new Meter(lhs.Value * rhs.Value); }
        public static Meter operator *(Second lhs, Meter_Sec rhs) { return new Meter(lhs.Value * rhs.Value); }
        public static Meter_Sec2 operator /(Meter_Sec lhs, Second rhs) { return new Meter_Sec2(lhs.Value / rhs.Value); }
        public static Second operator /(Meter_Sec lhs, Meter_Sec2 rhs) { return new Second(lhs.Value / rhs.Value); }
        public static Meter2_Sec2 operator *(Meter_Sec lhs, Meter_Sec rhs) { return new Meter2_Sec2(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter_Sec.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter_Sec.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Meter_Sec.Format, Value, Meter_Sec.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense / Second.Sense;
        private static readonly int s_family = 13;
        private static double s_factor = Meter.Factor / Second.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m/s");

        private static readonly Meter_Sec s_one = new Meter_Sec(1d);
        private static readonly Meter_Sec s_zero = new Meter_Sec(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Meter_Sec One { get { return s_one; } }
        public static Meter_Sec Zero { get { return s_zero; } }
        #endregion
    }
}
