/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Watt : IQuantity<double>, IEquatable<Watt>, IComparable<Watt>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Watt.Sense; } }
        public int UnitFamily { get { return Watt.Family; } }
        public double UnitFactor { get { return Watt.Factor; } }
        public string UnitFormat { get { return Watt.Format; } }
        public SymbolCollection UnitSymbol { get { return Watt.Symbol; } }

        #endregion

        #region Constructor(s)
        public Watt(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Watt(double q) { return new Watt(q); }
        public static Watt From(IQuantity<double> q)
        {
            if (q.UnitSense != Watt.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Watt\"", q.GetType().Name));
            return new Watt((Watt.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Watt>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Watt) && Equals((Watt)obj); }
        public bool /* IEquatable<Watt> */ Equals(Watt other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Watt>
        public static bool operator ==(Watt lhs, Watt rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Watt lhs, Watt rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Watt lhs, Watt rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Watt lhs, Watt rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Watt lhs, Watt rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Watt lhs, Watt rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Watt> */ CompareTo(Watt other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Watt operator +(Watt lhs, Watt rhs) { return new Watt(lhs.Value + rhs.Value); }
        public static Watt operator -(Watt lhs, Watt rhs) { return new Watt(lhs.Value - rhs.Value); }
        public static Watt operator ++(Watt q) { return new Watt(q.Value + 1d); }
        public static Watt operator --(Watt q) { return new Watt(q.Value - 1d); }
        public static Watt operator -(Watt q) { return new Watt(-q.Value); }
        public static Watt operator *(double lhs, Watt rhs) { return new Watt(lhs * rhs.Value); }
        public static Watt operator *(Watt lhs, double rhs) { return new Watt(lhs.Value * rhs); }
        public static Watt operator /(Watt lhs, double rhs) { return new Watt(lhs.Value / rhs); }
        public static double operator /(Watt lhs, Watt rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Joule operator *(Watt lhs, Second rhs) { return new Joule(lhs.Value * rhs.Value); }
        public static Joule operator *(Second lhs, Watt rhs) { return new Joule(lhs.Value * rhs.Value); }
        public static Volt operator /(Watt lhs, Ampere rhs) { return new Volt(lhs.Value / rhs.Value); }
        public static Ampere operator /(Watt lhs, Volt rhs) { return new Ampere(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Watt.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Watt.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Watt.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Joule.Sense / Second.Sense;
        private static readonly int s_family = 17;
        private static double s_factor = Joule.Factor / Second.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("W");

        private static readonly Watt s_one = new Watt(1d);
        private static readonly Watt s_zero = new Watt(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Watt One { get { return s_one; } }
        public static Watt Zero { get { return s_zero; } }
        #endregion
    }
}
