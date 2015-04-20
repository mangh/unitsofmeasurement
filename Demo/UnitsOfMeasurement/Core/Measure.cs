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
    /// Measure (unit|scale) type proxy giving access to static
    /// members (e.g.: Sense, Family, Symbol, Format) of the measure type
    /// </summary>
    /// <remarks>In release 1.0 it was named UnitProxy</remarks>
    public abstract partial class Measure : IEquatable<Measure>
    {
        #region Fields
        private readonly RuntimeTypeHandle m_handle;
        #endregion

        #region Properties

        public RuntimeTypeHandle Handle { get { return m_handle; } }
        public Type Type { get { return Type.GetTypeFromHandle(m_handle); } }

        // Measure static properties (independent of underlying value type)
        public abstract Dimension Sense { get; }
        public abstract int Family { get; }
        public abstract SymbolCollection Symbol { get; }
        public abstract string Format { get; set; }

        #endregion

        #region Constructor(s)
        /// <summary>
        /// Measure (unit|scale) type proxy constructor
        /// </summary>
        /// <param name="t">measure (unit|scale) type</param>
        protected Measure(Type t)
        {
            CheckType(t);
            m_handle = t.TypeHandle;
        }
        public abstract void CheckType(Type t);
        #endregion

        #region IEquatable<MeasureProxy>
        public override int GetHashCode() { return m_handle.GetHashCode(); }
        public override bool Equals(object obj) { return (obj != null) && (obj is Measure) && Equals((Measure)obj); }
        public bool Equals(Measure other) { return this.m_handle.Equals(other.Handle); }
        #endregion

        #region Methods
        /// <summary>
        /// Get static property of the measure (unit|scale)
        /// </summary>
        /// <param name="name">(static) property name</param>
        /// <returns>property value (as object)</returns>
        /// <exception cref="System.NullReferenceException">Thrown when name refers to non-existent property</exception>
        public object GetProperty(string name)
        {
            Type measure = this.Type;
            PropertyInfo property = measure.GetProperty(name);
            return property.GetValue(measure, null);
        }
        /// <summary>
        /// Set static property of the measure (unit|scale)
        /// </summary>
        /// <param name="name">(static) property name</param>
        /// <param name="value">(static) property value</param>
        /// <returns>property value (as object)</returns>
        /// <exception cref="System.NullReferenceException">Thrown when name refers to non-existent property</exception>
        public void SetProperty(string name, object value)
        {
            Type measure = this.Type;
            PropertyInfo property = measure.GetProperty(name);
            property.SetValue(measure, value, null);
        }
        /// <summary>
        /// Create instance (object) of the measure (unit|scale)
        /// </summary>
        /// <param name="value">constructor argument</param>
        /// <returns>Instance of the measure (object)</returns>
        /// <exception cref="System.NullReferenceException">Thrown when no constructor exists for the given value type</exception>
        public object CreateInstance(object value)
        {
            Type[] argTypes = { value.GetType() };  // Constructor argument types
            object[] argValues = { value };         // Constructor argument values
            ConstructorInfo ctor = this.Type.GetConstructor(argTypes);   // Get constructor
            return ctor.Invoke(argValues);          // Return measure instance
        }
        /// <summary>
        /// Invoke static method of the measure (unit|scale)
        /// </summary>
        /// <param name="name">name of the method to be invoked</param>
        /// <param name="arguments">method arguments</param>
        /// <returns>method return value (as object)</returns>
        /// <exception cref="System.NullReferenceException">Thrown when name refers to non-existent method</exception>
        public object InvokeMethod(string name, object[] arguments)
        {
            Type measure = this.Type;
            MethodInfo mi = measure.GetMethod(name);
            return mi.Invoke(measure, arguments);
        }

        public override string ToString()
        {
            return String.Format("({0}) {1} {{\"{2}\"}}", this.Sense, this.Type.Name, String.Join("\", \"", this.Symbol));
        }
        #endregion
    }
}
