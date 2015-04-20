/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    /// <summary>Factory for creating measure proxies (i.e. Unit&lt;T&gt; or Scale&lt;T&gt; types)</summary>
    public class MeasureFactory
    {
        #region Fields
        private readonly Type m_genericMeasure;     // generic measure proxy type: Unit<>, Scale<>
        private readonly Type m_genericInterface;   // generic interface implemented by the measure type: IQuantity<>, ILevel<>
        private readonly bool m_isUnitFactory;
        #endregion

        #region Properties
        public bool IsUnitFactory { get { return m_isUnitFactory; } }
        #endregion

        #region Constructor(s)
        /// <summary>Factory for creating either Unit&lt;T&gt; or Scale&lt;T&gt; proxies</summary>
        /// <param name="genericInterfaceHandle">IQuantity&lt;&gt; or ILevel&lt;&gt; generic type handle, designating output proxy type (Unit&lt;T&gt; or Scale&lt;T&gt; accordingly)</param>
        /// <example>new MeasureFactory(UnitConstants.GenericInterfaceHandle)</example>
        public MeasureFactory(RuntimeTypeHandle genericInterfaceHandle)
        {
            m_genericInterface = Type.GetTypeFromHandle(genericInterfaceHandle);
            m_isUnitFactory = genericInterfaceHandle.Equals(UnitConstants.GenericInterfaceHandle);
            m_genericMeasure = Type.GetTypeFromHandle(m_isUnitFactory ? UnitConstants.GenericTypeHandle : ScaleConstants.GenericTypeHandle);
        }
        #endregion

        #region Methods
        /// <summary>Create measure proxy (Unit&lt;T&gt; or Scale&lt;T&gt;) for the given input type</summary>
        /// <param name="t">input type to create proxy from</param>
        /// <returns>
        /// Unit&lt;T&gt; proxy for unit factory; Scale&lt;T&gt; proxy for scale factory; null for types not supported by the factory
        /// </returns>
        public Measure CreateMeasure(Type t)
        {
            if (t.IsValueType)
            {
                Type intrface = t.GetInterface(m_genericInterface.Name, false);
                if (intrface != null)
                {
                    Type measure = m_genericMeasure.MakeGenericType(intrface.GetGenericArguments());
                    return measure
                        .GetConstructor(new Type[] { typeof(System.Type) })
                        .Invoke(new object[] { t }) as Measure;
                }
            }
            return null;
        }
        #endregion
    }
}
