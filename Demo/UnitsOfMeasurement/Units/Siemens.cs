/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Siemens : IQuantity<double>, IEquatable<Siemens>, IComparable<Siemens>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Siemens(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Siemens(double q) { return new Siemens(q); }
        public static Siemens From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Siemens.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Siemens\"", q.GetType().Name));
            return new Siemens((Siemens.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Siemens>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Siemens) && Equals((Siemens)obj); }
        public bool /* IEquatable<Siemens> */ Equals(Siemens other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Siemens>
        public static bool operator ==(Siemens lhs, Siemens rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Siemens lhs, Siemens rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Siemens lhs, Siemens rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Siemens lhs, Siemens rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Siemens lhs, Siemens rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Siemens lhs, Siemens rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Siemens> */ CompareTo(Siemens other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Siemens operator +(Siemens lhs, Siemens rhs) { return new Siemens(lhs.Value + rhs.Value); }
        public static Siemens operator -(Siemens lhs, Siemens rhs) { return new Siemens(lhs.Value - rhs.Value); }
        public static Siemens operator ++(Siemens q) { return new Siemens(q.Value + 1d); }
        public static Siemens operator --(Siemens q) { return new Siemens(q.Value - 1d); }
        public static Siemens operator -(Siemens q) { return new Siemens(-q.Value); }
        public static Siemens operator *(double lhs, Siemens rhs) { return new Siemens(lhs * rhs.Value); }
        public static Siemens operator *(Siemens lhs, double rhs) { return new Siemens(lhs.Value * rhs); }
        public static Siemens operator /(Siemens lhs, double rhs) { return new Siemens(lhs.Value / rhs); }
        public static double operator /(Siemens lhs, Siemens rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Ampere operator *(Siemens lhs, Volt rhs) { return new Ampere(lhs.Value * rhs.Value); }
        public static Ampere operator *(Volt lhs, Siemens rhs) { return new Ampere(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Siemens.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Siemens.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Siemens.Format, Value, Siemens.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Ampere.Sense / Volt.Sense;
        private static readonly int s_family = 25;
        private static double s_factor = Ampere.Factor / Volt.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("S");

        private static readonly Siemens s_one = new Siemens(1d);
        private static readonly Siemens s_zero = new Siemens(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Siemens One { get { return s_one; } }
        public static Siemens Zero { get { return s_zero; } }
        #endregion
    }
}
