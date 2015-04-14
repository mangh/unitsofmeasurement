/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Poundal : IQuantity<double>, IEquatable<Poundal>, IComparable<Poundal>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Poundal.Sense; } }
        public int UnitFamily { get { return Poundal.Family; } }
        public double UnitFactor { get { return Poundal.Factor; } }
        public string UnitFormat { get { return Poundal.Format; } }
        public SymbolCollection UnitSymbol { get { return Poundal.Symbol; } }

        #endregion

        #region Constructor(s)
        public Poundal(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Poundal(double q) { return new Poundal(q); }
        public static explicit operator Poundal(PoundForce q) { return new Poundal((Poundal.Factor / PoundForce.Factor) * q.Value); }
        public static explicit operator Poundal(Newton q) { return new Poundal((Poundal.Factor / Newton.Factor) * q.Value); }
        public static explicit operator Poundal(Dyne q) { return new Poundal((Poundal.Factor / Dyne.Factor) * q.Value); }
        public static Poundal From(IQuantity<double> q)
        {
            if (q.UnitSense != Poundal.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Poundal\"", q.GetType().Name));
            return new Poundal((Poundal.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Poundal>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Poundal) && Equals((Poundal)obj); }
        public bool /* IEquatable<Poundal> */ Equals(Poundal other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Poundal>
        public static bool operator ==(Poundal lhs, Poundal rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Poundal lhs, Poundal rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Poundal lhs, Poundal rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Poundal lhs, Poundal rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Poundal lhs, Poundal rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Poundal lhs, Poundal rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Poundal> */ CompareTo(Poundal other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Poundal operator +(Poundal lhs, Poundal rhs) { return new Poundal(lhs.Value + rhs.Value); }
        public static Poundal operator -(Poundal lhs, Poundal rhs) { return new Poundal(lhs.Value - rhs.Value); }
        public static Poundal operator ++(Poundal q) { return new Poundal(q.Value + 1d); }
        public static Poundal operator --(Poundal q) { return new Poundal(q.Value - 1d); }
        public static Poundal operator -(Poundal q) { return new Poundal(-q.Value); }
        public static Poundal operator *(double lhs, Poundal rhs) { return new Poundal(lhs * rhs.Value); }
        public static Poundal operator *(Poundal lhs, double rhs) { return new Poundal(lhs.Value * rhs); }
        public static Poundal operator /(Poundal lhs, double rhs) { return new Poundal(lhs.Value / rhs); }
        public static double operator /(Poundal lhs, Poundal rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Poundal.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Poundal.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Poundal.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Newton.Sense;
        private static readonly int s_family = Newton.Family;
        private static double s_factor = Newton.Factor / 0.138254954376d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("pdl");

        private static readonly Poundal s_one = new Poundal(1d);
        private static readonly Poundal s_zero = new Poundal(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Poundal One { get { return s_one; } }
        public static Poundal Zero { get { return s_zero; } }
        #endregion
    }
}
