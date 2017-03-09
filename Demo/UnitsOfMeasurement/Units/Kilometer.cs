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

        #region Properties
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
            if (q.Unit.Family != Kilometer.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Kilometer\"", q.GetType().Name));
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
        public override string ToString() { return ToString(Kilometer.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Kilometer.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Kilometer.Format, m_value, Kilometer.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Meter.Sense;
        private static readonly int s_family = Meter.Family;
        private static /*mutable*/ double s_factor = Meter.Factor / 1000d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("km");
        private static readonly Unit<double> s_proxy = new Kilometer_Proxy();

        private static readonly Kilometer s_one = new Kilometer(1d);
        private static readonly Kilometer s_zero = new Kilometer(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Kilometer One { get { return s_one; } }
        public static Kilometer Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Kilometer_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Kilometer.Family; } }
        public override Dimension Sense { get { return Kilometer.Sense; } }
        public override SymbolCollection Symbol { get { return Kilometer.Symbol; } }
        public override double Factor { get { return Kilometer.Factor; } set { Kilometer.Factor = value; } }
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
