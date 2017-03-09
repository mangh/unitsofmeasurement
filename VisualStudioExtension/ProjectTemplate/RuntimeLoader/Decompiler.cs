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

namespace $safeprojectname$
{
    public partial class RuntimeLoader
    {
        private class Decompiler
        {
            #region Fields
            private List<Man.UnitsOfMeasurement.UnitType> m_units;
            private List<Man.UnitsOfMeasurement.ScaleType> m_scales;
            private Dictionary<int, Man.UnitsOfMeasurement.MeasureType> m_families;
            #endregion

            #region Properties
            public int MaxFamilyFound { get { return m_families.Count <= 0 ? -1 : m_families.Max(kv => kv.Key); } }
            #endregion

            #region Constructor(s)
            public Decompiler(List<Man.UnitsOfMeasurement.UnitType> units, List<Man.UnitsOfMeasurement.ScaleType> scales)
            {
                m_units = units;
                m_scales = scales;
                m_families = new Dictionary<int, Man.UnitsOfMeasurement.MeasureType>(16);
            }
            #endregion

            #region Methods
            public void Decompile()
            {
                foreach(var u in Catalog.Units<double>()) Decompile(u);
                foreach(var u in Catalog.Units<decimal>()) Decompile(u);
                foreach(var u in Catalog.Units<float>()) Decompile(u);

                foreach(var s in Catalog.Scales<double>()) Decompile(s);
                foreach(var s in Catalog.Scales<decimal>()) Decompile(s);
                foreach(var s in Catalog.Scales<float>()) Decompile(s);
            }

            private void Decompile<T>(Unit<T> unit)
                where T : struct
            {
                Man.UnitsOfMeasurement.Number factor = Man.UnitsOfMeasurement.Number.CreateFromObject(unit.Factor);

                Man.UnitsOfMeasurement.UnitType decompiledUnit =
                    new Man.UnitsOfMeasurement.UnitType(
                        unit.Type.Name,
                        new Man.UnitsOfMeasurement.SenseExpr(TranslateDimension(unit.Sense), null /* no sense code */),
                        new Man.UnitsOfMeasurement.NumExpr(factor != null, factor, null /* no factor code */)
                    );

                decompiledUnit.Tags.AddRange(unit.Symbol);

                AddFamily(unit.Family, decompiledUnit);

                m_units.Add(decompiledUnit);
            }

            private void Decompile<T>(Scale<T> scale)
                where T : struct
            {
                string scaleRefPoint = Attribute.IsDefined(scale.Type, typeof(ScaleReferencePointAttribute)) ?
                    (Attribute.GetCustomAttribute(scale.Type, typeof(ScaleReferencePointAttribute)) as ScaleReferencePointAttribute).Name :
                    string.Empty;

                Man.UnitsOfMeasurement.Number offset = Man.UnitsOfMeasurement.Number.CreateFromObject(scale.Offset.Value);
                Man.UnitsOfMeasurement.UnitType scaleUnitType = m_units.Find(u => u.Name == scale.Unit.Type.Name);

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
