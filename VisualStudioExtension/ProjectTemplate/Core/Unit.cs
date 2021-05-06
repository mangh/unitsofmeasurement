/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Collections.Generic;

namespace $safeprojectname$
{
    /// <summary>
    /// Unit base proxy type giving access to properties common to all unit types.
    /// </summary>
    public abstract class Unit : Measure
    {
        #region Constants
        public static readonly RuntimeTypeHandle GenericTypeHandle = typeof(Unit<>).TypeHandle;
        public static readonly string GenericTypeFullName = typeof(Unit<>).FullName;
        public static readonly string GenericInterfaceFullName = typeof(IQuantity<>).FullName;
        #endregion

        #region Properties
        public abstract Dimension Sense { get; }
        public abstract SymbolCollection Symbol { get; }
        public abstract string Format { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create unit proxy from a unit type.
        /// </summary>
        /// <param name="unit">Unit of any value type.</param>
        protected Unit(Type unit) :
            base(unit)
        {
        }
        #endregion

        #region Formatting
        public override string ToString()
        {
            return string.Format("[{0}] {1} {2}", Sense, Type.Name, Symbol);
        }
        #endregion
    }

    /// <summary>
    /// Unit proxy type giving access to properties and methods specific to the type parameter T.
    /// </summary>
    /// <typeparam name="T">Value type underlying the unit type: double, decimal, float.</typeparam>
    public abstract class Unit<T> : Unit
        where T : struct
    {
        #region Properties
        public string Alias { get; private set; }
        // Basically, factors for all units - except monetary - are constant. 
        // Therefore monetary units have to override both getter and setter accessors.
        // All other, "normal" units have to override the getter only and leave the setter as-is
        // i.e. raise exception on attempt to change the factor.
        public virtual T Factor
        {
            get { throw new NotImplementedException(string.Format("{0}.Factor Proxy getter not implemented.", Alias)); }
            set { throw new InvalidOperationException(string.Format("{0}.Factor is constant and cannot be re-set via its Proxy.", Alias)); }
        }
        #endregion

        #region Constructor(s)

        /// <summary>Creates unit proxy from a unit type.</summary>
        /// <param name="unit">Unit value type implementing IQuantity&lt;T&gt; interface.</param>
        /// <exception cref="System.ArgumentException">Thrown when unit argument is not a value type implementing IQuantity&lt;T&gt; interface.</exception>
        protected Unit(Type unit) :
            base(unit)
        {
            Alias = unit.Name;
            if (!IsAssignableFrom(unit))
                throw new ArgumentException(string.Format("\"{0}\" is not a unit type implementing {1} interface.", Alias, typeof(IQuantity<T>).Name));
        }
        /// <summary>Verifies whether the type is a unit value type implementing IQuantity&lt;T&gt; interface.</summary>
        /// <param name="t">Type to be verified.</param>
        /// <returns>"true" for a valid unit type, otherwise "false".</returns>
        public static bool IsAssignableFrom(Type t)
        {
            return t.IsValueType && typeof(IQuantity<T>).IsAssignableFrom(t);
        }
        #endregion

        #region Methods
        /// <summary>Creates quantity (unit instance object).</summary>
        /// <param name="value">Value to be assigned to the quantity.</param>
        /// <returns>Quantity of the given value.</returns>
        public abstract IQuantity<T> Create(T value);

        /// <summary>Converts quantity to the unit of measurement represented by this proxy.</summary>
        /// <param name="quantity">Quantity to be converted from.</param>
        /// <returns>Quantity converted to the unit of measurement represented by this proxy.</returns>
        public abstract IQuantity<T> From(IQuantity<T> quantity);
        #endregion
    }
}
