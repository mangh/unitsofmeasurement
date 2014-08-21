/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Coulomb : IQuantity<double>, IEquatable<Coulomb>, IComparable<Coulomb>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Coulomb.Sense; } }
        public int UnitFamily { get { return Coulomb.Family; } }
        public double UnitFactor { get { return Coulomb.Factor; } }
        public string UnitFormat { get { return Coulomb.Format; } }
        public SymbolCollection UnitSymbol { get { return Coulomb.Symbol; } }

        #endregion

        #region Constructor(s)
        public Coulomb(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Coulomb(double q) { return new Coulomb(q); }
        public static Coulomb From(IQuantity<double> q)
        {
            if (q.UnitSense != Coulomb.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Coulomb\"", q.GetType().Name));
            return new Coulomb((Coulomb.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Coulomb) && Equals((Coulomb)obj); }
        public bool /* IEquatable<Coulomb> */ Equals(Coulomb other) { return this.Value == other.Value; }
        public int /* IComparable<Coulomb> */ CompareTo(Coulomb other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Comparison
        public static bool operator ==(Coulomb lhs, Coulomb rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Coulomb lhs, Coulomb rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Coulomb lhs, Coulomb rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Coulomb lhs, Coulomb rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Coulomb lhs, Coulomb rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Coulomb lhs, Coulomb rhs) { return lhs.Value >= rhs.Value; }
        #endregion

        #region Arithmetic
        // Inner:
        public static Coulomb operator +(Coulomb lhs, Coulomb rhs) { return new Coulomb(lhs.Value + rhs.Value); }
        public static Coulomb operator -(Coulomb lhs, Coulomb rhs) { return new Coulomb(lhs.Value - rhs.Value); }
        public static Coulomb operator ++(Coulomb q) { return new Coulomb(q.Value + 1d); }
        public static Coulomb operator --(Coulomb q) { return new Coulomb(q.Value - 1d); }
        public static Coulomb operator -(Coulomb q) { return new Coulomb(-q.Value); }
        public static Coulomb operator *(double lhs, Coulomb rhs) { return new Coulomb(lhs * rhs.Value); }
        public static Coulomb operator *(Coulomb lhs, double rhs) { return new Coulomb(lhs.Value * rhs); }
        public static Coulomb operator /(Coulomb lhs, double rhs) { return new Coulomb(lhs.Value / rhs); }
        // Outer:
        public static double operator /(Coulomb lhs, Coulomb rhs) { return lhs.Value / rhs.Value; }
        public static Second operator /(Coulomb lhs, Ampere rhs) { return new Second(lhs.Value / rhs.Value); }
        public static Ampere operator /(Coulomb lhs, Second rhs) { return new Ampere(lhs.Value / rhs.Value); }
        public static Farad operator /(Coulomb lhs, Volt rhs) { return new Farad(lhs.Value / rhs.Value); }
        public static Volt operator /(Coulomb lhs, Farad rhs) { return new Volt(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Coulomb.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Coulomb.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Coulomb.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Ampere.Sense * Second.Sense;
        private static readonly int s_family = 56;
        private static double s_factor = Ampere.Factor * Second.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("C");

        private static readonly Coulomb s_one = new Coulomb(1d);
        private static readonly Coulomb s_zero = new Coulomb(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Coulomb One { get { return s_one; } }
        public static Coulomb Zero { get { return s_zero; } }
        #endregion
    }
}
