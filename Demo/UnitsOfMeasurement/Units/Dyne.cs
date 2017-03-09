/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Dyne : IQuantity<double>, IEquatable<Dyne>, IComparable<Dyne>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Dyne.Proxy; } }
        #endregion

        #region Constructor(s)
        public Dyne(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Dyne(double q) { return new Dyne(q); }
        public static explicit operator Dyne(Poundal q) { return new Dyne((Dyne.Factor / Poundal.Factor) * q.m_value); }
        public static explicit operator Dyne(PoundForce q) { return new Dyne((Dyne.Factor / PoundForce.Factor) * q.m_value); }
        public static explicit operator Dyne(Newton q) { return new Dyne((Dyne.Factor / Newton.Factor) * q.m_value); }
        public static Dyne From(IQuantity<double> q)
        {
            if (q.Unit.Family != Dyne.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Dyne\"", q.GetType().Name));
            return new Dyne((Dyne.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Dyne>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Dyne) && Equals((Dyne)obj); }
        public bool /* IEquatable<Dyne> */ Equals(Dyne other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Dyne>
        public static bool operator ==(Dyne lhs, Dyne rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Dyne lhs, Dyne rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Dyne lhs, Dyne rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Dyne lhs, Dyne rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Dyne lhs, Dyne rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Dyne lhs, Dyne rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Dyne> */ CompareTo(Dyne other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Dyne operator +(Dyne lhs, Dyne rhs) { return new Dyne(lhs.m_value + rhs.m_value); }
        public static Dyne operator -(Dyne lhs, Dyne rhs) { return new Dyne(lhs.m_value - rhs.m_value); }
        public static Dyne operator ++(Dyne q) { return new Dyne(q.m_value + 1d); }
        public static Dyne operator --(Dyne q) { return new Dyne(q.m_value - 1d); }
        public static Dyne operator -(Dyne q) { return new Dyne(-q.m_value); }
        public static Dyne operator *(double lhs, Dyne rhs) { return new Dyne(lhs * rhs.m_value); }
        public static Dyne operator *(Dyne lhs, double rhs) { return new Dyne(lhs.m_value * rhs); }
        public static Dyne operator /(Dyne lhs, double rhs) { return new Dyne(lhs.m_value / rhs); }
        public static double operator /(Dyne lhs, Dyne rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Dyne.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Dyne.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Dyne.Format, m_value, Dyne.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Newton.Sense;
        private static readonly int s_family = Newton.Family;
        private static /*mutable*/ double s_factor = 100000d * Newton.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("dyn");
        private static readonly Unit<double> s_proxy = new Dyne_Proxy();

        private static readonly Dyne s_one = new Dyne(1d);
        private static readonly Dyne s_zero = new Dyne(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Dyne One { get { return s_one; } }
        public static Dyne Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Dyne_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Dyne.Family; } }
        public override Dimension Sense { get { return Dyne.Sense; } }
        public override SymbolCollection Symbol { get { return Dyne.Symbol; } }
        public override double Factor { get { return Dyne.Factor; } set { Dyne.Factor = value; } }
        public override string Format { get { return Dyne.Format; } set { Dyne.Format = value; } }
        #endregion

        #region Constructor(s)
        public Dyne_Proxy() :
            base(typeof(Dyne))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Dyne(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Dyne.From(quantity);
        }
        #endregion
    }
}
