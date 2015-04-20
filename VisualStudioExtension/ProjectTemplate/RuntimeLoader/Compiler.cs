/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System.CodeDom.Compiler;
using System.Reflection;

namespace $safeprojectname$
{
    internal class Compiler
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
        public Assembly CompileFromSource(string source, string[] referencedAssemblies)
        {
            // Setup appropriate CodeDomProvider ///////////////////////////////////////////////////////
            CompilerParameters parameters = new CompilerParameters(referencedAssemblies);
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;

            // Compile the source code /////////////////////////////////////////////////////////////////
            m_results = m_provider.CompileAssemblyFromSource(parameters, source);
            return m_results.Errors.HasErrors ? null : m_results.CompiledAssembly;
        }
        //private static Assembly ResolveAssemblyReference(object sender, ResolveEventArgs args)
        //{
        //    return Array.Find(AppDomain.CurrentDomain.GetAssemblies(), a => a.FullName == args.Name);
        //}
        #endregion
    }
}
