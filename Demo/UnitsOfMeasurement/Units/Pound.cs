/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Pound : IQuantity<double>, IEquatable<Pound>, IComparable<Pound>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Pound.Proxy; } }
        #endregion

        #region Constructor(s)
        public Pound(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Pound(double q) { return new Pound(q); }
        public static explicit operator Pound(Ounce q) { return new Pound((Pound.Factor / Ounce.Factor) * q.m_value); }
        public static explicit operator Pound(Tonne q) { return new Pound((Pound.Factor / Tonne.Factor) * q.m_value); }
        public static explicit operator Pound(Gram q) { return new Pound((Pound.Factor / Gram.Factor) * q.m_value); }
        public static explicit operator Pound(Kilogram q) { return new Pound((Pound.Factor / Kilogram.Factor) * q.m_value); }
        public static Pound From(IQuantity<double> q)
        {
            if (q.Unit.Family != Pound.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Pound\"", q.GetType().Name));
            }
            return new Pound((Pound.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Pound>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Pound) && Equals((Pound)obj); }
        public bool /* IEquatable<Pound> */ Equals(Pound other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Pound>
        public static bool operator ==(Pound lhs, Pound rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Pound lhs, Pound rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Pound lhs, Pound rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Pound lhs, Pound rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Pound lhs, Pound rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Pound lhs, Pound rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Pound> */ CompareTo(Pound other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Pound operator +(Pound lhs, Pound rhs) { return new Pound(lhs.m_value + rhs.m_value); }
        public static Pound operator -(Pound lhs, Pound rhs) { return new Pound(lhs.m_value - rhs.m_value); }
        public static Pound operator ++(Pound q) { return new Pound(q.m_value + 1d); }
        public static Pound operator --(Pound q) { return new Pound(q.m_value - 1d); }
        public static Pound operator -(Pound q) { return new Pound(-q.m_value); }
        public static Pound operator *(double lhs, Pound rhs) { return new Pound(lhs * rhs.m_value); }
        public static Pound operator *(Pound lhs, double rhs) { return new Pound(lhs.m_value * rhs); }
        public static Pound operator /(Pound lhs, double rhs) { return new Pound(lhs.m_value / rhs); }
        public static double operator /(Pound lhs, Pound rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Pound.Format, q, Pound.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Kilogram.Sense;
        public const int Family = Kilogram.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("lb");
        public static readonly Unit<double> Proxy = new Pound_Proxy();
        public const double Factor = Kilogram.Factor / 0.45359237d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Pound One = new Pound(1d);
        public static readonly Pound Zero = new Pound(0d);
        #endregion
    }

    public partial class Pound_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Pound.Sense; } }
        public override int Family { get { return Pound.Family; } }
        public override double Factor { get { return Pound.Factor; } }
        public override SymbolCollection Symbol { get { return Pound.Symbol; } }
        public override string Format { get { return Pound.Format; } set { Pound.Format = value; } }
        #endregion

        #region Constructor(s)
        public Pound_Proxy() :
            base(typeof(Pound))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Pound(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Pound.From(quantity);
        }
        #endregion
    }
}
