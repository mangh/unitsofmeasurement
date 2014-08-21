/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Fahrenheit : ILevel<double>, IEquatable<Fahrenheit>, IComparable<Fahrenheit>
    {
        #region Fields
        private readonly DegFahrenheit m_level;
        #endregion

        #region Properties

        // instance properties
        public DegFahrenheit Level { get { return m_level; } }
        public DegFahrenheit Extent { get { return (m_level - Fahrenheit.Offset); } }

        // scale properties
        public DegFahrenheit ScaleOffset { get { return Fahrenheit.Offset; } }
        public string ScaleFormat { get { return Fahrenheit.Format; } }

        // ILevel<double> properties
        IQuantity<double> ILevel<double>.Level { get { return Level; } }
        IQuantity<double> ILevel<double>.Extent { get { return Extent; } }
        IQuantity<double> ILevel<double>.ScaleOffset { get { return ScaleOffset; } }

        #endregion

        #region Constructor(s)
        public Fahrenheit(DegFahrenheit level)
        {
            m_level = level;
        }
        public Fahrenheit(double level) :
            this((DegFahrenheit)level)
        {
        }
        #endregion

        #region Conversions
        public static explicit operator Fahrenheit(double q) { return new Fahrenheit(q); }
        public static explicit operator Fahrenheit(DegFahrenheit q) { return new Fahrenheit(q); }
        public static explicit operator Fahrenheit(Rankine q) { return new Fahrenheit((DegFahrenheit)(q.Extent) + Fahrenheit.Offset); }
        public static explicit operator Fahrenheit(Celsius q) { return new Fahrenheit((DegFahrenheit)(q.Extent) + Fahrenheit.Offset); }
        public static explicit operator Fahrenheit(Kelvin q) { return new Fahrenheit((DegFahrenheit)(q.Extent) + Fahrenheit.Offset); }
        public static Fahrenheit From(ILevel<double> q)
        {
            return new Fahrenheit(DegFahrenheit.From(q.Extent) + Fahrenheit.Offset);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_level.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Fahrenheit) && Equals((Fahrenheit)obj); }
        public bool /* IEquatable<Fahrenheit> */ Equals(Fahrenheit other) { return this.Level == other.Level; }
        public int /* IComparable<Fahrenheit> */ CompareTo(Fahrenheit other) { return this.Level.CompareTo(other.Level); }
        #endregion

        #region Comparison
        public static bool operator ==(Fahrenheit lhs, Fahrenheit rhs) { return lhs.Level == rhs.Level; }
        public static bool operator !=(Fahrenheit lhs, Fahrenheit rhs) { return lhs.Level != rhs.Level; }
        public static bool operator <(Fahrenheit lhs, Fahrenheit rhs) { return lhs.Level < rhs.Level; }
        public static bool operator >(Fahrenheit lhs, Fahrenheit rhs) { return lhs.Level > rhs.Level; }
        public static bool operator <=(Fahrenheit lhs, Fahrenheit rhs) { return lhs.Level <= rhs.Level; }
        public static bool operator >=(Fahrenheit lhs, Fahrenheit rhs) { return lhs.Level >= rhs.Level; }
        #endregion

        #region Arithmetic
        public static Fahrenheit operator +(Fahrenheit lhs, DegFahrenheit rhs) { return new Fahrenheit(lhs.Level + rhs); }
        public static Fahrenheit operator +(DegFahrenheit lhs, Fahrenheit rhs) { return new Fahrenheit(lhs + rhs.Level); }
        public static Fahrenheit operator -(Fahrenheit lhs, DegFahrenheit rhs) { return new Fahrenheit(lhs.Level - rhs); }
        public static DegFahrenheit operator -(Fahrenheit lhs, Fahrenheit rhs) { return (lhs.Level - rhs.Level); }
        public static Fahrenheit operator -(Fahrenheit q) { return new Fahrenheit(-q.Level); }
        public static Fahrenheit operator ++(Fahrenheit q) { return q + DegFahrenheit.One; }
        public static Fahrenheit operator --(Fahrenheit q) { return q - DegFahrenheit.One; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Fahrenheit.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Fahrenheit.Format); }
        public string ToString(IFormatProvider fp, string format) { return m_level.ToString(fp, format); }
        #endregion

        #region Statics
        private static DegFahrenheit s_offset = new DegFahrenheit(-273.15d * (9d / 5d) + 32d);
        private static string s_format = "{0} {1}";
        private static Fahrenheit s_zero = new Fahrenheit(0d);
        
        public static DegFahrenheit Offset { get { return s_offset; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static Fahrenheit Zero { get { return s_zero; } }
        #endregion
    }
}
