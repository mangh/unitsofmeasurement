/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Yard : IQuantity<double>, IEquatable<Yard>, IComparable<Yard>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Yard.Proxy; } }
        #endregion

        #region Constructor(s)
        public Yard(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Yard(double q) { return new Yard(q); }
        public static explicit operator Yard(Mile q) { return new Yard((Yard.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Yard(Kilometer q) { return new Yard((Yard.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Yard(Millimeter q) { return new Yard((Yard.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Yard(Centimeter q) { return new Yard((Yard.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Yard(Meter q) { return new Yard((Yard.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Yard(Inch q) { return new Yard((Yard.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Yard(Foot q) { return new Yard((Yard.Factor / Foot.Factor) * q.m_value); }
        public static Yard From(IQuantity<double> q)
        {
            if (q.Unit.Family != Yard.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Yard\"", q.GetType().Name));
            return new Yard((Yard.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Yard>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Yard) && Equals((Yard)obj); }
        public bool /* IEquatable<Yard> */ Equals(Yard other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Yard>
        public static bool operator ==(Yard lhs, Yard rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Yard lhs, Yard rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Yard lhs, Yard rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Yard lhs, Yard rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Yard lhs, Yard rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Yard lhs, Yard rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Yard> */ CompareTo(Yard other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Yard operator +(Yard lhs, Yard rhs) { return new Yard(lhs.m_value + rhs.m_value); }
        public static Yard operator -(Yard lhs, Yard rhs) { return new Yard(lhs.m_value - rhs.m_value); }
        public static Yard operator ++(Yard q) { return new Yard(q.m_value + 1d); }
        public static Yard operator --(Yard q) { return new Yard(q.m_value - 1d); }
        public static Yard operator -(Yard q) { return new Yard(-q.m_value); }
        public static Yard operator *(double lhs, Yard rhs) { return new Yard(lhs * rhs.m_value); }
        public static Yard operator *(Yard lhs, double rhs) { return new Yard(lhs.m_value * rhs); }
        public static Yard operator /(Yard lhs, double rhs) { return new Yard(lhs.m_value / rhs); }
        public static double operator /(Yard lhs, Yard rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Yard.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Yard.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Yard.Format, m_value, Yard.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Foot.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = Foot.Factor / 3d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("yd");
        private static readonly Unit<double> s_proxy = new Yard_Proxy();

        private static readonly Yard s_one = new Yard(1d);
        private static readonly Yard s_zero = new Yard(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Yard One { get { return s_one; } }
        public static Yard Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Yard_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Yard.Family; } }
        public override Dimension Sense { get { return Yard.Sense; } }
        public override SymbolCollection Symbol { get { return Yard.Symbol; } }
        public override double Factor { get { return Yard.Factor; } set { Yard.Factor = value; } }
        public override string Format { get { return Yard.Format; } set { Yard.Format = value; } }
        #endregion

        #region Constructor(s)
        public Yard_Proxy() :
            base(typeof(Yard))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Yard(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Yard.From(quantity);
        }
        #endregion
    }
}
