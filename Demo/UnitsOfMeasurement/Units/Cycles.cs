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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Cycles.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Cycles\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Cycles.Format, q, Cycles.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Radian.Sense;
        public const int Family = Radian.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("c");
        public static readonly Unit<double> Proxy = new Cycles_Proxy();
        public const double Factor = Radian.Factor / (2d * System.Math.PI);
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Cycles One = new Cycles(1d);
        public static readonly Cycles Zero = new Cycles(0d);
        #endregion
    }

    public partial class Cycles_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Cycles.Sense; } }
        public override int Family { get { return Cycles.Family; } }
        public override double Factor { get { return Cycles.Factor; } }
        public override SymbolCollection Symbol { get { return Cycles.Symbol; } }
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
