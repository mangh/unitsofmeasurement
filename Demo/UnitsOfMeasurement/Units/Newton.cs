/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Newton : IQuantity<double>, IEquatable<Newton>, IComparable<Newton>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
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
        public static explicit operator Newton(Dyne q) { return new Newton((Newton.Factor / Dyne.Factor) * q.m_value); }
        public static explicit operator Newton(Poundal q) { return new Newton((Newton.Factor / Poundal.Factor) * q.m_value); }
        public static explicit operator Newton(PoundForce q) { return new Newton((Newton.Factor / PoundForce.Factor) * q.m_value); }
        public static Newton From(IQuantity<double> q)
        {
            if (q.Unit.Family != Newton.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Newton\"", q.GetType().Name));
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
        public static Pascal operator /(Newton lhs, SquareMeter rhs) { return new Pascal(lhs.m_value / rhs.m_value); }
        public static SquareMeter operator /(Newton lhs, Pascal rhs) { return new SquareMeter(lhs.m_value / rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Newton.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Newton.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Newton.Format, m_value, Newton.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Kilogram.Sense * Meter_Sec2.Sense;
        private static readonly int s_family = 15;
        private static /*mutable*/ double s_factor = Kilogram.Factor * Meter_Sec2.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("N");
        private static readonly Unit<double> s_proxy = new Newton_Proxy();

        private static readonly Newton s_one = new Newton(1d);
        private static readonly Newton s_zero = new Newton(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Newton One { get { return s_one; } }
        public static Newton Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Newton_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Newton.Family; } }
        public override Dimension Sense { get { return Newton.Sense; } }
        public override SymbolCollection Symbol { get { return Newton.Symbol; } }
        public override double Factor { get { return Newton.Factor; } set { Newton.Factor = value; } }
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
