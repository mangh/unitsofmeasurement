/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
	public partial struct Pascal : IQuantity<double>, IEquatable<Pascal>, IComparable<Pascal>
	{
		#region Fields
		private readonly double m_value;
		#endregion

		#region Properties

		// instance properties
		public double Value { get { return m_value; } }

		// unit properties
		public Dimension UnitSense { get { return Pascal.Sense; } }
		public int UnitFamily { get { return Pascal.Family; } }
		public double UnitFactor { get { return Pascal.Factor; } }
		public string UnitFormat { get { return Pascal.Format; } }
		public SymbolCollection UnitSymbol { get { return Pascal.Symbol; } }

		#endregion

		#region Constructor(s)
		public Pascal(double value)
		{
			m_value = value;
		}
		#endregion

		#region Conversions
		public static explicit operator Pascal(double q) { return new Pascal(q); }
		public static explicit operator Pascal(MillimeterHg q) { return new Pascal((Pascal.Factor / MillimeterHg.Factor) * q.Value); }
		public static explicit operator Pascal(AtmStandard q) { return new Pascal((Pascal.Factor / AtmStandard.Factor) * q.Value); }
		public static explicit operator Pascal(AtmTechnical q) { return new Pascal((Pascal.Factor / AtmTechnical.Factor) * q.Value); }
		public static explicit operator Pascal(Bar q) { return new Pascal((Pascal.Factor / Bar.Factor) * q.Value); }
        public static Pascal From(IQuantity<double> q)
        {
			if (q.UnitSense != Pascal.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"Pascal\"", q.GetType().Name));
			return new Pascal((Pascal.Factor / q.UnitFactor) * q.Value);
        }
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_value.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Pascal) && Equals((Pascal)obj); }
		public bool /* IEquatable<Pascal> */ Equals(Pascal other) { return this.Value == other.Value; }
		public int /* IComparable<Pascal> */ CompareTo(Pascal other) { return this.Value.CompareTo(other.Value); }
		#endregion

		#region Comparison
		public static bool operator ==(Pascal lhs, Pascal rhs) { return lhs.Value == rhs.Value; }
		public static bool operator !=(Pascal lhs, Pascal rhs) { return lhs.Value != rhs.Value; }
		public static bool operator <(Pascal lhs, Pascal rhs) { return lhs.Value < rhs.Value; }
		public static bool operator >(Pascal lhs, Pascal rhs) { return lhs.Value > rhs.Value; }
		public static bool operator <=(Pascal lhs, Pascal rhs) { return lhs.Value <= rhs.Value; }
		public static bool operator >=(Pascal lhs, Pascal rhs) { return lhs.Value >= rhs.Value; }
		#endregion

		#region Arithmetic
		// Inner:
		public static Pascal operator +(Pascal lhs, Pascal rhs) { return new Pascal(lhs.Value + rhs.Value); }
		public static Pascal operator -(Pascal lhs, Pascal rhs) { return new Pascal(lhs.Value - rhs.Value); }
		public static Pascal operator ++(Pascal q) { return new Pascal(q.Value + 1d); }
		public static Pascal operator --(Pascal q) { return new Pascal(q.Value - 1d); }
		public static Pascal operator -(Pascal q) { return new Pascal(-q.Value); }
		public static Pascal operator *(double lhs, Pascal rhs) { return new Pascal(lhs * rhs.Value); }
		public static Pascal operator *(Pascal lhs, double rhs) { return new Pascal(lhs.Value * rhs); }
		public static Pascal operator /(Pascal lhs, double rhs) { return new Pascal(lhs.Value / rhs); }
		// Outer:
		public static double operator /(Pascal lhs, Pascal rhs) { return lhs.Value / rhs.Value; }
		public static Newton operator *(Pascal lhs, SquareMeter rhs) { return new Newton(lhs.Value * rhs.Value); }
		public static Newton operator *(SquareMeter lhs, Pascal rhs) { return new Newton(lhs.Value * rhs.Value); }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, Pascal.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, Pascal.Format); }
		public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, Pascal.Symbol[0]); }
		#endregion

		#region Statics
		private static readonly Dimension s_sense = Newton.Sense / SquareMeter.Sense;
		private static readonly int s_family = 51;
		private static double s_factor = Newton.Factor / SquareMeter.Factor;
		private static string s_format = "{0} {1}";
		private static readonly SymbolCollection s_symbol = new SymbolCollection("Pa");

		private static readonly Pascal s_one = new Pascal(1d);
		private static readonly Pascal s_zero = new Pascal(0d);
		
		public static Dimension Sense { get { return s_sense; } }
		public static int Family { get { return s_family; } }
		public static double Factor { get { return s_factor; } set { s_factor = value; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static SymbolCollection Symbol { get { return s_symbol; } }

		public static Pascal One { get { return s_one; } }
		public static Pascal Zero { get { return s_zero; } }
		#endregion
	}
}
