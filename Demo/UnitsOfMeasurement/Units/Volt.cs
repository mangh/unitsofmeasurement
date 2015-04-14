/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Volt : IQuantity<double>, IEquatable<Volt>, IComparable<Volt>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Volt.Sense; } }
        public int UnitFamily { get { return Volt.Family; } }
        public double UnitFactor { get { return Volt.Factor; } }
        public string UnitFormat { get { return Volt.Format; } }
        public SymbolCollection UnitSymbol { get { return Volt.Symbol; } }

        #endregion

        #region Constructor(s)
        public Volt(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Volt(double q) { return new Volt(q); }
        public static Volt From(IQuantity<double> q)
        {
            if (q.UnitSense != Volt.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Volt\"", q.GetType().Name));
            return new Volt((Volt.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Volt>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Volt) && Equals((Volt)obj); }
        public bool /* IEquatable<Volt> */ Equals(Volt other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Volt>
        public static bool operator ==(Volt lhs, Volt rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Volt lhs, Volt rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Volt lhs, Volt rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Volt lhs, Volt rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Volt lhs, Volt rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Volt lhs, Volt rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Volt> */ CompareTo(Volt other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Volt operator +(Volt lhs, Volt rhs) { return new Volt(lhs.Value + rhs.Value); }
        public static Volt operator -(Volt lhs, Volt rhs) { return new Volt(lhs.Value - rhs.Value); }
        public static Volt operator ++(Volt q) { return new Volt(q.Value + 1d); }
        public static Volt operator --(Volt q) { return new Volt(q.Value - 1d); }
        public static Volt operator -(Volt q) { return new Volt(-q.Value); }
        public static Volt operator *(double lhs, Volt rhs) { return new Volt(lhs * rhs.Value); }
        public static Volt operator *(Volt lhs, double rhs) { return new Volt(lhs.Value * rhs); }
        public static Volt operator /(Volt lhs, double rhs) { return new Volt(lhs.Value / rhs); }
        public static double operator /(Volt lhs, Volt rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Joule operator *(Volt lhs, Coulomb rhs) { return new Joule(lhs.Value * rhs.Value); }
        public static Joule operator *(Coulomb lhs, Volt rhs) { return new Joule(lhs.Value * rhs.Value); }
        public static Watt operator *(Volt lhs, Ampere rhs) { return new Watt(lhs.Value * rhs.Value); }
        public static Watt operator *(Ampere lhs, Volt rhs) { return new Watt(lhs.Value * rhs.Value); }
        public static Ohm operator /(Volt lhs, Ampere rhs) { return new Ohm(lhs.Value / rhs.Value); }
        public static Ampere operator /(Volt lhs, Ohm rhs) { return new Ampere(lhs.Value / rhs.Value); }
        public static Weber operator *(Volt lhs, Second rhs) { return new Weber(lhs.Value * rhs.Value); }
        public static Weber operator *(Second lhs, Volt rhs) { return new Weber(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Volt.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Volt.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Volt.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Joule.Sense / Coulomb.Sense;
        private static readonly int s_family = 23;
        private static double s_factor = Joule.Factor / Coulomb.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("V");

        private static readonly Volt s_one = new Volt(1d);
        private static readonly Volt s_zero = new Volt(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Volt One { get { return s_one; } }
        public static Volt Zero { get { return s_zero; } }
        #endregion
    }
}
