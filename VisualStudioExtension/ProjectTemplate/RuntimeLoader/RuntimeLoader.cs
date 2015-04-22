/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.IO;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Reflection;

namespace $safeprojectname$
{
    public partial class RuntimeLoader
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
        public RuntimeLoader()
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
        /// <summary>Load supplementary (runtime) units/scales from a definition text file</summary>
        /// <param name="definitionsTextfile">definition file path</param>
        /// <param name="compiledMeasures">assemblies containing compile-time units and/or scales</param>
        /// <returns>assembly with supplementary (runtime) units/scales, saved to an external DLL | null in case of errors</returns>
        public Assembly LoadFromFile(string definitionsTextfile, string[] compiledMeasures)
        {
            string definitionsAssembly;
            return (IsCompilationRequired(definitionsTextfile, out definitionsAssembly)) ? 
                Load(definitionsTextfile, compiledMeasures, m_parser.ParseFile, definitionsAssembly) :
                LoadFromAssembly(definitionsAssembly);
        }

        /// <summary>Load supplementary (runtime) units/scales from a definition string</summary>
        /// <param name="definitions">definition string</param>
        /// <param name="compiledMeasures">assemblies containing compile-time units and/or scales</param>
        /// <returns>assembly with supplementary (runtime) units/scales, NOT saved to an external DLL | null in case of errors</returns>
        public Assembly LoadFromString(string definitions, string[] compiledMeasures)
        {
            return Load(definitions, compiledMeasures, m_parser.ParseString, null);
        }

        /// <summary>Load supplementary (runtime) units/scales from a file or string</summary>
        /// <param name="definitions">definition file path | definition string</param>
        /// <param name="compiledMeasures">assemblies containing compile-time units and/or scales</param>
        /// <param name="parse">ParseFile | ParseString (Parser methods)</param>
        /// <param name="outputAssemblyPath">path to the output DLL | null if the DLL is not required</param>
        /// <returns>assembly with supplementary (runtime) units/scales | null in case of errors</returns>
        private Assembly Load(string definitions, string[] compiledMeasures, Func<string, bool> parse, string outputAssemblyPath)
        {
            // Initialize m_units & m_scales lists with compile-time definitions:
            m_decompiler.Decompile(compiledMeasures);

            int unitStartIndex = m_units.Count;                     // start index for (possible) new units
            int scaleStartIndex = m_scales.Count;                   // start index for (possible) new scales
            int familyStartId = m_decompiler.MaxFamilyFound + 1;    // start id for (possible) new families

            // Parse (append) new definitions into m_units & m_scales lists:
            m_errors = m_parser.Errors;
            if (!parse(definitions)) 
                return null;

            // Generate source code (for the new definitions only): 
            Generator generator = new Generator(familyStartId, m_units, unitStartIndex, m_scales, scaleStartIndex);
            string source = generator.TransformText();

            // Compile the generated source code:
            Assembly supplement = m_compiler.CompileFromSource(source, compiledMeasures, outputAssemblyPath);
            if (supplement == null) m_errors = m_compiler.Errors;
            return supplement;
        }

        /// <summary>Load runtime definitions from previously compiled assembly</summary>
        /// <param name="assemblyPath">path to the assembly file</param>
        /// <returns>assembly with supplementary (runtime) units/scales</returns>
        private Assembly LoadFromAssembly(string assemblyPath)
        {
            m_errors = m_parser.Errors;
            m_errors.Clear();
            return Assembly.LoadFrom(assemblyPath);
        }

        /// <summary>Tests whether definitions have been modified since the last compilation</summary>
        /// <param name="definitionsTextfile">definitions file path</param>
        /// <param name="definitionsAssembly">assembly file path, set to definitionsDirectory/definitionsFileName.dll</param>
        /// <returns>
        /// true if the definitions have been modified and require recompilation; 
        /// false otherwise (runtime definitions can be loaded directly from the saved assembly)
        /// </returns>
        private bool IsCompilationRequired(string definitionsTextfile, out string definitionsAssembly)
        {
            definitionsAssembly = String.Format("{0}\\{1}.dll", 
                Path.GetDirectoryName(definitionsTextfile), Path.GetFileNameWithoutExtension(definitionsTextfile));

            FileSystemInfo textfile = new FileInfo(definitionsTextfile);
            FileSystemInfo assembly = new FileInfo(definitionsAssembly);

            return (textfile.LastWriteTime >= assembly.LastWriteTime);
        }
        #endregion
    }
}
