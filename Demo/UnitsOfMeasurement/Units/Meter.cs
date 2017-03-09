/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Meter : IQuantity<double>, IEquatable<Meter>, IComparable<Meter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Meter.Proxy; } }
        #endregion

        #region Constructor(s)
        public Meter(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Meter(double q) { return new Meter(q); }
        public static explicit operator Meter(Inch q) { return new Meter((Meter.Factor / Inch.Factor) * q.m_value); }
        public static explicit operator Meter(Foot q) { return new Meter((Meter.Factor / Foot.Factor) * q.m_value); }
        public static explicit operator Meter(Yard q) { return new Meter((Meter.Factor / Yard.Factor) * q.m_value); }
        public static explicit operator Meter(Mile q) { return new Meter((Meter.Factor / Mile.Factor) * q.m_value); }
        public static explicit operator Meter(Kilometer q) { return new Meter((Meter.Factor / Kilometer.Factor) * q.m_value); }
        public static explicit operator Meter(Millimeter q) { return new Meter((Meter.Factor / Millimeter.Factor) * q.m_value); }
        public static explicit operator Meter(Centimeter q) { return new Meter((Meter.Factor / Centimeter.Factor) * q.m_value); }
        public static Meter From(IQuantity<double> q)
        {
            if (q.Unit.Family != Meter.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Meter\"", q.GetType().Name));
            return new Meter((Meter.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Meter>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Meter) && Equals((Meter)obj); }
        public bool /* IEquatable<Meter> */ Equals(Meter other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Meter>
        public static bool operator ==(Meter lhs, Meter rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Meter lhs, Meter rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Meter lhs, Meter rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Meter lhs, Meter rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Meter lhs, Meter rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Meter lhs, Meter rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Meter> */ CompareTo(Meter other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter operator +(Meter lhs, Meter rhs) { return new Meter(lhs.m_value + rhs.m_value); }
        public static Meter operator -(Meter lhs, Meter rhs) { return new Meter(lhs.m_value - rhs.m_value); }
        public static Meter operator ++(Meter q) { return new Meter(q.m_value + 1d); }
        public static Meter operator --(Meter q) { return new Meter(q.m_value - 1d); }
        public static Meter operator -(Meter q) { return new Meter(-q.m_value); }
        public static Meter operator *(double lhs, Meter rhs) { return new Meter(lhs * rhs.m_value); }
        public static Meter operator *(Meter lhs, double rhs) { return new Meter(lhs.m_value * rhs); }
        public static Meter operator /(Meter lhs, double rhs) { return new Meter(lhs.m_value / rhs); }
        public static double operator /(Meter lhs, Meter rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static SquareMeter operator *(Meter lhs, Meter rhs) { return new SquareMeter(lhs.m_value * rhs.m_value); }
        public static Meter_Sec operator /(Meter lhs, Second rhs) { return new Meter_Sec(lhs.m_value / rhs.m_value); }
        public static Second operator /(Meter lhs, Meter_Sec rhs) { return new Second(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Meter.Format, m_value, Meter.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Dimension.Length;
        private static readonly int s_family = 0;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m");
        private static readonly Unit<double> s_proxy = new Meter_Proxy();

        private static readonly Meter s_one = new Meter(1d);
        private static readonly Meter s_zero = new Meter(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Meter One { get { return s_one; } }
        public static Meter Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Meter_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Meter.Family; } }
        public override Dimension Sense { get { return Meter.Sense; } }
        public override SymbolCollection Symbol { get { return Meter.Symbol; } }
        public override double Factor { get { return Meter.Factor; } set { Meter.Factor = value; } }
        public override string Format { get { return Meter.Format; } set { Meter.Format = value; } }
        #endregion

        #region Constructor(s)
        public Meter_Proxy() :
            base(typeof(Meter))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Meter(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Meter.From(quantity);
        }
        #endregion
    }
}
