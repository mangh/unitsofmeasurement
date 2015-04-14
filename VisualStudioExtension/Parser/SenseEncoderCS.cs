/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at http://unitsofmeasurement.codeplex.com/license


********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Man.UnitsOfMeasurement
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    internal class SenseEncoderCS : IASTEncoder
    {
        private static string s_notImplementedTypeEncoding = "Dimension encoding not provided for \"{0}\" node type";

        private Stack<SenseExpr> m_stack;
        private SenseExpr m_senselessExpr = new SenseExpr(Dimension.None, "Dimension.None");

        public SenseEncoderCS()
        {
            m_stack = new Stack<SenseExpr>(16);
        }

        public SenseExpr Encode(ASTNode node)
        {
            node.Accept(this);
            if (m_stack.Count() != 1) throw new InvalidOperationException(String.Format("{0}: invalid stack processing", this.GetType().Name));
            return m_stack.Pop();
        }

        public void Encode(ASTNumber node)
        {
            m_stack.Push(m_senselessExpr);
        }
        public void Encode(ASTLiteral node)
        {
            m_stack.Push(m_senselessExpr);
        }
        public void Encode(ASTMagnitude node)
        {
            if (node.Exponent == -1)
            {
                m_stack.Push(m_senselessExpr);
            }
            else
            {
                Magnitude m = (Magnitude)node.Exponent;
                m_stack.Push(new SenseExpr(new Dimension(m), String.Format("Dimension.{0}", m.ToString())));
            }
        }
        public void Encode(ASTUnit node)
        {
            m_stack.Push(new SenseExpr(node.Unit.Sense.Value, String.Format("{0}.Sense", node.Unit.Name)));
        }
        public void Encode(ASTUnary node)
        {
            throw new NotImplementedException(String.Format(s_notImplementedTypeEncoding, node.GetType().FullName));
        }
        public void Encode(ASTParenthesized node)
        {
            SenseExpr nested = m_stack.Pop();
            m_stack.Push(new SenseExpr(nested.Value, String.Format("({0})", nested.Code)));
        }
        public void Encode(ASTProduct node)
        {
            SenseExpr rhs = m_stack.Pop();
            SenseExpr lhs = m_stack.Pop();
            if (lhs.Value == Dimension.None)
                m_stack.Push(new SenseExpr(rhs.Value, rhs.Code));
            else if (rhs.Value == Dimension.None)
                m_stack.Push(new SenseExpr(lhs.Value, lhs.Code));
            else
                m_stack.Push(new SenseExpr(lhs.Value * rhs.Value, String.Format("{0} * {1}", lhs.Code, rhs.Code)));
        }
        public void Encode(ASTQuotient node)
        {
            SenseExpr rhs = m_stack.Pop();
            SenseExpr lhs = m_stack.Pop();
            if (rhs.Value == Dimension.None)
                m_stack.Push(new SenseExpr(lhs.Value, lhs.Code));
            else
                m_stack.Push(new SenseExpr(lhs.Value / rhs.Value, String.Format("{0} / {1}", lhs.Code, rhs.Code)));
        }
        public void Encode(ASTSum node)
        {
            throw new NotImplementedException(String.Format(s_notImplementedTypeEncoding, node.GetType().FullName));
        }
        public void Encode(ASTDifference node)
        {
            throw new NotImplementedException(String.Format(s_notImplementedTypeEncoding, node.GetType().FullName));
        }
    }
}
