/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Gram : IQuantity<double>, IEquatable<Gram>, IComparable<Gram>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Gram.Sense; } }
        public int UnitFamily { get { return Gram.Family; } }
        public double UnitFactor { get { return Gram.Factor; } }
        public string UnitFormat { get { return Gram.Format; } }
        public SymbolCollection UnitSymbol { get { return Gram.Symbol; } }

        #endregion

        #region Constructor(s)
        public Gram(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Gram(double q) { return new Gram(q); }
        public static explicit operator Gram(Kilogram q) { return new Gram((Gram.Factor / Kilogram.Factor) * q.Value); }
        public static explicit operator Gram(Pound q) { return new Gram((Gram.Factor / Pound.Factor) * q.Value); }
        public static explicit operator Gram(Ounce q) { return new Gram((Gram.Factor / Ounce.Factor) * q.Value); }
        public static explicit operator Gram(Tonne q) { return new Gram((Gram.Factor / Tonne.Factor) * q.Value); }
        public static Gram From(IQuantity<double> q)
        {
            if (q.UnitSense != Gram.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Gram\"", q.GetType().Name));
            return new Gram((Gram.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Gram>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Gram) && Equals((Gram)obj); }
        public bool /* IEquatable<Gram> */ Equals(Gram other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Gram>
        public static bool operator ==(Gram lhs, Gram rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Gram lhs, Gram rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Gram lhs, Gram rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Gram lhs, Gram rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Gram lhs, Gram rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Gram lhs, Gram rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Gram> */ CompareTo(Gram other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Gram operator +(Gram lhs, Gram rhs) { return new Gram(lhs.Value + rhs.Value); }
        public static Gram operator -(Gram lhs, Gram rhs) { return new Gram(lhs.Value - rhs.Value); }
        public static Gram operator ++(Gram q) { return new Gram(q.Value + 1d); }
        public static Gram operator --(Gram q) { return new Gram(q.Value - 1d); }
        public static Gram operator -(Gram q) { return new Gram(-q.Value); }
        public static Gram operator *(double lhs, Gram rhs) { return new Gram(lhs * rhs.Value); }
        public static Gram operator *(Gram lhs, double rhs) { return new Gram(lhs.Value * rhs); }
        public static Gram operator /(Gram lhs, double rhs) { return new Gram(lhs.Value / rhs); }
        public static double operator /(Gram lhs, Gram rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Gram.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Gram.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Gram.Format, Value, Gram.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Kilogram.Sense;
        private static readonly int s_family = Kilogram.Family;
        private static double s_factor = 1000d * Kilogram.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("g");

        private static readonly Gram s_one = new Gram(1d);
        private static readonly Gram s_zero = new Gram(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Gram One { get { return s_one; } }
        public static Gram Zero { get { return s_zero; } }
        #endregion
    }
}
