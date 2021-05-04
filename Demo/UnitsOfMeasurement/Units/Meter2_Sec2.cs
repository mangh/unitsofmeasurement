/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Meter2_Sec2 : IQuantity<double>, IEquatable<Meter2_Sec2>, IComparable<Meter2_Sec2>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Meter2_Sec2.Proxy; } }
        #endregion

        #region Constructor(s)
        public Meter2_Sec2(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Meter2_Sec2(double q) { return new Meter2_Sec2(q); }
        public static Meter2_Sec2 From(IQuantity<double> q)
        {
            if (q.Unit.Family != Meter2_Sec2.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Meter2_Sec2\"", q.GetType().Name));
            }
            return new Meter2_Sec2((Meter2_Sec2.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Meter2_Sec2>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Meter2_Sec2) && Equals((Meter2_Sec2)obj); }
        public bool /* IEquatable<Meter2_Sec2> */ Equals(Meter2_Sec2 other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Meter2_Sec2>
        public static bool operator ==(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Meter2_Sec2> */ CompareTo(Meter2_Sec2 other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter2_Sec2 operator +(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return new Meter2_Sec2(lhs.m_value + rhs.m_value); }
        public static Meter2_Sec2 operator -(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return new Meter2_Sec2(lhs.m_value - rhs.m_value); }
        public static Meter2_Sec2 operator ++(Meter2_Sec2 q) { return new Meter2_Sec2(q.m_value + 1d); }
        public static Meter2_Sec2 operator --(Meter2_Sec2 q) { return new Meter2_Sec2(q.m_value - 1d); }
        public static Meter2_Sec2 operator -(Meter2_Sec2 q) { return new Meter2_Sec2(-q.m_value); }
        public static Meter2_Sec2 operator *(double lhs, Meter2_Sec2 rhs) { return new Meter2_Sec2(lhs * rhs.m_value); }
        public static Meter2_Sec2 operator *(Meter2_Sec2 lhs, double rhs) { return new Meter2_Sec2(lhs.m_value * rhs); }
        public static Meter2_Sec2 operator /(Meter2_Sec2 lhs, double rhs) { return new Meter2_Sec2(lhs.m_value / rhs); }
        public static double operator /(Meter2_Sec2 lhs, Meter2_Sec2 rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter_Sec operator /(Meter2_Sec2 lhs, Meter_Sec rhs) { return new Meter_Sec(lhs.m_value / rhs.m_value); }
        public static Meter operator /(Meter2_Sec2 lhs, Meter_Sec2 rhs) { return new Meter(lhs.m_value / rhs.m_value); }
        public static Meter_Sec2 operator /(Meter2_Sec2 lhs, Meter rhs) { return new Meter_Sec2(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Meter2_Sec2.Format, q, Meter2_Sec2.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Meter_Sec.Sense * Meter_Sec.Sense;
        public const int Family = 28;
        public static readonly SymbolCollection Symbol = new SymbolCollection("m2/s2");
        public static readonly Unit<double> Proxy = new Meter2_Sec2_Proxy();
        public const double Factor = Meter_Sec.Factor * Meter_Sec.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Meter2_Sec2 One = new Meter2_Sec2(1d);
        public static readonly Meter2_Sec2 Zero = new Meter2_Sec2(0d);
        #endregion
    }

    public partial class Meter2_Sec2_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Meter2_Sec2.Sense; } }
        public override int Family { get { return Meter2_Sec2.Family; } }
        public override double Factor { get { return Meter2_Sec2.Factor; } }
        public override SymbolCollection Symbol { get { return Meter2_Sec2.Symbol; } }
        public override string Format { get { return Meter2_Sec2.Format; } set { Meter2_Sec2.Format = value; } }
        #endregion

        #region Constructor(s)
        public Meter2_Sec2_Proxy() :
            base(typeof(Meter2_Sec2))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Meter2_Sec2(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Meter2_Sec2.From(quantity);
        }
        #endregion
    }
}
