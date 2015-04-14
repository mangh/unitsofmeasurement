/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Farad : IQuantity<double>, IEquatable<Farad>, IComparable<Farad>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Farad.Sense; } }
        public int UnitFamily { get { return Farad.Family; } }
        public double UnitFactor { get { return Farad.Factor; } }
        public string UnitFormat { get { return Farad.Format; } }
        public SymbolCollection UnitSymbol { get { return Farad.Symbol; } }

        #endregion

        #region Constructor(s)
        public Farad(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Farad(double q) { return new Farad(q); }
        public static Farad From(IQuantity<double> q)
        {
            if (q.UnitSense != Farad.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Farad\"", q.GetType().Name));
            return new Farad((Farad.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Farad>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Farad) && Equals((Farad)obj); }
        public bool /* IEquatable<Farad> */ Equals(Farad other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Farad>
        public static bool operator ==(Farad lhs, Farad rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Farad lhs, Farad rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Farad lhs, Farad rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Farad lhs, Farad rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Farad lhs, Farad rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Farad lhs, Farad rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Farad> */ CompareTo(Farad other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Farad operator +(Farad lhs, Farad rhs) { return new Farad(lhs.Value + rhs.Value); }
        public static Farad operator -(Farad lhs, Farad rhs) { return new Farad(lhs.Value - rhs.Value); }
        public static Farad operator ++(Farad q) { return new Farad(q.Value + 1d); }
        public static Farad operator --(Farad q) { return new Farad(q.Value - 1d); }
        public static Farad operator -(Farad q) { return new Farad(-q.Value); }
        public static Farad operator *(double lhs, Farad rhs) { return new Farad(lhs * rhs.Value); }
        public static Farad operator *(Farad lhs, double rhs) { return new Farad(lhs.Value * rhs); }
        public static Farad operator /(Farad lhs, double rhs) { return new Farad(lhs.Value / rhs); }
        public static double operator /(Farad lhs, Farad rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Coulomb operator *(Farad lhs, Volt rhs) { return new Coulomb(lhs.Value * rhs.Value); }
        public static Coulomb operator *(Volt lhs, Farad rhs) { return new Coulomb(lhs.Value * rhs.Value); }
        public static Second operator *(Farad lhs, Ohm rhs) { return new Second(lhs.Value * rhs.Value); }
        public static Second operator *(Ohm lhs, Farad rhs) { return new Second(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Farad.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Farad.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Farad.Format, Value, Farad.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Coulomb.Sense / Volt.Sense;
        private static readonly int s_family = 26;
        private static double s_factor = Coulomb.Factor / Volt.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("F");

        private static readonly Farad s_one = new Farad(1d);
        private static readonly Farad s_zero = new Farad(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Farad One { get { return s_one; } }
        public static Farad Zero { get { return s_zero; } }
        #endregion
    }
}
