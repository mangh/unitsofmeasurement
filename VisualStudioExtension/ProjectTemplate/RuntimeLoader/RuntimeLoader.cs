/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Reflection;

namespace $safeprojectname$
{
    public class RunTimeLoader
    {
        #region Fields
        private List<Man.UnitsOfMeasurement.UnitType> m_units;
        private List<Man.UnitsOfMeasurement.ScaleType> m_scales;
        private Decompiler m_decompiler;
        private Parser m_parser;
        private Compiler m_compiler;
        private CompilerErrorCollection m_errors;
        #endregion

        #region Properties
        public CompilerErrorCollection Errors { get { return m_errors; } }
        #endregion

        #region Constructor(s)
        public RunTimeLoader()
        {
            m_units = new List<Man.UnitsOfMeasurement.UnitType>();
            m_scales = new List<Man.UnitsOfMeasurement.ScaleType>();

            m_decompiler = new Decompiler(m_units, m_scales);
            m_parser = new Parser(m_units, m_scales);
            m_compiler = new Compiler();

            m_errors = m_parser.Errors;
        }
        #endregion

        #region Methods
        public Assembly LoadFromFile(string definitionfile, string[] referencedAssemblies)
        {
            return Load(definitionfile, referencedAssemblies, m_parser.ParseFile);
        }
        public Assembly LoadFromString(string definitionstring, string[] referencedAssemblies)
        {
            return Load(definitionstring, referencedAssemblies, m_parser.ParseString);
        }
        private Assembly Load(string definitions, string[] referencedAssemblies, Func<string, bool> parse)
        {
            m_decompiler.Decompile(referencedAssemblies);

            int unitStartIndex = m_units.Count;
            int scaleStartIndex = m_scales.Count;
            int familyStartId = m_decompiler.MaxFamilyFound + 1;

            Assembly result = null;
            m_errors = m_parser.Errors;
            if (parse(definitions))
            {
                Generator generator = new Generator(familyStartId, m_units, unitStartIndex, m_scales, scaleStartIndex);
                string source = generator.TransformText();

                result = m_compiler.CompileFromSource(source, referencedAssemblies);
                if (result == null) m_errors = m_compiler.Errors;
            }
            return result;
        }
        #endregion
    }
}
