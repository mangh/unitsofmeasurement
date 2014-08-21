/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    public partial struct RPM : IQuantity<double>, IEquatable<RPM>, IComparable<RPM>
    {
        #region Fields
        private readonly double m_value;
        #endregion

        #region Properties

        // instance properties
        public double Value { get { return m_value; } }

        // unit properties
        public Dimension UnitSense { get { return RPM.Sense; } }
        public int UnitFamily { get { return RPM.Family; } }
        public double UnitFactor { get { return RPM.Factor; } }
        public string UnitFormat { get { return RPM.Format; } }
        public SymbolCollection UnitSymbol { get { return RPM.Symbol; } }

        #endregion

        #region Constructor(s)
        public RPM(double value)
        {
            m_value = value;
        }
        #endregion

        #region Conversions
        public static explicit operator RPM(double q) { return new RPM(q); }
        public static explicit operator RPM(Hertz q) { return new RPM((RPM.Factor / Hertz.Factor) * q.Value); }
        public static explicit operator RPM(Radian_Sec q) { return new RPM((RPM.Factor / Radian_Sec.Factor) * q.Value); }
        public static RPM From(IQuantity<double> q)
        {
            if (q.UnitSense != RPM.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"RPM\"", q.GetType().Name));
            return new RPM((RPM.Factor / q.UnitFactor) * q.Value);
        }
        #endregion

        #region IObject / IEquatable / IComparable
        public override int GetHashCode() { return m_value.GetHashCode(); }
        public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is RPM) && Equals((RPM)obj); }
        public bool /* IEquatable<RPM> */ Equals(RPM other) { return this.Value == other.Value; }
        public int /* IComparable<RPM> */ CompareTo(RPM other) { return this.Value.CompareTo(other.Value); }
        #endregion

        #region Comparison
        public static bool operator ==(RPM lhs, RPM rhs) { return lhs.Value == rhs.Value; }
        public static bool operator !=(RPM lhs, RPM rhs) { return lhs.Value != rhs.Value; }
        public static bool operator <(RPM lhs, RPM rhs) { return lhs.Value < rhs.Value; }
        public static bool operator >(RPM lhs, RPM rhs) { return lhs.Value > rhs.Value; }
        public static bool operator <=(RPM lhs, RPM rhs) { return lhs.Value <= rhs.Value; }
        public static bool operator >=(RPM lhs, RPM rhs) { return lhs.Value >= rhs.Value; }
        #endregion

        #region Arithmetic
        // Inner:
        public static RPM operator +(RPM lhs, RPM rhs) { return new RPM(lhs.Value + rhs.Value); }
        public static RPM operator -(RPM lhs, RPM rhs) { return new RPM(lhs.Value - rhs.Value); }
        public static RPM operator ++(RPM q) { return new RPM(q.Value + 1d); }
        public static RPM operator --(RPM q) { return new RPM(q.Value - 1d); }
        public static RPM operator -(RPM q) { return new RPM(-q.Value); }
        public static RPM operator *(double lhs, RPM rhs) { return new RPM(lhs * rhs.Value); }
        public static RPM operator *(RPM lhs, double rhs) { return new RPM(lhs.Value * rhs); }
        public static RPM operator /(RPM lhs, double rhs) { return new RPM(lhs.Value / rhs); }
        // Outer:
        public static double operator /(RPM lhs, RPM rhs) { return lhs.Value / rhs.Value; }
        public static Cycles operator *(RPM lhs, Minute rhs) { return new Cycles(lhs.Value * rhs.Value); }
        public static Cycles operator *(Minute lhs, RPM rhs) { return new Cycles(lhs.Value * rhs.Value); }
        #endregion

        #region Formatting
        public override string ToString() { return ToString(null, RPM.Format); }
        public string ToString(string format) { return ToString(null, format); }
        public string ToString(IFormatProvider fp) { return ToString(fp, RPM.Format); }
        public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, RPM.Symbol[0]); }
        #endregion

        #region Statics
        private static readonly Dimension s_sense = Cycles.Sense / Minute.Sense;
        private static readonly int s_family = 32;
        private static double s_factor = Cycles.Factor / Minute.Factor;
        private static string s_format = "{0} {1}";
        private static readonly SymbolCollection s_symbol = new SymbolCollection("rpm");

        private static readonly RPM s_one = new RPM(1d);
        private static readonly RPM s_zero = new RPM(0d);
        
        public static Dimension Sense { get { return s_sense; } }
        public static int Family { get { return s_family; } }
        public static double Factor { get { return s_factor; } set { s_factor = value; } }
        public static string Format { get { return s_format; } set { s_format = value; } }
        public static SymbolCollection Symbol { get { return s_symbol; } }

        public static RPM One { get { return s_one; } }
        public static RPM Zero { get { return s_zero; } }
        #endregion
    }
}
