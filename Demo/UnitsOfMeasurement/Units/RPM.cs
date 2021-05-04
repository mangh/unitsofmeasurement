/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct RPM : IQuantity<double>, IEquatable<RPM>, IComparable<RPM>, IFormattable
    {
        #region Fields
        internal readonly double m_value;
        #endregion

        #region Properties / IQuantity<double>
        public double Value { get { return m_value; } }
        Unit<double> IQuantity<double>.Unit { get { return RPM.Proxy; } }
        #endregion

        #region Constructor(s)
        public RPM(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator RPM(double q) { return new RPM(q); }
        public static explicit operator RPM(Hertz q) { return new RPM((RPM.Factor / Hertz.Factor) * q.m_value); }
        public static explicit operator RPM(Radian_Sec q) { return new RPM((RPM.Factor / Radian_Sec.Factor) * q.m_value); }
        public static RPM From(IQuantity<double> q)
        {
            if (q.Unit.Family != RPM.Family)
            {
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"RPM\"", q.GetType().Name));
            }
            return new RPM((RPM.Factor / q.Unit.Factor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable<RPM>
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj is RPM) && Equals((RPM)obj); }
        public bool /* IEquatable<RPM> */ Equals(RPM other) { return this.m_value == other.m_value; }
        #endregion

        #region Comparison / IComparable<RPM>
        public static bool operator ==(RPM lhs, RPM rhs) { return lhs.m_value == rhs.m_value; }
        public static bool operator !=(RPM lhs, RPM rhs) { return lhs.m_value != rhs.m_value; }
        public static bool operator <(RPM lhs, RPM rhs) { return lhs.m_value < rhs.m_value; }
        public static bool operator >(RPM lhs, RPM rhs) { return lhs.m_value > rhs.m_value; }
        public static bool operator <=(RPM lhs, RPM rhs) { return lhs.m_value <= rhs.m_value; }
        public static bool operator >=(RPM lhs, RPM rhs) { return lhs.m_value >= rhs.m_value; }
        public int /* IComparable<RPM> */ CompareTo(RPM other) { return this.m_value.CompareTo(other.m_value); }
        #endregion

        #region Arithmetic
        // Inner:
        public static RPM operator +(RPM lhs, RPM rhs) { return new RPM(lhs.m_value + rhs.m_value); }
        public static RPM operator -(RPM lhs, RPM rhs) { return new RPM(lhs.m_value - rhs.m_value); }
        public static RPM operator ++(RPM q) { return new RPM(q.m_value + 1d); }
        public static RPM operator --(RPM q) { return new RPM(q.m_value - 1d); }
        public static RPM operator -(RPM q) { return new RPM(-q.m_value); }
        public static RPM operator *(double lhs, RPM rhs) { return new RPM(lhs * rhs.m_value); }
        public static RPM operator *(RPM lhs, double rhs) { return new RPM(lhs.m_value * rhs); }
        public static RPM operator /(RPM lhs, double rhs) { return new RPM(lhs.m_value / rhs); }
        public static double operator /(RPM lhs, RPM rhs) { return lhs.m_value / rhs.m_value; }
        // Outer:
        public static Cycles operator *(RPM lhs, Minute rhs) { return new Cycles(lhs.m_value * rhs.m_value); }
        public static Cycles operator *(Minute lhs, RPM rhs) { return new Cycles(lhs.m_value * rhs.m_value); }
        #endregion

        #region Formatting
        public static string String(double q, string format = null, IFormatProvider fp = null)
        {
            return string.Format(fp, format ?? RPM.Format, q, RPM.Symbol.Default);
        }

        public override string ToString() { return String(m_value); }
        public string ToString(string format) { return String(m_value, format); }
        public string ToString(IFormatProvider fp) { return String(m_value, null, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp) { return String(m_value, format, fp); }
        #endregion

        #region Static fields and properties (DO NOT CHANGE!)
        public static readonly Dimension Sense = Cycles.Sense / Minute.Sense;
        public const int Family = Hertz.Family;
        public static readonly SymbolCollection Symbol = new SymbolCollection("rpm");
        public static readonly Unit<double> Proxy = new RPM_Proxy();
        public const double Factor = Cycles.Factor / Minute.Factor;
        public static string Format { get { return s_format; } set { s_format = value; } }
        private static string s_format = "{0} {1}";
        #endregion

        #region Predefined quantities
        public static readonly RPM One = new RPM(1d);
        public static readonly RPM Zero = new RPM(0d);
        #endregion
    }

    public partial class RPM_Proxy : Unit<double>
    {
        #region Properties
        public override Dimension Sense { get { return RPM.Sense; } }
        public override int Family { get { return RPM.Family; } }
        public override double Factor { get { return RPM.Factor; } }
        public override SymbolCollection Symbol { get { return RPM.Symbol; } }
        public override string Format { get { return RPM.Format; } set { RPM.Format = value; } }
        #endregion

        #region Constructor(s)
        public RPM_Proxy() :
            base(typeof(RPM))
        {
        }
        #endregion

        #region Methods
        public override IQuantity<double> Create(double value)
        {
            return new RPM(value);
        }
        public override IQuantity<double> From(IQuantity<double> quantity)
        {
            return RPM.From(quantity);
        }
        #endregion
    }
}
