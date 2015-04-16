/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Joule : IQuantity<double>, IEquatable<Joule>, IComparable<Joule>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public Joule(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Joule(double q) { return new Joule(q); }
        public static Joule From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != Joule.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"Joule\"", q.GetType().Name));
            return new Joule((Joule.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Joule>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Joule) && Equals((Joule)obj); }
        public bool /* IEquatable<Joule> */ Equals(Joule other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Joule>
        public static bool operator ==(Joule lhs, Joule rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Joule lhs, Joule rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Joule lhs, Joule rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Joule lhs, Joule rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Joule lhs, Joule rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Joule lhs, Joule rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Joule> */ CompareTo(Joule other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Joule operator +(Joule lhs, Joule rhs) { return new Joule(lhs.Value + rhs.Value); }
        public static Joule operator -(Joule lhs, Joule rhs) { return new Joule(lhs.Value - rhs.Value); }
        public static Joule operator ++(Joule q) { return new Joule(q.Value + 1d); }
        public static Joule operator --(Joule q) { return new Joule(q.Value - 1d); }
        public static Joule operator -(Joule q) { return new Joule(-q.Value); }
        public static Joule operator *(double lhs, Joule rhs) { return new Joule(lhs * rhs.Value); }
        public static Joule operator *(Joule lhs, double rhs) { return new Joule(lhs.Value * rhs); }
        public static Joule operator /(Joule lhs, double rhs) { return new Joule(lhs.Value / rhs); }
        public static double operator /(Joule lhs, Joule rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Meter operator /(Joule lhs, Newton rhs) { return new Meter(lhs.Value / rhs.Value); }
        public static Newton operator /(Joule lhs, Meter rhs) { return new Newton(lhs.Value / rhs.Value); }
        public static Watt operator /(Joule lhs, Second rhs) { return new Watt(lhs.Value / rhs.Value); }
        public static Second operator /(Joule lhs, Watt rhs) { return new Second(lhs.Value / rhs.Value); }
        public static Joule_Kelvin operator /(Joule lhs, DegKelvin rhs) { return new Joule_Kelvin(lhs.Value / rhs.Value); }
        public static DegKelvin operator /(Joule lhs, Joule_Kelvin rhs) { return new DegKelvin(lhs.Value / rhs.Value); }
        public static Volt operator /(Joule lhs, Coulomb rhs) { return new Volt(lhs.Value / rhs.Value); }
        public static Coulomb operator /(Joule lhs, Volt rhs) { return new Coulomb(lhs.Value / rhs.Value); }
        public static Weber operator /(Joule lhs, Ampere rhs) { return new Weber(lhs.Value / rhs.Value); }
        public static Ampere operator /(Joule lhs, Weber rhs) { return new Ampere(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Joule.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Joule.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Joule.Format, Value, Joule.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Newton.Sense * Meter.Sense;
        private static readonly int s_family = 16;
        private static double s_factor = Newton.Factor * Meter.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("J");

        private static readonly Joule s_one = new Joule(1d);
        private static readonly Joule s_zero = new Joule(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Joule One { get { return s_one; } }
        public static Joule Zero { get { return s_zero; } }
        #endregion
    }
}
