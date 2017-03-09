/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Radian : IQuantity<double>, IEquatable<Radian>, IComparable<Radian>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Radian.Proxy; } }
        #endregion

        #region Constructor(s)
        public Radian(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Radian(double q) { return new Radian(q); }
        public static explicit operator Radian(Cycles q) { return new Radian((Radian.Factor / Cycles.Factor) * q.m_value); }
        public static explicit operator Radian(Grad q) { return new Radian((Radian.Factor / Grad.Factor) * q.m_value); }
        public static explicit operator Radian(Degree q) { return new Radian((Radian.Factor / Degree.Factor) * q.m_value); }
        public static Radian From(IQuantity<double> q)
        {
            if (q.Unit.Family != Radian.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Radian\"", q.GetType().Name));
            return new Radian((Radian.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Radian>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Radian) && Equals((Radian)obj); }
        public bool /* IEquatable<Radian> */ Equals(Radian other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Radian>
        public static bool operator ==(Radian lhs, Radian rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Radian lhs, Radian rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Radian lhs, Radian rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Radian lhs, Radian rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Radian lhs, Radian rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Radian lhs, Radian rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Radian> */ CompareTo(Radian other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Radian operator +(Radian lhs, Radian rhs) { return new Radian(lhs.m_value + rhs.m_value); }
        public static Radian operator -(Radian lhs, Radian rhs) { return new Radian(lhs.m_value - rhs.m_value); }
        public static Radian operator ++(Radian q) { return new Radian(q.m_value + 1d); }
        public static Radian operator --(Radian q) { return new Radian(q.m_value - 1d); }
        public static Radian operator -(Radian q) { return new Radian(-q.m_value); }
        public static Radian operator *(double lhs, Radian rhs) { return new Radian(lhs * rhs.m_value); }
        public static Radian operator *(Radian lhs, double rhs) { return new Radian(lhs.m_value * rhs); }
        public static Radian operator /(Radian lhs, double rhs) { return new Radian(lhs.m_value / rhs); }
        public static double operator /(Radian lhs, Radian rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Radian_Sec operator /(Radian lhs, Second rhs) { return new Radian_Sec(lhs.m_value / rhs.m_value); }
        public static Second operator /(Radian lhs, Radian_Sec rhs) { return new Second(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Radian.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Radian.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Radian.Format, m_value, Radian.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Dimension.None;
        private static readonly int s_family = 8;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("rad");
        private static readonly Unit<double> s_proxy = new Radian_Proxy();

        private static readonly Radian s_one = new Radian(1d);
        private static readonly Radian s_zero = new Radian(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Radian One { get { return s_one; } }
        public static Radian Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Radian_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Radian.Family; } }
        public override Dimension Sense { get { return Radian.Sense; } }
        public override SymbolCollection Symbol { get { return Radian.Symbol; } }
        public override double Factor { get { return Radian.Factor; } set { Radian.Factor = value; } }
        public override string Format { get { return Radian.Format; } set { Radian.Format = value; } }
        #endregion

        #region Constructor(s)
        public Radian_Proxy() :
            base(typeof(Radian))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Radian(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Radian.From(quantity);
        }
        #endregion
    }
}
