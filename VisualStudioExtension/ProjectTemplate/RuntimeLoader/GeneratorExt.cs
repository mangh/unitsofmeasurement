/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Collections.Generic;
using Man.UnitsOfMeasurement;

namespace $safeprojectname$
{
    public partial class Generator
    {
        #region Fields
        private int __family;
        private List<UnitType> __units;
        private int __unitstartindex;
        private List<ScaleType> __scales;
        private int __scalestartindex;
        private string __projectNamespace;
        #endregion

        #region Constructor(s)
        public Generator(int familystart, List<UnitType> units, int unitstartindex, List<ScaleType> scales, int scalestartindex)
        {
            __family = familystart;
            __units = units;
            __unitstartindex = unitstartindex;
            __scales = scales;
            __scalestartindex = scalestartindex;
            __projectNamespace = this.GetType().Namespace;
        }
        public Generator()
        {
            throw new NotImplementedException(String.Format("{0}: parameterless constructor is inappropriate for generating run-time units", "UnitsOfMeasurement1.Generator"));
        }
        #endregion
    }
}
