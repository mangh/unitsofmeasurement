/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Ampere : IQuantity<double>, IEquatable<Ampere>, IComparable<Ampere>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Ampere(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Ampere(double q) { return new Ampere(q); }
        public static Ampere From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Ampere.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Ampere\"", q.GetType().Name));
            return new Ampere((Ampere.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Ampere>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Ampere) && Equals((Ampere)obj); }
        public bool /* IEquatable<Ampere> */ Equals(Ampere other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Ampere>
        public static bool operator ==(Ampere lhs, Ampere rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Ampere lhs, Ampere rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Ampere lhs, Ampere rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Ampere lhs, Ampere rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Ampere lhs, Ampere rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Ampere lhs, Ampere rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Ampere> */ CompareTo(Ampere other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Ampere operator +(Ampere lhs, Ampere rhs) { return new Ampere(lhs.Value + rhs.Value); }
        public static Ampere operator -(Ampere lhs, Ampere rhs) { return new Ampere(lhs.Value - rhs.Value); }
        public static Ampere operator ++(Ampere q) { return new Ampere(q.Value + 1d); }
        public static Ampere operator --(Ampere q) { return new Ampere(q.Value - 1d); }
        public static Ampere operator -(Ampere q) { return new Ampere(-q.Value); }
        public static Ampere operator *(double lhs, Ampere rhs) { return new Ampere(lhs * rhs.Value); }
        public static Ampere operator *(Ampere lhs, double rhs) { return new Ampere(lhs.Value * rhs); }
        public static Ampere operator /(Ampere lhs, double rhs) { return new Ampere(lhs.Value / rhs); }
        public static double operator /(Ampere lhs, Ampere rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Coulomb operator *(Ampere lhs, Second rhs) { return new Coulomb(lhs.Value * rhs.Value); }
        public static Coulomb operator *(Second lhs, Ampere rhs) { return new Coulomb(lhs.Value * rhs.Value); }
        public static Siemens operator /(Ampere lhs, Volt rhs) { return new Siemens(lhs.Value / rhs.Value); }
        public static Volt operator /(Ampere lhs, Siemens rhs) { return new Volt(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Ampere.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Ampere.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Ampere.Format, Value, Ampere.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.ElectricCurrent;
        private static readonly int s_family = 4;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("A");

        private static readonly Ampere s_one = new Ampere(1d);
        private static readonly Ampere s_zero = new Ampere(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Ampere One { get { return s_one; } }
        public static Ampere Zero { get { return s_zero; } }
        #endregion
    }
}
