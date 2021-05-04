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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Weber.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Weber\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Weber.Format, q, Weber.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Joule.Sense / Ampere.Sense;
        public const int Family = 27;
        public static readonly SymbolCollection Symbol = new SymbolCollection("Wb");
        public static readonly Unit<double> Proxy = new Weber_Proxy();
        public const double Factor = Joule.Factor / Ampere.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Weber One = new Weber(1d);
        public static readonly Weber Zero = new Weber(0d);
        #endregion
    }

    public partial class Weber_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Weber.Sense; } }
        public override int Family { get { return Weber.Family; } }
        public override double Factor { get { return Weber.Factor; } }
        public override SymbolCollection Symbol { get { return Weber.Symbol; } }
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
