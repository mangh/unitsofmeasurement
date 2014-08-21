/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Candela : IQuantity<double>, IEquatable<Candela>, IComparable<Candela>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Candela.Sense; } }
        public int UnitFamily { get { return Candela.Family; } }
        public double UnitFactor { get { return Candela.Factor; } }
        public string UnitFormat { get { return Candela.Format; } }
        public SymbolCollection UnitSymbol { get { return Candela.Symbol; } }

        #endregion

        #region Constructor(s)
        public Candela(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Candela(double q) { return new Candela(q); }
        public static Candela From(IQuantity<double> q)
        {
            if (q.UnitSense != Candela.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Candela\"", q.GetType().Name));
            return new Candela((Candela.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Candela) && Equals((Candela)obj); }
        public bool /* IEquatable<Candela> */ Equals(Candela other) { return this.Value == other.Value; }
        public int /* IComparable<Candela> */ CompareTo(Candela other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Comparison
        public static bool operator ==(Candela lhs, Candela rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Candela lhs, Candela rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Candela lhs, Candela rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Candela lhs, Candela rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Candela lhs, Candela rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Candela lhs, Candela rhs) { return lhs.Value >= rhs.Value; }
        #endregion

        #region Arithmetic
        // Inner:
        public static Candela operator +(Candela lhs, Candela rhs) { return new Candela(lhs.Value + rhs.Value); }
        public static Candela operator -(Candela lhs, Candela rhs) { return new Candela(lhs.Value - rhs.Value); }
        public static Candela operator ++(Candela q) { return new Candela(q.Value + 1d); }
        public static Candela operator --(Candela q) { return new Candela(q.Value - 1d); }
        public static Candela operator -(Candela q) { return new Candela(-q.Value); }
        public static Candela operator *(double lhs, Candela rhs) { return new Candela(lhs * rhs.Value); }
        public static Candela operator *(Candela lhs, double rhs) { return new Candela(lhs.Value * rhs); }
        public static Candela operator /(Candela lhs, double rhs) { return new Candela(lhs.Value / rhs); }
        // Outer:
        public static double operator /(Candela lhs, Candela rhs) { return lhs.Value / rhs.Value; }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Candela.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Candela.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Candela.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.LuminousIntensity;
        private static readonly int s_family = 22;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("cd");

        private static readonly Candela s_one = new Candela(1d);
        private static readonly Candela s_zero = new Candela(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Candela One { get { return s_one; } }
        public static Candela Zero { get { return s_zero; } }
        #endregion
    }
}
