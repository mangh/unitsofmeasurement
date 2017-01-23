/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Reflection;

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
        public const string CreateMethodName = "Create";
        public const string ConvertMethodName = "Convert";

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
        private readonly Dimension m_sense;
        private readonly int m_family;
        private readonly SymbolCollection m_symbol;

        private readonly Func<T> m_factorGet;
        private readonly Action<T> m_factorSet;

        private readonly Func<string> m_formatGet;
        private readonly Action<string> m_formatSet;

        private readonly Func<T, IQuantity<T>> m_createQuantity;
        private readonly Func<IQuantity<T>, IQuantity<T>> m_convertQuantity;
        #endregion

        #region Properties
        public override Dimension Sense
        {
            get { return m_sense; }
        }
        public override int Family
        {
            get { return m_family; }
        }
        public override SymbolCollection Symbol
        {
            get { return m_symbol; }
        }
        public override string Format
        {
            get { return m_formatGet(); }
            set { m_formatSet(value); }
        }
        public T Factor
        {
            get { return m_factorGet(); }
            set { m_factorSet(value); }
        }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Construct unit type proxy from a value type implementing IQuantity&lt;T&gt;
        /// </summary>
        /// <param name="t">unit value type implementing IQuantity&lt;T&gt;</param>
        /// <exception cref="System.ArgumentException">Thrown when Type t is not a value type implementing IQuantity&lt;T&gt;</exception>
        public Unit(Type unit) :
            base(unit)
        {
            if(!IsAssignableFrom(unit))
                throw new ArgumentException(string.Format("\"{0}\" is not a unit type implementing IQuantity<> interface.", unit.Name));

            m_sense = (Dimension)GetProperty(UnitConstants.SensePropertyName);
            m_family = (int)GetProperty(UnitConstants.FamilyPropertyName);
            m_symbol = (SymbolCollection)GetProperty(UnitConstants.SymbolPropertyName);

            PropertyInfo pi = unit.GetProperty(UnitConstants.FactorPropertyName);
            m_factorGet = Delegate.CreateDelegate(typeof(Func<T>), pi.GetGetMethod()) as Func<T>;
            m_factorSet = Delegate.CreateDelegate(typeof(Action<T>), pi.GetSetMethod()) as Action<T>;

            pi = unit.GetProperty(UnitConstants.FormatPropertyName);
            m_formatGet = Delegate.CreateDelegate(typeof(Func<string>), pi.GetGetMethod()) as Func<string>;
            m_formatSet = Delegate.CreateDelegate(typeof(Action<string>), pi.GetSetMethod()) as Action<string>;
            m_createQuantity = Delegate.CreateDelegate(typeof(Func<T, IQuantity<T>>), unit.GetMethod(UnitConstants.CreateMethodName)) as Func<T, IQuantity<T>>;
            m_convertQuantity = Delegate.CreateDelegate(typeof(Func<IQuantity<T>, IQuantity<T>>), unit.GetMethod(UnitConstants.ConvertMethodName)) as Func<IQuantity<T>, IQuantity<T>>;
        }
        /// <summary>
        /// Construct unit type proxy from IQuantity&lt;T&gt; unit instance object
        /// </summary>
        /// <param name="q">IQuantity&lt;T&gt; instance object</param>
        public Unit(IQuantity<T> q) :
            this(q.GetType())
        {
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
            return m_createQuantity(value);
        }
        public override object CreateInstance(object value)
        {
            if(value is T) return m_createQuantity((T)value);
            throw new ArgumentException(string.Format("{0}.CreateInstance: value is not of type \"{1}\".", typeof(Unit<T>).Name, typeof(T).Name));
        }

        /// <summary>
        /// Convert IQuantity&lt;T&gt; quantity to the unit of measurement of this unit type
        /// </summary>
        /// <param name="q">input IQuantity&lt;T&gt; instance object (to be converted from)</param>
        /// <returns>IQuantity&lt;T&gt; instance object of this unit type (conversion result)</returns>
        public IQuantity<T> ConvertQuantity(IQuantity<T> q)
        {
            return m_convertQuantity(q);
        }
        public override object ConvertInstance(object quantity)
        {
            IQuantity<T> q = quantity as IQuantity<T>;
            if(q != null) return m_convertQuantity(q);
            throw new ArgumentException(string.Format("{0}.ConvertInstance: quantity is not of type \"{1}\".", typeof(Unit<T>).Name, typeof(IQuantity<T>).Name));
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
