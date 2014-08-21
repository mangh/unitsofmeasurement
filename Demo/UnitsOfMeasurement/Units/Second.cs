/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
	public partial struct Second : IQuantity<double>, IEquatable<Second>, IComparable<Second>
	{
		#region Fields
		private readonly double m_value;
		#endregion

		#region Properties

		// instance properties
		public double Value { get { return m_value; } }

		// unit properties
		public Dimension UnitSense { get { return Second.Sense; } }
		public int UnitFamily { get { return Second.Family; } }
		public double UnitFactor { get { return Second.Factor; } }
		public string UnitFormat { get { return Second.Format; } }
		public SymbolCollection UnitSymbol { get { return Second.Symbol; } }

		#endregion

		#region Constructor(s)
		public Second(double value)
		{
			m_value = value;
		}
		#endregion

		#region Conversions
		public static explicit operator Second(double q) { return new Second(q); }
		public static explicit operator Second(Minute q) { return new Second((Second.Factor / Minute.Factor) * q.Value); }
		public static explicit operator Second(Hour q) { return new Second((Second.Factor / Hour.Factor) * q.Value); }
        public static Second From(IQuantity<double> q)
        {
			if (q.UnitSense != Second.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Second\"", q.GetType().Name));
			return new Second((Second.Factor / q.UnitFactor) * q.Value);
        }
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_value.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Second) && Equals((Second)obj); }
		public bool /* IEquatable<Second> */ Equals(Second other) { return this.Value == other.Value; }
		public int /* IComparable<Second> */ CompareTo(Second other) { return this.Value.CompareTo(other.Value); }
		#endregion

		#region Comparison
		public static bool operator ==(Second lhs, Second rhs) { return lhs.Value == rhs.Value; }
		public static bool operator !=(Second lhs, Second rhs) { return lhs.Value != rhs.Value; }
		public static bool operator <(Second lhs, Second rhs) { return lhs.Value < rhs.Value; }
		public static bool operator >(Second lhs, Second rhs) { return lhs.Value > rhs.Value; }
		public static bool operator <=(Second lhs, Second rhs) { return lhs.Value <= rhs.Value; }
		public static bool operator >=(Second lhs, Second rhs) { return lhs.Value >= rhs.Value; }
		#endregion

		#region Arithmetic
		// Inner:
		public static Second operator +(Second lhs, Second rhs) { return new Second(lhs.Value + rhs.Value); }
		public static Second operator -(Second lhs, Second rhs) { return new Second(lhs.Value - rhs.Value); }
		public static Second operator ++(Second q) { return new Second(q.Value + 1d); }
		public static Second operator --(Second q) { return new Second(q.Value - 1d); }
		public static Second operator -(Second q) { return new Second(-q.Value); }
		public static Second operator *(double lhs, Second rhs) { return new Second(lhs * rhs.Value); }
		public static Second operator *(Second lhs, double rhs) { return new Second(lhs.Value * rhs); }
		public static Second operator /(Second lhs, double rhs) { return new Second(lhs.Value / rhs); }
		// Outer:
		public static double operator /(Second lhs, Second rhs) { return lhs.Value / rhs.Value; }
		public static Farad operator /(Second lhs, Ohm rhs) { return new Farad(lhs.Value / rhs.Value); }
		public static Ohm operator /(Second lhs, Farad rhs) { return new Ohm(lhs.Value / rhs.Value); }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, Second.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, Second.Format); }
		public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Second.Symbol[0]); }
		#endregion

		#region Statics
		private static readonly Dimension s_sense = Dimension.Time;
		private static readonly int s_family = 8;
		private static double s_factor = 1d;
		private static string s_format = "{0} {1}";
		private static readonly SymbolCollection s_symbol = new SymbolCollection("s");

		private static readonly Second s_one = new Second(1d);
		private static readonly Second s_zero = new Second(0d);
		
		public static Dimension Sense { get { return s_sense; } }
		public static int Family { get { return s_family; } }
		public static double Factor { get { return s_factor; } set { s_factor = value; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static SymbolCollection Symbol { get { return s_symbol; } }

		public static Second One { get { return s_one; } }
		public static Second Zero { get { return s_zero; } }
		#endregion
	}
}
