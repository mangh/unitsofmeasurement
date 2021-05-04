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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Radian_Sec.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Radian_Sec\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Radian_Sec.Format, q, Radian_Sec.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Radian.Sense / Second.Sense;
        public const int Family = Hertz.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("rad/s");
        public static readonly Unit<double> Proxy = new Radian_Sec_Proxy();
        public const double Factor = Radian.Factor / Second.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Radian_Sec One = new Radian_Sec(1d);
        public static readonly Radian_Sec Zero = new Radian_Sec(0d);
        #endregion
    }

    public partial class Radian_Sec_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Radian_Sec.Sense; } }
        public override int Family { get { return Radian_Sec.Family; } }
        public override double Factor { get { return Radian_Sec.Factor; } }
        public override SymbolCollection Symbol { get { return Radian_Sec.Symbol; } }
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
