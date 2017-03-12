/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct Meter_Sec : IQuantity<double>, IEquatable<Meter_Sec>, IComparable<Meter_Sec>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Meter_Sec.Proxy; } }
        #endregion

        #region Constructor(s)
        public Meter_Sec(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Meter_Sec(double q) { return new Meter_Sec(q); }
        public static Meter_Sec From(IQuantity<double> q)
        {
            if (q.Unit.Family != Meter_Sec.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Meter_Sec\"", q.GetType().Name));
            return new Meter_Sec((Meter_Sec.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Meter_Sec>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Meter_Sec) && Equals((Meter_Sec)obj); }
        public bool /* IEquatable<Meter_Sec> */ Equals(Meter_Sec other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Meter_Sec>
        public static bool operator ==(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Meter_Sec> */ CompareTo(Meter_Sec other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Meter_Sec operator +(Meter_Sec lhs, Meter_Sec rhs) { return new Meter_Sec(lhs.m_value + rhs.m_value); }
        public static Meter_Sec operator -(Meter_Sec lhs, Meter_Sec rhs) { return new Meter_Sec(lhs.m_value - rhs.m_value); }
        public static Meter_Sec operator ++(Meter_Sec q) { return new Meter_Sec(q.m_value + 1d); }
        public static Meter_Sec operator --(Meter_Sec q) { return new Meter_Sec(q.m_value - 1d); }
        public static Meter_Sec operator -(Meter_Sec q) { return new Meter_Sec(-q.m_value); }
        public static Meter_Sec operator *(double lhs, Meter_Sec rhs) { return new Meter_Sec(lhs * rhs.m_value); }
        public static Meter_Sec operator *(Meter_Sec lhs, double rhs) { return new Meter_Sec(lhs.m_value * rhs); }
        public static Meter_Sec operator /(Meter_Sec lhs, double rhs) { return new Meter_Sec(lhs.m_value / rhs); }
        public static double operator /(Meter_Sec lhs, Meter_Sec rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter operator *(Meter_Sec lhs, Second rhs) { return new Meter(lhs.m_value * rhs.m_value); }
        public static Meter operator *(Second lhs, Meter_Sec rhs) { return new Meter(lhs.m_value * rhs.m_value); }
        public static Meter_Sec2 operator /(Meter_Sec lhs, Second rhs) { return new Meter_Sec2(lhs.m_value / rhs.m_value); }
        public static Second operator /(Meter_Sec lhs, Meter_Sec2 rhs) { return new Second(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Meter_Sec.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Meter_Sec.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Meter_Sec.Format, m_value, Meter_Sec.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Meter.Sense / Second.Sense;
        private static readonly int s_family = 6;
        private static /*mutable*/ double s_factor = Meter.Factor / Second.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("m/s");
        private static readonly Unit<double> s_proxy = new Meter_Sec_Proxy();

        private static readonly Meter_Sec s_one = new Meter_Sec(1d);
        private static readonly Meter_Sec s_zero = new Meter_Sec(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Meter_Sec One { get { return s_one; } }
        public static Meter_Sec Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Meter_Sec_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Meter_Sec.Family; } }
        public override Dimension Sense { get { return Meter_Sec.Sense; } }
        public override SymbolCollection Symbol { get { return Meter_Sec.Symbol; } }
        public override double Factor { get { return Meter_Sec.Factor; } set { Meter_Sec.Factor = value; } }
        public override string Format { get { return Meter_Sec.Format; } set { Meter_Sec.Format = value; } }
        #endregion

        #region Constructor(s)
        public Meter_Sec_Proxy() :
            base(typeof(Meter_Sec))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Meter_Sec(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Meter_Sec.From(quantity);
        }
        #endregion
    }
}
