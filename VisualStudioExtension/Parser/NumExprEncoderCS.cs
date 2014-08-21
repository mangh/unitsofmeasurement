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
    internal class NumExprEncoderCS : IASTEncoder
    {
        private Stack<NumExpr> m_stack;
        private NumericType m_numtype;
        private string m_targetnamespace;

        public NumExprEncoderCS()
        {
            m_stack = new Stack<NumExpr>(16);
        }

        public NumExpr Encode(ASTNode node, NumericType numType, string unitnamespace)
        {
            m_numtype = numType;
            m_targetnamespace = unitnamespace;

            node.Accept(this);
            if (m_stack.Count() != 1) throw new InvalidOperationException(String.Format("{0}: invalid stack processing", this.GetType().Name));
            return m_stack.Pop();
        }

        public void Encode(ASTNumber node)
        {
            m_stack.Push(new NumExpr(true, node.Number, node.Number.CSString()));
        }
        public void Encode(ASTLiteral node)
        {
            m_stack.Push(new NumExpr(false, m_numtype.One, node.Literal));  // NOTE: it takes 1.0 (one) as a fake (untrue) value of the Literal
        }
        public void Encode(ASTMagnitude node)
        {
            m_stack.Push(new NumExpr(true, m_numtype.One, m_numtype.One.CSString()));
        }
        public void Encode(ASTUnit node)
        {
            UnitType unit = node.Unit;
            m_stack.Push(new NumExpr(unit.Factor.IsTrueValue, unit.Factor.Value, String.Format("{0}.Factor", node.Unit.Name)));
        }
        public void Encode(ASTUnary node)
        {
            NumExpr expr = m_stack.Pop();
            m_stack.Push(node.Plus ?
                new NumExpr(expr.IsTrueValue, expr.Value, String.Format("+{0}", expr.Code)) :
                new NumExpr(expr.IsTrueValue, expr.Value.Negate(), String.Format("-{0}", expr.Code))
            );
        }
        public void Encode(ASTParenthesized node)
        {
            NumExpr expr = m_stack.Pop();
            m_stack.Push(new NumExpr(expr.IsTrueValue, expr.Value, String.Format("({0})", expr.Code)));
        }
        public void Encode(ASTProduct node)
        {
            NumExpr rhs = m_stack.Pop();
            NumExpr lhs = m_stack.Pop();
            m_stack.Push(new NumExpr(lhs.IsTrueValue && rhs.IsTrueValue, lhs.Value * rhs.Value, String.Format("{0} * {1}", lhs.Code, rhs.Code)));
        }
        public void Encode(ASTQuotient node)
        {
            NumExpr rhs = m_stack.Pop();
            NumExpr lhs = m_stack.Pop();
            m_stack.Push(new NumExpr(lhs.IsTrueValue && rhs.IsTrueValue, lhs.Value / rhs.Value, String.Format("{0} / {1}", lhs.Code, rhs.Code)));
        }
        public void Encode(ASTSum node)
        {
            NumExpr rhs = m_stack.Pop();
            NumExpr lhs = m_stack.Pop();
            m_stack.Push(new NumExpr(lhs.IsTrueValue && rhs.IsTrueValue, lhs.Value + rhs.Value, String.Format("{0} + {1}", lhs.Code, rhs.Code)));
        }
        public void Encode(ASTDifference node)
        {
            NumExpr rhs = m_stack.Pop();
            NumExpr lhs = m_stack.Pop();
            m_stack.Push(new NumExpr(lhs.IsTrueValue && rhs.IsTrueValue, lhs.Value - rhs.Value, String.Format("{0} - {1}", lhs.Code, rhs.Code)));
        }
    }
}
