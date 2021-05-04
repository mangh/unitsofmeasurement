/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Millimeter : IQuantity<double>, IEquatable<Millimeter>, IComparable<Millimeter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Millimeter.Proxy; } }
        #endregion

        #region Constructor(s)
        public Millimeter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Millimeter(double q) { return new Millimeter(q); }
        public static explicit operator Millimeter(Centimeter q) { return new Millimeter((Millimeter.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Millimeter(Meter q) { return new Millimeter((Millimeter.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Millimeter(Inch q) { return new Millimeter((Millimeter.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Millimeter(Foot q) { return new Millimeter((Millimeter.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Millimeter(Yard q) { return new Millimeter((Millimeter.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Millimeter(Mile q) { return new Millimeter((Millimeter.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Millimeter(Kilometer q) { return new Millimeter((Millimeter.Factor / Kilometer.Factor) * q.m_value); }
        public static Millimeter From(IQuantity<double> q)
        {
            if (q.Unit.Family != Millimeter.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Millimeter\"", q.GetType().Name));
            }
            return new Millimeter((Millimeter.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Millimeter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Millimeter) && Equals((Millimeter)obj); }
        public bool /* IEquatable<Millimeter> */ Equals(Millimeter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Millimeter>
        public static bool operator ==(Millimeter lhs, Millimeter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Millimeter lhs, Millimeter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Millimeter lhs, Millimeter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Millimeter lhs, Millimeter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Millimeter lhs, Millimeter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Millimeter lhs, Millimeter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Millimeter> */ CompareTo(Millimeter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Millimeter operator +(Millimeter lhs, Millimeter rhs) { return new Millimeter(lhs.m_value + rhs.m_value); }
        public static Millimeter operator -(Millimeter lhs, Millimeter rhs) { return new Millimeter(lhs.m_value - rhs.m_value); }
        public static Millimeter operator ++(Millimeter q) { return new Millimeter(q.m_value + 1d); }
        public static Millimeter operator --(Millimeter q) { return new Millimeter(q.m_value - 1d); }
        public static Millimeter operator -(Millimeter q) { return new Millimeter(-q.m_value); }
        public static Millimeter operator *(double lhs, Millimeter rhs) { return new Millimeter(lhs * rhs.m_value); }
        public static Millimeter operator *(Millimeter lhs, double rhs) { return new Millimeter(lhs.m_value * rhs); }
        public static Millimeter operator /(Millimeter lhs, double rhs) { return new Millimeter(lhs.m_value / rhs); }
        public static double operator /(Millimeter lhs, Millimeter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Millimeter.Format, q, Millimeter.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Meter.Sense;
        public const int Family = Meter.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("mm");
        public static readonly Unit<double> Proxy = new Millimeter_Proxy();
        public const double Factor = 1000d * Meter.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Millimeter One = new Millimeter(1d);
        public static readonly Millimeter Zero = new Millimeter(0d);
        #endregion
    }

    public partial class Millimeter_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Millimeter.Sense; } }
        public override int Family { get { return Millimeter.Family; } }
        public override double Factor { get { return Millimeter.Factor; } }
        public override SymbolCollection Symbol { get { return Millimeter.Symbol; } }
        public override string Format { get { return Millimeter.Format; } set { Millimeter.Format = value; } }
        #endregion

        #region Constructor(s)
        public Millimeter_Proxy() :
            base(typeof(Millimeter))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Millimeter(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Millimeter.From(quantity);
        }
        #endregion
    }
}
