/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct Kilogram : IQuantity<double>, IEquatable<Kilogram>, IComparable<Kilogram>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Kilogram.Proxy; } }
        #endregion

        #region Constructor(s)
        public Kilogram(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Kilogram(double q) { return new Kilogram(q); }
        public static explicit operator Kilogram(Pound q) { return new Kilogram((Kilogram.Factor / Pound.Factor) * q.m_value); }
        public static explicit operator Kilogram(Ounce q) { return new Kilogram((Kilogram.Factor / Ounce.Factor) * q.m_value); }
        public static explicit operator Kilogram(Tonne q) { return new Kilogram((Kilogram.Factor / Tonne.Factor) * q.m_value); }
        public static explicit operator Kilogram(Gram q) { return new Kilogram((Kilogram.Factor / Gram.Factor) * q.m_value); }
        public static Kilogram From(IQuantity<double> q)
        {
            if (q.Unit.Family != Kilogram.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Kilogram\"", q.GetType().Name));
            return new Kilogram((Kilogram.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Kilogram>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Kilogram) && Equals((Kilogram)obj); }
        public bool /* IEquatable<Kilogram> */ Equals(Kilogram other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Kilogram>
        public static bool operator ==(Kilogram lhs, Kilogram rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Kilogram lhs, Kilogram rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Kilogram lhs, Kilogram rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Kilogram lhs, Kilogram rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Kilogram lhs, Kilogram rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Kilogram lhs, Kilogram rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Kilogram> */ CompareTo(Kilogram other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Kilogram operator +(Kilogram lhs, Kilogram rhs) { return new Kilogram(lhs.m_value + rhs.m_value); }
        public static Kilogram operator -(Kilogram lhs, Kilogram rhs) { return new Kilogram(lhs.m_value - rhs.m_value); }
        public static Kilogram operator ++(Kilogram q) { return new Kilogram(q.m_value + 1d); }
        public static Kilogram operator --(Kilogram q) { return new Kilogram(q.m_value - 1d); }
        public static Kilogram operator -(Kilogram q) { return new Kilogram(-q.m_value); }
        public static Kilogram operator *(double lhs, Kilogram rhs) { return new Kilogram(lhs * rhs.m_value); }
        public static Kilogram operator *(Kilogram lhs, double rhs) { return new Kilogram(lhs.m_value * rhs); }
        public static Kilogram operator /(Kilogram lhs, double rhs) { return new Kilogram(lhs.m_value / rhs); }
        public static double operator /(Kilogram lhs, Kilogram rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Newton operator *(Kilogram lhs, Meter_Sec2 rhs) { return new Newton(lhs.m_value * rhs.m_value); }
        public static Newton operator *(Meter_Sec2 lhs, Kilogram rhs) { return new Newton(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(Kilogram.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(Kilogram.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? Kilogram.Format, m_value, Kilogram.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Dimension.Mass;
        private static readonly int s_family = 2;
        private static /*mutable*/ double s_factor = 1d;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("kg");
        private static readonly Unit<double> s_proxy = new Kilogram_Proxy();

        private static readonly Kilogram s_one = new Kilogram(1d);
        private static readonly Kilogram s_zero = new Kilogram(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static Kilogram One { get { return s_one; } }
        public static Kilogram Zero { get { return s_zero; } }
        #endregion
    }

    public partial class Kilogram_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return Kilogram.Family; } }
        public override Dimension Sense { get { return Kilogram.Sense; } }
        public override SymbolCollection Symbol { get { return Kilogram.Symbol; } }
        public override double Factor { get { return Kilogram.Factor; } set { Kilogram.Factor = value; } }
        public override string Format { get { return Kilogram.Format; } set { Kilogram.Format = value; } }
        #endregion

        #region Constructor(s)
        public Kilogram_Proxy() :
            base(typeof(Kilogram))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Kilogram(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Kilogram.From(quantity);
        }
        #endregion
    }
}
