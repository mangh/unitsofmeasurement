/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace $safeprojectname$
{
	public partial struct NewtonMeter : IQuantity<double>, IEquatable<NewtonMeter>, IComparable<NewtonMeter>
	{
		#region Fields
		private readonly double m_value;
		#endregion

		#region Properties

		// instance properties
		public double Value { get { return m_value; } }

		// unit properties
		public Dimension UnitSense { get { return NewtonMeter.Sense; } }
		public int UnitFamily { get { return NewtonMeter.Family; } }
		public double UnitFactor { get { return NewtonMeter.Factor; } }
		public string UnitFormat { get { return NewtonMeter.Format; } }
		public SymbolCollection UnitSymbol { get { return NewtonMeter.Symbol; } }

		#endregion

		#region Constructor(s)
		public NewtonMeter(double value)
		{
			m_value = value;
		}
		#endregion

		#region Conversions
		public static explicit operator NewtonMeter(double q) { return new NewtonMeter(q); }
        public static NewtonMeter From(IQuantity<double> q)
        {
			if (q.UnitSense != NewtonMeter.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"NewtonMeter\"", q.GetType().Name));
			return new NewtonMeter((NewtonMeter.Factor / q.UnitFactor) * q.Value);
        }
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_value.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is NewtonMeter) && Equals((NewtonMeter)obj); }
		public bool /* IEquatable<NewtonMeter> */ Equals(NewtonMeter other) { return this.Value == other.Value; }
		public int /* IComparable<NewtonMeter> */ CompareTo(NewtonMeter other) { return this.Value.CompareTo(other.Value); }
		#endregion

		#region Comparison
		public static bool operator ==(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value == rhs.Value; }
		public static bool operator !=(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value != rhs.Value; }
		public static bool operator <(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value < rhs.Value; }
		public static bool operator >(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value > rhs.Value; }
		public static bool operator <=(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value <= rhs.Value; }
		public static bool operator >=(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value >= rhs.Value; }
		#endregion

		#region Arithmetic
		// Inner:
		public static NewtonMeter operator +(NewtonMeter lhs, NewtonMeter rhs) { return new NewtonMeter(lhs.Value + rhs.Value); }
		public static NewtonMeter operator -(NewtonMeter lhs, NewtonMeter rhs) { return new NewtonMeter(lhs.Value - rhs.Value); }
		public static NewtonMeter operator ++(NewtonMeter q) { return new NewtonMeter(q.Value + 1d); }
		public static NewtonMeter operator --(NewtonMeter q) { return new NewtonMeter(q.Value - 1d); }
		public static NewtonMeter operator -(NewtonMeter q) { return new NewtonMeter(-q.Value); }
		public static NewtonMeter operator *(double lhs, NewtonMeter rhs) { return new NewtonMeter(lhs * rhs.Value); }
		public static NewtonMeter operator *(NewtonMeter lhs, double rhs) { return new NewtonMeter(lhs.Value * rhs); }
		public static NewtonMeter operator /(NewtonMeter lhs, double rhs) { return new NewtonMeter(lhs.Value / rhs); }
		// Outer:
		public static double operator /(NewtonMeter lhs, NewtonMeter rhs) { return lhs.Value / rhs.Value; }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, NewtonMeter.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, NewtonMeter.Format); }
		public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, NewtonMeter.Symbol[0]); }
		#endregion

		#region Statics
		private static readonly Dimension s_sense = Kilogram.Sense * Meter_Sec2.Sense * Meter.Sense;
		private static readonly int s_family = 19;
		private static double s_factor = Kilogram.Factor * Meter_Sec2.Factor * Meter.Factor;
		private static string s_format = "{0} {1}";
		private static readonly SymbolCollection s_symbol = new SymbolCollection("N\u00B7m", "N*m");

		private static readonly NewtonMeter s_one = new NewtonMeter(1d);
		private static readonly NewtonMeter s_zero = new NewtonMeter(0d);
		
		public static Dimension Sense { get { return s_sense; } }
		public static int Family { get { return s_family; } }
		public static double Factor { get { return s_factor; } set { s_factor = value; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static SymbolCollection Symbol { get { return s_symbol; } }

		public static NewtonMeter One { get { return s_one; } }
		public static NewtonMeter Zero { get { return s_zero; } }
		#endregion
	}
}
