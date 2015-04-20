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
        private readonly DegCelsius m_level;
        #endregion

        #region Properties
        // instance properties
        public DegCelsius Level { get { return m_level; } }
        public DegCelsius NormalizedLevel { get { return (m_level - Celsius.Offset); } }
        // ILevel<double> properties
        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.NormalizedLevel { get { return NormalizedLevel; } }
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
            /* The following 2 statements might be required if you have two (or more) scale families derived from the same units
               but bound to different reference levels. E.g. two families of temperature scales: one with common reference level
               set to absolute zero and the other one with common reference level set to water freeze point.
               This is rather unlikely and the statements are commented out to avoid (likely) superfluous checks. */
               
            // Scale<double> source = new Scale<double>(q);
            // if (source.Family != Celsius.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Celsius\"", q.GetType().Name));

            return new Celsius(DegCelsius.From(q.NormalizedLevel) + Celsius.Offset);
        }
        #endregion

        #region IObject / IEquatable<Celsius>
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Celsius) && Equals((Celsius)obj); }
        public bool /* IEquatable<Celsius> */ Equals(Celsius other) { return this.Level == other.Level; }
        #endregion

        #region Comparison / IComparable<Celsius>
        public static bool operator ==(Celsius lhs, Celsius rhs) { return lhs.Level == rhs.Level; }
        public static bool operator !=(Celsius lhs, Celsius rhs) { return lhs.Level != rhs.Level; }
        public static bool operator <(Celsius lhs, Celsius rhs) { return lhs.Level < rhs.Level; }
        public static bool operator >(Celsius lhs, Celsius rhs) { return lhs.Level > rhs.Level; }
        public static bool operator <=(Celsius lhs, Celsius rhs) { return lhs.Level <= rhs.Level; }
        public static bool operator >=(Celsius lhs, Celsius rhs) { return lhs.Level >= rhs.Level; }
        public int /* IComparable<Celsius> */ CompareTo(Celsius other) { return this.Level.CompareTo(other.Level); }
        #endregion

        #region Arithmetic
        public static Celsius operator +(Celsius lhs, DegCelsius rhs) { return new Celsius(lhs.Level + rhs); }
        public static Celsius operator +(DegCelsius lhs, Celsius rhs) { return new Celsius(lhs + rhs.Level); }
        public static Celsius operator -(Celsius lhs, DegCelsius rhs) { return new Celsius(lhs.Level - rhs); }
        public static DegCelsius operator -(Celsius lhs, Celsius rhs) { return (lhs.Level - rhs.Level); }
        public static Celsius operator -(Celsius q) { return new Celsius(-q.Level); }
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

        #region Statics
        private static readonly DegCelsius s_offset = new DegCelsius(-273.15d);  // offset to AbsoluteZero
        private static readonly int s_family = Kelvin.Family;
        private static string s_format = "{0} {1}";
        private static readonly Celsius s_zero = new Celsius(0d);
        
        public static DegCelsius Offset { get { return s_offset; } }
        public static int Family { get { return s_family; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static Celsius Zero { get { return s_zero; } }
        #endregion
    }
}
