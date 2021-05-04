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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Grad.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Grad\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Grad.Format, q, Grad.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Radian.Sense;
        public const int Family = Radian.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("grad");
        public static readonly Unit<double> Proxy = new Grad_Proxy();
        public const double Factor = (200d / System.Math.PI) * Radian.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Grad One = new Grad(1d);
        public static readonly Grad Zero = new Grad(0d);
        #endregion
    }

    public partial class Grad_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Grad.Sense; } }
        public override int Family { get { return Grad.Family; } }
        public override double Factor { get { return Grad.Factor; } }
        public override SymbolCollection Symbol { get { return Grad.Symbol; } }
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
