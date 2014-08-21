/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
	public partial struct Kelvin : ILevel<double>, IEquatable<Kelvin>, IComparable<Kelvin>
	{
		#region Fields
		private readonly DegKelvin m_level;
		#endregion

		#region Properties

		// instance properties
		public DegKelvin Level { get { return m_level; } }
		public DegKelvin Extent { get { return (m_level - Kelvin.Offset); } }

		// scale properties
		public DegKelvin ScaleOffset { get { return Kelvin.Offset; } }
		public string ScaleFormat { get { return Kelvin.Format; } }

		// ILevel<double> properties
		IQuantity<double> ILevel<double>.Level { get { return Level; } }
		IQuantity<double> ILevel<double>.Extent { get { return Extent; } }
		IQuantity<double> ILevel<double>.ScaleOffset { get { return ScaleOffset; } }

		#endregion

		#region Constructor(s)
		public Kelvin(DegKelvin level)
		{
			m_level = level;
		}
		public Kelvin(double level) :
			this((DegKelvin)level)
		{
		}
		#endregion

		#region Conversions
		public static explicit operator Kelvin(double q) { return new Kelvin(q); }
		public static explicit operator Kelvin(DegKelvin q) { return new Kelvin(q); }
		public static explicit operator Kelvin(Fahrenheit q) { return new Kelvin((DegKelvin)(q.Extent) + Kelvin.Offset); }
		public static explicit operator Kelvin(Rankine q) { return new Kelvin((DegKelvin)(q.Extent) + Kelvin.Offset); }
		public static explicit operator Kelvin(Celsius q) { return new Kelvin((DegKelvin)(q.Extent) + Kelvin.Offset); }
		public static Kelvin From(ILevel<double> q)
		{
			return new Kelvin(DegKelvin.From(q.Extent) + Kelvin.Offset);
		}
		#endregion

		#region IObject / IEquatable / IComparable
		public override int GetHashCode() { return m_level.GetHashCode(); }
		public override bool /* IObject */ Equals(object obj) { return (obj != null) && (obj is Kelvin) && Equals((Kelvin)obj); }
		public bool /* IEquatable<Kelvin> */ Equals(Kelvin other) { return this.Level == other.Level; }
		public int /* IComparable<Kelvin> */ CompareTo(Kelvin other) { return this.Level.CompareTo(other.Level); }
		#endregion

		#region Comparison
		public static bool operator ==(Kelvin lhs, Kelvin rhs) { return lhs.Level == rhs.Level; }
		public static bool operator !=(Kelvin lhs, Kelvin rhs) { return lhs.Level != rhs.Level; }
		public static bool operator <(Kelvin lhs, Kelvin rhs) { return lhs.Level < rhs.Level; }
		public static bool operator >(Kelvin lhs, Kelvin rhs) { return lhs.Level > rhs.Level; }
		public static bool operator <=(Kelvin lhs, Kelvin rhs) { return lhs.Level <= rhs.Level; }
		public static bool operator >=(Kelvin lhs, Kelvin rhs) { return lhs.Level >= rhs.Level; }
		#endregion

		#region Arithmetic
		public static Kelvin operator +(Kelvin lhs, DegKelvin rhs) { return new Kelvin(lhs.Level + rhs); }
		public static Kelvin operator +(DegKelvin lhs, Kelvin rhs) { return new Kelvin(lhs + rhs.Level); }
		public static Kelvin operator -(Kelvin lhs, DegKelvin rhs) { return new Kelvin(lhs.Level - rhs); }
		public static DegKelvin operator -(Kelvin lhs, Kelvin rhs) { return (lhs.Level - rhs.Level); }
		public static Kelvin operator -(Kelvin q) { return new Kelvin(-q.Level); }
		public static Kelvin operator ++(Kelvin q) { return q + DegKelvin.One; }
		public static Kelvin operator --(Kelvin q) { return q - DegKelvin.One; }
		#endregion

		#region Formatting
		public override string ToString() { return ToString(null, Kelvin.Format); }
		public string ToString(string format) { return ToString(null, format); }
		public string ToString(IFormatProvider fp) { return ToString(fp, Kelvin.Format); }
        public string ToString(IFormatProvider fp, string format) { return m_level.ToString(fp, format); }
		#endregion

		#region Statics
        private static DegKelvin s_offset = new DegKelvin(0d);
		private static string s_format = "{0} {1}";
		private static Kelvin s_zero = new Kelvin(0d);
		
		public static DegKelvin Offset { get { return s_offset; } }
		public static string Format { get { return s_format; } set { s_format = value; } }
		public static Kelvin Zero { get { return s_zero; } }
		#endregion
	}
}
