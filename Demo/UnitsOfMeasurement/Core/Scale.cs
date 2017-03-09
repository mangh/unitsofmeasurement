/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Collections.Generic;

namespace Demo.UnitsOfMeasurement
{
    /// <summary>
    /// Scale base proxy type giving access to properties common to all scale types (regardless of their value type).
    /// </summary>
    public abstract class Scale : Measure
    {
        #region Constants
        public static readonly RuntimeTypeHandle GenericTypeHandle = typeof(Scale<>).TypeHandle;
        public static readonly string GenericTypeFullName = typeof(Scale<>).FullName;
        public static readonly string GenericInterfaceFullName = typeof(ILevel<>).FullName;
        #endregion

        #region Properties
        public abstract Unit Unit { get; }
        public abstract string Format { get; set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Create scale proxy from a scale type.
        /// </summary>
        /// <param name="scale">Scale of any value type.</param>
        protected Scale(Type scale) :
            base(scale)
        {
        }
        #endregion

        #region Formatting
        public override string ToString()
        {
            return string.Format("[{0}] {1} {2}", Unit.Sense, Type.Name, Unit.Symbol);
        }
        #endregion
    }

    /// <summary>
    /// Scale proxy type giving access to properties and methods specific to the type parameter T.
    /// </summary>
    /// <typeparam name="T">Value type underlying the scale type: double, decimal, float.</typeparam>
    public abstract class Scale<T> : Scale
        where T : struct
    {
        #region Properties
        public abstract IQuantity<T> Offset { get; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Creates scale proxy from a scale type.
        /// </summary>
        /// <param name="scale">Scale value type implementing ILevel&lt;T&gt;.</param>
        /// <exception cref="System.ArgumentException">Thrown when scale argument is not a value type implementing ILevel&lt;T&gt;.</exception>
        protected Scale(Type scale) :
            base(scale)
        {
            if(!IsAssignableFrom(scale))
                throw new ArgumentException(string.Format("\"{0}\" is not a scale type implementing {1} interface.", scale.Name, typeof(ILevel<T>).Name));
        }
        /// <summary>
        /// Verifies whether the type is a scale value type implementing ILevel&lt;T&gt;.
        /// </summary>
        /// <param name="t">Type to be verified.</param>
        /// <returns>"true" for valid scale type, otherwise "false".</returns>
        public static bool IsAssignableFrom(Type t)
        {
            return t.IsValueType && typeof(ILevel<T>).IsAssignableFrom(t);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates level (scale instance object).
        /// </summary>
        /// <param name="value">Value to be assigned to the level.</param>
        /// <returns>Level of the given value.</returns>
        public abstract ILevel<T> Create(T value);

        /// <summary>
        /// Converts level to the scale represented by this proxy.
        /// </summary>
        /// <param name="level">Level to be converted from.</param>
        /// <returns>Converted level.</returns>
        public abstract ILevel<T> From(ILevel<T> level);

        /// <summary>
        /// Converts (attaches) quantity to the scale represented by this proxy.
        /// </summary>
        /// <param name="quantity">Quantity to be converted (attached).</param>
        /// <returns>Level attached to the scale.</returns>
        public abstract ILevel<T> From(IQuantity<T> quantity);
        #endregion
    }
}
