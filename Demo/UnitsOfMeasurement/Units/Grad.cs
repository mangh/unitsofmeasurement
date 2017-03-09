/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Grad : IQuantity<double>, IEquatable<Grad>, IComparable<Grad>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Grad.Proxy; } }
        #endregion

        #region Constructor(s)
        public Grad(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Grad(double q) { return new Grad(q); }
        public static explicit operator Grad(Degree q) { return new Grad((Grad.Factor / Degree.Factor) * q.m_value); }
        public static explicit operator Grad(Radian q) { return new Grad((Grad.Factor / Radian.Factor) * q.m_value); }
        public static explicit operator Grad(Cycles q) { return new Grad((Grad.Factor / Cycles.Factor) * q.m_value); }
        public static Grad From(IQuantity<double> q)
        {
            if (q.Unit.Family != Grad.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Grad\"", q.GetType().Name));
            return new Grad((Grad.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Grad>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Grad) && Equals((Grad)obj); }
        public bool /* IEquatable<Grad> */ Equals(Grad other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Grad>
        public static bool operator ==(Grad lhs, Grad rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Grad lhs, Grad rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Grad lhs, Grad rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Grad lhs, Grad rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Grad lhs, Grad rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Grad lhs, Grad rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Grad> */ CompareTo(Grad other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Grad operator +(Grad lhs, Grad rhs) { return new Grad(lhs.m_value + rhs.m_value); }
        public static Grad operator -(Grad lhs, Grad rhs) { return new Grad(lhs.m_value - rhs.m_value); }
        public static Grad operator ++(Grad q) { return new Grad(q.m_value + 1d); }
        public static Grad operator --(Grad q) { return new Grad(q.m_value - 1d); }
        public static Grad operator -(Grad q) { return new Grad(-q.m_value); }
        public static Grad operator *(double lhs, Grad rhs) { return new Grad(lhs * rhs.m_value); }
        public static Grad operator *(Grad lhs, double rhs) { return new Grad(lhs.m_value * rhs); }
        public static Grad operator /(Grad lhs, double rhs) { return new Grad(lhs.m_value / rhs); }
        public static double operator /(Grad lhs, Grad rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Grad.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Grad.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Grad.Format, m_value, Grad.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Radian.Sense;
        private static readonly int s_family = Radian.Family;
        private static /*mutable*/ double s_factor = (200d / Math.PI) * Radian.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("grad");
        private static readonly Unit<double> s_proxy = new Grad_Proxy();

        private static readonly Grad s_one = new Grad(1d);
        private static readonly Grad s_zero = new Grad(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Grad One { get { return s_one; } }
        public static Grad Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Grad_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Grad.Family; } }
        public override Dimension Sense { get { return Grad.Sense; } }
        public override SymbolCollection Symbol { get { return Grad.Symbol; } }
        public override double Factor { get { return Grad.Factor; } set { Grad.Factor = value; } }
        public override string Format { get { return Grad.Format; } set { Grad.Format = value; } }
        #endregion

        #region Constructor(s)
        public Grad_Proxy() :
            base(typeof(Grad))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Grad(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Grad.From(quantity);
        }
        #endregion
    }
}
