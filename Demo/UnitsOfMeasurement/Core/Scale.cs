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
    /// Scale constants
    /// </summary>
    public static class ScaleConstants
    {
        // static properties
        public const string OffsetPropertyName = "Offset";
        public const string FamilyPropertyName = "Family";
        public const string FormatPropertyName = "Format";

        // static methods
        public const string CreateMethodName = "Create";
        public const string ConvertMethodName = "Convert";

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
        private readonly int m_family;
        private readonly IQuantity<T> _offset;

        private readonly Func<string> m_formatGet;
        private readonly Action<string> m_formatSet;

        private readonly Func<T, ILevel<T>> m_createLevel;
        private readonly Func<ILevel<T>, ILevel<T>> m_convertLevel;
        #endregion

        #region Properties

        public Unit<T> Unit
        {
            get { return m_unit; }
        }
        public override Dimension Sense
        {
            get { return m_unit.Sense; }
        }
        public override int Family
        {
            get { return m_family; }
        }
        public override SymbolCollection Symbol
        {
            get { return m_unit.Symbol; }
        }
        public override string Format
        {
            get { return m_formatGet(); }
            set { m_formatSet(value); }
        }
        public IQuantity<T> Offset
        {
            get { return _offset; }
        }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Construct scale type proxy from a value type implementing ILevel&lt;T&gt;
        /// </summary>
        /// <param name="t">scale value type implementing ILevel&lt;T&gt;</param>
        /// <exception cref="System.ArgumentException">Thrown when Type t is not a value type implementing ILevel&lt;T&gt;</exception>
        public Scale(Type scale) :
            base(scale)
        {
            if(!IsAssignableFrom(scale))
                throw new ArgumentException(string.Format("\"{0}\" is not a scale type implementing ILevel<> interface.", scale.Name));

            m_family = (int)GetProperty(ScaleConstants.FamilyPropertyName);
            _offset = (IQuantity<T>)GetProperty(ScaleConstants.OffsetPropertyName);
            m_unit = new Unit<T>(_offset);

            PropertyInfo pi = scale.GetProperty(ScaleConstants.FormatPropertyName);
            m_formatGet = Delegate.CreateDelegate(typeof(Func<string>), pi.GetGetMethod()) as Func<string>;
            m_formatSet = Delegate.CreateDelegate(typeof(Action<string>), pi.GetSetMethod()) as Action<string>;
            m_createLevel = Delegate.CreateDelegate(typeof(Func<T, ILevel<T>>), scale.GetMethod(ScaleConstants.CreateMethodName)) as Func<T, ILevel<T>>;
            m_convertLevel = Delegate.CreateDelegate(typeof(Func<ILevel<T>, ILevel<T>>), scale.GetMethod(ScaleConstants.ConvertMethodName)) as Func<ILevel<T>, ILevel<T>>;
        }
        /// <summary>
        /// Construct scale type proxy from ILevel&lt;T&gt; scale instance object
        /// </summary>
        /// <param name="q">ILevel&lt;T&gt; instance object</param>
        public Scale(ILevel<T> q) :
            this(q.GetType())
        {
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
            return m_createLevel(value);
        }
        public override object CreateInstance(object value)
        {
            if(value is T) return m_createLevel((T)value);
            throw new ArgumentException(string.Format("{0}.CreateInstance: value is not of type \"{1}\".", typeof(Scale<T>).Name, typeof(T).Name));
        }

        /// <summary>
        /// Convert ILevel&lt;T&gt; level to the unit of measurement and offset of this scale type
        /// </summary>
        /// <param name="q">input ILevel&lt;T&gt; instance object (to be converted from)</param>
        /// <returns>ILevel&lt;T&gt; instance object of this scale type (conversion result)</returns>
        public ILevel<T> ConvertLevel(ILevel<T> q)
        {
            return m_convertLevel(q);
        }
        public override object ConvertInstance(object level)
        {
            ILevel<T> q = level as ILevel<T>;
            if(q != null) return m_convertLevel(q);
            throw new ArgumentException(string.Format("{0}.ConvertInstance: level is not of type \"{1}\".", typeof(Scale<T>).Name, typeof(ILevel<T>).Name));
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
