/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct Meter : IQuantity<double>, IEquatable<Meter>, IComparable<Meter>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
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
        public static Meter From(IQuantity<double> q)
        {
            if (q.Unit.Family != Meter.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Meter\"", q.GetType().Name));
            }
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
        public static Meter_Sec operator /(Meter lhs, Second rhs) { return new Meter_Sec(lhs.m_value / rhs.m_value); }
        public static Second operator /(Meter lhs, Meter_Sec rhs) { return new Second(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Meter.Format, q, Meter.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Dimension.Length;
        public const int Family = 0;
        public static readonly SymbolCollection Symbol = new SymbolCollection("m");
        public static readonly Unit<double> Proxy = new Meter_Proxy();
        public const double Factor = 1d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Meter One = new Meter(1d);
        public static readonly Meter Zero = new Meter(0d);
        #endregion
    }

    public partial class Meter_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Meter.Sense; } }
        public override int Family { get { return Meter.Family; } }
        public override double Factor { get { return Meter.Factor; } }
        public override SymbolCollection Symbol { get { return Meter.Symbol; } }
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
