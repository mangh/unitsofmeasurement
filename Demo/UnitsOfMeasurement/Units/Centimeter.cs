/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Centimeter : IQuantity<double>, IEquatable<Centimeter>, IComparable<Centimeter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Centimeter.Proxy; } }
        #endregion

        #region Constructor(s)
        public Centimeter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Centimeter(double q) { return new Centimeter(q); }
        public static explicit operator Centimeter(Meter q) { return new Centimeter((Centimeter.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Centimeter(Inch q) { return new Centimeter((Centimeter.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Centimeter(Foot q) { return new Centimeter((Centimeter.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Centimeter(Yard q) { return new Centimeter((Centimeter.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Centimeter(Mile q) { return new Centimeter((Centimeter.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Centimeter(Kilometer q) { return new Centimeter((Centimeter.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Centimeter(Millimeter q) { return new Centimeter((Centimeter.Factor / Millimeter.Factor) * q.m_value); }
        public static Centimeter From(IQuantity<double> q)
        {
            if (q.Unit.Family != Centimeter.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Centimeter\"", q.GetType().Name));
            return new Centimeter((Centimeter.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Centimeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Centimeter) && Equals((Centimeter)obj); }
        public bool /* IEquatable<Centimeter> */ Equals(Centimeter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Centimeter>
        public static bool operator ==(Centimeter lhs, Centimeter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Centimeter lhs, Centimeter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Centimeter lhs, Centimeter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Centimeter lhs, Centimeter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Centimeter lhs, Centimeter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Centimeter lhs, Centimeter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Centimeter> */ CompareTo(Centimeter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Centimeter operator +(Centimeter lhs, Centimeter rhs) { return new Centimeter(lhs.m_value + rhs.m_value); }
        public static Centimeter operator -(Centimeter lhs, Centimeter rhs) { return new Centimeter(lhs.m_value - rhs.m_value); }
        public static Centimeter operator ++(Centimeter q) { return new Centimeter(q.m_value + 1d); }
        public static Centimeter operator --(Centimeter q) { return new Centimeter(q.m_value - 1d); }
        public static Centimeter operator -(Centimeter q) { return new Centimeter(-q.m_value); }
        public static Centimeter operator *(double lhs, Centimeter rhs) { return new Centimeter(lhs * rhs.m_value); }
        public static Centimeter operator *(Centimeter lhs, double rhs) { return new Centimeter(lhs.m_value * rhs); }
        public static Centimeter operator /(Centimeter lhs, double rhs) { return new Centimeter(lhs.m_value / rhs); }
        public static double operator /(Centimeter lhs, Centimeter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Centimeter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Centimeter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Centimeter.Format, m_value, Centimeter.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Meter.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = 100d * Meter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("cm");
        private static readonly Unit<double> s_proxy = new Centimeter_Proxy();

        private static readonly Centimeter s_one = new Centimeter(1d);
        private static readonly Centimeter s_zero = new Centimeter(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Centimeter One { get { return s_one; } }
        public static Centimeter Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Centimeter_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Centimeter.Family; } }
        public override Dimension Sense { get { return Centimeter.Sense; } }
        public override SymbolCollection Symbol { get { return Centimeter.Symbol; } }
        public override double Factor { get { return Centimeter.Factor; } set { Centimeter.Factor = value; } }
        public override string Format { get { return Centimeter.Format; } set { Centimeter.Format = value; } }
        #endregion

        #region Constructor(s)
        public Centimeter_Proxy() :
            base(typeof(Centimeter))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Centimeter(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Centimeter.From(quantity);
        }
        #endregion
    }
}
