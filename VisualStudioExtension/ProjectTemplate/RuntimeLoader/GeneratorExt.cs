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
        private bool __late;    // late measures cannot access m_value/m_level fields of compile-time units
        private int __family;
        private int __unitstartindex;
        private int __scalestartindex;
        private List<UnitType> __units;
        private List<ScaleType> __scales;
        private string __projectNamespace;
        #endregion

        #region Constructor(s)
        public Generator(RuntimeLoader.ICatalog catalog, int unitStartIndex, int scaleStartIndex, int familyStartId)
        {
            __late = true;
            __family = familyStartId;
            __units = catalog.Units;
            __unitstartindex = unitStartIndex;
            __scales = catalog.Scales;
            __scalestartindex = scaleStartIndex;
            __projectNamespace = this.GetType().Namespace;
        }
        public Generator()
        {
            throw new NotImplementedException(String.Format("{0}(): parameterless constructor is inappropriate for generating run-time units.", this.GetType().FullName));
        }
        #endregion
    }
}
