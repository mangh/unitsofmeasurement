/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Demo.UnitsOfMeasurement
{
    public partial class RuntimeLoader
    {
        private class Decompiler
        {
            #region Fields
            private List<Man.UnitsOfMeasurement.UnitType> m_units;
            private List<Man.UnitsOfMeasurement.ScaleType> m_scales;
            private Dictionary<int, Man.UnitsOfMeasurement.MeasureType> m_families;
            private MeasureFactory m_unitFactory;
            private MeasureFactory m_scaleFactory;
            #endregion

            #region Properties
            public int MaxFamilyFound { get { return m_families.Count <= 0 ? -1 : m_families.Max(kv => kv.Key); } }
            #endregion

            #region Constructor(s)
            public Decompiler(List<Man.UnitsOfMeasurement.UnitType> units, List<Man.UnitsOfMeasurement.ScaleType> scales)
            {
                m_units = units;
                m_unitFactory = new MeasureFactory(UnitConstants.GenericInterfaceHandle);

                m_scales = scales;
                m_scaleFactory = new MeasureFactory(ScaleConstants.GenericInterfaceHandle);

                m_families = new Dictionary<int, Man.UnitsOfMeasurement.MeasureType>(16);
            }
            #endregion

            #region Methods
            public void Decompile(IEnumerable<string> assemblypaths)
            {
                foreach (string assemblypath in assemblypaths) Decompile(Assembly.LoadFrom(assemblypath));
            }
            public void Decompile(IEnumerable<Assembly> assemblies)
            {
                foreach (Assembly assembly in assemblies) Decompile(assembly);
            }
            public void Decompile(Assembly assembly)
            {
                List<Measure> scalesfound = new List<Measure>();
                Measure measure;
                foreach (Type t in assembly.GetExportedTypes())
                {
                    if ((measure = m_scaleFactory.CreateMeasure(t)) != null)
                        scalesfound.Add(measure);

                    else if ((measure = m_unitFactory.CreateMeasure(t)) != null)
                        DecompileUnit(measure);
                }
                // Scales are to be processed after all (underlying) units are known (decompiled)
                foreach (Measure scale in scalesfound)
                {
                    DecompileScale(scale);
                }
            }

            private void DecompileUnit(Measure unit)
            {
                Man.UnitsOfMeasurement.Number factor =
                    Man.UnitsOfMeasurement.Number.CreateFromObject(unit.GetProperty(UnitConstants.FactorPropertyName));

                Man.UnitsOfMeasurement.UnitType decompiledUnit =
                    new Man.UnitsOfMeasurement.UnitType(
                        unit.Type.Name,
                        new Man.UnitsOfMeasurement.SenseExpr(TranslateDimension(unit.Sense), null /* no sense code */),
                        new Man.UnitsOfMeasurement.NumExpr(factor != null, factor, null /* no factor code */)
                    );

                AddFamily(unit.Family, decompiledUnit);

                m_units.Add(decompiledUnit);
            }

            private void DecompileScale(Measure scale)
            {
                string scaleRefPoint = Attribute.IsDefined(scale.Type, typeof(ScaleReferencePointAttribute)) ?
                    (Attribute.GetCustomAttribute(scale.Type, typeof(ScaleReferencePointAttribute)) as ScaleReferencePointAttribute).Name :
                    String.Empty;

                object scaleOffset = scale.GetProperty(ScaleConstants.OffsetPropertyName);
                Type scaleUnit = scaleOffset.GetType();

                Man.UnitsOfMeasurement.Number offset =
                    Man.UnitsOfMeasurement.Number.CreateFromObject(
                        scaleUnit.GetProperty(UnitConstants.ValuePropertyName).GetValue(scaleOffset, null)
                    );

                Man.UnitsOfMeasurement.UnitType scaleUnitType = m_units.Find(u => u.Name == scaleUnit.Name);

                Man.UnitsOfMeasurement.ScaleType decompiledScale =
                    new Man.UnitsOfMeasurement.ScaleType(
                        scale.Type.Name,
                        scaleRefPoint,
                        scaleUnitType,
                        new Man.UnitsOfMeasurement.NumExpr(offset != null, offset, null /* no offset code */)
                    );

                AddFamily(scale.Family, decompiledScale);

                m_scales.Add(decompiledScale);
            }

            private void AddFamily(int family, Man.UnitsOfMeasurement.MeasureType measureType)
            {
                Man.UnitsOfMeasurement.MeasureType primal;
                if (m_families.TryGetValue(family, out primal))
                    primal.AddRelative(measureType);
                else
                    m_families.Add(family, measureType);
            }
            private Man.UnitsOfMeasurement.Dimension TranslateDimension(Dimension sense)
            {
                return new Man.UnitsOfMeasurement.Dimension(
                    sense[Magnitude.Length],
                    sense[Magnitude.Time],
                    sense[Magnitude.Mass],
                    sense[Magnitude.Temperature],
                    sense[Magnitude.ElectricCurrent],
                    sense[Magnitude.AmountOfSubstance],
                    sense[Magnitude.LuminousIntensity],
                    sense[Magnitude.Other]
                );
            }
            #endregion
        }
    }
}
