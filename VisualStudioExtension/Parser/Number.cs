/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System;
using System.Globalization;

namespace Man.UnitsOfMeasurement
{
    /// <summary>
	/// TODO: Update summary.
	/// </summary>
	public abstract class Number : IEquatable<Number>
	{
        #region Properties
        public abstract bool IsOne { get; }
        public abstract bool IsZero { get; }
        public abstract NumericType Type { get; }
        #endregion

        #region Constructor(s)
        //protected Number()
		//{
		//}
		#endregion

		#region Methods
		public abstract Number Add(Number other);
		public abstract Number Subtract(Number other);
		public abstract Number Multiply(Number other);
		public abstract Number Divide(Number other);
		public abstract Number Negate();
		public abstract bool Equals(Number other);
		public override bool Equals(object obj) { return (obj != null) && (obj is Number) && Equals((Number)obj); }
        public override int GetHashCode() { return 0; }
        public abstract string CSString();
		#endregion

		#region Operators
		public static Number operator +(Number lhs, Number rhs) { return lhs.Add(rhs); }
		public static Number operator -(Number lhs, Number rhs) { return lhs.Subtract(rhs); }
		public static Number operator *(Number lhs, Number rhs) { return lhs.Multiply(rhs); }
		public static Number operator /(Number lhs, Number rhs) { return lhs.Divide(rhs); }
		public static bool operator ==(Number lhs, Number rhs) { return object.ReferenceEquals(lhs, rhs) || (!object.Equals(lhs, null) && lhs.Equals(rhs)); }
		public static bool operator !=(Number lhs, Number rhs) { return !(lhs == rhs); }
		#endregion

        #region Static methods
        public static void CompatibilityException(Number lhs, Number rhs) { throw new ArgumentException(String.Format("Incompatible numbers: \"{0}\" and \"{1}\"", lhs, rhs)); }
        #endregion
    }
	public class DoubleNumber : Number
	{
        #region Properties
        public double Value { get; private set; }

        public override bool IsOne { get { return Value == 1.0; } }
        public override bool IsZero { get { return Value == 0.0; } }
        public override NumericType Type { get { return NumericType.Double; } }
        #endregion

        #region Constructor(s)
        public DoubleNumber(double value)
		{
			Value = value;
		}
        #endregion

        #region Methods
        public override Number Add(Number other) { DoubleNumber rhs = Cast(other); return new DoubleNumber(this.Value + rhs.Value); }
		public override Number Subtract(Number other) { DoubleNumber rhs = Cast(other); return new DoubleNumber(this.Value - rhs.Value); }
		public override Number Multiply(Number other) { DoubleNumber rhs = Cast(other); return new DoubleNumber(this.Value * rhs.Value); }
		public override Number Divide(Number other) { DoubleNumber rhs = Cast(other); return new DoubleNumber(this.Value / rhs.Value); }
		public override Number Negate() { return new DoubleNumber(-this.Value); }
        public override bool Equals(Number other) { if (other == null) return false; DoubleNumber rhs = Cast(other); return (this.Value == rhs.Value); }
        public override int GetHashCode() { return Value.GetHashCode(); }

		private DoubleNumber Cast(Number other)
		{
			var rhs = (DoubleNumber)other;
			if (rhs == null) Number.CompatibilityException(this, other);
			return rhs;
		}

        public override string CSString() { return String.Format(CultureInfo.InvariantCulture, "{0}d", Value); }
        public override string ToString() { return Value.ToString(CultureInfo.InvariantCulture); }
        #endregion
	}

	public class DecimalNumber : Number
	{
        #region Properties
        public decimal Value { get; private set; }

        public override bool IsOne { get { return Value == decimal.One; } }
        public override bool IsZero { get { return Value == decimal.Zero; } }
        public override NumericType Type { get { return NumericType.Decimal; } }
        #endregion

        #region Constructor(s)
        public DecimalNumber(decimal value)
		{
			Value = value;
		}
        #endregion

        #region Methods
        public override Number Add(Number other) { DecimalNumber rhs = Cast(other); return new DecimalNumber(this.Value + rhs.Value); }
		public override Number Subtract(Number other) { DecimalNumber rhs = Cast(other); return new DecimalNumber(this.Value - rhs.Value); }
		public override Number Multiply(Number other) { DecimalNumber rhs = Cast(other); return new DecimalNumber(this.Value * rhs.Value); }
		public override Number Divide(Number other) { DecimalNumber rhs = Cast(other); return new DecimalNumber(this.Value / rhs.Value); }
		public override Number Negate() { return new DecimalNumber(-this.Value); }
        public override bool Equals(Number other) { if (other == null) return false; DecimalNumber rhs = Cast(other); return (this.Value == rhs.Value); }
        public override int GetHashCode() { return Value.GetHashCode(); }

		private DecimalNumber Cast(Number other)
		{
			DecimalNumber rhs = other as DecimalNumber;
			if (rhs == null) Number.CompatibilityException(this, other);
			return rhs;
		}

        //public override string CSString() { return String.Format(CultureInfo.InvariantCulture, "{0}m", Value); }
        public override string CSString() { return IsZero ? "decimal.Zero" : (IsOne ? "decimal.One" : String.Format(CultureInfo.InvariantCulture, "{0}m", Value)); }
        public override string ToString() { return Value.ToString(CultureInfo.InvariantCulture); }
        #endregion
	}

	public class FloatNumber : Number
	{
        #region Properties
        public float Value { get; private set; }

		public override bool IsOne { get { return Value == 1.0f; } }
        public override bool IsZero { get { return Value == 0.0f; } }
        public override NumericType Type { get { return NumericType.Float; } }
        #endregion

        #region Constructor(s)
        public FloatNumber(float value)
		{
			Value = value;
		}
        #endregion

        #region Methods
        public override Number Add(Number other) { FloatNumber rhs = Cast(other); return new FloatNumber(this.Value + rhs.Value); }
		public override Number Subtract(Number other) { FloatNumber rhs = Cast(other); return new FloatNumber(this.Value - rhs.Value); }
		public override Number Multiply(Number other) { FloatNumber rhs = Cast(other); return new FloatNumber(this.Value * rhs.Value); }
		public override Number Divide(Number other) { FloatNumber rhs = Cast(other); return new FloatNumber(this.Value / rhs.Value); }
		public override Number Negate() { return new FloatNumber(-this.Value); }
        public override bool Equals(Number other) { if (other == null) return false; FloatNumber rhs = Cast(other); return (this.Value == rhs.Value); }
        public override int GetHashCode() { return Value.GetHashCode(); }

		private FloatNumber Cast(Number other)
		{
			FloatNumber another = other as FloatNumber;
			if (another == null) Number.CompatibilityException(this, other);
			return another;
		}

        public override string CSString() { return String.Format(CultureInfo.InvariantCulture, "{0}f", Value); }
        public override string ToString() { return Value.ToString(CultureInfo.InvariantCulture); }
        #endregion
	}
}
