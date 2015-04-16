/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Mole : IQuantity<double>, IEquatable<Mole>, IComparable<Mole>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Mole(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Mole(double q) { return new Mole(q); }
        public static Mole From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Mole.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Mole\"", q.GetType().Name));
            return new Mole((Mole.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Mole>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Mole) && Equals((Mole)obj); }
        public bool /* IEquatable<Mole> */ Equals(Mole other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Mole>
        public static bool operator ==(Mole lhs, Mole rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Mole lhs, Mole rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Mole lhs, Mole rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Mole lhs, Mole rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Mole lhs, Mole rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Mole lhs, Mole rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Mole> */ CompareTo(Mole other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Mole operator +(Mole lhs, Mole rhs) { return new Mole(lhs.Value + rhs.Value); }
        public static Mole operator -(Mole lhs, Mole rhs) { return new Mole(lhs.Value - rhs.Value); }
        public static Mole operator ++(Mole q) { return new Mole(q.Value + 1d); }
        public static Mole operator --(Mole q) { return new Mole(q.Value - 1d); }
        public static Mole operator -(Mole q) { return new Mole(-q.Value); }
        public static Mole operator *(double lhs, Mole rhs) { return new Mole(lhs * rhs.Value); }
        public static Mole operator *(Mole lhs, double rhs) { return new Mole(lhs.Value * rhs); }
        public static Mole operator /(Mole lhs, double rhs) { return new Mole(lhs.Value / rhs); }
        public static double operator /(Mole lhs, Mole rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Mole.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Mole.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Mole.Format, Value, Mole.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.AmountOfSubstance;
        private static readonly int s_family = 5;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("mol");

        private static readonly Mole s_one = new Mole(1d);
        private static readonly Mole s_zero = new Mole(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Mole One { get { return s_one; } }
        public static Mole Zero { get { return s_zero; } }
        #endregion
    }
}
