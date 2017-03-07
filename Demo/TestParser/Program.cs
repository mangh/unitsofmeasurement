/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.IO;
using System.Collections.Generic;
using Man.UnitsOfMeasurement;

namespace TestParser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<UnitType> units = new List<UnitType>();
            List<ScaleType> scales = new List<ScaleType>();
            using (StreamReader input = File.OpenText(@"..\..\..\UnitsOfMeasurement\Units\_definitions.txt"))
            {
                Lexer lexer = new Lexer(input, LogParserError);
                Parser parser = new Parser(lexer, units, scales);
                parser.Parse();
            }
        }
        static void LogParserError(bool isError, int line, int column, string token, string message)
        {
            Console.WriteLine("({0},{1}) :: {2} :: {3}", line, column, token, message);
        }
    }
}
