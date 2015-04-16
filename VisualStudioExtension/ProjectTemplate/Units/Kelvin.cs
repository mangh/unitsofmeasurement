/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace $safeprojectname$
{
    [ScaleReferencePoint("AbsoluteZero")]
    public partial struct Kelvin : ILevel<double>, IEquatable<Kelvin>, IComparable<Kelvin>, IFormattable
    {
        #region Fields
        private readonly DegKelvin m_level;
        #endregion

        #region Properties
        // instance properties
        public DegKelvin Level { get { return m_level; } }
        public DegKelvin NormalizedLevel { get { return (m_level - Kelvin.Offset); } }
        // ILevel<double> properties
        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
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
            /* The following 2 statements might be required if you have two (or more) scale families derived from the same units
               but bound to different reference levels. E.g. two families of temperature scales: one with common reference level
               set to absolute zero and the other one with common reference level set to water freeze point.
               This is rather unlikely and the statements are commented out to avoid (likely) superfluous checks. */
               
            // Scale<double> source = new Scale<double>(q);
            // if (source.Family != Kelvin.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Kelvin\"", q.GetType().Name));

            return new Kelvin(DegKelvin.From(q.NormalizedLevel) + Kelvin.Offset);
        }
        #endregion

        #region IObject / IEquatable<Kelvin>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Kelvin) && Equals((Kelvin)obj); }
        public bool /* IEquatable<Kelvin> */ Equals(Kelvin other) { return this.Level == other.Level; }
        #endregion

        #region Comparison / IComparable<Kelvin>
        public static bool operator ==(Kelvin lhs, Kelvin rhs) { return lhs.Level == rhs.Level; }
        public static bool operator !=(Kelvin lhs, Kelvin rhs) { return lhs.Level != rhs.Level; }
        public static bool operator <(Kelvin lhs, Kelvin rhs) { return lhs.Level < rhs.Level; }
        public static bool operator >(Kelvin lhs, Kelvin rhs) { return lhs.Level > rhs.Level; }
        public static bool operator <=(Kelvin lhs, Kelvin rhs) { return lhs.Level <= rhs.Level; }
        public static bool operator >=(Kelvin lhs, Kelvin rhs) { return lhs.Level >= rhs.Level; }
        public int /* IComparable<Kelvin> */ CompareTo(Kelvin other) { return this.Level.CompareTo(other.Level); }
        #endregion

        #region Arithmetic
        public static Kelvin operator +(Kelvin lhs, DegKelvin rhs) { return new Kelvin(lhs.Level + rhs); }
        public static Kelvin operator +(DegKelvin lhs, Kelvin rhs) { return new Kelvin(lhs + rhs.Level); }
        public static Kelvin operator -(Kelvin lhs, DegKelvin rhs) { return new Kelvin(lhs.Level - rhs); }
        public static DegKelvin operator -(Kelvin lhs, Kelvin rhs) { return (lhs.Level - rhs.Level); }
        public static Kelvin operator -(Kelvin q) { return new Kelvin(-q.Level); }
        public static Kelvin operator ++(Kelvin q) { return q + DegKelvin.One; }
        public static Kelvin operator --(Kelvin q) { return q - DegKelvin.One; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Kelvin.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Kelvin.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return m_level.ToString(format ?? Kelvin.Format, fp);
        }
        #endregion

        #region Statics
        private static readonly DegKelvin s_offset = new DegKelvin(0d);  // offset to AbsoluteZero
        private static readonly int s_family = 13;
        private static string s_format = "{0} {1}";
        private static readonly Kelvin s_zero = new Kelvin(0d);
        
        public static DegKelvin Offset { get { return s_offset; } }
        public static int Family { get { return s_family; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static Kelvin Zero { get { return s_zero; } }
        #endregion
    }
}
