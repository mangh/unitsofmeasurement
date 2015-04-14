/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Pound : IQuantity<double>, IEquatable<Pound>, IComparable<Pound>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Pound.Sense; } }
        public int UnitFamily { get { return Pound.Family; } }
        public double UnitFactor { get { return Pound.Factor; } }
        public string UnitFormat { get { return Pound.Format; } }
        public SymbolCollection UnitSymbol { get { return Pound.Symbol; } }

        #endregion

        #region Constructor(s)
        public Pound(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Pound(double q) { return new Pound(q); }
        public static explicit operator Pound(Ounce q) { return new Pound((Pound.Factor / Ounce.Factor) * q.Value); }
        public static explicit operator Pound(Tonne q) { return new Pound((Pound.Factor / Tonne.Factor) * q.Value); }
        public static explicit operator Pound(Gram q) { return new Pound((Pound.Factor / Gram.Factor) * q.Value); }
        public static explicit operator Pound(Kilogram q) { return new Pound((Pound.Factor / Kilogram.Factor) * q.Value); }
        public static Pound From(IQuantity<double> q)
        {
            if (q.UnitSense != Pound.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Pound\"", q.GetType().Name));
            return new Pound((Pound.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Pound>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Pound) && Equals((Pound)obj); }
        public bool /* IEquatable<Pound> */ Equals(Pound other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Pound>
        public static bool operator ==(Pound lhs, Pound rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Pound lhs, Pound rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Pound lhs, Pound rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Pound lhs, Pound rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Pound lhs, Pound rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Pound lhs, Pound rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Pound> */ CompareTo(Pound other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Pound operator +(Pound lhs, Pound rhs) { return new Pound(lhs.Value + rhs.Value); }
        public static Pound operator -(Pound lhs, Pound rhs) { return new Pound(lhs.Value - rhs.Value); }
        public static Pound operator ++(Pound q) { return new Pound(q.Value + 1d); }
        public static Pound operator --(Pound q) { return new Pound(q.Value - 1d); }
        public static Pound operator -(Pound q) { return new Pound(-q.Value); }
        public static Pound operator *(double lhs, Pound rhs) { return new Pound(lhs * rhs.Value); }
        public static Pound operator *(Pound lhs, double rhs) { return new Pound(lhs.Value * rhs); }
        public static Pound operator /(Pound lhs, double rhs) { return new Pound(lhs.Value / rhs); }
        public static double operator /(Pound lhs, Pound rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Pound.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Pound.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Pound.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Kilogram.Sense;
        private static readonly int s_family = Kilogram.Family;
        private static double s_factor = Kilogram.Factor / 0.45359237d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("lb");

        private static readonly Pound s_one = new Pound(1d);
        private static readonly Pound s_zero = new Pound(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Pound One { get { return s_one; } }
        public static Pound Zero { get { return s_zero; } }
        #endregion
    }
}
