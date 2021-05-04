/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;

namespace Demo.UnitsOfMeasurement
{
    public partial class RuntimeLoader
    {
        private class Compiler
        {
            #region Fields
            private CompilerResults m_result;
            #endregion

            #region Properties
            public IEnumerable<string> Errors { get { if (m_result == null) yield break; else foreach (var e in m_result.Errors) yield return e.ToString(); } }
            #endregion

            #region Constructor(s)
            public Compiler()
            {
                m_result = null;
            }
            #endregion

            #region Methods
            public Assembly CompileFromSource(string source, string[] referencedAssemblies, string targetAssemblyPath)
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

                m_result = null;

                // Compile the source code
                using (var m_provider = new Microsoft.CSharp.CSharpCodeProvider())
                {
                    m_result = m_provider.CompileAssemblyFromSource(parameters, source);
                    if (!m_result.Errors.HasErrors)
                    {
                        return m_result.CompiledAssembly;
                    }
                }
                return null;
            }
            #endregion
        }
    }
}
