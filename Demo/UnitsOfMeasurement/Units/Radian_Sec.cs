/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Radian_Sec : IQuantity<double>, IEquatable<Radian_Sec>, IComparable<Radian_Sec>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Radian_Sec.Proxy; } }
        #endregion

        #region Constructor(s)
        public Radian_Sec(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Radian_Sec(double q) { return new Radian_Sec(q); }
        public static explicit operator Radian_Sec(RPM q) { return new Radian_Sec((Radian_Sec.Factor / RPM.Factor) * q.m_value); }
        public static explicit operator Radian_Sec(Hertz q) { return new Radian_Sec((Radian_Sec.Factor / Hertz.Factor) * q.m_value); }
        public static Radian_Sec From(IQuantity<double> q)
        {
            if (q.Unit.Family != Radian_Sec.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Radian_Sec\"", q.GetType().Name));
            return new Radian_Sec((Radian_Sec.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Radian_Sec>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Radian_Sec) && Equals((Radian_Sec)obj); }
        public bool /* IEquatable<Radian_Sec> */ Equals(Radian_Sec other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Radian_Sec>
        public static bool operator ==(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Radian_Sec> */ CompareTo(Radian_Sec other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Radian_Sec operator +(Radian_Sec lhs, Radian_Sec rhs) { return new Radian_Sec(lhs.m_value + rhs.m_value); }
        public static Radian_Sec operator -(Radian_Sec lhs, Radian_Sec rhs) { return new Radian_Sec(lhs.m_value - rhs.m_value); }
        public static Radian_Sec operator ++(Radian_Sec q) { return new Radian_Sec(q.m_value + 1d); }
        public static Radian_Sec operator --(Radian_Sec q) { return new Radian_Sec(q.m_value - 1d); }
        public static Radian_Sec operator -(Radian_Sec q) { return new Radian_Sec(-q.m_value); }
        public static Radian_Sec operator *(double lhs, Radian_Sec rhs) { return new Radian_Sec(lhs * rhs.m_value); }
        public static Radian_Sec operator *(Radian_Sec lhs, double rhs) { return new Radian_Sec(lhs.m_value * rhs); }
        public static Radian_Sec operator /(Radian_Sec lhs, double rhs) { return new Radian_Sec(lhs.m_value / rhs); }
        public static double operator /(Radian_Sec lhs, Radian_Sec rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Radian operator *(Radian_Sec lhs, Second rhs) { return new Radian(lhs.m_value * rhs.m_value); }
        public static Radian operator *(Second lhs, Radian_Sec rhs) { return new Radian(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Radian_Sec.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Radian_Sec.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Radian_Sec.Format, m_value, Radian_Sec.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Radian.Sense / Second.Sense;
        private static readonly int s_family = Hertz.Family;
        private static /*mutable*/ double s_factor = Radian.Factor / Second.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("rad/s");
        private static readonly Unit<double> s_proxy = new Radian_Sec_Proxy();

        private static readonly Radian_Sec s_one = new Radian_Sec(1d);
        private static readonly Radian_Sec s_zero = new Radian_Sec(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Radian_Sec One { get { return s_one; } }
        public static Radian_Sec Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Radian_Sec_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Radian_Sec.Family; } }
        public override Dimension Sense { get { return Radian_Sec.Sense; } }
        public override SymbolCollection Symbol { get { return Radian_Sec.Symbol; } }
        public override double Factor { get { return Radian_Sec.Factor; } set { Radian_Sec.Factor = value; } }
        public override string Format { get { return Radian_Sec.Format; } set { Radian_Sec.Format = value; } }
        #endregion

        #region Constructor(s)
        public Radian_Sec_Proxy() :
            base(typeof(Radian_Sec))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Radian_Sec(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Radian_Sec.From(quantity);
        }
        #endregion
    }
}
