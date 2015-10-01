/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.CodeDom.Compiler;
using System.Reflection;

namespace $safeprojectname$
{
    public partial class RuntimeLoader
    {
        private class Compiler
        {
            #region Fields
            private CompilerResults m_results;
            #endregion

            #region Properties
            public CompilerResults Results { get { return m_results; } }
            #endregion

            #region Constructor(s)
            public Compiler()
            {
                m_results = null;
            }
            #endregion

            #region Methods
            public bool CompileFromSource(string source, string[] referencedAssemblies, string targetAssemblyPath)
            {
                CompilerParameters parameters = new CompilerParameters(referencedAssemblies);
                if(String.IsNullOrWhiteSpace(targetAssemblyPath))
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
                using(var m_provider = new Microsoft.CSharp.CSharpCodeProvider())
                {
                    m_results = m_provider.CompileAssemblyFromSource(parameters, source);
                    return !m_results.Errors.HasErrors;
                }
            }
            #endregion
        }
    }
}
