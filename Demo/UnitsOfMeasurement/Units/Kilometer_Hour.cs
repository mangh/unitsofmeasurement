/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
	public partial struct Kilometer_Hour : IQuantity<double>, IEquatable<Kilometer_Hour>, IComparable<Kilometer_Hour>
	{
		#region Fields
		private readonly double m_value;
		#endregion

		#region Properties

		// instance properties
		public double Value { get { return m_value; } }

		// unit properties
		public Dimension UnitSense { get { return Kilometer_Hour.Sense; } }
		public int UnitFamily { get { return Kilometer_Hour.Family; } }
		public double UnitFactor { get { return Kilometer_Hour.Factor; } }
		public string UnitFormat { get { return Kilometer_Hour.Format; } }
		public SymbolCollection UnitSymbol { get { return Kilometer_Hour.Symbol; } }

		#endregion

		#region Constructor(s)
		public Kilometer_Hour(double value)
		{
			m_value = value;
		}
		#endregion

		#region Conversions
		public static explicit operator Kilometer_Hour(double q) { return new Kilometer_Hour(q); }
		public static explicit operator Kilometer_Hour(Meter_Sec q) { return new Kilometer_Hour((Kilometer_Hour.Factor / Meter_Sec.Factor) * q.Value); }
		public static explicit operator Kilometer_Hour(MPH q) { return new Kilometer_Hour((Kilometer_Hour.Factor / MPH.Factor) * q.Value); }
        public static Kilometer_Hour From(IQuantity<double> q)
        {
			if (q.UnitSense != Kilometer_Hour.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Kilometer_Hour\"", q.GetType().Name));
			return new Kilometer_Hour((Kilometer_Hour.Factor / q.UnitFactor) * q.Value);
        }
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_value.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Kilometer_Hour) && Equals((Kilometer_Hour)obj); }
		public bool /* IEquatable<Kilometer_Hour> */ Equals(Kilometer_Hour other) { return this.Value == other.Value; }
		public int /* IComparable<Kilometer_Hour> */ CompareTo(Kilometer_Hour other) { return this.Value.CompareTo(other.Value); }
		#endregion

		#region Comparison
		public static bool operator ==(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.Value == rhs.Value; }
		public static bool operator !=(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.Value != rhs.Value; }
		public static bool operator <(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.Value < rhs.Value; }
		public static bool operator >(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.Value > rhs.Value; }
		public static bool operator <=(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.Value <= rhs.Value; }
		public static bool operator >=(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.Value >= rhs.Value; }
		#endregion

		#region Arithmetic
		// Inner:
		public static Kilometer_Hour operator +(Kilometer_Hour lhs, Kilometer_Hour rhs) { return new Kilometer_Hour(lhs.Value + rhs.Value); }
		public static Kilometer_Hour operator -(Kilometer_Hour lhs, Kilometer_Hour rhs) { return new Kilometer_Hour(lhs.Value - rhs.Value); }
		public static Kilometer_Hour operator ++(Kilometer_Hour q) { return new Kilometer_Hour(q.Value + 1d); }
		public static Kilometer_Hour operator --(Kilometer_Hour q) { return new Kilometer_Hour(q.Value - 1d); }
		public static Kilometer_Hour operator -(Kilometer_Hour q) { return new Kilometer_Hour(-q.Value); }
		public static Kilometer_Hour operator *(double lhs, Kilometer_Hour rhs) { return new Kilometer_Hour(lhs * rhs.Value); }
		public static Kilometer_Hour operator *(Kilometer_Hour lhs, double rhs) { return new Kilometer_Hour(lhs.Value * rhs); }
		public static Kilometer_Hour operator /(Kilometer_Hour lhs, double rhs) { return new Kilometer_Hour(lhs.Value / rhs); }
		// Outer:
		public static double operator /(Kilometer_Hour lhs, Kilometer_Hour rhs) { return lhs.Value / rhs.Value; }
		public static Kilometer operator *(Kilometer_Hour lhs, Hour rhs) { return new Kilometer(lhs.Value * rhs.Value); }
		public static Kilometer operator *(Hour lhs, Kilometer_Hour rhs) { return new Kilometer(lhs.Value * rhs.Value); }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, Kilometer_Hour.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, Kilometer_Hour.Format); }
		public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Kilometer_Hour.Symbol[0]); }
		#endregion

		#region Statics
		private static readonly Dimension s_sense = Kilometer.Sense / Hour.Sense;
		private static readonly int s_family = 38;
		private static double s_factor = Kilometer.Factor / Hour.Factor;
		private static string s_format = "{0} {1}";
		private static readonly SymbolCollection s_symbol = new SymbolCollection("km/h");

		private static readonly Kilometer_Hour s_one = new Kilometer_Hour(1d);
		private static readonly Kilometer_Hour s_zero = new Kilometer_Hour(0d);
		
		public static Dimension Sense { get { return s_sense; } }
		public static int Family { get { return s_family; } }
		public static double Factor { get { return s_factor; } set { s_factor = value; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static SymbolCollection Symbol { get { return s_symbol; } }

		public static Kilometer_Hour One { get { return s_one; } }
		public static Kilometer_Hour Zero { get { return s_zero; } }
		#endregion
	}
}
