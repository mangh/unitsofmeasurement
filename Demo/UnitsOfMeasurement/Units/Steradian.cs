/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Steradian : IQuantity<double>, IEquatable<Steradian>, IComparable<Steradian>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Steradian.Proxy; } }
        #endregion

        #region Constructor(s)
        public Steradian(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Steradian(double q) { return new Steradian(q); }
        public static Steradian From(IQuantity<double> q)
        {
            if (q.Unit.Family != Steradian.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Steradian\"", q.GetType().Name));
            }
            return new Steradian((Steradian.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Steradian>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Steradian) && Equals((Steradian)obj); }
        public bool /* IEquatable<Steradian> */ Equals(Steradian other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Steradian>
        public static bool operator ==(Steradian lhs, Steradian rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Steradian lhs, Steradian rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Steradian lhs, Steradian rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Steradian lhs, Steradian rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Steradian lhs, Steradian rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Steradian lhs, Steradian rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Steradian> */ CompareTo(Steradian other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Steradian operator +(Steradian lhs, Steradian rhs) { return new Steradian(lhs.m_value + rhs.m_value); }
        public static Steradian operator -(Steradian lhs, Steradian rhs) { return new Steradian(lhs.m_value - rhs.m_value); }
        public static Steradian operator ++(Steradian q) { return new Steradian(q.m_value + 1d); }
        public static Steradian operator --(Steradian q) { return new Steradian(q.m_value - 1d); }
        public static Steradian operator -(Steradian q) { return new Steradian(-q.m_value); }
        public static Steradian operator *(double lhs, Steradian rhs) { return new Steradian(lhs * rhs.m_value); }
        public static Steradian operator *(Steradian lhs, double rhs) { return new Steradian(lhs.m_value * rhs); }
        public static Steradian operator /(Steradian lhs, double rhs) { return new Steradian(lhs.m_value / rhs); }
        public static double operator /(Steradian lhs, Steradian rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Steradian.Format, q, Steradian.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Dimension.None;
        public const int Family = 9;
        public static readonly SymbolCollection Symbol = new SymbolCollection("sr");
        public static readonly Unit<double> Proxy = new Steradian_Proxy();
        public const double Factor = 1d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Steradian One = new Steradian(1d);
        public static readonly Steradian Zero = new Steradian(0d);
        #endregion
    }

    public partial class Steradian_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Steradian.Sense; } }
        public override int Family { get { return Steradian.Family; } }
        public override double Factor { get { return Steradian.Factor; } }
        public override SymbolCollection Symbol { get { return Steradian.Symbol; } }
        public override string Format { get { return Steradian.Format; } set { Steradian.Format = value; } }
        #endregion

        #region Constructor(s)
        public Steradian_Proxy() :
            base(typeof(Steradian))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Steradian(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Steradian.From(quantity);
        }
        #endregion
    }
}
