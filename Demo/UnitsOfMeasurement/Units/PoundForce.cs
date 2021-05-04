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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != PoundForce.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"PoundForce\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? PoundForce.Format, q, PoundForce.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Newton.Sense;
        public const int Family = Newton.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("lbf");
        public static readonly Unit<double> Proxy = new PoundForce_Proxy();
        public const double Factor = Newton.Factor / 4.4482216152605d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly PoundForce One = new PoundForce(1d);
        public static readonly PoundForce Zero = new PoundForce(0d);
        #endregion
    }

    public partial class PoundForce_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return PoundForce.Sense; } }
        public override int Family { get { return PoundForce.Family; } }
        public override double Factor { get { return PoundForce.Factor; } }
        public override SymbolCollection Symbol { get { return PoundForce.Symbol; } }
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
