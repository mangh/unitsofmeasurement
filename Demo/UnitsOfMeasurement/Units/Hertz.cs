/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Hertz : IQuantity<double>, IEquatable<Hertz>, IComparable<Hertz>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Hertz.Proxy; } }
        #endregion

        #region Constructor(s)
        public Hertz(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Hertz(double q) { return new Hertz(q); }
        public static explicit operator Hertz(Radian_Sec q) { return new Hertz((Hertz.Factor / Radian_Sec.Factor) * q.m_value); }
        public static explicit operator Hertz(RPM q) { return new Hertz((Hertz.Factor / RPM.Factor) * q.m_value); }
        public static Hertz From(IQuantity<double> q)
        {
            if (q.Unit.Family != Hertz.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Hertz\"", q.GetType().Name));
            }
            return new Hertz((Hertz.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Hertz>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Hertz) && Equals((Hertz)obj); }
        public bool /* IEquatable<Hertz> */ Equals(Hertz other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Hertz>
        public static bool operator ==(Hertz lhs, Hertz rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Hertz lhs, Hertz rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Hertz lhs, Hertz rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Hertz lhs, Hertz rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Hertz lhs, Hertz rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Hertz lhs, Hertz rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Hertz> */ CompareTo(Hertz other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Hertz operator +(Hertz lhs, Hertz rhs) { return new Hertz(lhs.m_value + rhs.m_value); }
        public static Hertz operator -(Hertz lhs, Hertz rhs) { return new Hertz(lhs.m_value - rhs.m_value); }
        public static Hertz operator ++(Hertz q) { return new Hertz(q.m_value + 1d); }
        public static Hertz operator --(Hertz q) { return new Hertz(q.m_value - 1d); }
        public static Hertz operator -(Hertz q) { return new Hertz(-q.m_value); }
        public static Hertz operator *(double lhs, Hertz rhs) { return new Hertz(lhs * rhs.m_value); }
        public static Hertz operator *(Hertz lhs, double rhs) { return new Hertz(lhs.m_value * rhs); }
        public static Hertz operator /(Hertz lhs, double rhs) { return new Hertz(lhs.m_value / rhs); }
        public static double operator /(Hertz lhs, Hertz rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Cycles operator *(Hertz lhs, Second rhs) { return new Cycles(lhs.m_value * rhs.m_value); }
        public static Cycles operator *(Second lhs, Hertz rhs) { return new Cycles(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Hertz.Format, q, Hertz.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Cycles.Sense / Second.Sense;
        public const int Family = 10;
        public static readonly SymbolCollection Symbol = new SymbolCollection("Hz");
        public static readonly Unit<double> Proxy = new Hertz_Proxy();
        public const double Factor = Cycles.Factor / Second.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Hertz One = new Hertz(1d);
        public static readonly Hertz Zero = new Hertz(0d);
        #endregion
    }

    public partial class Hertz_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Hertz.Sense; } }
        public override int Family { get { return Hertz.Family; } }
        public override double Factor { get { return Hertz.Factor; } }
        public override SymbolCollection Symbol { get { return Hertz.Symbol; } }
        public override string Format { get { return Hertz.Format; } set { Hertz.Format = value; } }
        #endregion

        #region Constructor(s)
        public Hertz_Proxy() :
            base(typeof(Hertz))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Hertz(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Hertz.From(quantity);
        }
        #endregion
    }
}
