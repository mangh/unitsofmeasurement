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
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return SquareFoot.Proxy; } }
        #endregion

        #region Constructor(s)
        public SquareFoot(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator SquareFoot(double q) { return new SquareFoot(q); }
        public static explicit operator SquareFoot(SquareMeter q) { return new SquareFoot((SquareFoot.Factor / SquareMeter.Factor) * q.m_value); }
        public static SquareFoot From(IQuantity<double> q)
        {
            if (q.Unit.Family != SquareFoot.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"SquareFoot\"", q.GetType().Name));
            return new SquareFoot((SquareFoot.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<SquareFoot>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is SquareFoot) && Equals((SquareFoot)obj); }
        public bool /* IEquatable<SquareFoot> */ Equals(SquareFoot other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<SquareFoot>
        public static bool operator ==(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<SquareFoot> */ CompareTo(SquareFoot other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static SquareFoot operator +(SquareFoot lhs, SquareFoot rhs) { return new SquareFoot(lhs.m_value + rhs.m_value); }
        public static SquareFoot operator -(SquareFoot lhs, SquareFoot rhs) { return new SquareFoot(lhs.m_value - rhs.m_value); }
        public static SquareFoot operator ++(SquareFoot q) { return new SquareFoot(q.m_value + 1d); }
        public static SquareFoot operator --(SquareFoot q) { return new SquareFoot(q.m_value - 1d); }
        public static SquareFoot operator -(SquareFoot q) { return new SquareFoot(-q.m_value); }
        public static SquareFoot operator *(double lhs, SquareFoot rhs) { return new SquareFoot(lhs * rhs.m_value); }
        public static SquareFoot operator *(SquareFoot lhs, double rhs) { return new SquareFoot(lhs.m_value * rhs); }
        public static SquareFoot operator /(SquareFoot lhs, double rhs) { return new SquareFoot(lhs.m_value / rhs); }
        public static double operator /(SquareFoot lhs, SquareFoot rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Foot operator /(SquareFoot lhs, Foot rhs) { return new Foot(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(SquareFoot.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(SquareFoot.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? SquareFoot.Format, m_value, SquareFoot.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Foot.Sense * Foot.Sense;
        private static readonly int s_family = SquareMeter.Family;
        private static /*mutable*/ double s_factor = Foot.Factor * Foot.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("ft\u00B2", "sq ft");
        private static readonly Unit<double> s_proxy = new SquareFoot_Proxy();

        private static readonly SquareFoot s_one = new SquareFoot(1d);
        private static readonly SquareFoot s_zero = new SquareFoot(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static SquareFoot One { get { return s_one; } }
        public static SquareFoot Zero { get { return s_zero; } }
        #endregion
    }

    public partial class SquareFoot_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return SquareFoot.Family; } }
        public override Dimension Sense { get { return SquareFoot.Sense; } }
        public override SymbolCollection Symbol { get { return SquareFoot.Symbol; } }
        public override double Factor { get { return SquareFoot.Factor; } set { SquareFoot.Factor = value; } }
        public override string Format { get { return SquareFoot.Format; } set { SquareFoot.Format = value; } }
        #endregion

        #region Constructor(s)
        public SquareFoot_Proxy() :
            base(typeof(SquareFoot))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new SquareFoot(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return SquareFoot.From(quantity);
        }
        #endregion
    }
}
