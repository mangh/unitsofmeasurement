/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.Collections.Generic;

namespace Man.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class Parser
    {
        #region Fields
        private Lexer m_lexer;
        private Lexer.Symbol m_symbol;
        private string m_token;
        private List<UnitType> m_units;
        private List<ScaleType> m_scales;
        private SenseEncoderCS m_senseEncoder;
        private NumExprEncoderCS m_exprEncoder;
        #endregion

        #region Properties
        #endregion

        #region Constructor(s)
        public Parser(Lexer lexer, List<UnitType> units, List<ScaleType> scales)
        {
            m_lexer = lexer;
            m_units = units;
            m_scales = scales;
            m_senseEncoder = new SenseEncoderCS();
            m_exprEncoder = new NumExprEncoderCS();

            GetToken();
        }
        #endregion

        #region Methods
        // <UnitsOfMeasure> ::=  <UnitsOfMeasure> <Entity> | <Entity>
        // <Entity> ::= <Unit> | <Scale>
        // <Unit> ::= 'unit'<ValueType> Identifier <Tags> <Format> '=' <Dim Expr> ';'
        // <Scale> ::= 'scale' Identifier <Format> Identifier '=' Identifier <Num Expr> ';'
        public void Parse()
        {
            string badTokenMessageFormat = "\"{0}\" found while expected \"unit\" or \"scale\" keyword.";

            while (m_symbol != Lexer.Symbol.EOF)
            {
                if (m_symbol != Lexer.Symbol.Identifier)
                {
                    Note(badTokenMessageFormat, m_token);
                    Synchronize();
                }
                else if (m_token == "unit")
                {
                    GetToken();
                    ParseUnit();
                    CheckSemicolon();
                }
                else if (m_token == "scale")
                {
                    GetToken();
                    ParseScale();
                    CheckSemicolon();
                }
                else
                {
                    Note(badTokenMessageFormat, m_token);
                    Synchronize();
                }
            }
        }

        private Lexer.Symbol GetToken()
        {
            m_symbol = m_lexer.GetToken();
            m_token = m_lexer.TokenText;
            return m_symbol;
        }

        private string GetEntityName(string entityType)
        {
            if (m_symbol != Lexer.Symbol.Identifier)
            {
                Note("\"{0}\" found while expected {1} name.", m_token, entityType);
            }
            else if (IsUniqueName(m_token))
            {
                string entityName = m_token;
                GetToken();
                return entityName;
            }
            else
            {
                Note("{0}: duplicate definition (unit and scale names must be unique).", m_token);
            }
            return null;
        }

        private void CheckSemicolon()
        {
            if (m_symbol == Lexer.Symbol.Semicolon)
                GetToken();

            else if (m_lexer.TokenIsFaulty)
                Synchronize();

            else
                Note("\"{0}\" found while expected semicolon \";\".", m_token);
        }

        private void Synchronize()
        {
            while (m_symbol != Lexer.Symbol.EOF)
            {
                if (m_symbol == Lexer.Symbol.Semicolon)
                {
                    GetToken();
                    break;
                }
                if ((m_symbol == Lexer.Symbol.Identifier) && ((m_token == "unit") || (m_token == "scale")))
                {
                    break;
                }
                GetToken();
            }
        }

        private UnitType FindUnit(string name) { return m_units.Find(u => u.Name == name); }
        private UnitType FindUnitOfTag(string tag) { return m_units.Find(u => u.Tags.Contains(tag)); }
        private ScaleType FindScale(string name) { return m_scales.Find(s => s.Name == name); }
        private ScaleType FindScale(string refpoint, UnitType unit) { return m_scales.Find(s => (s.RefPoint == refpoint) && (s.Unit == unit)); }
        private bool IsUniqueName(string name) { return (FindUnit(name) == null) && (FindScale(name) == null); }

        private void Note(string info)
        {
            m_lexer.Note(info);
        }
        public void Note(string format, params object[] info)
        {
            m_lexer.Note(format, info);
        }
        public void Note(int line, int column, string token, string info)
        {
            m_lexer.Note(line, column, token, info);
        }
        #endregion
    }
}
