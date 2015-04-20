/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.CodeDom.Compiler;  // CompilerErrorCollection

namespace $safeprojectname$
{
    public class Parser
    {
        #region Fields
        private string m_filePath;
        private List<Man.UnitsOfMeasurement.UnitType> m_units;
        private List<Man.UnitsOfMeasurement.ScaleType> m_scales;
        private CompilerErrorCollection m_errors;
        #endregion

        #region Properties
        public CompilerErrorCollection Errors { get { return m_errors; } }
        #endregion

        #region Constructor(s)
        public Parser(List<Man.UnitsOfMeasurement.UnitType> units, List<Man.UnitsOfMeasurement.ScaleType> scales)
        {
            m_units = units;
            m_scales = scales;
            m_errors = new CompilerErrorCollection();
        }
        #endregion

        #region Methods
        public bool ParseString(string definitions)
        {
            m_filePath = null;
            StringReader input = new StringReader(definitions);
            return Parse(input);
        }

        public bool ParseFile(string filePath)
        {
            m_filePath = filePath;
            StreamReader input = null;
            bool done = false;
            try
            {
                input = File.OpenText(filePath);
                done = Parse(input);
            }
            catch (Exception e)
            {
                LogError(true, 0, 0, "parser exception", e.Message);
            }
            finally
            {
                if (input != null) input.Close();
            }
            return done;
        }

        private bool Parse(TextReader input)
        {
            m_errors.Clear();

            var lexer = new Man.UnitsOfMeasurement.Lexer(input, LogError);
            var parser = new Man.UnitsOfMeasurement.Parser(lexer, m_units, m_scales);
            parser.Parse();

            return !m_errors.HasErrors;
        }

        private void LogError(bool isError, int line, int column, string token, string message)
        {
            var error = new CompilerError(m_filePath, line, column, token, message);
            error.IsWarning = !isError;
            m_errors.Add(error);
        }
        #endregion
    }
}
