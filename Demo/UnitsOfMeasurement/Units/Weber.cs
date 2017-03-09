/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Weber : IQuantity<double>, IEquatable<Weber>, IComparable<Weber>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Weber.Proxy; } }
        #endregion

        #region Constructor(s)
        public Weber(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Weber(double q) { return new Weber(q); }
        public static Weber From(IQuantity<double> q)
        {
            if (q.Unit.Family != Weber.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Weber\"", q.GetType().Name));
            return new Weber((Weber.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Weber>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Weber) && Equals((Weber)obj); }
        public bool /* IEquatable<Weber> */ Equals(Weber other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Weber>
        public static bool operator ==(Weber lhs, Weber rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Weber lhs, Weber rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Weber lhs, Weber rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Weber lhs, Weber rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Weber lhs, Weber rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Weber lhs, Weber rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Weber> */ CompareTo(Weber other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Weber operator +(Weber lhs, Weber rhs) { return new Weber(lhs.m_value + rhs.m_value); }
        public static Weber operator -(Weber lhs, Weber rhs) { return new Weber(lhs.m_value - rhs.m_value); }
        public static Weber operator ++(Weber q) { return new Weber(q.m_value + 1d); }
        public static Weber operator --(Weber q) { return new Weber(q.m_value - 1d); }
        public static Weber operator -(Weber q) { return new Weber(-q.m_value); }
        public static Weber operator *(double lhs, Weber rhs) { return new Weber(lhs * rhs.m_value); }
        public static Weber operator *(Weber lhs, double rhs) { return new Weber(lhs.m_value * rhs); }
        public static Weber operator /(Weber lhs, double rhs) { return new Weber(lhs.m_value / rhs); }
        public static double operator /(Weber lhs, Weber rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Joule operator *(Weber lhs, Ampere rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Joule operator *(Ampere lhs, Weber rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Second operator /(Weber lhs, Volt rhs) { return new Second(lhs.m_value / rhs.m_value); }
        public static Volt operator /(Weber lhs, Second rhs) { return new Volt(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Weber.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Weber.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Weber.Format, m_value, Weber.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Joule.Sense / Ampere.Sense;
        private static readonly int s_family = 27;
        private static /*mutable*/ double s_factor = Joule.Factor / Ampere.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("Wb");
        private static readonly Unit<double> s_proxy = new Weber_Proxy();

        private static readonly Weber s_one = new Weber(1d);
        private static readonly Weber s_zero = new Weber(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Weber One { get { return s_one; } }
        public static Weber Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Weber_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Weber.Family; } }
        public override Dimension Sense { get { return Weber.Sense; } }
        public override SymbolCollection Symbol { get { return Weber.Symbol; } }
        public override double Factor { get { return Weber.Factor; } set { Weber.Factor = value; } }
        public override string Format { get { return Weber.Format; } set { Weber.Format = value; } }
        #endregion

        #region Constructor(s)
        public Weber_Proxy() :
            base(typeof(Weber))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Weber(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Weber.From(quantity);
        }
        #endregion
    }
}
