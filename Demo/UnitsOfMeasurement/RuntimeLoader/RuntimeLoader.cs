/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Demo.UnitsOfMeasurement
{
    public partial class RuntimeLoader
    {
        #region Fields
        private readonly Decompiler m_decompiler;    // decompiles compile-time (in-memory) units
        private readonly Parser m_parser;            // parses late definitions
        private readonly Compiler m_compiler;        // C# compiler (compiles new generated units & scales)
        #endregion

        #region Properties
        // errors found when parsing/compiling the late units 
        public IEnumerable<string> Errors => m_parser.Errors.Concat(m_compiler.Errors);
        #endregion

        #region Constructor(s)
        public RuntimeLoader()
        {
            m_decompiler = new Decompiler();
            m_parser = new Parser();
            m_compiler = new Compiler();
        }
        #endregion

        #region Methods
        /// <summary>Load supplementary (runtime) units/scales from a definition text file</summary>
        /// <param name="lateDefinitionsPath">definition file path</param>
        /// <returns>true on success, false on errors</returns>
        public bool LoadFromFile(string lateDefinitionsPath)
        {
            string definitionsAssembly =
                string.Format("{0}\\{1}.dll",
                    Path.GetDirectoryName(lateDefinitionsPath), 
                    Path.GetFileNameWithoutExtension(lateDefinitionsPath)
                );

            FileSystemInfo textfile = new FileInfo(lateDefinitionsPath);
            FileSystemInfo assembly = new FileInfo(definitionsAssembly);

            Assembly supplement = (textfile.LastWriteTime >= assembly.LastWriteTime) ?
                Compile(lateDefinitionsPath, m_parser.ParseFile, outputAssemblyPath: definitionsAssembly) :
                Assembly.LoadFrom(definitionsAssembly);

            if (supplement != null)
            {
                Catalog.AppendFromAssembly(supplement);
            }
            return (supplement != null);
        }

        /// <summary>Load supplementary (runtime) units/scales from a definition string</summary>
        /// <param name="lateDefinitions">definition string</param>
        /// <returns>true on success, false on errors</returns>
        public bool LoadFromString(string lateDefinitions)
        {
            Assembly supplement = Compile(lateDefinitions, m_parser.ParseString, outputAssemblyPath: null);
            if (supplement != null)
            {
                Catalog.AppendFromAssembly(supplement);
            }
            return (supplement != null);
        }

        /// <summary>
        /// Compile supplementary (runtime) units/scales from a file or string
        /// </summary>
        /// <param name="definitions">definition file path --or-- definition string</param>
        /// <param name="parse">ParseFile | ParseString (parser methods)</param>
        /// <param name="outputAssemblyPath">path to the output DLL | null if the DLL is not required</param>
        /// <returns>assembly with supplementary (runtime) units/scales | null in case of errors</returns>
        private Assembly Compile(string definitions, Func<string, ICatalog, bool> parse, string outputAssemblyPath)
        {
            // Retrieve compile-time definitions of all Catalog entities:
            m_decompiler.Decompile();

            int unitCount = m_decompiler.Units.Count;          // start index for (possible) new units
            int scaleCount = m_decompiler.Scales.Count;        // start index for (possible) new scales
            int familyStartId = m_decompiler.MaxFamilyFound + 1;    // start id for (possible) new families

            Assembly supplement = null;

            // Parse (append) new definitions:
            if (parse(definitions, m_decompiler) && ((m_decompiler.Units.Count > unitCount) || (m_decompiler.Scales.Count > scaleCount)))
            {
                // Generate source code (for the new definitions only): 
                Generator generator = new Generator(m_decompiler, unitCount, scaleCount, familyStartId);
                string source = generator.TransformText();

                // References to assemblies containing units & scales that might be referenced from the source.
                // NOTE: references to measures appended previously from string (and not saved to a DLL) are not available!!!
                string[] references = Catalog.All
                        .Select(m => m.Type.Assembly.Location).Distinct()
                        .Where(location => !string.IsNullOrWhiteSpace(location)) // NOTE: empty locations for measures appended from string!!!
                        .ToArray();

                // Compile the generated source code:
                supplement = m_compiler.CompileFromSource(source, references, outputAssemblyPath);
            }
            return supplement;
        }
        #endregion
    }
}
