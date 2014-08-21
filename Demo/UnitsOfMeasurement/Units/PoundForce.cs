/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
	public partial struct PoundForce : IQuantity<double>, IEquatable<PoundForce>, IComparable<PoundForce>
	{
		#region Fields
		private readonly double m_value;
		#endregion

		#region Properties

		// instance properties
		public double Value { get { return m_value; } }

		// unit properties
		public Dimension UnitSense { get { return PoundForce.Sense; } }
		public int UnitFamily { get { return PoundForce.Family; } }
		public double UnitFactor { get { return PoundForce.Factor; } }
		public string UnitFormat { get { return PoundForce.Format; } }
		public SymbolCollection UnitSymbol { get { return PoundForce.Symbol; } }

		#endregion

		#region Constructor(s)
		public PoundForce(double value)
		{
			m_value = value;
		}
		#endregion

		#region Conversions
		public static explicit operator PoundForce(double q) { return new PoundForce(q); }
		public static explicit operator PoundForce(Newton q) { return new PoundForce((PoundForce.Factor / Newton.Factor) * q.Value); }
		public static explicit operator PoundForce(Dyne q) { return new PoundForce((PoundForce.Factor / Dyne.Factor) * q.Value); }
		public static explicit operator PoundForce(Poundal q) { return new PoundForce((PoundForce.Factor / Poundal.Factor) * q.Value); }
        public static PoundForce From(IQuantity<double> q)
        {
			if (q.UnitSense != PoundForce.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"PoundForce\"", q.GetType().Name));
			return new PoundForce((PoundForce.Factor / q.UnitFactor) * q.Value);
        }
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_value.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is PoundForce) && Equals((PoundForce)obj); }
		public bool /* IEquatable<PoundForce> */ Equals(PoundForce other) { return this.Value == other.Value; }
		public int /* IComparable<PoundForce> */ CompareTo(PoundForce other) { return this.Value.CompareTo(other.Value); }
		#endregion

		#region Comparison
		public static bool operator ==(PoundForce lhs, PoundForce rhs) { return lhs.Value == rhs.Value; }
		public static bool operator !=(PoundForce lhs, PoundForce rhs) { return lhs.Value != rhs.Value; }
		public static bool operator <(PoundForce lhs, PoundForce rhs) { return lhs.Value < rhs.Value; }
		public static bool operator >(PoundForce lhs, PoundForce rhs) { return lhs.Value > rhs.Value; }
		public static bool operator <=(PoundForce lhs, PoundForce rhs) { return lhs.Value <= rhs.Value; }
		public static bool operator >=(PoundForce lhs, PoundForce rhs) { return lhs.Value >= rhs.Value; }
		#endregion

		#region Arithmetic
		// Inner:
		public static PoundForce operator +(PoundForce lhs, PoundForce rhs) { return new PoundForce(lhs.Value + rhs.Value); }
		public static PoundForce operator -(PoundForce lhs, PoundForce rhs) { return new PoundForce(lhs.Value - rhs.Value); }
		public static PoundForce operator ++(PoundForce q) { return new PoundForce(q.Value + 1d); }
		public static PoundForce operator --(PoundForce q) { return new PoundForce(q.Value - 1d); }
		public static PoundForce operator -(PoundForce q) { return new PoundForce(-q.Value); }
		public static PoundForce operator *(double lhs, PoundForce rhs) { return new PoundForce(lhs * rhs.Value); }
		public static PoundForce operator *(PoundForce lhs, double rhs) { return new PoundForce(lhs.Value * rhs); }
		public static PoundForce operator /(PoundForce lhs, double rhs) { return new PoundForce(lhs.Value / rhs); }
		// Outer:
		public static double operator /(PoundForce lhs, PoundForce rhs) { return lhs.Value / rhs.Value; }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, PoundForce.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, PoundForce.Format); }
		public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, PoundForce.Symbol[0]); }
		#endregion

		#region Statics
		private static readonly Dimension s_sense = Newton.Sense;
		private static readonly int s_family = 42;
		private static double s_factor = Newton.Factor / 4.4482216152605d;
		private static string s_format = "{0} {1}";
		private static readonly SymbolCollection s_symbol = new SymbolCollection("lbf");

		private static readonly PoundForce s_one = new PoundForce(1d);
		private static readonly PoundForce s_zero = new PoundForce(0d);
		
		public static Dimension Sense { get { return s_sense; } }
		public static int Family { get { return s_family; } }
		public static double Factor { get { return s_factor; } set { s_factor = value; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static SymbolCollection Symbol { get { return s_symbol; } }

		public static PoundForce One { get { return s_one; } }
		public static PoundForce Zero { get { return s_zero; } }
		#endregion
	}
}
