/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Dyne : IQuantity<double>, IEquatable<Dyne>, IComparable<Dyne>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return Dyne.Sense; } }
        public int UnitFamily { get { return Dyne.Family; } }
        public double UnitFactor { get { return Dyne.Factor; } }
        public string UnitFormat { get { return Dyne.Format; } }
        public SymbolCollection UnitSymbol { get { return Dyne.Symbol; } }

        #endregion

        #region Constructor(s)
        public Dyne(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Dyne(double q) { return new Dyne(q); }
        public static explicit operator Dyne(Poundal q) { return new Dyne((Dyne.Factor / Poundal.Factor) * q.Value); }
        public static explicit operator Dyne(PoundForce q) { return new Dyne((Dyne.Factor / PoundForce.Factor) * q.Value); }
        public static explicit operator Dyne(Newton q) { return new Dyne((Dyne.Factor / Newton.Factor) * q.Value); }
        public static Dyne From(IQuantity<double> q)
        {
            if (q.UnitSense != Dyne.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Dyne\"", q.GetType().Name));
            return new Dyne((Dyne.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Dyne>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Dyne) && Equals((Dyne)obj); }
        public bool /* IEquatable<Dyne> */ Equals(Dyne other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<Dyne>
        public static bool operator ==(Dyne lhs, Dyne rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(Dyne lhs, Dyne rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(Dyne lhs, Dyne rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(Dyne lhs, Dyne rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(Dyne lhs, Dyne rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(Dyne lhs, Dyne rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<Dyne> */ CompareTo(Dyne other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Dyne operator +(Dyne lhs, Dyne rhs) { return new Dyne(lhs.Value + rhs.Value); }
        public static Dyne operator -(Dyne lhs, Dyne rhs) { return new Dyne(lhs.Value - rhs.Value); }
        public static Dyne operator ++(Dyne q) { return new Dyne(q.Value + 1d); }
        public static Dyne operator --(Dyne q) { return new Dyne(q.Value - 1d); }
        public static Dyne operator -(Dyne q) { return new Dyne(-q.Value); }
        public static Dyne operator *(double lhs, Dyne rhs) { return new Dyne(lhs * rhs.Value); }
        public static Dyne operator *(Dyne lhs, double rhs) { return new Dyne(lhs.Value * rhs); }
        public static Dyne operator /(Dyne lhs, double rhs) { return new Dyne(lhs.Value / rhs); }
        public static double operator /(Dyne lhs, Dyne rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, Dyne.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, Dyne.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Dyne.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Newton.Sense;
        private static readonly int s_family = Newton.Family;
        private static double s_factor = 100000d * Newton.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("dyn");

        private static readonly Dyne s_one = new Dyne(1d);
        private static readonly Dyne s_zero = new Dyne(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static Dyne One { get { return s_one; } }
        public static Dyne Zero { get { return s_zero; } }
        #endregion
    }
}
