/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Ampere : IQuantity<double>, IEquatable<Ampere>, IComparable<Ampere>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Ampere.Sense; } }
        public int UnitFamily { get { return Ampere.Family; } }
        public double UnitFactor { get { return Ampere.Factor; } }
        public string UnitFormat { get { return Ampere.Format; } }
        public SymbolCollection UnitSymbol { get { return Ampere.Symbol; } }

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
            if (q.UnitSense != Ampere.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Ampere\"", q.GetType().Name));
            return new Ampere((Ampere.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Ampere) && Equals((Ampere)obj); }
        public bool /* IEquatable<Ampere> */ Equals(Ampere other) { return this.Value == other.Value; }
        public int /* IComparable<Ampere> */ CompareTo(Ampere other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Comparison
        public static bool operator ==(Ampere lhs, Ampere rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Ampere lhs, Ampere rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Ampere lhs, Ampere rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Ampere lhs, Ampere rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Ampere lhs, Ampere rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Ampere lhs, Ampere rhs) { return lhs.Value >= rhs.Value; }
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
        // Outer:
        public static double operator /(Ampere lhs, Ampere rhs) { return lhs.Value / rhs.Value; }
        public static Coulomb operator *(Ampere lhs, Second rhs) { return new Coulomb(lhs.Value * rhs.Value); }
        public static Coulomb operator *(Second lhs, Ampere rhs) { return new Coulomb(lhs.Value * rhs.Value); }
        public static Siemens operator /(Ampere lhs, Volt rhs) { return new Siemens(lhs.Value / rhs.Value); }
        public static Volt operator /(Ampere lhs, Siemens rhs) { return new Volt(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Ampere.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Ampere.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Ampere.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.ElectricCurrent;
        private static readonly int s_family = 20;
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
