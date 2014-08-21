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
    public class BinaryOperation
    {
        public AbstractType Result { get; private set; }
        public string Operation { get; private set; }
        public AbstractType Lhs { get; private set; }
        public AbstractType Rhs { get; private set; }

        public BinaryOperation(AbstractType result, string operation, AbstractType lhs, AbstractType rhs)
        {
            Result = result;
            Operation = operation;
            Lhs = lhs;
            Rhs = rhs;
        }
    }
}
