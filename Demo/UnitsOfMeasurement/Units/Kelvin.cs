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
    public partial struct Kelvin : ILevel<double>, IEquatable<Kelvin>, IComparable<Kelvin>, IFormattable
    {
        #region Fields
        internal readonly DegKelvin m_level;
        #endregion

        #region Properties / ILevel<double>
        public DegKelvin Level { get { return m_level; } }
        public DegKelvin NormalizedLevel { get { return (m_level - Kelvin.Offset); } }

        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
        Scale<double> ILevel<double>.Scale { get { return Kelvin.Proxy; } }
        #endregion

        #region Constructor(s)
        public Kelvin(DegKelvin level)
        {
            m_level = level;
        }
        public Kelvin(double level) :
            this(new DegKelvin(level))
        {
        }
        #endregion

        #region Conversions
        public static explicit operator Kelvin(double q) { return new Kelvin(q); }
        public static explicit operator Kelvin(DegKelvin q) { return new Kelvin(q); }

        public static explicit operator Kelvin(Fahrenheit q) { return new Kelvin((DegKelvin)(q.NormalizedLevel) + Kelvin.Offset); }
        public static explicit operator Kelvin(Rankine q) { return new Kelvin((DegKelvin)(q.NormalizedLevel) + Kelvin.Offset); }
        public static explicit operator Kelvin(Celsius q) { return new Kelvin((DegKelvin)(q.NormalizedLevel) + Kelvin.Offset); }
        public static Kelvin From(ILevel<double> q)
        {
            if (q.Scale.Family != Kelvin.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Kelvin\".", q.GetType().Name));
            }
            return new Kelvin(DegKelvin.From(q.NormalizedLevel) + Kelvin.Offset);
        }
        public static Kelvin From(IQuantity<double> q)
        {
            Scale<double> scale = Catalog.Scale(Kelvin.Family, q.Unit);
            if (scale == null)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Kelvin\".", q.GetType().Name));
            }
            return Kelvin.From(scale.Create(q.Value));
        }
        #endregion

        #region IObject / IEquatable<Kelvin>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Kelvin) && Equals((Kelvin)obj); }
        public bool /* IEquatable<Kelvin> */ Equals(Kelvin other) { return this.m_level == other.m_level; }
        #endregion

        #region Comparison / IComparable<Kelvin>
        public static bool operator ==(Kelvin lhs, Kelvin rhs) { return lhs.m_level == rhs.m_level; }
        public static bool operator !=(Kelvin lhs, Kelvin rhs) { return lhs.m_level != rhs.m_level; }
        public static bool operator <(Kelvin lhs, Kelvin rhs) { return lhs.m_level < rhs.m_level; }
        public static bool operator >(Kelvin lhs, Kelvin rhs) { return lhs.m_level > rhs.m_level; }
        public static bool operator <=(Kelvin lhs, Kelvin rhs) { return lhs.m_level <= rhs.m_level; }
        public static bool operator >=(Kelvin lhs, Kelvin rhs) { return lhs.m_level >= rhs.m_level; }
        public int /* IComparable<Kelvin> */ CompareTo(Kelvin other) { return this.m_level.CompareTo(other.m_level); }
        #endregion

        #region Arithmetic
        public static Kelvin operator +(Kelvin lhs, DegKelvin rhs) { return new Kelvin(lhs.m_level + rhs); }
        public static Kelvin operator +(DegKelvin lhs, Kelvin rhs) { return new Kelvin(lhs + rhs.m_level); }
        public static Kelvin operator -(Kelvin lhs, DegKelvin rhs) { return new Kelvin(lhs.m_level - rhs); }
        public static DegKelvin operator -(Kelvin lhs, Kelvin rhs) { return (lhs.m_level - rhs.m_level); }
        public static Kelvin operator -(Kelvin q) { return new Kelvin(-q.m_level); }
        public static Kelvin operator ++(Kelvin q) { return q + DegKelvin.One; }
        public static Kelvin operator --(Kelvin q) { return q - DegKelvin.One; }
        #endregion

        #region Formatting
        public static string String(double level, string format = null, IFormatProvider fp = null)
        {
            return DegKelvin.String(level, format ?? Kelvin.Format, fp);
        }

        public override string ToString() { return String(m_level.m_value); }
        public string ToString(string format) { return String(m_level.m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_level.m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_level.m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly int Family = 29;
        public static readonly DegKelvin Offset /* from AbsoluteZero */ = new DegKelvin(0d);
        public static readonly Scale<double> Proxy = new Kelvin_Proxy();
        private static string s_format = "{0} {1}";
        public static string Format { get { return s_format; } set { s_format = value; } }
        #endregion

        #region Predefined levels
        public static readonly Kelvin Zero = new Kelvin(0d);
        #endregion
    }

    public partial class Kelvin_Proxy : Scale<double>
    {
        #region Properties
        public override int Family { get { return Kelvin.Family; } }
        public override Unit Unit { get { return DegKelvin.Proxy; } }
        public override IQuantity<double> Offset { get { return Kelvin.Offset; } }
        public override string Format { get { return Kelvin.Format; } set { Kelvin.Format = value; } }
        #endregion

        #region Constructor(s)
        public Kelvin_Proxy() :
            base(typeof(Kelvin))
        {
        }
        #endregion

        #region Methods
        public override ILevel<double> Create(double value)
        {
            return new Kelvin(value);
        }
        public override ILevel<double> From(ILevel<double> level)
        {
            return Kelvin.From(level);
        }
        public override ILevel<double> From(IQuantity<double> quantity)
        {
            return Kelvin.From(quantity);
        }
        #endregion
    }
}
