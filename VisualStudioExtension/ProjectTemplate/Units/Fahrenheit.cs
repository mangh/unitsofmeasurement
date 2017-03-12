/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    [ScaleReferencePoint("AbsoluteZero")]
    public partial struct Fahrenheit : ILevel<double>, IEquatable<Fahrenheit>, IComparable<Fahrenheit>, IFormattable
    {
        #region Fields
        internal readonly DegFahrenheit m_level;
        #endregion

        #region Properties
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

        public static explicit operator Fahrenheit(Celsius q) { return new Fahrenheit((DegFahrenheit)(q.NormalizedLevel) + Fahrenheit.Offset); }
        public static explicit operator Fahrenheit(Kelvin q) { return new Fahrenheit((DegFahrenheit)(q.NormalizedLevel) + Fahrenheit.Offset); }
        public static Fahrenheit From(ILevel<double> q)
        {
            if (q.Scale.Family != Fahrenheit.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Fahrenheit\".", q.GetType().Name));
            return new Fahrenheit(DegFahrenheit.From(q.NormalizedLevel) + Fahrenheit.Offset);
        }
        public static Fahrenheit From(IQuantity<double> q)
        {
            Scale<double> scale = Catalog.Scale(Fahrenheit.Family, q.Unit);
            if(scale == null) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Fahrenheit\".", q.GetType().Name));
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
        public override string ToString() { return ToString(Fahrenheit.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Fahrenheit.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return m_level.ToString(format ?? Fahrenheit.Format, fp);
        }
        #endregion

        #region Static fields
        private static readonly DegFahrenheit s_offset /* from AbsoluteZero reference level */ = new DegFahrenheit(-273.15d * (9d / 5d) + 32d);
        private static readonly int s_family = Kelvin.Family;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly Scale<double> s_proxy = new Fahrenheit_Proxy();

        private static readonly Fahrenheit s_zero = new Fahrenheit(0d);
        #endregion
        
        #region Static properties
        public static DegFahrenheit Offset { get { return s_offset; } }
        public static int Family { get { return s_family; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static Scale<double> Proxy { get { return s_proxy; } }

        public static Fahrenheit Zero { get { return s_zero; } }
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
