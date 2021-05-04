/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Inch : IQuantity<double>, IEquatable<Inch>, IComparable<Inch>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Inch.Proxy; } }
        #endregion

        #region Constructor(s)
        public Inch(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Inch(double q) { return new Inch(q); }
        public static explicit operator Inch(Foot q) { return new Inch((Inch.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Inch(Yard q) { return new Inch((Inch.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Inch(Mile q) { return new Inch((Inch.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Inch(Kilometer q) { return new Inch((Inch.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Inch(Millimeter q) { return new Inch((Inch.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Inch(Centimeter q) { return new Inch((Inch.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Inch(Meter q) { return new Inch((Inch.Factor / Meter.Factor) * q.m_value); }
        public static Inch From(IQuantity<double> q)
        {
            if (q.Unit.Family != Inch.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Inch\"", q.GetType().Name));
            }
            return new Inch((Inch.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Inch>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Inch) && Equals((Inch)obj); }
        public bool /* IEquatable<Inch> */ Equals(Inch other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Inch>
        public static bool operator ==(Inch lhs, Inch rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Inch lhs, Inch rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Inch lhs, Inch rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Inch lhs, Inch rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Inch lhs, Inch rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Inch lhs, Inch rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Inch> */ CompareTo(Inch other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Inch operator +(Inch lhs, Inch rhs) { return new Inch(lhs.m_value + rhs.m_value); }
        public static Inch operator -(Inch lhs, Inch rhs) { return new Inch(lhs.m_value - rhs.m_value); }
        public static Inch operator ++(Inch q) { return new Inch(q.m_value + 1d); }
        public static Inch operator --(Inch q) { return new Inch(q.m_value - 1d); }
        public static Inch operator -(Inch q) { return new Inch(-q.m_value); }
        public static Inch operator *(double lhs, Inch rhs) { return new Inch(lhs * rhs.m_value); }
        public static Inch operator *(Inch lhs, double rhs) { return new Inch(lhs.m_value * rhs); }
        public static Inch operator /(Inch lhs, double rhs) { return new Inch(lhs.m_value / rhs); }
        public static double operator /(Inch lhs, Inch rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Inch.Format, q, Inch.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Meter.Sense;
        public const int Family = Meter.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("in");
        public static readonly Unit<double> Proxy = new Inch_Proxy();
        public const double Factor = 100d * Meter.Factor / 2.54d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Inch One = new Inch(1d);
        public static readonly Inch Zero = new Inch(0d);
        #endregion
    }

    public partial class Inch_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Inch.Sense; } }
        public override int Family { get { return Inch.Family; } }
        public override double Factor { get { return Inch.Factor; } }
        public override SymbolCollection Symbol { get { return Inch.Symbol; } }
        public override string Format { get { return Inch.Format; } set { Inch.Format = value; } }
        #endregion

        #region Constructor(s)
        public Inch_Proxy() :
            base(typeof(Inch))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Inch(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Inch.From(quantity);
        }
        #endregion
    }
}
