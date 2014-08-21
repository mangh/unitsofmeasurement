/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
	public partial struct AtmTechnical : IQuantity<double>, IEquatable<AtmTechnical>, IComparable<AtmTechnical>
	{
		#region Fields
		private readonly double m_value;
		#endregion

		#region Properties

		// instance properties
		public double Value { get { return m_value; } }

		// unit properties
		public Dimension UnitSense { get { return AtmTechnical.Sense; } }
		public int UnitFamily { get { return AtmTechnical.Family; } }
		public double UnitFactor { get { return AtmTechnical.Factor; } }
		public string UnitFormat { get { return AtmTechnical.Format; } }
		public SymbolCollection UnitSymbol { get { return AtmTechnical.Symbol; } }

		#endregion

		#region Constructor(s)
		public AtmTechnical(double value)
		{
			m_value = value;
		}
		#endregion

		#region Conversions
		public static explicit operator AtmTechnical(double q) { return new AtmTechnical(q); }
		public static explicit operator AtmTechnical(Bar q) { return new AtmTechnical((AtmTechnical.Factor / Bar.Factor) * q.Value); }
		public static explicit operator AtmTechnical(Pascal q) { return new AtmTechnical((AtmTechnical.Factor / Pascal.Factor) * q.Value); }
		public static explicit operator AtmTechnical(MillimeterHg q) { return new AtmTechnical((AtmTechnical.Factor / MillimeterHg.Factor) * q.Value); }
		public static explicit operator AtmTechnical(AtmStandard q) { return new AtmTechnical((AtmTechnical.Factor / AtmStandard.Factor) * q.Value); }
        public static AtmTechnical From(IQuantity<double> q)
        {
			if (q.UnitSense != AtmTechnical.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"AtmTechnical\"", q.GetType().Name));
			return new AtmTechnical((AtmTechnical.Factor / q.UnitFactor) * q.Value);
        }
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_value.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is AtmTechnical) && Equals((AtmTechnical)obj); }
		public bool /* IEquatable<AtmTechnical> */ Equals(AtmTechnical other) { return this.Value == other.Value; }
		public int /* IComparable<AtmTechnical> */ CompareTo(AtmTechnical other) { return this.Value.CompareTo(other.Value); }
		#endregion

		#region Comparison
		public static bool operator ==(AtmTechnical lhs, AtmTechnical rhs) { return lhs.Value == rhs.Value; }
		public static bool operator !=(AtmTechnical lhs, AtmTechnical rhs) { return lhs.Value != rhs.Value; }
		public static bool operator <(AtmTechnical lhs, AtmTechnical rhs) { return lhs.Value < rhs.Value; }
		public static bool operator >(AtmTechnical lhs, AtmTechnical rhs) { return lhs.Value > rhs.Value; }
		public static bool operator <=(AtmTechnical lhs, AtmTechnical rhs) { return lhs.Value <= rhs.Value; }
		public static bool operator >=(AtmTechnical lhs, AtmTechnical rhs) { return lhs.Value >= rhs.Value; }
		#endregion

		#region Arithmetic
		// Inner:
		public static AtmTechnical operator +(AtmTechnical lhs, AtmTechnical rhs) { return new AtmTechnical(lhs.Value + rhs.Value); }
		public static AtmTechnical operator -(AtmTechnical lhs, AtmTechnical rhs) { return new AtmTechnical(lhs.Value - rhs.Value); }
		public static AtmTechnical operator ++(AtmTechnical q) { return new AtmTechnical(q.Value + 1d); }
		public static AtmTechnical operator --(AtmTechnical q) { return new AtmTechnical(q.Value - 1d); }
		public static AtmTechnical operator -(AtmTechnical q) { return new AtmTechnical(-q.Value); }
		public static AtmTechnical operator *(double lhs, AtmTechnical rhs) { return new AtmTechnical(lhs * rhs.Value); }
		public static AtmTechnical operator *(AtmTechnical lhs, double rhs) { return new AtmTechnical(lhs.Value * rhs); }
		public static AtmTechnical operator /(AtmTechnical lhs, double rhs) { return new AtmTechnical(lhs.Value / rhs); }
		// Outer:
		public static double operator /(AtmTechnical lhs, AtmTechnical rhs) { return lhs.Value / rhs.Value; }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, AtmTechnical.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, AtmTechnical.Format); }
		public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, AtmTechnical.Symbol[0]); }
		#endregion

		#region Statics
		private static readonly Dimension s_sense = Pascal.Sense;
		private static readonly int s_family = 51;
		private static double s_factor = Pascal.Factor / 98066.5d;
		private static string s_format = "{0} {1}";
		private static readonly SymbolCollection s_symbol = new SymbolCollection("at");

		private static readonly AtmTechnical s_one = new AtmTechnical(1d);
		private static readonly AtmTechnical s_zero = new AtmTechnical(0d);
		
		public static Dimension Sense { get { return s_sense; } }
		public static int Family { get { return s_family; } }
		public static double Factor { get { return s_factor; } set { s_factor = value; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static SymbolCollection Symbol { get { return s_symbol; } }

		public static AtmTechnical One { get { return s_one; } }
		public static AtmTechnical Zero { get { return s_zero; } }
		#endregion
	}
}
