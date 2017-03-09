/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Inch : IQuantity<double>, IEquatable<Inch>, IComparable<Inch>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Inch.Proxy; } }
        #endregion

        #region Constructor(s)
        public Inch(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Inch(double q) { return new Inch(q); }
        public static explicit operator Inch(Foot q) { return new Inch((Inch.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Inch(Yard q) { return new Inch((Inch.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Inch(Mile q) { return new Inch((Inch.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Inch(Kilometer q) { return new Inch((Inch.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Inch(Millimeter q) { return new Inch((Inch.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Inch(Centimeter q) { return new Inch((Inch.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Inch(Meter q) { return new Inch((Inch.Factor / Meter.Factor) * q.m_value); }
        public static Inch From(IQuantity<double> q)
        {
            if (q.Unit.Family != Inch.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Inch\"", q.GetType().Name));
            return new Inch((Inch.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Inch>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Inch) && Equals((Inch)obj); }
        public bool /* IEquatable<Inch> */ Equals(Inch other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Inch>
        public static bool operator ==(Inch lhs, Inch rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Inch lhs, Inch rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Inch lhs, Inch rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Inch lhs, Inch rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Inch lhs, Inch rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Inch lhs, Inch rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Inch> */ CompareTo(Inch other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Inch operator +(Inch lhs, Inch rhs) { return new Inch(lhs.m_value + rhs.m_value); }
        public static Inch operator -(Inch lhs, Inch rhs) { return new Inch(lhs.m_value - rhs.m_value); }
        public static Inch operator ++(Inch q) { return new Inch(q.m_value + 1d); }
        public static Inch operator --(Inch q) { return new Inch(q.m_value - 1d); }
        public static Inch operator -(Inch q) { return new Inch(-q.m_value); }
        public static Inch operator *(double lhs, Inch rhs) { return new Inch(lhs * rhs.m_value); }
        public static Inch operator *(Inch lhs, double rhs) { return new Inch(lhs.m_value * rhs); }
        public static Inch operator /(Inch lhs, double rhs) { return new Inch(lhs.m_value / rhs); }
        public static double operator /(Inch lhs, Inch rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Inch.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Inch.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Inch.Format, m_value, Inch.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Meter.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = 100d * Meter.Factor / 2.54d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("in");
        private static readonly Unit<double> s_proxy = new Inch_Proxy();

        private static readonly Inch s_one = new Inch(1d);
        private static readonly Inch s_zero = new Inch(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Inch One { get { return s_one; } }
        public static Inch Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Inch_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Inch.Family; } }
        public override Dimension Sense { get { return Inch.Sense; } }
        public override SymbolCollection Symbol { get { return Inch.Symbol; } }
        public override double Factor { get { return Inch.Factor; } set { Inch.Factor = value; } }
        public override string Format { get { return Inch.Format; } set { Inch.Format = value; } }
        #endregion

        #region Constructor(s)
        public Inch_Proxy() :
            base(typeof(Inch))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Inch(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Inch.From(quantity);
        }
        #endregion
    }
}
