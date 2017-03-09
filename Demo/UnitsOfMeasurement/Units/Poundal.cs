/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Poundal : IQuantity<double>, IEquatable<Poundal>, IComparable<Poundal>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Poundal.Proxy; } }
        #endregion

        #region Constructor(s)
        public Poundal(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Poundal(double q) { return new Poundal(q); }
        public static explicit operator Poundal(PoundForce q) { return new Poundal((Poundal.Factor / PoundForce.Factor) * q.m_value); }
        public static explicit operator Poundal(Newton q) { return new Poundal((Poundal.Factor / Newton.Factor) * q.m_value); }
        public static explicit operator Poundal(Dyne q) { return new Poundal((Poundal.Factor / Dyne.Factor) * q.m_value); }
        public static Poundal From(IQuantity<double> q)
        {
            if (q.Unit.Family != Poundal.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Poundal\"", q.GetType().Name));
            return new Poundal((Poundal.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Poundal>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Poundal) && Equals((Poundal)obj); }
        public bool /* IEquatable<Poundal> */ Equals(Poundal other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Poundal>
        public static bool operator ==(Poundal lhs, Poundal rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Poundal lhs, Poundal rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Poundal lhs, Poundal rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Poundal lhs, Poundal rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Poundal lhs, Poundal rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Poundal lhs, Poundal rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Poundal> */ CompareTo(Poundal other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Poundal operator +(Poundal lhs, Poundal rhs) { return new Poundal(lhs.m_value + rhs.m_value); }
        public static Poundal operator -(Poundal lhs, Poundal rhs) { return new Poundal(lhs.m_value - rhs.m_value); }
        public static Poundal operator ++(Poundal q) { return new Poundal(q.m_value + 1d); }
        public static Poundal operator --(Poundal q) { return new Poundal(q.m_value - 1d); }
        public static Poundal operator -(Poundal q) { return new Poundal(-q.m_value); }
        public static Poundal operator *(double lhs, Poundal rhs) { return new Poundal(lhs * rhs.m_value); }
        public static Poundal operator *(Poundal lhs, double rhs) { return new Poundal(lhs.m_value * rhs); }
        public static Poundal operator /(Poundal lhs, double rhs) { return new Poundal(lhs.m_value / rhs); }
        public static double operator /(Poundal lhs, Poundal rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Poundal.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Poundal.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Poundal.Format, m_value, Poundal.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Newton.Sense;
        private static readonly int s_family = Newton.Family;
        private static /*mutable*/ double s_factor = Newton.Factor / 0.138254954376d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("pdl");
        private static readonly Unit<double> s_proxy = new Poundal_Proxy();

        private static readonly Poundal s_one = new Poundal(1d);
        private static readonly Poundal s_zero = new Poundal(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Poundal One { get { return s_one; } }
        public static Poundal Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Poundal_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Poundal.Family; } }
        public override Dimension Sense { get { return Poundal.Sense; } }
        public override SymbolCollection Symbol { get { return Poundal.Symbol; } }
        public override double Factor { get { return Poundal.Factor; } set { Poundal.Factor = value; } }
        public override string Format { get { return Poundal.Format; } set { Poundal.Format = value; } }
        #endregion

        #region Constructor(s)
        public Poundal_Proxy() :
            base(typeof(Poundal))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Poundal(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Poundal.From(quantity);
        }
        #endregion
    }
}
