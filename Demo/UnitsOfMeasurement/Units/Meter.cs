/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Meter : IQuantity<double>, IEquatable<Meter>, IComparable<Meter>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Meter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Meter(double q) { return new Meter(q); }
        public static explicit operator Meter(Inch q) { return new Meter((Meter.Factor / Inch.Factor) * q.Value); }
        public static explicit operator Meter(Foot q) { return new Meter((Meter.Factor / Foot.Factor) * q.Value); }
        public static explicit operator Meter(Yard q) { return new Meter((Meter.Factor / Yard.Factor) * q.Value); }
        public static explicit operator Meter(Mile q) { return new Meter((Meter.Factor / Mile.Factor) * q.Value); }
        public static explicit operator Meter(Kilometer q) { return new Meter((Meter.Factor / Kilometer.Factor) * q.Value); }
        public static explicit operator Meter(Millimeter q) { return new Meter((Meter.Factor / Millimeter.Factor) * q.Value); }
        public static explicit operator Meter(Centimeter q) { return new Meter((Meter.Factor / Centimeter.Factor) * q.Value); }
        public static Meter From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Meter.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Meter\"", q.GetType().Name));
            return new Meter((Meter.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Meter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Meter) && Equals((Meter)obj); }
        public bool /* IEquatable<Meter> */ Equals(Meter other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Meter>
        public static bool operator ==(Meter lhs, Meter rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Meter lhs, Meter rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Meter lhs, Meter rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Meter lhs, Meter rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Meter lhs, Meter rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Meter lhs, Meter rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Meter> */ CompareTo(Meter other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter operator +(Meter lhs, Meter rhs) { return new Meter(lhs.Value + rhs.Value); }
        public static Meter operator -(Meter lhs, Meter rhs) { return new Meter(lhs.Value - rhs.Value); }
        public static Meter operator ++(Meter q) { return new Meter(q.Value + 1d); }
        public static Meter operator --(Meter q) { return new Meter(q.Value - 1d); }
        public static Meter operator -(Meter q) { return new Meter(-q.Value); }
        public static Meter operator *(double lhs, Meter rhs) { return new Meter(lhs * rhs.Value); }
        public static Meter operator *(Meter lhs, double rhs) { return new Meter(lhs.Value * rhs); }
        public static Meter operator /(Meter lhs, double rhs) { return new Meter(lhs.Value / rhs); }
        public static double operator /(Meter lhs, Meter rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static SquareMeter operator *(Meter lhs, Meter rhs) { return new SquareMeter(lhs.Value * rhs.Value); }
        public static Meter_Sec operator /(Meter lhs, Second rhs) { return new Meter_Sec(lhs.Value / rhs.Value); }
        public static Second operator /(Meter lhs, Meter_Sec rhs) { return new Second(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Meter.Format, Value, Meter.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Length;
        private static readonly int s_family = 0;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m");

        private static readonly Meter s_one = new Meter(1d);
        private static readonly Meter s_zero = new Meter(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Meter One { get { return s_one; } }
        public static Meter Zero { get { return s_zero; } }
        #endregion
    }
}
