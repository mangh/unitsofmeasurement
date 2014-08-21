/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace $safeprojectname$
{
	public partial struct Meter : IQuantity<double>, IEquatable<Meter>, IComparable<Meter>
	{
		#region Fields
		private readonly double m_value;
		#endregion

		#region Properties

		// instance properties
		public double Value { get { return m_value; } }

		// unit properties
		public Dimension UnitSense { get { return Meter.Sense; } }
		public int UnitFamily { get { return Meter.Family; } }
		public double UnitFactor { get { return Meter.Factor; } }
		public string UnitFormat { get { return Meter.Format; } }
		public SymbolCollection UnitSymbol { get { return Meter.Symbol; } }

		#endregion

		#region Constructor(s)
		public Meter(double value)
		{
			m_value = value;
		}
		#endregion

		#region Conversions
		public static explicit operator Meter(double q) { return new Meter(q); }
        public static Meter From(IQuantity<double> q)
        {
			if (q.UnitSense != Meter.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Meter\"", q.GetType().Name));
			return new Meter((Meter.Factor / q.UnitFactor) * q.Value);
        }
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_value.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Meter) && Equals((Meter)obj); }
		public bool /* IEquatable<Meter> */ Equals(Meter other) { return this.Value == other.Value; }
		public int /* IComparable<Meter> */ CompareTo(Meter other) { return this.Value.CompareTo(other.Value); }
		#endregion

		#region Comparison
		public static bool operator ==(Meter lhs, Meter rhs) { return lhs.Value == rhs.Value; }
		public static bool operator !=(Meter lhs, Meter rhs) { return lhs.Value != rhs.Value; }
		public static bool operator <(Meter lhs, Meter rhs) { return lhs.Value < rhs.Value; }
		public static bool operator >(Meter lhs, Meter rhs) { return lhs.Value > rhs.Value; }
		public static bool operator <=(Meter lhs, Meter rhs) { return lhs.Value <= rhs.Value; }
		public static bool operator >=(Meter lhs, Meter rhs) { return lhs.Value >= rhs.Value; }
		#endregion

		#region Arithmetic
		// Inner:
		public static Meter operator +(Meter lhs, Meter rhs) { return new Meter(lhs.Value + rhs.Value); }
		public static Meter operator -(Meter lhs, Meter rhs) { return new Meter(lhs.Value - rhs.Value); }
		public static Meter operator ++(Meter q) { return new Meter(q.Value + 1d); }
		public static Meter operator --(Meter q) { return new Meter(q.Value - 1d); }
		public static Meter operator -(Meter q) { return new Meter(-q.Value); }
		public static Meter operator *(double lhs, Meter rhs) { return new Meter(lhs * rhs.Value); }
		public static Meter operator *(Meter lhs, double rhs) { return new Meter(lhs.Value * rhs); }
		public static Meter operator /(Meter lhs, double rhs) { return new Meter(lhs.Value / rhs); }
		// Outer:
		public static double operator /(Meter lhs, Meter rhs) { return lhs.Value / rhs.Value; }
		public static SquareMeter operator *(Meter lhs, Meter rhs) { return new SquareMeter(lhs.Value * rhs.Value); }
		public static Meter_Sec operator /(Meter lhs, Second rhs) { return new Meter_Sec(lhs.Value / rhs.Value); }
		public static Second operator /(Meter lhs, Meter_Sec rhs) { return new Second(lhs.Value / rhs.Value); }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, Meter.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, Meter.Format); }
		public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Meter.Symbol[0]); }
		#endregion

		#region Statics
		private static readonly Dimension s_sense = Dimension.Length;
		private static readonly int s_family = 0;
		private static double s_factor = 1d;
		private static string s_format = "{0} {1}";
		private static readonly SymbolCollection s_symbol = new SymbolCollection("m");

		private static readonly Meter s_one = new Meter(1d);
		private static readonly Meter s_zero = new Meter(0d);
		
		public static Dimension Sense { get { return s_sense; } }
		public static int Family { get { return s_family; } }
		public static double Factor { get { return s_factor; } set { s_factor = value; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static SymbolCollection Symbol { get { return s_symbol; } }

		public static Meter One { get { return s_one; } }
		public static Meter Zero { get { return s_zero; } }
		#endregion
	}
}
