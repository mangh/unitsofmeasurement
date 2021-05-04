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
    public partial struct Rankine : ILevel<double>, IEquatable<Rankine>, IComparable<Rankine>, IFormattable
    {
        #region Fields
        internal readonly DegRankine m_level;
        #endregion

        #region Properties / ILevel<double>
        public DegRankine Level { get { return m_level; } }
        public DegRankine NormalizedLevel { get { return (m_level - Rankine.Offset); } }

        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
        Scale<double> ILevel<double>.Scale { get { return Rankine.Proxy; } }
        #endregion

        #region Constructor(s)
        public Rankine(DegRankine level)
        {
            m_level = level;
        }
        public Rankine(double level) :
            this(new DegRankine(level))
        {
        }
        #endregion

        #region Conversions
        public static explicit operator Rankine(double q) { return new Rankine(q); }
        public static explicit operator Rankine(DegRankine q) { return new Rankine(q); }

        public static explicit operator Rankine(Celsius q) { return new Rankine((DegRankine)(q.NormalizedLevel) + Rankine.Offset); }
        public static explicit operator Rankine(Kelvin q) { return new Rankine((DegRankine)(q.NormalizedLevel) + Rankine.Offset); }
        public static explicit operator Rankine(Fahrenheit q) { return new Rankine((DegRankine)(q.NormalizedLevel) + Rankine.Offset); }
        public static Rankine From(ILevel<double> q)
        {
            if (q.Scale.Family != Rankine.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Rankine\".", q.GetType().Name));
            }
            return new Rankine(DegRankine.From(q.NormalizedLevel) + Rankine.Offset);
        }
        public static Rankine From(IQuantity<double> q)
        {
            Scale<double> scale = Catalog.Scale(Rankine.Family, q.Unit);
            if (scale == null)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Rankine\".", q.GetType().Name));
            }
            return Rankine.From(scale.Create(q.Value));
        }
        #endregion

        #region IObject / IEquatable<Rankine>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Rankine) && Equals((Rankine)obj); }
        public bool /* IEquatable<Rankine> */ Equals(Rankine other) { return this.m_level == other.m_level; }
        #endregion

        #region Comparison / IComparable<Rankine>
        public static bool operator ==(Rankine lhs, Rankine rhs) { return lhs.m_level == rhs.m_level; }
        public static bool operator !=(Rankine lhs, Rankine rhs) { return lhs.m_level != rhs.m_level; }
        public static bool operator <(Rankine lhs, Rankine rhs) { return lhs.m_level < rhs.m_level; }
        public static bool operator >(Rankine lhs, Rankine rhs) { return lhs.m_level > rhs.m_level; }
        public static bool operator <=(Rankine lhs, Rankine rhs) { return lhs.m_level <= rhs.m_level; }
        public static bool operator >=(Rankine lhs, Rankine rhs) { return lhs.m_level >= rhs.m_level; }
        public int /* IComparable<Rankine> */ CompareTo(Rankine other) { return this.m_level.CompareTo(other.m_level); }
        #endregion

        #region Arithmetic
        public static Rankine operator +(Rankine lhs, DegRankine rhs) { return new Rankine(lhs.m_level + rhs); }
        public static Rankine operator +(DegRankine lhs, Rankine rhs) { return new Rankine(lhs + rhs.m_level); }
        public static Rankine operator -(Rankine lhs, DegRankine rhs) { return new Rankine(lhs.m_level - rhs); }
        public static DegRankine operator -(Rankine lhs, Rankine rhs) { return (lhs.m_level - rhs.m_level); }
        public static Rankine operator -(Rankine q) { return new Rankine(-q.m_level); }
        public static Rankine operator ++(Rankine q) { return q + DegRankine.One; }
        public static Rankine operator --(Rankine q) { return q - DegRankine.One; }
        #endregion

        #region Formatting
        public static string String(double level, string format = null, IFormatProvider fp = null)
        {
            return DegRankine.String(level, format ?? Rankine.Format, fp);
        }

        public override string ToString() { return String(m_level.m_value); }
        public string ToString(string format) { return String(m_level.m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_level.m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_level.m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly int Family = Kelvin.Family;
        public static readonly DegRankine Offset /* from AbsoluteZero */ = new DegRankine(0d);
        public static readonly Scale<double> Proxy = new Rankine_Proxy();
        private static string s_format = "{0} {1}";
        public static string Format { get { return s_format; } set { s_format = value; } }
        #endregion

        #region Predefined levels
        public static readonly Rankine Zero = new Rankine(0d);
        #endregion
    }

    public partial class Rankine_Proxy : Scale<double>
    {
        #region Properties
        public override int Family { get { return Rankine.Family; } }
        public override Unit Unit { get { return DegRankine.Proxy; } }
        public override IQuantity<double> Offset { get { return Rankine.Offset; } }
        public override string Format { get { return Rankine.Format; } set { Rankine.Format = value; } }
        #endregion

        #region Constructor(s)
        public Rankine_Proxy() :
            base(typeof(Rankine))
        {
        }
        #endregion

        #region Methods
        public override ILevel<double> Create(double value)
        {
            return new Rankine(value);
        }
        public override ILevel<double> From(ILevel<double> level)
        {
            return Rankine.From(level);
        }
        public override ILevel<double> From(IQuantity<double> quantity)
        {
            return Rankine.From(quantity);
        }
        #endregion
    }
}
