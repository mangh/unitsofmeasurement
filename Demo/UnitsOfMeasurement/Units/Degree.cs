/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Degree : IQuantity<double>, IEquatable<Degree>, IComparable<Degree>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Degree.Proxy; } }
        #endregion

        #region Constructor(s)
        public Degree(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Degree(double q) { return new Degree(q); }
        public static explicit operator Degree(Radian q) { return new Degree((Degree.Factor / Radian.Factor) * q.m_value); }
        public static explicit operator Degree(Cycles q) { return new Degree((Degree.Factor / Cycles.Factor) * q.m_value); }
        public static explicit operator Degree(Grad q) { return new Degree((Degree.Factor / Grad.Factor) * q.m_value); }
        public static Degree From(IQuantity<double> q)
        {
            if (q.Unit.Family != Degree.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Degree\"", q.GetType().Name));
            }
            return new Degree((Degree.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Degree>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Degree) && Equals((Degree)obj); }
        public bool /* IEquatable<Degree> */ Equals(Degree other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Degree>
        public static bool operator ==(Degree lhs, Degree rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Degree lhs, Degree rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Degree lhs, Degree rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Degree lhs, Degree rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Degree lhs, Degree rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Degree lhs, Degree rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Degree> */ CompareTo(Degree other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Degree operator +(Degree lhs, Degree rhs) { return new Degree(lhs.m_value + rhs.m_value); }
        public static Degree operator -(Degree lhs, Degree rhs) { return new Degree(lhs.m_value - rhs.m_value); }
        public static Degree operator ++(Degree q) { return new Degree(q.m_value + 1d); }
        public static Degree operator --(Degree q) { return new Degree(q.m_value - 1d); }
        public static Degree operator -(Degree q) { return new Degree(-q.m_value); }
        public static Degree operator *(double lhs, Degree rhs) { return new Degree(lhs * rhs.m_value); }
        public static Degree operator *(Degree lhs, double rhs) { return new Degree(lhs.m_value * rhs); }
        public static Degree operator /(Degree lhs, double rhs) { return new Degree(lhs.m_value / rhs); }
        public static double operator /(Degree lhs, Degree rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Degree.Format, q, Degree.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Radian.Sense;
        public const int Family = Radian.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("\u00B0", "deg");
        public static readonly Unit<double> Proxy = new Degree_Proxy();
        public const double Factor = (180d / System.Math.PI) * Radian.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0}{1}";
        #endregion

        #region Predefined quantities
        public static readonly Degree One = new Degree(1d);
        public static readonly Degree Zero = new Degree(0d);
        #endregion
    }

    public partial class Degree_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Degree.Sense; } }
        public override int Family { get { return Degree.Family; } }
        public override double Factor { get { return Degree.Factor; } }
        public override SymbolCollection Symbol { get { return Degree.Symbol; } }
        public override string Format { get { return Degree.Format; } set { Degree.Format = value; } }
        #endregion

        #region Constructor(s)
        public Degree_Proxy() :
            base(typeof(Degree))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Degree(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Degree.From(quantity);
        }
        #endregion
    }
}
