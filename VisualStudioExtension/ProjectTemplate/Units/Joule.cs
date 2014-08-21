/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace $safeprojectname$
{
	public partial struct Joule : IQuantity<double>, IEquatable<Joule>, IComparable<Joule>
	{
		#region Fields
		private readonly double m_value;
		#endregion

		#region Properties

		// instance properties
		public double Value { get { return m_value; } }

		// unit properties
		public Dimension UnitSense { get { return Joule.Sense; } }
		public int UnitFamily { get { return Joule.Family; } }
		public double UnitFactor { get { return Joule.Factor; } }
		public string UnitFormat { get { return Joule.Format; } }
		public SymbolCollection UnitSymbol { get { return Joule.Symbol; } }

		#endregion

		#region Constructor(s)
		public Joule(double value)
		{
			m_value = value;
		}
		#endregion

		#region Conversions
		public static explicit operator Joule(double q) { return new Joule(q); }
        public static Joule From(IQuantity<double> q)
        {
			if (q.UnitSense != Joule.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Joule\"", q.GetType().Name));
			return new Joule((Joule.Factor / q.UnitFactor) * q.Value);
        }
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_value.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Joule) && Equals((Joule)obj); }
		public bool /* IEquatable<Joule> */ Equals(Joule other) { return this.Value == other.Value; }
		public int /* IComparable<Joule> */ CompareTo(Joule other) { return this.Value.CompareTo(other.Value); }
		#endregion

		#region Comparison
		public static bool operator ==(Joule lhs, Joule rhs) { return lhs.Value == rhs.Value; }
		public static bool operator !=(Joule lhs, Joule rhs) { return lhs.Value != rhs.Value; }
		public static bool operator <(Joule lhs, Joule rhs) { return lhs.Value < rhs.Value; }
		public static bool operator >(Joule lhs, Joule rhs) { return lhs.Value > rhs.Value; }
		public static bool operator <=(Joule lhs, Joule rhs) { return lhs.Value <= rhs.Value; }
		public static bool operator >=(Joule lhs, Joule rhs) { return lhs.Value >= rhs.Value; }
		#endregion

		#region Arithmetic
		// Inner:
		public static Joule operator +(Joule lhs, Joule rhs) { return new Joule(lhs.Value + rhs.Value); }
		public static Joule operator -(Joule lhs, Joule rhs) { return new Joule(lhs.Value - rhs.Value); }
		public static Joule operator ++(Joule q) { return new Joule(q.Value + 1d); }
		public static Joule operator --(Joule q) { return new Joule(q.Value - 1d); }
		public static Joule operator -(Joule q) { return new Joule(-q.Value); }
		public static Joule operator *(double lhs, Joule rhs) { return new Joule(lhs * rhs.Value); }
		public static Joule operator *(Joule lhs, double rhs) { return new Joule(lhs.Value * rhs); }
		public static Joule operator /(Joule lhs, double rhs) { return new Joule(lhs.Value / rhs); }
		// Outer:
		public static double operator /(Joule lhs, Joule rhs) { return lhs.Value / rhs.Value; }
		public static Meter operator /(Joule lhs, Newton rhs) { return new Meter(lhs.Value / rhs.Value); }
		public static Newton operator /(Joule lhs, Meter rhs) { return new Newton(lhs.Value / rhs.Value); }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, Joule.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, Joule.Format); }
		public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Joule.Symbol[0]); }
		#endregion

		#region Statics
		private static readonly Dimension s_sense = Newton.Sense * Meter.Sense;
		private static readonly int s_family = 18;
		private static double s_factor = Newton.Factor * Meter.Factor;
		private static string s_format = "{0} {1}";
		private static readonly SymbolCollection s_symbol = new SymbolCollection("J");

		private static readonly Joule s_one = new Joule(1d);
		private static readonly Joule s_zero = new Joule(0d);
		
		public static Dimension Sense { get { return s_sense; } }
		public static int Family { get { return s_family; } }
		public static double Factor { get { return s_factor; } set { s_factor = value; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static SymbolCollection Symbol { get { return s_symbol; } }

		public static Joule One { get { return s_one; } }
		public static Joule Zero { get { return s_zero; } }
		#endregion
	}
}
