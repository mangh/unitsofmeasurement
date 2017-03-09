/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Cycles : IQuantity<double>, IEquatable<Cycles>, IComparable<Cycles>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Cycles.Proxy; } }
        #endregion

        #region Constructor(s)
        public Cycles(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Cycles(double q) { return new Cycles(q); }
        public static explicit operator Cycles(Grad q) { return new Cycles((Cycles.Factor / Grad.Factor) * q.m_value); }
        public static explicit operator Cycles(Degree q) { return new Cycles((Cycles.Factor / Degree.Factor) * q.m_value); }
        public static explicit operator Cycles(Radian q) { return new Cycles((Cycles.Factor / Radian.Factor) * q.m_value); }
        public static Cycles From(IQuantity<double> q)
        {
            if (q.Unit.Family != Cycles.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Cycles\"", q.GetType().Name));
            return new Cycles((Cycles.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Cycles>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Cycles) && Equals((Cycles)obj); }
        public bool /* IEquatable<Cycles> */ Equals(Cycles other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Cycles>
        public static bool operator ==(Cycles lhs, Cycles rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Cycles lhs, Cycles rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Cycles lhs, Cycles rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Cycles lhs, Cycles rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Cycles lhs, Cycles rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Cycles lhs, Cycles rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Cycles> */ CompareTo(Cycles other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Cycles operator +(Cycles lhs, Cycles rhs) { return new Cycles(lhs.m_value + rhs.m_value); }
        public static Cycles operator -(Cycles lhs, Cycles rhs) { return new Cycles(lhs.m_value - rhs.m_value); }
        public static Cycles operator ++(Cycles q) { return new Cycles(q.m_value + 1d); }
        public static Cycles operator --(Cycles q) { return new Cycles(q.m_value - 1d); }
        public static Cycles operator -(Cycles q) { return new Cycles(-q.m_value); }
        public static Cycles operator *(double lhs, Cycles rhs) { return new Cycles(lhs * rhs.m_value); }
        public static Cycles operator *(Cycles lhs, double rhs) { return new Cycles(lhs.m_value * rhs); }
        public static Cycles operator /(Cycles lhs, double rhs) { return new Cycles(lhs.m_value / rhs); }
        public static double operator /(Cycles lhs, Cycles rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Hertz operator /(Cycles lhs, Second rhs) { return new Hertz(lhs.m_value / rhs.m_value); }
        public static Second operator /(Cycles lhs, Hertz rhs) { return new Second(lhs.m_value / rhs.m_value); }
        public static RPM operator /(Cycles lhs, Minute rhs) { return new RPM(lhs.m_value / rhs.m_value); }
        public static Minute operator /(Cycles lhs, RPM rhs) { return new Minute(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Cycles.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Cycles.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Cycles.Format, m_value, Cycles.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Radian.Sense;
        private static readonly int s_family = Radian.Family;
        private static /*mutable*/ double s_factor = Radian.Factor / (2d * Math.PI);
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("c");
        private static readonly Unit<double> s_proxy = new Cycles_Proxy();

        private static readonly Cycles s_one = new Cycles(1d);
        private static readonly Cycles s_zero = new Cycles(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Cycles One { get { return s_one; } }
        public static Cycles Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Cycles_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Cycles.Family; } }
        public override Dimension Sense { get { return Cycles.Sense; } }
        public override SymbolCollection Symbol { get { return Cycles.Symbol; } }
        public override double Factor { get { return Cycles.Factor; } set { Cycles.Factor = value; } }
        public override string Format { get { return Cycles.Format; } set { Cycles.Format = value; } }
        #endregion

        #region Constructor(s)
        public Cycles_Proxy() :
            base(typeof(Cycles))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Cycles(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Cycles.From(quantity);
        }
        #endregion
    }
}
