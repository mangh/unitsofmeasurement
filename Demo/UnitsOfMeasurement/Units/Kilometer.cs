/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Kilometer : IQuantity<double>, IEquatable<Kilometer>, IComparable<Kilometer>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Kilometer.Sense; } }
        public int UnitFamily { get { return Kilometer.Family; } }
        public double UnitFactor { get { return Kilometer.Factor; } }
        public string UnitFormat { get { return Kilometer.Format; } }
        public SymbolCollection UnitSymbol { get { return Kilometer.Symbol; } }

        #endregion

        #region Constructor(s)
        public Kilometer(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Kilometer(double q) { return new Kilometer(q); }
        public static explicit operator Kilometer(Millimeter q) { return new Kilometer((Kilometer.Factor / Millimeter.Factor) * q.Value); }
        public static explicit operator Kilometer(Centimeter q) { return new Kilometer((Kilometer.Factor / Centimeter.Factor) * q.Value); }
        public static explicit operator Kilometer(Meter q) { return new Kilometer((Kilometer.Factor / Meter.Factor) * q.Value); }
        public static explicit operator Kilometer(Inch q) { return new Kilometer((Kilometer.Factor / Inch.Factor) * q.Value); }
        public static explicit operator Kilometer(Foot q) { return new Kilometer((Kilometer.Factor / Foot.Factor) * q.Value); }
        public static explicit operator Kilometer(Yard q) { return new Kilometer((Kilometer.Factor / Yard.Factor) * q.Value); }
        public static explicit operator Kilometer(Mile q) { return new Kilometer((Kilometer.Factor / Mile.Factor) * q.Value); }
        public static Kilometer From(IQuantity<double> q)
        {
            if (q.UnitSense != Kilometer.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Kilometer\"", q.GetType().Name));
            return new Kilometer((Kilometer.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Kilometer>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Kilometer) && Equals((Kilometer)obj); }
        public bool /* IEquatable<Kilometer> */ Equals(Kilometer other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Kilometer>
        public static bool operator ==(Kilometer lhs, Kilometer rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Kilometer lhs, Kilometer rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Kilometer lhs, Kilometer rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Kilometer lhs, Kilometer rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Kilometer lhs, Kilometer rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Kilometer lhs, Kilometer rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Kilometer> */ CompareTo(Kilometer other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Kilometer operator +(Kilometer lhs, Kilometer rhs) { return new Kilometer(lhs.Value + rhs.Value); }
        public static Kilometer operator -(Kilometer lhs, Kilometer rhs) { return new Kilometer(lhs.Value - rhs.Value); }
        public static Kilometer operator ++(Kilometer q) { return new Kilometer(q.Value + 1d); }
        public static Kilometer operator --(Kilometer q) { return new Kilometer(q.Value - 1d); }
        public static Kilometer operator -(Kilometer q) { return new Kilometer(-q.Value); }
        public static Kilometer operator *(double lhs, Kilometer rhs) { return new Kilometer(lhs * rhs.Value); }
        public static Kilometer operator *(Kilometer lhs, double rhs) { return new Kilometer(lhs.Value * rhs); }
        public static Kilometer operator /(Kilometer lhs, double rhs) { return new Kilometer(lhs.Value / rhs); }
        public static double operator /(Kilometer lhs, Kilometer rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Kilometer_Hour operator /(Kilometer lhs, Hour rhs) { return new Kilometer_Hour(lhs.Value / rhs.Value); }
        public static Hour operator /(Kilometer lhs, Kilometer_Hour rhs) { return new Hour(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Kilometer.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Kilometer.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Kilometer.Format, Value, Kilometer.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Meter.Sense;
        private static readonly int s_family = Meter.Family;
        private static double s_factor = Meter.Factor / 1000d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("km");

        private static readonly Kilometer s_one = new Kilometer(1d);
        private static readonly Kilometer s_zero = new Kilometer(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Kilometer One { get { return s_one; } }
        public static Kilometer Zero { get { return s_zero; } }
        #endregion
    }
}
