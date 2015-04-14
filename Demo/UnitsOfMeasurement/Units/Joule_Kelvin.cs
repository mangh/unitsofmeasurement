/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Joule_Kelvin : IQuantity<double>, IEquatable<Joule_Kelvin>, IComparable<Joule_Kelvin>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Joule_Kelvin.Sense; } }
        public int UnitFamily { get { return Joule_Kelvin.Family; } }
        public double UnitFactor { get { return Joule_Kelvin.Factor; } }
        public string UnitFormat { get { return Joule_Kelvin.Format; } }
        public SymbolCollection UnitSymbol { get { return Joule_Kelvin.Symbol; } }

        #endregion

        #region Constructor(s)
        public Joule_Kelvin(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Joule_Kelvin(double q) { return new Joule_Kelvin(q); }
        public static Joule_Kelvin From(IQuantity<double> q)
        {
            if (q.UnitSense != Joule_Kelvin.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Joule_Kelvin\"", q.GetType().Name));
            return new Joule_Kelvin((Joule_Kelvin.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Joule_Kelvin>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Joule_Kelvin) && Equals((Joule_Kelvin)obj); }
        public bool /* IEquatable<Joule_Kelvin> */ Equals(Joule_Kelvin other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Joule_Kelvin>
        public static bool operator ==(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Joule_Kelvin> */ CompareTo(Joule_Kelvin other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Joule_Kelvin operator +(Joule_Kelvin lhs, Joule_Kelvin rhs) { return new Joule_Kelvin(lhs.Value + rhs.Value); }
        public static Joule_Kelvin operator -(Joule_Kelvin lhs, Joule_Kelvin rhs) { return new Joule_Kelvin(lhs.Value - rhs.Value); }
        public static Joule_Kelvin operator ++(Joule_Kelvin q) { return new Joule_Kelvin(q.Value + 1d); }
        public static Joule_Kelvin operator --(Joule_Kelvin q) { return new Joule_Kelvin(q.Value - 1d); }
        public static Joule_Kelvin operator -(Joule_Kelvin q) { return new Joule_Kelvin(-q.Value); }
        public static Joule_Kelvin operator *(double lhs, Joule_Kelvin rhs) { return new Joule_Kelvin(lhs * rhs.Value); }
        public static Joule_Kelvin operator *(Joule_Kelvin lhs, double rhs) { return new Joule_Kelvin(lhs.Value * rhs); }
        public static Joule_Kelvin operator /(Joule_Kelvin lhs, double rhs) { return new Joule_Kelvin(lhs.Value / rhs); }
        public static double operator /(Joule_Kelvin lhs, Joule_Kelvin rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Joule operator *(Joule_Kelvin lhs, DegKelvin rhs) { return new Joule(lhs.Value * rhs.Value); }
        public static Joule operator *(DegKelvin lhs, Joule_Kelvin rhs) { return new Joule(lhs.Value * rhs.Value); }
        public static Joule_Kelvin_Kilogram operator /(Joule_Kelvin lhs, Kilogram rhs) { return new Joule_Kelvin_Kilogram(lhs.Value / rhs.Value); }
        public static Kilogram operator /(Joule_Kelvin lhs, Joule_Kelvin_Kilogram rhs) { return new Kilogram(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Joule_Kelvin.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Joule_Kelvin.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? Joule_Kelvin.Format, Value, Joule_Kelvin.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Joule.Sense / DegKelvin.Sense;
        private static readonly int s_family = 19;
        private static double s_factor = Joule.Factor / DegKelvin.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("J/K");

        private static readonly Joule_Kelvin s_one = new Joule_Kelvin(1d);
        private static readonly Joule_Kelvin s_zero = new Joule_Kelvin(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Joule_Kelvin One { get { return s_one; } }
        public static Joule_Kelvin Zero { get { return s_zero; } }
        #endregion
    }
}
