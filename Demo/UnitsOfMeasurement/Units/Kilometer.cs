/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Kilometer : IQuantity<double>, IEquatable<Kilometer>, IComparable<Kilometer>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Kilometer.Proxy; } }
        #endregion

        #region Constructor(s)
        public Kilometer(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Kilometer(double q) { return new Kilometer(q); }
        public static explicit operator Kilometer(Millimeter q) { return new Kilometer((Kilometer.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Kilometer(Centimeter q) { return new Kilometer((Kilometer.Factor / Centimeter.Factor) * q.m_value); }
        public static explicit operator Kilometer(Meter q) { return new Kilometer((Kilometer.Factor / Meter.Factor) * q.m_value); }
        public static explicit operator Kilometer(Inch q) { return new Kilometer((Kilometer.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Kilometer(Foot q) { return new Kilometer((Kilometer.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Kilometer(Yard q) { return new Kilometer((Kilometer.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Kilometer(Mile q) { return new Kilometer((Kilometer.Factor / Mile.Factor) * q.m_value); }
        public static Kilometer From(IQuantity<double> q)
        {
            if (q.Unit.Family != Kilometer.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Kilometer\"", q.GetType().Name));
            }
            return new Kilometer((Kilometer.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Kilometer>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Kilometer) && Equals((Kilometer)obj); }
        public bool /* IEquatable<Kilometer> */ Equals(Kilometer other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Kilometer>
        public static bool operator ==(Kilometer lhs, Kilometer rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Kilometer lhs, Kilometer rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Kilometer lhs, Kilometer rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Kilometer lhs, Kilometer rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Kilometer lhs, Kilometer rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Kilometer lhs, Kilometer rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Kilometer> */ CompareTo(Kilometer other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Kilometer operator +(Kilometer lhs, Kilometer rhs) { return new Kilometer(lhs.m_value + rhs.m_value); }
        public static Kilometer operator -(Kilometer lhs, Kilometer rhs) { return new Kilometer(lhs.m_value - rhs.m_value); }
        public static Kilometer operator ++(Kilometer q) { return new Kilometer(q.m_value + 1d); }
        public static Kilometer operator --(Kilometer q) { return new Kilometer(q.m_value - 1d); }
        public static Kilometer operator -(Kilometer q) { return new Kilometer(-q.m_value); }
        public static Kilometer operator *(double lhs, Kilometer rhs) { return new Kilometer(lhs * rhs.m_value); }
        public static Kilometer operator *(Kilometer lhs, double rhs) { return new Kilometer(lhs.m_value * rhs); }
        public static Kilometer operator /(Kilometer lhs, double rhs) { return new Kilometer(lhs.m_value / rhs); }
        public static double operator /(Kilometer lhs, Kilometer rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Kilometer_Hour operator /(Kilometer lhs, Hour rhs) { return new Kilometer_Hour(lhs.m_value / rhs.m_value); }
        public static Hour operator /(Kilometer lhs, Kilometer_Hour rhs) { return new Hour(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Kilometer.Format, q, Kilometer.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Meter.Sense;
        public const int Family = Meter.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("km");
        public static readonly Unit<double> Proxy = new Kilometer_Proxy();
        public const double Factor = Meter.Factor / 1000d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Kilometer One = new Kilometer(1d);
        public static readonly Kilometer Zero = new Kilometer(0d);
        #endregion
    }

    public partial class Kilometer_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Kilometer.Sense; } }
        public override int Family { get { return Kilometer.Family; } }
        public override double Factor { get { return Kilometer.Factor; } }
        public override SymbolCollection Symbol { get { return Kilometer.Symbol; } }
        public override string Format { get { return Kilometer.Format; } set { Kilometer.Format = value; } }
        #endregion

        #region Constructor(s)
        public Kilometer_Proxy() :
            base(typeof(Kilometer))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Kilometer(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Kilometer.From(quantity);
        }
        #endregion
    }
}
