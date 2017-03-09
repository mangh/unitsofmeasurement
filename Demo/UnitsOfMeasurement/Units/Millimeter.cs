/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Millimeter : IQuantity<double>, IEquatable<Millimeter>, IComparable<Millimeter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Millimeter.Proxy; } }
        #endregion

        #region Constructor(s)
        public Millimeter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Millimeter(double q) { return new Millimeter(q); }
        public static explicit operator Millimeter(Centimeter q) { return new Millimeter((Millimeter.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Millimeter(Meter q) { return new Millimeter((Millimeter.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Millimeter(Inch q) { return new Millimeter((Millimeter.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Millimeter(Foot q) { return new Millimeter((Millimeter.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Millimeter(Yard q) { return new Millimeter((Millimeter.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Millimeter(Mile q) { return new Millimeter((Millimeter.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Millimeter(Kilometer q) { return new Millimeter((Millimeter.Factor / Kilometer.Factor) * q.m_value); }
        public static Millimeter From(IQuantity<double> q)
        {
            if (q.Unit.Family != Millimeter.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Millimeter\"", q.GetType().Name));
            return new Millimeter((Millimeter.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Millimeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Millimeter) && Equals((Millimeter)obj); }
        public bool /* IEquatable<Millimeter> */ Equals(Millimeter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Millimeter>
        public static bool operator ==(Millimeter lhs, Millimeter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Millimeter lhs, Millimeter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Millimeter lhs, Millimeter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Millimeter lhs, Millimeter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Millimeter lhs, Millimeter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Millimeter lhs, Millimeter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Millimeter> */ CompareTo(Millimeter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Millimeter operator +(Millimeter lhs, Millimeter rhs) { return new Millimeter(lhs.m_value + rhs.m_value); }
        public static Millimeter operator -(Millimeter lhs, Millimeter rhs) { return new Millimeter(lhs.m_value - rhs.m_value); }
        public static Millimeter operator ++(Millimeter q) { return new Millimeter(q.m_value + 1d); }
        public static Millimeter operator --(Millimeter q) { return new Millimeter(q.m_value - 1d); }
        public static Millimeter operator -(Millimeter q) { return new Millimeter(-q.m_value); }
        public static Millimeter operator *(double lhs, Millimeter rhs) { return new Millimeter(lhs * rhs.m_value); }
        public static Millimeter operator *(Millimeter lhs, double rhs) { return new Millimeter(lhs.m_value * rhs); }
        public static Millimeter operator /(Millimeter lhs, double rhs) { return new Millimeter(lhs.m_value / rhs); }
        public static double operator /(Millimeter lhs, Millimeter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Millimeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Millimeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Millimeter.Format, m_value, Millimeter.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Meter.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = 1000d * Meter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mm");
        private static readonly Unit<double> s_proxy = new Millimeter_Proxy();

        private static readonly Millimeter s_one = new Millimeter(1d);
        private static readonly Millimeter s_zero = new Millimeter(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Millimeter One { get { return s_one; } }
        public static Millimeter Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Millimeter_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Millimeter.Family; } }
        public override Dimension Sense { get { return Millimeter.Sense; } }
        public override SymbolCollection Symbol { get { return Millimeter.Symbol; } }
        public override double Factor { get { return Millimeter.Factor; } set { Millimeter.Factor = value; } }
        public override string Format { get { return Millimeter.Format; } set { Millimeter.Format = value; } }
        #endregion

        #region Constructor(s)
        public Millimeter_Proxy() :
            base(typeof(Millimeter))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Millimeter(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Millimeter.From(quantity);
        }
        #endregion
    }
}
