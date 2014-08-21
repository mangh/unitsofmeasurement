/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct Kilogram : IQuantity<double>, IEquatable<Kilogram>, IComparable<Kilogram>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Kilogram.Sense; } }
        public int UnitFamily { get { return Kilogram.Family; } }
        public double UnitFactor { get { return Kilogram.Factor; } }
        public string UnitFormat { get { return Kilogram.Format; } }
        public SymbolCollection UnitSymbol { get { return Kilogram.Symbol; } }

        #endregion

        #region Constructor(s)
        public Kilogram(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Kilogram(double q) { return new Kilogram(q); }
        public static Kilogram From(IQuantity<double> q)
        {
            if (q.UnitSense != Kilogram.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Kilogram\"", q.GetType().Name));
            return new Kilogram((Kilogram.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Kilogram) && Equals((Kilogram)obj); }
        public bool /* IEquatable<Kilogram> */ Equals(Kilogram other) { return this.Value == other.Value; }
        public int /* IComparable<Kilogram> */ CompareTo(Kilogram other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Comparison
        public static bool operator ==(Kilogram lhs, Kilogram rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Kilogram lhs, Kilogram rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Kilogram lhs, Kilogram rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Kilogram lhs, Kilogram rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Kilogram lhs, Kilogram rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Kilogram lhs, Kilogram rhs) { return lhs.Value >= rhs.Value; }
        #endregion

        #region Arithmetic
        // Inner:
        public static Kilogram operator +(Kilogram lhs, Kilogram rhs) { return new Kilogram(lhs.Value + rhs.Value); }
        public static Kilogram operator -(Kilogram lhs, Kilogram rhs) { return new Kilogram(lhs.Value - rhs.Value); }
        public static Kilogram operator ++(Kilogram q) { return new Kilogram(q.Value + 1d); }
        public static Kilogram operator --(Kilogram q) { return new Kilogram(q.Value - 1d); }
        public static Kilogram operator -(Kilogram q) { return new Kilogram(-q.Value); }
        public static Kilogram operator *(double lhs, Kilogram rhs) { return new Kilogram(lhs * rhs.Value); }
        public static Kilogram operator *(Kilogram lhs, double rhs) { return new Kilogram(lhs.Value * rhs); }
        public static Kilogram operator /(Kilogram lhs, double rhs) { return new Kilogram(lhs.Value / rhs); }
        // Outer:
        public static double operator /(Kilogram lhs, Kilogram rhs) { return lhs.Value / rhs.Value; }
        public static Newton operator *(Kilogram lhs, Meter_Sec2 rhs) { return new Newton(lhs.Value * rhs.Value); }
        public static Newton operator *(Meter_Sec2 lhs, Kilogram rhs) { return new Newton(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Kilogram.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Kilogram.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Kilogram.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Dimension.Mass;
        private static readonly int s_family = 2;
        private static double s_factor = 1d;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("kg");

        private static readonly Kilogram s_one = new Kilogram(1d);
        private static readonly Kilogram s_zero = new Kilogram(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Kilogram One { get { return s_one; } }
        public static Kilogram Zero { get { return s_zero; } }
        #endregion
    }
}
