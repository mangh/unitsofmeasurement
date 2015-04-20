/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Reflection;

namespace $safeprojectname$
{
    /// <summary>
    /// Scale constants
    /// </summary>
    public static class ScaleConstants
    {
        // static properties
        public const string OffsetPropertyName = "Offset";
        public const string FamilyPropertyName = "Family";
        public const string FormatPropertyName = "Format";

        // static methods
        public const string ConversionMethodName = "From";

        // instance properties
        public const string LevelPropertyName = "Level";
        public const string NormalizedLevelPropertyName = "NormalizedLevel";

        // generic types
        public static readonly RuntimeTypeHandle GenericTypeHandle = typeof(Scale<>).TypeHandle;
        public static readonly RuntimeTypeHandle GenericInterfaceHandle = typeof(ILevel<>).TypeHandle;
    }

    /// <summary>
    /// Scale type proxy giving access to static members (e.g.: Sense, Family, Symbol, Format) of the scale type
    /// </summary>
    /// <typeparam name="T">double, decimal, float: value type underlying the scale type</typeparam>
    public partial class Scale<T> : Measure where T : struct
    {
        #region Fields
        private readonly Unit<T> m_unit;
        #endregion

        #region Properties

        public Unit<T> Unit { get { return m_unit; } }

        public override Dimension Sense
        {
            get { return m_unit.Sense; }
        }
        public override int Family
        {
            get { return (int)GetProperty(ScaleConstants.FamilyPropertyName); }
        }
        public override SymbolCollection Symbol
        {
            get { return m_unit.Symbol; }
        }
        public override string Format
        {
            get { return (string)GetProperty(ScaleConstants.FormatPropertyName); }
            set { SetProperty(ScaleConstants.FormatPropertyName, value); }
        }
        public IQuantity<T> Offset
        {
            get { return (IQuantity<T>)GetProperty(ScaleConstants.OffsetPropertyName); }
        }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Construct scale type proxy from a value type implementing ILevel&lt;T&gt;
        /// </summary>
        /// <param name="t">scale value type implementing ILevel&lt;T&gt;</param>
        /// <exception cref="System.ArgumentException">Thrown when Type t is not a value type implementing ILevel&lt;T&gt;</exception>
        public Scale(Type t) :
            base(t)
        {
            m_unit = new Unit<T>(this.Offset);
        }
        /// <summary>
        /// Construct scale type proxy from ILevel&lt;T&gt; scale instance object
        /// </summary>
        /// <param name="q">ILevel&lt;T&gt; instance object</param>
        public Scale(ILevel<T> q) :
            this(q.GetType())
        {
        }
        public override void CheckType(Type t)
        {
            if (!IsAssignableFrom(t)) throw new ArgumentException(String.Format("\"{0}\" is not a scale value type implementing ILevel<{1}>", t.Name, default(T).GetType().Name));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create scale instance object (level)
        /// </summary>
        /// <param name="value">level value</param>
        /// <returns>ILevel&lt;T&gt; instance object (level)</returns>
        public ILevel<T> CreateLevel(T value)
        {
            return (ILevel<T>)CreateInstance(value);
        }

        /// <summary>
        /// Convert ILevel&lt;T&gt; level to the unit of measurement and offset of this scale type
        /// </summary>
        /// <param name="q">input ILevel&lt;T&gt; instance object (to be converted from)</param>
        /// <returns>ILevel&lt;T&gt; instance object of this scale type (conversion result)</returns>
        public ILevel<T> From(ILevel<T> q)
        {
            return (ILevel<T>)InvokeMethod(ScaleConstants.ConversionMethodName, new object[] { q });
        }

        #endregion

        #region Statics
        /// <summary>
        /// Verify whether the type is a scale type
        /// </summary>
        /// <param name="t">type to be verified</param>
        /// <returns>"true" for scale type, otherwise "false"</returns>
        public static bool IsAssignableFrom(Type t)
        {
            return t.IsValueType && typeof(ILevel<T>).IsAssignableFrom(t);
        }
        #endregion
    }
}
