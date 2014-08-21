/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
	public partial struct EUR : IQuantity<decimal>, IEquatable<EUR>, IComparable<EUR>
	{
		#region Fields
		private readonly decimal m_value;
		#endregion

		#region Properties

		// instance properties
		public decimal Value { get { return m_value; } }

		// unit properties
		public Dimension UnitSense { get { return EUR.Sense; } }
		public int UnitFamily { get { return EUR.Family; } }
		public decimal UnitFactor { get { return EUR.Factor; } }
		public string UnitFormat { get { return EUR.Format; } }
		public SymbolCollection UnitSymbol { get { return EUR.Symbol; } }

		#endregion

		#region Constructor(s)
		public EUR(decimal value)
		{
			m_value = value;
		}
		#endregion

		#region Conversions
		public static explicit operator EUR(decimal q) { return new EUR(q); }
		public static explicit operator EUR(PLN q) { return new EUR((EUR.Factor / PLN.Factor) * q.Value); }
		public static explicit operator EUR(GBP q) { return new EUR((EUR.Factor / GBP.Factor) * q.Value); }
		public static explicit operator EUR(USD q) { return new EUR((EUR.Factor / USD.Factor) * q.Value); }
        public static EUR From(IQuantity<decimal> q)
        {
			if (q.UnitSense != EUR.Sense) throw new InvalidOperationException(String.Format("Cannot convert type \"{0}\" to \"EUR\"", q.GetType().Name));
			return new EUR((EUR.Factor / q.UnitFactor) * q.Value);
        }
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_value.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is EUR) && Equals((EUR)obj); }
		public bool /* IEquatable<EUR> */ Equals(EUR other) { return this.Value == other.Value; }
		public int /* IComparable<EUR> */ CompareTo(EUR other) { return this.Value.CompareTo(other.Value); }
		#endregion

		#region Comparison
		public static bool operator ==(EUR lhs, EUR rhs) { return lhs.Value == rhs.Value; }
		public static bool operator !=(EUR lhs, EUR rhs) { return lhs.Value != rhs.Value; }
		public static bool operator <(EUR lhs, EUR rhs) { return lhs.Value < rhs.Value; }
		public static bool operator >(EUR lhs, EUR rhs) { return lhs.Value > rhs.Value; }
		public static bool operator <=(EUR lhs, EUR rhs) { return lhs.Value <= rhs.Value; }
		public static bool operator >=(EUR lhs, EUR rhs) { return lhs.Value >= rhs.Value; }
		#endregion

		#region Arithmetic
		// Inner:
		public static EUR operator +(EUR lhs, EUR rhs) { return new EUR(lhs.Value + rhs.Value); }
		public static EUR operator -(EUR lhs, EUR rhs) { return new EUR(lhs.Value - rhs.Value); }
		public static EUR operator ++(EUR q) { return new EUR(q.Value + decimal.One); }
		public static EUR operator --(EUR q) { return new EUR(q.Value - decimal.One); }
		public static EUR operator -(EUR q) { return new EUR(-q.Value); }
		public static EUR operator *(decimal lhs, EUR rhs) { return new EUR(lhs * rhs.Value); }
		public static EUR operator *(EUR lhs, decimal rhs) { return new EUR(lhs.Value * rhs); }
		public static EUR operator /(EUR lhs, decimal rhs) { return new EUR(lhs.Value / rhs); }
		// Outer:
		public static decimal operator /(EUR lhs, EUR rhs) { return lhs.Value / rhs.Value; }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, EUR.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, EUR.Format); }
		public string ToString(IFormatProvider fp, string format) { return String.Format(fp, format, Value, EUR.Symbol[0]); }
		#endregion

		#region Statics
		private static readonly Dimension s_sense = Dimension.Other;
		private static readonly int s_family = 23;
		private static decimal s_factor = decimal.One;
		private static string s_format = "{0} {1}";
		private static readonly SymbolCollection s_symbol = new SymbolCollection("EUR");

		private static readonly EUR s_one = new EUR(decimal.One);
		private static readonly EUR s_zero = new EUR(decimal.Zero);
		
		public static Dimension Sense { get { return s_sense; } }
		public static int Family { get { return s_family; } }
		public static decimal Factor { get { return s_factor; } set { s_factor = value; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static SymbolCollection Symbol { get { return s_symbol; } }

		public static EUR One { get { return s_one; } }
		public static EUR Zero { get { return s_zero; } }
		#endregion
	}
}
