/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace $safeprojectname$
{
	public partial struct SquareMeter : IQuantity<double>, IEquatable<SquareMeter>, IComparable<SquareMeter>
	{
		#region Fields
		private readonly double m_value;
		#endregion

		#region Properties

		// instance properties
		public double Value { get { return m_value; } }

		// unit properties
		public Dimension UnitSense { get { return SquareMeter.Sense; } }
		public int UnitFamily { get { return SquareMeter.Family; } }
		public double UnitFactor { get { return SquareMeter.Factor; } }
		public string UnitFormat { get { return SquareMeter.Format; } }
		public SymbolCollection UnitSymbol { get { return SquareMeter.Symbol; } }

		#endregion

		#region Constructor(s)
		public SquareMeter(double value)
		{
			m_value = value;
		}
		#endregion

		#region Conversions
		public static explicit operator SquareMeter(double q) { return new SquareMeter(q); }
        public static SquareMeter From(IQuantity<double> q)
        {
			if (q.UnitSense != SquareMeter.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"SquareMeter\"", q.GetType().Name));
			return new SquareMeter((SquareMeter.Factor / q.UnitFactor) * q.Value);
        }
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_value.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is SquareMeter) && Equals((SquareMeter)obj); }
		public bool /* IEquatable<SquareMeter> */ Equals(SquareMeter other) { return this.Value == other.Value; }
		public int /* IComparable<SquareMeter> */ CompareTo(SquareMeter other) { return this.Value.CompareTo(other.Value); }
		#endregion

		#region Comparison
		public static bool operator ==(SquareMeter lhs, SquareMeter rhs) { return lhs.Value == rhs.Value; }
		public static bool operator !=(SquareMeter lhs, SquareMeter rhs) { return lhs.Value != rhs.Value; }
		public static bool operator <(SquareMeter lhs, SquareMeter rhs) { return lhs.Value < rhs.Value; }
		public static bool operator >(SquareMeter lhs, SquareMeter rhs) { return lhs.Value > rhs.Value; }
		public static bool operator <=(SquareMeter lhs, SquareMeter rhs) { return lhs.Value <= rhs.Value; }
		public static bool operator >=(SquareMeter lhs, SquareMeter rhs) { return lhs.Value >= rhs.Value; }
		#endregion

		#region Arithmetic
		// Inner:
		public static SquareMeter operator +(SquareMeter lhs, SquareMeter rhs) { return new SquareMeter(lhs.Value + rhs.Value); }
		public static SquareMeter operator -(SquareMeter lhs, SquareMeter rhs) { return new SquareMeter(lhs.Value - rhs.Value); }
		public static SquareMeter operator ++(SquareMeter q) { return new SquareMeter(q.Value + 1d); }
		public static SquareMeter operator --(SquareMeter q) { return new SquareMeter(q.Value - 1d); }
		public static SquareMeter operator -(SquareMeter q) { return new SquareMeter(-q.Value); }
		public static SquareMeter operator *(double lhs, SquareMeter rhs) { return new SquareMeter(lhs * rhs.Value); }
		public static SquareMeter operator *(SquareMeter lhs, double rhs) { return new SquareMeter(lhs.Value * rhs); }
		public static SquareMeter operator /(SquareMeter lhs, double rhs) { return new SquareMeter(lhs.Value / rhs); }
		// Outer:
		public static double operator /(SquareMeter lhs, SquareMeter rhs) { return lhs.Value / rhs.Value; }
		public static Meter operator /(SquareMeter lhs, Meter rhs) { return new Meter(lhs.Value / rhs.Value); }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, SquareMeter.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, SquareMeter.Format); }
		public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, SquareMeter.Symbol[0]); }
		#endregion

		#region Statics
		private static readonly Dimension s_sense = Meter.Sense * Meter.Sense;
		private static readonly int s_family = 14;
		private static double s_factor = Meter.Factor * Meter.Factor;
		private static string s_format = "{0} {1}";
		private static readonly SymbolCollection s_symbol = new SymbolCollection("m\u00B2", "m2");

		private static readonly SquareMeter s_one = new SquareMeter(1d);
		private static readonly SquareMeter s_zero = new SquareMeter(0d);
		
		public static Dimension Sense { get { return s_sense; } }
		public static int Family { get { return s_family; } }
		public static double Factor { get { return s_factor; } set { s_factor = value; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static SymbolCollection Symbol { get { return s_symbol; } }

		public static SquareMeter One { get { return s_one; } }
		public static SquareMeter Zero { get { return s_zero; } }
		#endregion
	}
}
