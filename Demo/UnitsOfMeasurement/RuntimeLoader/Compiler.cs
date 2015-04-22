/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System.CodeDom.Compiler;
using System.Reflection;

namespace Demo.UnitsOfMeasurement
{
    public partial class RuntimeLoader
    {
        private class Compiler
        {
            #region Fields
            private CodeDomProvider m_provider;
            private CompilerResults m_results;
            #endregion

            #region Properties
            public CompilerErrorCollection Errors { get { return m_results == null ? null : m_results.Errors; } }
            #endregion

            #region Constructor(s)
            public Compiler()
            {
                m_provider = new Microsoft.CSharp.CSharpCodeProvider();
                m_results = null;
            }
            #endregion

            #region Methods
            public Assembly CompileFromSource(string source, string[] referencedAssemblies, string targetAssemblyPath)
            {
                // Setup compiler parameters
                CompilerParameters parameters = new CompilerParameters(referencedAssemblies);
                if (string.IsNullOrWhiteSpace(targetAssemblyPath))
                {
                    parameters.GenerateInMemory = true;
                    parameters.GenerateExecutable = false;
                }
                else
                {
                    parameters.GenerateInMemory = false;
                    parameters.GenerateExecutable = false;
                    parameters.OutputAssembly = targetAssemblyPath;
                }

                // Compile the source code
                m_results = m_provider.CompileAssemblyFromSource(parameters, source);
                return m_results.Errors.HasErrors ? null : m_results.CompiledAssembly;
            }
            #endregion
        }
    }
}
