/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    /// <summary>
    /// Unit constants
    /// </summary>
    public static class UnitConstants
    {
        // static properties
        public const string SensePropertyName = "Sense";
        public const string FamilyPropertyName = "Family";
        public const string FactorPropertyName = "Factor";
        public const string FormatPropertyName = "Format";
        public const string SymbolPropertyName = "Symbol";

        // static methods
        public const string ConversionMethodName = "From";

        // instance properties
        public const string ValuePropertyName = "Value";

        // generic types
        public static readonly RuntimeTypeHandle GenericTypeHandle = typeof(Unit<>).TypeHandle;
        public static readonly RuntimeTypeHandle GenericInterfaceHandle = typeof(IQuantity<>).TypeHandle;
    }

    /// <summary>
    /// Unit type proxy giving access to static members (e.g.: Sense, Family, Symbol, Format) of the unit type
    /// </summary>
    /// <typeparam name="T">double, decimal, float: value type underlying the unit type</typeparam>
    public partial class Unit<T> : Measure where T : struct
    {
        #region Fields
        // None
        #endregion

        #region Properties
        public override Dimension Sense
        {
            get { return (Dimension)GetProperty(UnitConstants.SensePropertyName); }
        }
        public override int Family
        {
            get { return (int)GetProperty(UnitConstants.FamilyPropertyName); }
        }
        public override SymbolCollection Symbol
        {
            get { return (SymbolCollection)GetProperty(UnitConstants.SymbolPropertyName); }
        }
        public override string Format
        {
            get { return (string)GetProperty(UnitConstants.FormatPropertyName); }
            set { SetProperty(UnitConstants.FormatPropertyName, value); }
        }
        public T Factor
        {
            get { return (T)GetProperty(UnitConstants.FactorPropertyName); }
            set { SetProperty(UnitConstants.FactorPropertyName, value); }
        }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Construct unit type proxy from a value type implementing IQuantity&lt;T&gt;
        /// </summary>
        /// <param name="t">unit value type implementing IQuantity&lt;T&gt;</param>
        /// <exception cref="System.ArgumentException">Thrown when Type t is not a value type implementing IQuantity&lt;T&gt;</exception>
        public Unit(Type t) :
            base(t)
        {
        }
        /// <summary>
        /// Construct unit type proxy from IQuantity&lt;T&gt; unit instance object
        /// </summary>
        /// <param name="q">IQuantity&lt;T&gt; instance object</param>
        public Unit(IQuantity<T> q) :
            this(q.GetType())
        {
        }
        public override void CheckType(Type t)
        {
            if (!IsAssignableFrom(t)) throw new ArgumentException(String.Format("\"{0}\" is not a value type implementing IQuantity<{1}>", t.Name, default(T).GetType().Name));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create unit instance object (quantity)
        /// </summary>
        /// <param name="value">quantity value</param>
        /// <returns>IQuantity&lt;T&gt; instance object (quantity)</returns>
        public IQuantity<T> CreateQuantity(T value)
        {
            return (IQuantity<T>)CreateInstance(value);
        }

        /// <summary>
        /// Convert IQuantity&lt;T&gt; quantity to the unit of measurement of this unit type
        /// </summary>
        /// <param name="q">input IQuantity&lt;T&gt; instance object (to be converted from)</param>
        /// <returns>IQuantity&lt;T&gt; instance object of this unit type (conversion result)</returns>
        public IQuantity<T> From(IQuantity<T> q)
        {
            return (IQuantity<T>)InvokeMethod(UnitConstants.ConversionMethodName, new object[] { q });
        }
        #endregion

        #region Statics
        /// <summary>
        /// Verify whether the type is a unit type
        /// </summary>
        /// <param name="t">type to be verified</param>
        /// <returns>"true" for unit type, otherwise "false"</returns>
        public static bool IsAssignableFrom(Type t)
        {
            return t.IsValueType && typeof(IQuantity<T>).IsAssignableFrom(t);
        }
        #endregion
    }
}
