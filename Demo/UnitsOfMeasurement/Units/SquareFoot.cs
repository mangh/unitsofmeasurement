/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct SquareFoot : IQuantity<double>, IEquatable<SquareFoot>, IComparable<SquareFoot>, IFormattable
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        #endregion

        #region Constructor(s)
        public SquareFoot(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator SquareFoot(double q) { return new SquareFoot(q); }
        public static explicit operator SquareFoot(SquareMeter q) { return new SquareFoot((SquareFoot.Factor / SquareMeter.Factor) * q.Value); }
        public static SquareFoot From(IQuantity<double> q)
        {
            Unit<double> source = new Unit<double>(q);
            if (source.Family != SquareFoot.Family) throw new InvalidOperationException(String.Format("Cannot convert \"{0}\" to \"SquareFoot\"", q.GetType().Name));
            return new SquareFoot((SquareFoot.Factor / source.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<SquareFoot>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is SquareFoot) && Equals((SquareFoot)obj); }
        public bool /* IEquatable<SquareFoot> */ Equals(SquareFoot other) { return this.Value == other.Value; }
        #endregion

        #region Comparison / IComparable<SquareFoot>
        public static bool operator ==(SquareFoot lhs, SquareFoot rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(SquareFoot lhs, SquareFoot rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(SquareFoot lhs, SquareFoot rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(SquareFoot lhs, SquareFoot rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(SquareFoot lhs, SquareFoot rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(SquareFoot lhs, SquareFoot rhs) { return lhs.Value >= rhs.Value; }
        public int /* IComparable<SquareFoot> */ CompareTo(SquareFoot other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static SquareFoot operator +(SquareFoot lhs, SquareFoot rhs) { return new SquareFoot(lhs.Value + rhs.Value); }
        public static SquareFoot operator -(SquareFoot lhs, SquareFoot rhs) { return new SquareFoot(lhs.Value - rhs.Value); }
        public static SquareFoot operator ++(SquareFoot q) { return new SquareFoot(q.Value + 1d); }
        public static SquareFoot operator --(SquareFoot q) { return new SquareFoot(q.Value - 1d); }
        public static SquareFoot operator -(SquareFoot q) { return new SquareFoot(-q.Value); }
        public static SquareFoot operator *(double lhs, SquareFoot rhs) { return new SquareFoot(lhs * rhs.Value); }
        public static SquareFoot operator *(SquareFoot lhs, double rhs) { return new SquareFoot(lhs.Value * rhs); }
        public static SquareFoot operator /(SquareFoot lhs, double rhs) { return new SquareFoot(lhs.Value / rhs); }
        public static double operator /(SquareFoot lhs, SquareFoot rhs) { return lhs.Value / rhs.Value; }
        // Outer:
        public static Foot operator /(SquareFoot lhs, Foot rhs) { return new Foot(lhs.Value / rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(SquareFoot.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(SquareFoot.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return String.Format(fp, format ?? SquareFoot.Format, Value, SquareFoot.Symbol[0]);
        }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Foot.Sense * Foot.Sense;
        private static readonly int s_family = SquareMeter.Family;
        private static double s_factor = Foot.Factor * Foot.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("ft\u00B2", "sq ft");

        private static readonly SquareFoot s_one = new SquareFoot(1d);
        private static readonly SquareFoot s_zero = new SquareFoot(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static SquareFoot One { get { return s_one; } }
        public static SquareFoot Zero { get { return s_zero; } }
        #endregion
    }
}
