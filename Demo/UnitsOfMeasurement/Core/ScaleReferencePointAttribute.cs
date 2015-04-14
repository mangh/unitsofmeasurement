/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;

namespace Demo.UnitsOfMeasurement
{
    [AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    public class ScaleReferencePointAttribute : Attribute
    {
        public string Name { get; private set; }
        public ScaleReferencePointAttribute(string name)
        {
            Name = name;
        }
    }
}
