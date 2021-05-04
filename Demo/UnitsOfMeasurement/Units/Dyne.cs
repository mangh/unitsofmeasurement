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

        #region Properties / IQuantity<double>
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
            if (q.Unit.Family != Dyne.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Dyne\"", q.GetType().Name));
            }
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
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Dyne.Format, q, Dyne.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Newton.Sense;
        public const int Family = Newton.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("dyn");
        public static readonly Unit<double> Proxy = new Dyne_Proxy();
        public const double Factor = 100000d * Newton.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Dyne One = new Dyne(1d);
        public static readonly Dyne Zero = new Dyne(0d);
        #endregion
    }

    public partial class Dyne_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Dyne.Sense; } }
        public override int Family { get { return Dyne.Family; } }
        public override double Factor { get { return Dyne.Factor; } }
        public override SymbolCollection Symbol { get { return Dyne.Symbol; } }
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
