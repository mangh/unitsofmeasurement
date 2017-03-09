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
    public partial struct Celsius : ILevel<double>, IEquatable<Celsius>, IComparable<Celsius>, IFormattable
    {
        #region Fields
        internal readonly DegCelsius m_level;
        #endregion

        #region Properties
        public DegCelsius Level { get { return m_level; } }
        public DegCelsius NormalizedLevel { get { return (m_level - Celsius.Offset); } }

        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
        Scale<double> ILevel<double>.Scale { get { return Celsius.Proxy; } }
        #endregion

        #region Constructor(s)
        public Celsius(DegCelsius level)
        {
            m_level = level;
        }
        public Celsius(double level) :
            this(new DegCelsius(level))
        {
        }
        #endregion

        #region Conversions
        public static explicit operator Celsius(double q) { return new Celsius(q); }
        public static explicit operator Celsius(DegCelsius q) { return new Celsius(q); }

        public static explicit operator Celsius(Kelvin q) { return new Celsius((DegCelsius)(q.NormalizedLevel) + Celsius.Offset); }
        public static explicit operator Celsius(Fahrenheit q) { return new Celsius((DegCelsius)(q.NormalizedLevel) + Celsius.Offset); }
        public static explicit operator Celsius(Rankine q) { return new Celsius((DegCelsius)(q.NormalizedLevel) + Celsius.Offset); }
        public static Celsius From(ILevel<double> q)
        {
            if (q.Scale.Family != Celsius.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Celsius\".", q.GetType().Name));
            return new Celsius(DegCelsius.From(q.NormalizedLevel) + Celsius.Offset);
        }
        public static Celsius From(IQuantity<double> q)
        {
            Scale<double> scale = Catalog.Scale(Celsius.Family, q.Unit);
            if(scale == null) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Celsius\".", q.GetType().Name));
            return Celsius.From(scale.Create(q.Value));
        }
        #endregion

        #region IObject / IEquatable<Celsius>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Celsius) && Equals((Celsius)obj); }
        public bool /* IEquatable<Celsius> */ Equals(Celsius other) { return this.m_level == other.m_level; }
        #endregion

        #region Comparison / IComparable<Celsius>
        public static bool operator ==(Celsius lhs, Celsius rhs) { return lhs.m_level == rhs.m_level; }
        public static bool operator !=(Celsius lhs, Celsius rhs) { return lhs.m_level != rhs.m_level; }
        public static bool operator <(Celsius lhs, Celsius rhs) { return lhs.m_level < rhs.m_level; }
        public static bool operator >(Celsius lhs, Celsius rhs) { return lhs.m_level > rhs.m_level; }
        public static bool operator <=(Celsius lhs, Celsius rhs) { return lhs.m_level <= rhs.m_level; }
        public static bool operator >=(Celsius lhs, Celsius rhs) { return lhs.m_level >= rhs.m_level; }
        public int /* IComparable<Celsius> */ CompareTo(Celsius other) { return this.m_level.CompareTo(other.m_level); }
        #endregion

        #region Arithmetic
        public static Celsius operator +(Celsius lhs, DegCelsius rhs) { return new Celsius(lhs.m_level + rhs); }
        public static Celsius operator +(DegCelsius lhs, Celsius rhs) { return new Celsius(lhs + rhs.m_level); }
        public static Celsius operator -(Celsius lhs, DegCelsius rhs) { return new Celsius(lhs.m_level - rhs); }
        public static DegCelsius operator -(Celsius lhs, Celsius rhs) { return (lhs.m_level - rhs.m_level); }
        public static Celsius operator -(Celsius q) { return new Celsius(-q.m_level); }
        public static Celsius operator ++(Celsius q) { return q + DegCelsius.One; }
        public static Celsius operator --(Celsius q) { return q - DegCelsius.One; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Celsius.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Celsius.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return m_level.ToString(format ?? Celsius.Format, fp);
        }
        #endregion

        #region Static fields
        private static readonly DegCelsius s_offset /* from AbsoluteZero reference level */ = new DegCelsius(-273.15d);
        private static readonly int s_family = Kelvin.Family;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly Scale<double> s_proxy = new Celsius_Proxy();

        private static readonly Celsius s_zero = new Celsius(0d);
        #endregion
        
        #region Static properties
        public static DegCelsius Offset { get { return s_offset; } }
        public static int Family { get { return s_family; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static Scale<double> Proxy { get { return s_proxy; } }

        public static Celsius Zero { get { return s_zero; } }
        #endregion
    }
    public partial class Celsius_Proxy : Scale<double>
    {
        #region Properties
        public override int Family { get { return Celsius.Family; } }
        public override Unit Unit { get { return DegCelsius.Proxy; } }
        public override IQuantity<double> Offset { get { return Celsius.Offset; } }
        public override string Format { get { return Celsius.Format; } set { Celsius.Format = value; } }
        #endregion

        #region Constructor(s)
        public Celsius_Proxy() :
            base(typeof(Celsius))
        {
        }
        #endregion

        #region Methods
        public override ILevel<double> Create(double value)
        {
            return new Celsius(value);
        }
        public override ILevel<double> From(ILevel<double> level)
        {
            return Celsius.From(level);
        }
        public override ILevel<double> From(IQuantity<double> quantity)
        {
            return Celsius.From(quantity);
        }
        #endregion
    }
}
