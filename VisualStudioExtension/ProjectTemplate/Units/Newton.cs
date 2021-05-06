/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct Newton : IQuantity<double>, IEquatable<Newton>, IComparable<Newton>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Newton.Proxy; } }
        #endregion

        #region Constructor(s)
        public Newton(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Newton(double q) { return new Newton(q); }
        public static Newton From(IQuantity<double> q)
        {
            if (q.Unit.Family != Newton.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Newton\"", q.GetType().Name));
            }
            return new Newton((Newton.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Newton>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Newton) && Equals((Newton)obj); }
        public bool /* IEquatable<Newton> */ Equals(Newton other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Newton>
        public static bool operator ==(Newton lhs, Newton rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Newton lhs, Newton rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Newton lhs, Newton rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Newton lhs, Newton rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Newton lhs, Newton rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Newton lhs, Newton rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Newton> */ CompareTo(Newton other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Newton operator +(Newton lhs, Newton rhs) { return new Newton(lhs.m_value + rhs.m_value); }
        public static Newton operator -(Newton lhs, Newton rhs) { return new Newton(lhs.m_value - rhs.m_value); }
        public static Newton operator ++(Newton q) { return new Newton(q.m_value + 1d); }
        public static Newton operator --(Newton q) { return new Newton(q.m_value - 1d); }
        public static Newton operator -(Newton q) { return new Newton(-q.m_value); }
        public static Newton operator *(double lhs, Newton rhs) { return new Newton(lhs * rhs.m_value); }
        public static Newton operator *(Newton lhs, double rhs) { return new Newton(lhs.m_value * rhs); }
        public static Newton operator /(Newton lhs, double rhs) { return new Newton(lhs.m_value / rhs); }
        public static double operator /(Newton lhs, Newton rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Meter_Sec2 operator /(Newton lhs, Kilogram rhs) { return new Meter_Sec2(lhs.m_value / rhs.m_value); }
        public static Kilogram operator /(Newton lhs, Meter_Sec2 rhs) { return new Kilogram(lhs.m_value / rhs.m_value); }
        public static Joule operator *(Newton lhs, Meter rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static Joule operator *(Meter lhs, Newton rhs) { return new Joule(lhs.m_value * rhs.m_value); }
        public static NewtonMeter operator ^(Newton lhs, Meter rhs) { return new NewtonMeter(lhs.m_value * rhs.m_value); }
        public static NewtonMeter operator ^(Meter lhs, Newton rhs) { return new NewtonMeter(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Newton.Format, q, Newton.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Kilogram.Sense * Meter_Sec2.Sense;
        public const int Family = 8;
        public static readonly SymbolCollection Symbol = new SymbolCollection("N");
        public static readonly Unit<double> Proxy = new Newton_Proxy();
        public const double Factor = Kilogram.Factor * Meter_Sec2.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Newton One = new Newton(1d);
        public static readonly Newton Zero = new Newton(0d);
        #endregion
    }

    public partial class Newton_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Newton.Sense; } }
        public override int Family { get { return Newton.Family; } }
        public override double Factor { get { return Newton.Factor; } }
        public override SymbolCollection Symbol { get { return Newton.Symbol; } }
        public override string Format { get { return Newton.Format; } set { Newton.Format = value; } }
        #endregion

        #region Constructor(s)
        public Newton_Proxy() :
            base(typeof(Newton))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Newton(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Newton.From(quantity);
        }
        #endregion
    }
}
