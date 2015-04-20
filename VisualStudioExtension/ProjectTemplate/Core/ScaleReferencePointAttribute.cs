/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;

namespace $safeprojectname$
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
