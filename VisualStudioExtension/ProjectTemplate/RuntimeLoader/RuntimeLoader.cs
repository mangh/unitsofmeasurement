/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.IO;
using System.Linq;
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

        private Decompiler m_decompiler;    // decompiles in-memory units & into m_units & m_scales structures
        private Parser m_parser;            // parses txt definitions and supplements m_units & m_scales structures
        private Compiler m_compiler;        // C# compiler (compiles new generated units & scales)

        private CompilerErrorCollection m_errors;   // errors from either unit parser or C# compiler.
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
        public bool LoadFromFile(string definitionsTextfile)
        {
            Assembly supplement = CompileFromFile(definitionsTextfile);
            bool done = (supplement != null);
            if(done)
            {
                Catalog.AppendFromAssembly(supplement);
            }
            return done;
        }
        public bool LoadFromString(string definitions)
        {
            Assembly supplement = CompileFromString(definitions);
            bool done = (supplement != null);
            if(done)
            {
                Catalog.AppendFromAssembly(supplement);
            }
            return done;
        }

        /// <summary>Compile supplementary (runtime) units/scales from a definition text file</summary>
        /// <param name="definitionsTextfile">definition file path</param>
        /// <returns>assembly with supplementary (runtime) units/scales, saved to an external DLL | null in case of errors</returns>
        private Assembly CompileFromFile(string definitionsTextfile)
        {
            string definitionsAssembly =
                string.Format("{0}\\{1}.dll",
                    Path.GetDirectoryName(definitionsTextfile), 
                    Path.GetFileNameWithoutExtension(definitionsTextfile)
                );

            FileSystemInfo textfile = new FileInfo(definitionsTextfile);
            FileSystemInfo assembly = new FileInfo(definitionsAssembly);

            if(textfile.LastWriteTime >= assembly.LastWriteTime)
            {
                return Compile(definitionsTextfile, m_parser.ParseFile, outputAssemblyPath: definitionsAssembly);
            }
            else
            {
                m_errors = m_parser.Errors;
                m_errors.Clear();
                return Assembly.LoadFrom(definitionsAssembly);
            }
        }

        /// <summary>Load supplementary (runtime) units/scales from a definition string</summary>
        /// <param name="definitions">definition string</param>
        /// <returns>assembly with supplementary (runtime) units/scales, NOT saved to an external DLL | null in case of errors</returns>
        private Assembly CompileFromString(string definitions)
        {
            return Compile(definitions, m_parser.ParseString, outputAssemblyPath: null);
        }

        /// <summary>Compile supplementary (runtime) units/scales from a file or string</summary>
        /// <param name="definitions">definition file path --or-- definition string</param>
        /// <param name="parse">ParseFile | ParseString (parser methods)</param>
        /// <param name="outputAssemblyPath">path to the output DLL | null if the DLL is not required</param>
        /// <returns>assembly with supplementary (runtime) units/scales | null in case of errors</returns>
        private Assembly Compile(string definitions, Func<string, bool> parse, string outputAssemblyPath)
        {
            // Switch error collection back to the parser
            m_errors = m_parser.Errors;

            m_errors.Clear();

            // Initialize m_units & m_scales lists with compile-time definitions:
            m_decompiler.Decompile();

            int unitStartIndex = m_units.Count;                     // start index for (possible) new units
            int scaleStartIndex = m_scales.Count;                   // start index for (possible) new scales
            int familyStartId = m_decompiler.MaxFamilyFound + 1;    // start id for (possible) new families

            Assembly supplement = null;

            // Parse (append) new definitions into m_units & m_scales lists:
            if(parse(definitions))
            {
                // Generate source code (for the new definitions only): 
                Generator generator = new Generator(familyStartId, m_units, unitStartIndex, m_scales, scaleStartIndex);
                string source = generator.TransformText();

                // References to assemblies containing units & scales that might be referenced from the source.
                // NOTE: references to measures appended previously from string (and not saved to a DLL) are not available!!!
                string[] references = Catalog.All
                        .Select(m => m.Type.Assembly.Location).Distinct()
                        .Where(location => !string.IsNullOrWhiteSpace(location)) // NOTE: assembly locations for measures appended from string are empty!!!
                        .ToArray();

                // Compile the generated source code:
                if(m_compiler.CompileFromSource(source, references, outputAssemblyPath))
                    supplement = m_compiler.Results.CompiledAssembly;

                m_errors = m_compiler.Results.Errors;
            }
            return supplement;
        }
        #endregion
    }
}
