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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Minute.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Minute\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Minute.Format, q, Minute.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Second.Sense;
        public const int Family = Second.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("min");
        public static readonly Unit<double> Proxy = new Minute_Proxy();
        public const double Factor = Second.Factor / 60d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Minute One = new Minute(1d);
        public static readonly Minute Zero = new Minute(0d);
        #endregion
    }

    public partial class Minute_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Minute.Sense; } }
        public override int Family { get { return Minute.Family; } }
        public override double Factor { get { return Minute.Factor; } }
        public override SymbolCollection Symbol { get { return Minute.Symbol; } }
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
