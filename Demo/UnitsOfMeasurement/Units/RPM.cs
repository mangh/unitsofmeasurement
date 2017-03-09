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

        #region Properties
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
            if (q.Unit.Family != RPM.Family) throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" to \"RPM\"", q.GetType().Name));
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
        public override string ToString() { return ToString(RPM.Format, null); }
        public string ToString(string format) { return ToString(format, null); }
        public string ToString(IFormatProvider fp) { return ToString(RPM.Format, fp); }
        public string /* IFormattable */ ToString(string format, IFormatProvider fp)
        {
            return string.Format(fp, format ?? RPM.Format, m_value, RPM.Symbol.Default);
        }
        #endregion

        #region Static fields
        private static readonly Dimension s_sense = Cycles.Sense / Minute.Sense;
        private static readonly int s_family = Hertz.Family;
        private static /*mutable*/ double s_factor = Cycles.Factor / Minute.Factor;
        private static /*mutable*/ string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("rpm");
        private static readonly Unit<double> s_proxy = new RPM_Proxy();

        private static readonly RPM s_one = new RPM(1d);
        private static readonly RPM s_zero = new RPM(0d);
        #endregion

        #region Static Properties
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }
        public static Unit<double> Proxy { get { return s_proxy; } }

        public static RPM One { get { return s_one; } }
        public static RPM Zero { get { return s_zero; } }
        #endregion
    }

    public partial class RPM_Proxy : Unit<double>
    {
        #region Properties
        public override int Family { get { return RPM.Family; } }
        public override Dimension Sense { get { return RPM.Sense; } }
        public override SymbolCollection Symbol { get { return RPM.Symbol; } }
        public override double Factor { get { return RPM.Factor; } set { RPM.Factor = value; } }
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
