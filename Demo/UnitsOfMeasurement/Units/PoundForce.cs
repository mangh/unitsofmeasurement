/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct PoundForce : IQuantity<double>, IEquatable<PoundForce>, IComparable<PoundForce>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return PoundForce.Proxy; } }
        #endregion

        #region Constructor(s)
        public PoundForce(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator PoundForce(double q) { return new PoundForce(q); }
        public static explicit operator PoundForce(Newton q) { return new PoundForce((PoundForce.Factor / Newton.Factor) * q.m_value); }
        public static explicit operator PoundForce(Dyne q) { return new PoundForce((PoundForce.Factor / Dyne.Factor) * q.m_value); }
        public static explicit operator PoundForce(Poundal q) { return new PoundForce((PoundForce.Factor / Poundal.Factor) * q.m_value); }
        public static PoundForce From(IQuantity<double> q)
        {
            if (q.Unit.Family != PoundForce.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"PoundForce\"", q.GetType().Name));
            return new PoundForce((PoundForce.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<PoundForce>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is PoundForce) && Equals((PoundForce)obj); }
        public bool /* IEquatable<PoundForce> */ Equals(PoundForce other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<PoundForce>
        public static bool operator ==(PoundForce lhs, PoundForce rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(PoundForce lhs, PoundForce rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(PoundForce lhs, PoundForce rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(PoundForce lhs, PoundForce rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(PoundForce lhs, PoundForce rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(PoundForce lhs, PoundForce rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<PoundForce> */ CompareTo(PoundForce other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static PoundForce operator +(PoundForce lhs, PoundForce rhs) { return new PoundForce(lhs.m_value + rhs.m_value); }
        public static PoundForce operator -(PoundForce lhs, PoundForce rhs) { return new PoundForce(lhs.m_value - rhs.m_value); }
        public static PoundForce operator ++(PoundForce q) { return new PoundForce(q.m_value + 1d); }
        public static PoundForce operator --(PoundForce q) { return new PoundForce(q.m_value - 1d); }
        public static PoundForce operator -(PoundForce q) { return new PoundForce(-q.m_value); }
        public static PoundForce operator *(double lhs, PoundForce rhs) { return new PoundForce(lhs * rhs.m_value); }
        public static PoundForce operator *(PoundForce lhs, double rhs) { return new PoundForce(lhs.m_value * rhs); }
        public static PoundForce operator /(PoundForce lhs, double rhs) { return new PoundForce(lhs.m_value / rhs); }
        public static double operator /(PoundForce lhs, PoundForce rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public override string ToString() { return ToString(PoundForce.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(PoundForce.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? PoundForce.Format, m_value, PoundForce.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Newton.Sense;
        private static readonly int s_family = Newton.Family;
        private static /*mutable*/ double s_factor = Newton.Factor / 4.4482216152605d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("lbf");
        private static readonly Unit<double> s_proxy = new PoundForce_Proxy();

        private static readonly PoundForce s_one = new PoundForce(1d);
        private static readonly PoundForce s_zero = new PoundForce(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static PoundForce One { get { return s_one; } }
        public static PoundForce Zero { get { return s_zero; } }
        #endregion
    }

    public partial class PoundForce_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return PoundForce.Family; } }
        public override Dimension Sense { get { return PoundForce.Sense; } }
        public override SymbolCollection Symbol { get { return PoundForce.Symbol; } }
        public override double Factor { get { return PoundForce.Factor; } set { PoundForce.Factor = value; } }
        public override string Format { get { return PoundForce.Format; } set { PoundForce.Format = value; } }
        #endregion

        #region Constructor(s)
        public PoundForce_Proxy() :
            base(typeof(PoundForce))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new PoundForce(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return PoundForce.From(quantity);
        }
        #endregion
    }
}
