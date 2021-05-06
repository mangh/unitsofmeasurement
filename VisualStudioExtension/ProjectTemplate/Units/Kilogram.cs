/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct Kilogram : IQuantity<double>, IEquatable<Kilogram>, IComparable<Kilogram>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
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
        public static Kilogram From(IQuantity<double> q)
        {
            if (q.Unit.Family != Kilogram.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Kilogram\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Kilogram.Format, q, Kilogram.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Dimension.Mass;
        public const int Family = 2;
        public static readonly SymbolCollection Symbol = new SymbolCollection("kg");
        public static readonly Unit<double> Proxy = new Kilogram_Proxy();
        public const double Factor = 1d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Kilogram One = new Kilogram(1d);
        public static readonly Kilogram Zero = new Kilogram(0d);
        #endregion
    }

    public partial class Kilogram_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Kilogram.Sense; } }
        public override int Family { get { return Kilogram.Family; } }
        public override double Factor { get { return Kilogram.Factor; } }
        public override SymbolCollection Symbol { get { return Kilogram.Symbol; } }
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
