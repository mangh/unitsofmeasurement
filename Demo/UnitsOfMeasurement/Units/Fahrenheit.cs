/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    [ScaleReferencePoint("AbsoluteZero")]
    public partial struct Fahrenheit : ILevel<double>, IEquatable<Fahrenheit>, IComparable<Fahrenheit>, IFormattable
    {
        #region Fields
        internal readonly DegFahrenheit m_level;
        #endregion

        #region Properties / ILevel<double>
        public DegFahrenheit Level { get { return m_level; } }
        public DegFahrenheit NormalizedLevel { get { return (m_level - Fahrenheit.Offset); } }

        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
        Scale<double> ILevel<double>.Scale { get { return Fahrenheit.Proxy; } }
        #endregion

        #region Constructor(s)
        public Fahrenheit(DegFahrenheit level)
        {
            m_level = level;
        }
        public Fahrenheit(double level) :
            this(new DegFahrenheit(level))
        {
        }
        #endregion

        #region Conversions
        public static explicit operator Fahrenheit(double q) { return new Fahrenheit(q); }
        public static explicit operator Fahrenheit(DegFahrenheit q) { return new Fahrenheit(q); }

        public static explicit operator Fahrenheit(Rankine q) { return new Fahrenheit((DegFahrenheit)(q.NormalizedLevel) + Fahrenheit.Offset); }
        public static explicit operator Fahrenheit(Celsius q) { return new Fahrenheit((DegFahrenheit)(q.NormalizedLevel) + Fahrenheit.Offset); }
        public static explicit operator Fahrenheit(Kelvin q) { return new Fahrenheit((DegFahrenheit)(q.NormalizedLevel) + Fahrenheit.Offset); }
        public static Fahrenheit From(ILevel<double> q)
        {
            if (q.Scale.Family != Fahrenheit.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Fahrenheit\".", q.GetType().Name));
            }
            return new Fahrenheit(DegFahrenheit.From(q.NormalizedLevel) + Fahrenheit.Offset);
        }
        public static Fahrenheit From(IQuantity<double> q)
        {
            Scale<double> scale = Catalog.Scale(Fahrenheit.Family, q.Unit);
            if (scale == null)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Fahrenheit\".", q.GetType().Name));
            }
            return Fahrenheit.From(scale.Create(q.Value));
        }
        #endregion

        #region IObject / IEquatable<Fahrenheit>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Fahrenheit) && Equals((Fahrenheit)obj); }
        public bool /* IEquatable<Fahrenheit> */ Equals(Fahrenheit other) { return this.m_level == other.m_level; }
        #endregion

        #region Comparison / IComparable<Fahrenheit>
        public static bool operator ==(Fahrenheit lhs, Fahrenheit rhs) { return lhs.m_level == rhs.m_level; }
        public static bool operator !=(Fahrenheit lhs, Fahrenheit rhs) { return lhs.m_level != rhs.m_level; }
        public static bool operator <(Fahrenheit lhs, Fahrenheit rhs) { return lhs.m_level < rhs.m_level; }
        public static bool operator >(Fahrenheit lhs, Fahrenheit rhs) { return lhs.m_level > rhs.m_level; }
        public static bool operator <=(Fahrenheit lhs, Fahrenheit rhs) { return lhs.m_level <= rhs.m_level; }
        public static bool operator >=(Fahrenheit lhs, Fahrenheit rhs) { return lhs.m_level >= rhs.m_level; }
        public int /* IComparable<Fahrenheit> */ CompareTo(Fahrenheit other) { return this.m_level.CompareTo(other.m_level); }
        #endregion

        #region Arithmetic
        public static Fahrenheit operator +(Fahrenheit lhs, DegFahrenheit rhs) { return new Fahrenheit(lhs.m_level + rhs); }
        public static Fahrenheit operator +(DegFahrenheit lhs, Fahrenheit rhs) { return new Fahrenheit(lhs + rhs.m_level); }
        public static Fahrenheit operator -(Fahrenheit lhs, DegFahrenheit rhs) { return new Fahrenheit(lhs.m_level - rhs); }
        public static DegFahrenheit operator -(Fahrenheit lhs, Fahrenheit rhs) { return (lhs.m_level - rhs.m_level); }
        public static Fahrenheit operator -(Fahrenheit q) { return new Fahrenheit(-q.m_level); }
        public static Fahrenheit operator ++(Fahrenheit q) { return q + DegFahrenheit.One; }
        public static Fahrenheit operator --(Fahrenheit q) { return q - DegFahrenheit.One; }
        #endregion

        #region Formatting
        public static string String(double level, string format = null, IFormatProvider fp = null)
        {
            return DegFahrenheit.String(level, format ?? Fahrenheit.Format, fp);
        }

        public override string ToString() { return String(m_level.m_value); }
        public string ToString(string format) { return String(m_level.m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_level.m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_level.m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly int Family = Kelvin.Family;
        public static readonly DegFahrenheit Offset /* from AbsoluteZero */ = new DegFahrenheit(-273.15d * (9d / 5d) + 32d);
        public static readonly Scale<double> Proxy = new Fahrenheit_Proxy();
        private static string s_format = "{0} {1}";
        public static string Format { get { return s_format; } set { s_format = value; } }
        #endregion

        #region Predefined levels
        public static readonly Fahrenheit Zero = new Fahrenheit(0d);
        #endregion
    }

    public partial class Fahrenheit_Proxy : Scale<double>
    {
        #region Properties
        public override int Family { get { return Fahrenheit.Family; } }
        public override Unit Unit { get { return DegFahrenheit.Proxy; } }
        public override IQuantity<double> Offset { get { return Fahrenheit.Offset; } }
        public override string Format { get { return Fahrenheit.Format; } set { Fahrenheit.Format = value; } }
        #endregion

        #region Constructor(s)
        public Fahrenheit_Proxy() :
            base(typeof(Fahrenheit))
        {
        }
        #endregion

        #region Methods
        public override ILevel<double> Create(double value)
        {
            return new Fahrenheit(value);
        }
        public override ILevel<double> From(ILevel<double> level)
        {
            return Fahrenheit.From(level);
        }
        public override ILevel<double> From(IQuantity<double> quantity)
        {
            return Fahrenheit.From(quantity);
        }
        #endregion
    }
}
