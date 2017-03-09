/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Siemens : IQuantity<double>, IEquatable<Siemens>, IComparable<Siemens>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Siemens.Proxy; } }
        #endregion

        #region Constructor(s)
        public Siemens(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Siemens(double q) { return new Siemens(q); }
        public static Siemens From(IQuantity<double> q)
        {
            if (q.Unit.Family != Siemens.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Siemens\"", q.GetType().Name));
            return new Siemens((Siemens.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Siemens>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Siemens) && Equals((Siemens)obj); }
        public bool /* IEquatable<Siemens> */ Equals(Siemens other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Siemens>
        public static bool operator ==(Siemens lhs, Siemens rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Siemens lhs, Siemens rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Siemens lhs, Siemens rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Siemens lhs, Siemens rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Siemens lhs, Siemens rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Siemens lhs, Siemens rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Siemens> */ CompareTo(Siemens other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Siemens operator +(Siemens lhs, Siemens rhs) { return new Siemens(lhs.m_value + rhs.m_value); }
        public static Siemens operator -(Siemens lhs, Siemens rhs) { return new Siemens(lhs.m_value - rhs.m_value); }
        public static Siemens operator ++(Siemens q) { return new Siemens(q.m_value + 1d); }
        public static Siemens operator --(Siemens q) { return new Siemens(q.m_value - 1d); }
        public static Siemens operator -(Siemens q) { return new Siemens(-q.m_value); }
        public static Siemens operator *(double lhs, Siemens rhs) { return new Siemens(lhs * rhs.m_value); }
        public static Siemens operator *(Siemens lhs, double rhs) { return new Siemens(lhs.m_value * rhs); }
        public static Siemens operator /(Siemens lhs, double rhs) { return new Siemens(lhs.m_value / rhs); }
        public static double operator /(Siemens lhs, Siemens rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Ampere operator *(Siemens lhs, Volt rhs) { return new Ampere(lhs.m_value * rhs.m_value); }
        public static Ampere operator *(Volt lhs, Siemens rhs) { return new Ampere(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Siemens.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Siemens.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Siemens.Format, m_value, Siemens.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Ampere.Sense / Volt.Sense;
        private static readonly int s_family = 25;
        private static /*mutable*/ double s_factor = Ampere.Factor / Volt.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("S");
        private static readonly Unit<double> s_proxy = new Siemens_Proxy();

        private static readonly Siemens s_one = new Siemens(1d);
        private static readonly Siemens s_zero = new Siemens(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Siemens One { get { return s_one; } }
        public static Siemens Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Siemens_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Siemens.Family; } }
        public override Dimension Sense { get { return Siemens.Sense; } }
        public override SymbolCollection Symbol { get { return Siemens.Symbol; } }
        public override double Factor { get { return Siemens.Factor; } set { Siemens.Factor = value; } }
        public override string Format { get { return Siemens.Format; } set { Siemens.Format = value; } }
        #endregion

        #region Constructor(s)
        public Siemens_Proxy() :
            base(typeof(Siemens))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Siemens(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Siemens.From(quantity);
        }
        #endregion
    }
}
