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
    /// Unit constants
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
        /// Construct unit type proxy from a value type implementing IQuantity&lt;T&gt;
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
        public abstract T Factor { get; set; }
        #endregion

        #region Constructor(s)

        /// <summary>Creates unit proxy from a unit type.</summary>
        /// <param name="unit">Unit value type implementing IQuantity&lt;T&gt; interface.</param>
        /// <exception cref="System.ArgumentException">Thrown when unit argument is not a value type implementing IQuantity&lt;T&gt; interface.</exception>
        protected Unit(Type unit) :
            base(unit)
        {
            if(!IsAssignableFrom(unit))
                throw new ArgumentException(string.Format("\"{0}\" is not a unit type implementing {1} interface.", unit.Name, typeof(IQuantity<T>).Name));
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
