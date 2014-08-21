/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

namespace Man.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public partial class Lexer
    {
        public enum Symbol
        {
            // Special
            EOF = -2,
            Error = -1,
            Unknown = 0,

            // Operators
            Minus = 1, // '-'
            Plus = 2, // '+'
            Times = 3, // '*'
            Div = 4, // '/'
            EQ = 5, // '='
            LT = 6, // '<'
            GT = 7, // '>'
            Pipe = 8, // '|'

            // Brackets
            Lparen = 13, // '('
            Rparen = 14, // ')'
            //Rbrace = 15, // '}'
            //Lbrace = 16, // '{'
            Colon = 17, // ':'
            Semicolon = 18, // ';'

            // Non-terminals
            Comment = 30, // Comment
            Identifier = 31, // Identifier
            Qualifiedname = 32,
            IntNumber = 33, // IntLiteral
            RealNumber = 34, // RealLiteral
            StringLiteral = 35, // StringLiteral
        }
    }
}
