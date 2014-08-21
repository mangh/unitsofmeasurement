/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
	public partial struct Celsius : ILevel<double>, IEquatable<Celsius>, IComparable<Celsius>
	{
		#region Fields
		private readonly DegCelsius m_level;
		#endregion

		#region Properties

		// instance properties
		public DegCelsius Level { get { return m_level; } }
		public DegCelsius Extent { get { return (m_level - Celsius.Offset); } }

		// scale properties
		public DegCelsius ScaleOffset { get { return Celsius.Offset; } }
		public string ScaleFormat { get { return Celsius.Format; } }

		// ILevel<double> properties
		IQuantity<double> ILevel<double>.Level { get { return Level; } }
		IQuantity<double> ILevel<double>.Extent { get { return Extent; } }
		IQuantity<double> ILevel<double>.ScaleOffset { get { return ScaleOffset; } }

		#endregion

		#region Constructor(s)
		public Celsius(DegCelsius level)
		{
			m_level = level;
		}
		public Celsius(double level) :
			this((DegCelsius)level)
		{
		}
		#endregion

		#region Conversions
		public static explicit operator Celsius(double q) { return new Celsius(q); }
		public static explicit operator Celsius(DegCelsius q) { return new Celsius(q); }
		public static explicit operator Celsius(Kelvin q) { return new Celsius((DegCelsius)(q.Extent) + Celsius.Offset); }
		public static explicit operator Celsius(Fahrenheit q) { return new Celsius((DegCelsius)(q.Extent) + Celsius.Offset); }
		public static explicit operator Celsius(Rankine q) { return new Celsius((DegCelsius)(q.Extent) + Celsius.Offset); }
		public static Celsius From(ILevel<double> q)
		{
			return new Celsius(DegCelsius.From(q.Extent) + Celsius.Offset);
		}
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_level.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Celsius) && Equals((Celsius)obj); }
		public bool /* IEquatable<Celsius> */ Equals(Celsius other) { return this.Level == other.Level; }
		public int /* IComparable<Celsius> */ CompareTo(Celsius other) { return this.Level.CompareTo(other.Level); }
		#endregion

		#region Comparison
		public static bool operator ==(Celsius lhs, Celsius rhs) { return lhs.Level == rhs.Level; }
		public static bool operator !=(Celsius lhs, Celsius rhs) { return lhs.Level != rhs.Level; }
		public static bool operator <(Celsius lhs, Celsius rhs) { return lhs.Level < rhs.Level; }
		public static bool operator >(Celsius lhs, Celsius rhs) { return lhs.Level > rhs.Level; }
		public static bool operator <=(Celsius lhs, Celsius rhs) { return lhs.Level <= rhs.Level; }
		public static bool operator >=(Celsius lhs, Celsius rhs) { return lhs.Level >= rhs.Level; }
		#endregion

		#region Arithmetic
		public static Celsius operator +(Celsius lhs, DegCelsius rhs) { return new Celsius(lhs.Level + rhs); }
		public static Celsius operator +(DegCelsius lhs, Celsius rhs) { return new Celsius(lhs + rhs.Level); }
		public static Celsius operator -(Celsius lhs, DegCelsius rhs) { return new Celsius(lhs.Level - rhs); }
		public static DegCelsius operator -(Celsius lhs, Celsius rhs) { return (lhs.Level - rhs.Level); }
		public static Celsius operator -(Celsius q) { return new Celsius(-q.Level); }
		public static Celsius operator ++(Celsius q) { return q + DegCelsius.One; }
		public static Celsius operator --(Celsius q) { return q - DegCelsius.One; }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, Celsius.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, Celsius.Format); }
        public string ToString(IFormatProvider fp, string format) { return m_level.ToString(fp, format); }
		#endregion

		#region Statics
        private static DegCelsius s_offset = new DegCelsius(-273.15d);
		private static string s_format = "{0} {1}";
		private static Celsius s_zero = new Celsius(0d);
		
		public static DegCelsius Offset { get { return s_offset; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static Celsius Zero { get { return s_zero; } }
		#endregion
	}
}
