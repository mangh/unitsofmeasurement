/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
{
    public partial struct Second : IQuantity<double>, IEquatable<Second>, IComparable<Second>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return Second.Proxy; } }
        #endregion

        #region Constructor(s)
        public Second(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator Second(double q) { return new Second(q); }
        public static Second From(IQuantity<double> q)
        {
            if (q.Unit.Family != Second.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"Second\"", q.GetType().Name));
            }
            return new Second((Second.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<Second>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is Second) && Equals((Second)obj); }
        public bool /* IEquatable<Second> */ Equals(Second other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<Second>
        public static bool operator ==(Second lhs, Second rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(Second lhs, Second rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(Second lhs, Second rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(Second lhs, Second rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(Second lhs, Second rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(Second lhs, Second rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<Second> */ CompareTo(Second other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static Second operator +(Second lhs, Second rhs) { return new Second(lhs.m_value + rhs.m_value); }
        public static Second operator -(Second lhs, Second rhs) { return new Second(lhs.m_value - rhs.m_value); }
        public static Second operator ++(Second q) { return new Second(q.m_value + 1d); }
        public static Second operator --(Second q) { return new Second(q.m_value - 1d); }
        public static Second operator -(Second q) { return new Second(-q.m_value); }
        public static Second operator *(double lhs, Second rhs) { return new Second(lhs * rhs.m_value); }
        public static Second operator *(Second lhs, double rhs) { return new Second(lhs.m_value * rhs); }
        public static Second operator /(Second lhs, double rhs) { return new Second(lhs.m_value / rhs); }
        public static double operator /(Second lhs, Second rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? Second.Format, q, Second.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Dimension.Time;
        public const int Family = 1;
        public static readonly SymbolCollection Symbol = new SymbolCollection("s");
        public static readonly Unit<double> Proxy = new Second_Proxy();
        public const double Factor = 1d;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly Second One = new Second(1d);
        public static readonly Second Zero = new Second(0d);
        #endregion
    }

    public partial class Second_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return Second.Sense; } }
        public override int Family { get { return Second.Family; } }
        public override double Factor { get { return Second.Factor; } }
        public override SymbolCollection Symbol { get { return Second.Symbol; } }
        public override string Format { get { return Second.Format; } set { Second.Format = value; } }
        #endregion

        #region Constructor(s)
        public Second_Proxy() :
            base(typeof(Second))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new Second(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return Second.From(quantity);
        }
        #endregion
    }
}
