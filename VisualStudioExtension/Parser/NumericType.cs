/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System.Globalization;

namespace Man.UnitsOfMeasurement
{
    /// <summary>
	/// TODO: Update summary.
	/// </summary>
	public abstract class NumericType : AbstractType
	{
		#region Properties
		public string NetName { get; private set; }
        public abstract Number One { get; }
        public abstract Number Zero { get; }
        #endregion

		#region Constructor(s)
		public NumericType(string nameSpace, string netname, string name) :
			base(nameSpace, name, true)
		{
			NetName = netname;
		}
		#endregion

		#region Methods
		public abstract Number TryParse(string input);
		#endregion

		#region Statics
		public static NumericType Double = new DoubleType();
		public static NumericType Decimal = new DecimalType();
		public static NumericType Float = new FloatType();

		public static NumericType Factory(string type)
		{
			if (type == "double") return NumericType.Double;
			if (type == "decimal") return NumericType.Decimal;
			if (type == "float") return NumericType.Float;
			return null;
		}
		#endregion
	}

	public class DoubleType : NumericType
	{
        #region Statics
        private static DoubleNumber m_one = new DoubleNumber(1.0);
        private static DoubleNumber m_zero = new DoubleNumber(0.0);
        #endregion

        #region Properties
        public override Number One { get { return m_one; } }
        public override Number Zero { get { return m_zero; } }
        #endregion

		#region Constructor(s)
		public DoubleType() :
			base("System", "Double", "double")
		{
		}
		#endregion

		#region Methods
		public override Number TryParse(string input)
		{
			double number;
			return double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out number) ? new DoubleNumber(number) : null;
		}
		#endregion
	}

	public class DecimalType : NumericType
	{
        #region Statics
        private static DecimalNumber m_one = new DecimalNumber(decimal.One);
        private static DecimalNumber m_zero = new DecimalNumber(decimal.Zero);
        #endregion

        #region Properties
        public override Number One { get { return m_one; } }
        public override Number Zero { get { return m_zero; } }
        #endregion

		#region Constructor(s)
		public DecimalType() :
			base("System", "Decimal", "decimal")
		{
		}
		#endregion

		#region Methods
		public override Number TryParse(string input)
		{
			decimal number;
			return decimal.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out number) ? new DecimalNumber(number) : null;
		}
		#endregion
	}

	public class FloatType : NumericType
	{
        #region Statics
        private static FloatNumber m_one = new FloatNumber(1.0f);
        private static FloatNumber m_zero = new FloatNumber(0.0f);
        #endregion

        #region Properties
        public override Number One { get { return m_one; } }
        public override Number Zero { get { return m_zero; } }
        #endregion

		#region Constructor(s)
		public FloatType() :
			base("System", "Float", "float")
		{
		}
		#endregion

		#region Methods
		public override Number TryParse(string input)
		{
			float number;
			return float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out number) ? new FloatNumber(number) : null;
		}
		#endregion
	}
}
