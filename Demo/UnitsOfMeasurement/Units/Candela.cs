/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Candela : IQuantity<double>, IEquatable<Candela>, IComparable<Candela>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Candela(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Candela(double q) { return new Candela(q); }
        public static Candela From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Candela.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Candela\"", q.GetType().Name));
            return new Candela((Candela.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Candela>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Candela) && Equals((Candela)obj); }
        public bool /* IEquatable<Candela> */ Equals(Candela other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Candela>
        public static bool operator ==(Candela lhs, Candela rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Candela lhs, Candela rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Candela lhs, Candela rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Candela lhs, Candela rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Candela lhs, Candela rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Candela lhs, Candela rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Candela> */ CompareTo(Candela other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Candela operator +(Candela lhs, Candela rhs) { return new Candela(lhs.Value + rhs.Value); }
        public static Candela operator -(Candela lhs, Candela rhs) { return new Candela(lhs.Value - rhs.Value); }
        public static Candela operator ++(Candela q) { return new Candela(q.Value + 1d); }
        public static Candela operator --(Candela q) { return new Candela(q.Value - 1d); }
        public static Candela operator -(Candela q) { return new Candela(-q.Value); }
        public static Candela operator *(double lhs, Candela rhs) { return new Candela(lhs * rhs.Value); }
        public static Candela operator *(Candela lhs, double rhs) { return new Candela(lhs.Value * rhs); }
        public static Candela operator /(Candela lhs, double rhs) { return new Candela(lhs.Value / rhs); }
        public static double operator /(Candela lhs, Candela rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Candela.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Candela.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Candela.Format, Value, Candela.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.LuminousIntensity;
        private static readonly int s_family = 6;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("cd");

        private static readonly Candela s_one = new Candela(1d);
        private static readonly Candela s_zero = new Candela(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Candela One { get { return s_one; } }
        public static Candela Zero { get { return s_zero; } }
        #endregion
    }
}
