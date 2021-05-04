/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Yard : IQuantity<double>, IEquatable<Yard>, IComparable<Yard>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Yard.Proxy; } }
        #endregion

        #region Constructor(s)
        public Yard(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Yard(double q) { return new Yard(q); }
        public static explicit operator Yard(Mile q) { return new Yard((Yard.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Yard(Kilometer q) { return new Yard((Yard.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Yard(Millimeter q) { return new Yard((Yard.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Yard(Centimeter q) { return new Yard((Yard.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Yard(Meter q) { return new Yard((Yard.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Yard(Inch q) { return new Yard((Yard.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Yard(Foot q) { return new Yard((Yard.Factor / Foot.Factor) * q.m_value); }
        public static Yard From(IQuantity<double> q)
        {
            if (q.Unit.Family != Yard.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Yard\"", q.GetType().Name));
            }
            return new Yard((Yard.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Yard>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Yard) && Equals((Yard)obj); }
        public bool /* IEquatable<Yard> */ Equals(Yard other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Yard>
        public static bool operator ==(Yard lhs, Yard rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Yard lhs, Yard rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Yard lhs, Yard rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Yard lhs, Yard rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Yard lhs, Yard rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Yard lhs, Yard rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Yard> */ CompareTo(Yard other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Yard operator +(Yard lhs, Yard rhs) { return new Yard(lhs.m_value + rhs.m_value); }
        public static Yard operator -(Yard lhs, Yard rhs) { return new Yard(lhs.m_value - rhs.m_value); }
        public static Yard operator ++(Yard q) { return new Yard(q.m_value + 1d); }
        public static Yard operator --(Yard q) { return new Yard(q.m_value - 1d); }
        public static Yard operator -(Yard q) { return new Yard(-q.m_value); }
        public static Yard operator *(double lhs, Yard rhs) { return new Yard(lhs * rhs.m_value); }
        public static Yard operator *(Yard lhs, double rhs) { return new Yard(lhs.m_value * rhs); }
        public static Yard operator /(Yard lhs, double rhs) { return new Yard(lhs.m_value / rhs); }
        public static double operator /(Yard lhs, Yard rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Yard.Format, q, Yard.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Foot.Sense;
        public const int Family = Meter.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("yd");
        public static readonly Unit<double> Proxy = new Yard_Proxy();
        public const double Factor = Foot.Factor / 3d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Yard One = new Yard(1d);
        public static readonly Yard Zero = new Yard(0d);
        #endregion
    }

    public partial class Yard_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Yard.Sense; } }
        public override int Family { get { return Yard.Family; } }
        public override double Factor { get { return Yard.Factor; } }
        public override SymbolCollection Symbol { get { return Yard.Symbol; } }
        public override string Format { get { return Yard.Format; } set { Yard.Format = value; } }
        #endregion

        #region Constructor(s)
        public Yard_Proxy() :
            base(typeof(Yard))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Yard(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Yard.From(quantity);
        }
        #endregion
    }
}
