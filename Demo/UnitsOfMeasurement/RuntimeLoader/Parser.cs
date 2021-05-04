/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.CodeDom.Compiler;  // CompilerErrorCollection
using System.Collections.Generic;
using System.IO;

namespace Demo.UnitsOfMeasurement
{
    public partial class RuntimeLoader
    {
        private class Parser
        {
            #region Fields
            private string m_sourcePath;
            private CompilerErrorCollection m_errors;
            #endregion

            #region Properties
            public IEnumerable<string> Errors { get { foreach (CompilerError e in m_errors) yield return e.ToString(); } }
            #endregion

            #region Constructor(s)
            public Parser()
            {
                m_errors = new CompilerErrorCollection();
            }
            #endregion

            #region Methods
            public bool ParseString(string lateDefinitions, ICatalog current)
            {
                m_sourcePath = String.Empty;
                using (StringReader input = new StringReader(lateDefinitions))
                {
                    return Parse(input, current);
                }
            }

            public bool ParseFile(string lateDefinitionsPath, ICatalog current)
            {
                m_sourcePath = lateDefinitionsPath;
                using(StreamReader input = File.OpenText(lateDefinitionsPath))
                {
                    return Parse(input, current);
                }
            }

            private bool Parse(TextReader input, ICatalog current)
            {
                m_errors.Clear();

                var lexer = new Man.UnitsOfMeasurement.Lexer(input, LogError);
                var parser = new Man.UnitsOfMeasurement.Parser(lexer, current.Units, current.Scales);
                parser.Parse();

                return m_errors.Count <= 0;
            }

            private void LogError(bool isError, int line, int column, string token, string message)
            {
                var error = new CompilerError(m_sourcePath, line, column, token, message);
                error.IsWarning = !isError;
                m_errors.Add(error);
            }
            #endregion
        }
    }
}
