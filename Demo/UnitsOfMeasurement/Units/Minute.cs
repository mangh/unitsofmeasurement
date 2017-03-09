/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Minute : IQuantity<double>, IEquatable<Minute>, IComparable<Minute>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Minute.Proxy; } }
        #endregion

        #region Constructor(s)
        public Minute(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Minute(double q) { return new Minute(q); }
        public static explicit operator Minute(Hour q) { return new Minute((Minute.Factor / Hour.Factor) * q.m_value); }
        public static explicit operator Minute(Second q) { return new Minute((Minute.Factor / Second.Factor) * q.m_value); }
        public static Minute From(IQuantity<double> q)
        {
            if (q.Unit.Family != Minute.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Minute\"", q.GetType().Name));
            return new Minute((Minute.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Minute>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Minute) && Equals((Minute)obj); }
        public bool /* IEquatable<Minute> */ Equals(Minute other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Minute>
        public static bool operator ==(Minute lhs, Minute rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Minute lhs, Minute rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Minute lhs, Minute rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Minute lhs, Minute rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Minute lhs, Minute rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Minute lhs, Minute rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Minute> */ CompareTo(Minute other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Minute operator +(Minute lhs, Minute rhs) { return new Minute(lhs.m_value + rhs.m_value); }
        public static Minute operator -(Minute lhs, Minute rhs) { return new Minute(lhs.m_value - rhs.m_value); }
        public static Minute operator ++(Minute q) { return new Minute(q.m_value + 1d); }
        public static Minute operator --(Minute q) { return new Minute(q.m_value - 1d); }
        public static Minute operator -(Minute q) { return new Minute(-q.m_value); }
        public static Minute operator *(double lhs, Minute rhs) { return new Minute(lhs * rhs.m_value); }
        public static Minute operator *(Minute lhs, double rhs) { return new Minute(lhs.m_value * rhs); }
        public static Minute operator /(Minute lhs, double rhs) { return new Minute(lhs.m_value / rhs); }
        public static double operator /(Minute lhs, Minute rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Minute.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Minute.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Minute.Format, m_value, Minute.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Second.Sense;
        private static readonly int s_family = Second.Family;
        private static /*mutable*/ double s_factor = Second.Factor / 60d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("min");
        private static readonly Unit<double> s_proxy = new Minute_Proxy();

        private static readonly Minute s_one = new Minute(1d);
        private static readonly Minute s_zero = new Minute(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Minute One { get { return s_one; } }
        public static Minute Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Minute_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Minute.Family; } }
        public override Dimension Sense { get { return Minute.Sense; } }
        public override SymbolCollection Symbol { get { return Minute.Symbol; } }
        public override double Factor { get { return Minute.Factor; } set { Minute.Factor = value; } }
        public override string Format { get { return Minute.Format; } set { Minute.Format = value; } }
        #endregion

        #region Constructor(s)
        public Minute_Proxy() :
            base(typeof(Minute))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Minute(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Minute.From(quantity);
        }
        #endregion
    }
}
