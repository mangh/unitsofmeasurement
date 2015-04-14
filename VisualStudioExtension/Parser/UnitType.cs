/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/
using System;
using System.Collections;   // IEnumerable.GetEnumerator()
using System.Collections.Generic;

namespace Man.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UnitType : MeasureType
    {
        #region Properties
        public SenseExpr Sense { get; set; }
        public NumExpr Factor { get; set; }
        public string Format { get; set; }
        public List<string> Tags { get; private set; }
        // Binary operations, returning values of another (outer) type
        public List<BinaryOperation> OuterOperations { get; private set; }
        #endregion

        #region Constructor(s)
        public UnitType(string name) :
            base(MeasureType.DefaultNamespace, name)
        {
            Tags = new List<string>();
            OuterOperations = new List<BinaryOperation>();
        }
        #endregion

        #region Methods
        public void AddOuterOperation(AbstractType ret, string op, AbstractType lhs, AbstractType rhs)
        {
            OuterOperations.Add(new BinaryOperation(ret, op, lhs, rhs));
        }
        public override string ToString()
        {
            return String.Format("[{0}] {1} : {2} {{{3}}}",
                (Sense == null) ? String.Empty : Sense.Value.ToString(), 
                Name,
                (Factor == null) ? String.Empty : (Factor.IsTrueValue ? Factor.Value.ToString() : (Factor.Code ?? String.Empty)),
                Tags.Count <= 0 ? String.Empty : String.Format("\"{0}\"", String.Join("\", \"", Tags))
            );
        }
        #endregion
    }
}
