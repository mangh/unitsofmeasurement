/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    [ScaleReferencePoint("AbsoluteZero")]
    public partial struct Rankine : ILevel<double>, IEquatable<Rankine>, IComparable<Rankine>, IFormattable
    {
        #region Fields
        private readonly DegRankine m_level;
        #endregion

        #region Properties

        // instance properties
        public DegRankine Level { get { return m_level; } }
        public DegRankine Extent { get { return (m_level - Rankine.Offset); } }

        // scale properties
        public DegRankine ScaleOffset { get { return Rankine.Offset; } }
        public string ScaleFormat { get { return Rankine.Format; } }

        // ILevel<double> properties
        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.Extent { get { return Extent; } }
        IQuantity<double> ILevel<double>.ScaleOffset { get { return ScaleOffset; } }

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

        public static explicit operator Rankine(Celsius q) { return new Rankine((DegRankine)(q.Extent) + Rankine.Offset); }
        public static explicit operator Rankine(Kelvin q) { return new Rankine((DegRankine)(q.Extent) + Rankine.Offset); }
        public static explicit operator Rankine(Fahrenheit q) { return new Rankine((DegRankine)(q.Extent) + Rankine.Offset); }

        public static Rankine From(ILevel<double> q)
        {
            return new Rankine(DegRankine.From(q.Extent) + Rankine.Offset);
        }
        #endregion

        #region IObject / IEquatable<Rankine>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Rankine) && Equals((Rankine)obj); }
        public bool /* IEquatable<Rankine> */ Equals(Rankine other) { return this.Level == other.Level; }
        #endregion

        #region Comparison / IComparable<Rankine>
        public static bool operator ==(Rankine lhs, Rankine rhs) { return lhs.Level == rhs.Level; }
        public static bool operator !=(Rankine lhs, Rankine rhs) { return lhs.Level != rhs.Level; }
        public static bool operator <(Rankine lhs, Rankine rhs) { return lhs.Level < rhs.Level; }
        public static bool operator >(Rankine lhs, Rankine rhs) { return lhs.Level > rhs.Level; }
        public static bool operator <=(Rankine lhs, Rankine rhs) { return lhs.Level <= rhs.Level; }
        public static bool operator >=(Rankine lhs, Rankine rhs) { return lhs.Level >= rhs.Level; }
        public int /* IComparable<Rankine> */ CompareTo(Rankine other) { return this.Level.CompareTo(other.Level); }
        #endregion

        #region Arithmetic
        public static Rankine operator +(Rankine lhs, DegRankine rhs) { return new Rankine(lhs.Level + rhs); }
        public static Rankine operator +(DegRankine lhs, Rankine rhs) { return new Rankine(lhs + rhs.Level); }
        public static Rankine operator -(Rankine lhs, DegRankine rhs) { return new Rankine(lhs.Level - rhs); }
        public static DegRankine operator -(Rankine lhs, Rankine rhs) { return (lhs.Level - rhs.Level); }
        public static Rankine operator -(Rankine q) { return new Rankine(-q.Level); }
        public static Rankine operator ++(Rankine q) { return q + DegRankine.One; }
        public static Rankine operator --(Rankine q) { return q - DegRankine.One; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Rankine.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Rankine.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return m_level.ToString(format ?? Rankine.Format, fp);
        }
        #endregion

        #region Statics
        private static readonly DegRankine s_offset = new DegRankine(0d);  // offset to AbsoluteZero
        private static readonly int s_family = Kelvin.Family;
        private static string s_format = "{0} {1}";
        private static readonly Rankine s_zero = new Rankine(0d);
        
        public static DegRankine Offset { get { return s_offset; } }
        public static int Family { get { return s_family; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static Rankine Zero { get { return s_zero; } }
        #endregion
    }
}
