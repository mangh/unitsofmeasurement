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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Poundal.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Poundal\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Poundal.Format, q, Poundal.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Newton.Sense;
        public const int Family = Newton.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("pdl");
        public static readonly Unit<double> Proxy = new Poundal_Proxy();
        public const double Factor = Newton.Factor / 0.138254954376d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Poundal One = new Poundal(1d);
        public static readonly Poundal Zero = new Poundal(0d);
        #endregion
    }

    public partial class Poundal_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Poundal.Sense; } }
        public override int Family { get { return Poundal.Family; } }
        public override double Factor { get { return Poundal.Factor; } }
        public override SymbolCollection Symbol { get { return Poundal.Symbol; } }
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
