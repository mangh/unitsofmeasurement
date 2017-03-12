/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct Joule : IQuantity<double>, IEquatable<Joule>, IComparable<Joule>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Joule.Proxy; } }
        #endregion

        #region Constructor(s)
        public Joule(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Joule(double q) { return new Joule(q); }
        public static Joule From(IQuantity<double> q)
        {
            if (q.Unit.Family != Joule.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Joule\"", q.GetType().Name));
            return new Joule((Joule.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Joule>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Joule) && Equals((Joule)obj); }
        public bool /* IEquatable<Joule> */ Equals(Joule other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Joule>
        public static bool operator ==(Joule lhs, Joule rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Joule lhs, Joule rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Joule lhs, Joule rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Joule lhs, Joule rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Joule lhs, Joule rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Joule lhs, Joule rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Joule> */ CompareTo(Joule other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Joule operator +(Joule lhs, Joule rhs) { return new Joule(lhs.m_value + rhs.m_value); }
        public static Joule operator -(Joule lhs, Joule rhs) { return new Joule(lhs.m_value - rhs.m_value); }
        public static Joule operator ++(Joule q) { return new Joule(q.m_value + 1d); }
        public static Joule operator --(Joule q) { return new Joule(q.m_value - 1d); }
        public static Joule operator -(Joule q) { return new Joule(-q.m_value); }
        public static Joule operator *(double lhs, Joule rhs) { return new Joule(lhs * rhs.m_value); }
        public static Joule operator *(Joule lhs, double rhs) { return new Joule(lhs.m_value * rhs); }
        public static Joule operator /(Joule lhs, double rhs) { return new Joule(lhs.m_value / rhs); }
        public static double operator /(Joule lhs, Joule rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter operator /(Joule lhs, Newton rhs) { return new Meter(lhs.m_value / rhs.m_value); }
        public static Newton operator /(Joule lhs, Meter rhs) { return new Newton(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Joule.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Joule.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Joule.Format, m_value, Joule.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Newton.Sense * Meter.Sense;
        private static readonly int s_family = 9;
        private static /*mutable*/ double s_factor = Newton.Factor * Meter.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("J");
        private static readonly Unit<double> s_proxy = new Joule_Proxy();

        private static readonly Joule s_one = new Joule(1d);
        private static readonly Joule s_zero = new Joule(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Joule One { get { return s_one; } }
        public static Joule Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Joule_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Joule.Family; } }
        public override Dimension Sense { get { return Joule.Sense; } }
        public override SymbolCollection Symbol { get { return Joule.Symbol; } }
        public override double Factor { get { return Joule.Factor; } set { Joule.Factor = value; } }
        public override string Format { get { return Joule.Format; } set { Joule.Format = value; } }
        #endregion

        #region Constructor(s)
        public Joule_Proxy() :
            base(typeof(Joule))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Joule(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Joule.From(quantity);
        }
        #endregion
    }
}
