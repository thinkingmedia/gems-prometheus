﻿using System;
using System.Collections.Generic;
using Prometheus.Compile.Optomizer;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles basic math operations.
    /// </summary>
    public class MathOperators : PrometheusObject, iNodeOptimizer
    {
        /// <summary>
        /// A list of math operations
        /// </summary>
        private readonly HashSet<GrammarSymbol> _mathSymbols;

        /// <summary>
        /// Checks if a node performs math operations on two constant values.
        /// </summary>
        /// <param name="pNode">The node to check</param>
        /// <returns>True if it can be reduced.</returns>
        private bool CanReduce(Node pNode)
        {
            return (_mathSymbols.Contains(pNode.Type) &&
                    pNode.Children[0].Type == GrammarSymbol.Value &&
                    pNode.Children[1].Type == GrammarSymbol.Value);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MathOperators()
        {
            _mathSymbols = new HashSet<GrammarSymbol>
                           {
                               GrammarSymbol.AddExpression,
                               GrammarSymbol.SubExpression,
                               GrammarSymbol.MultiplyExpression,
                               GrammarSymbol.DivideExpression
                           };
        }

        /// <summary>
        /// Reduces the node to just a constant value.
        /// </summary>
        /// <param name="pNode">The node to reduce</param>
        /// <returns>Same node or a new node.</returns>
        public Node Optomize(Node pNode)
        {
            if (pNode.Children.Count != 2 ||
                pNode.Data.Count != 0 ||
                !CanReduce(pNode))
            {
                return pNode;
            }

            // do math operation now
            Node reduced = new Node(GrammarSymbol.Value, pNode.Location);

            Data valueA = pNode.Children[0].Data[0];
            Data valueB = pNode.Children[1].Data[0];

            switch (pNode.Type)
            {
                case GrammarSymbol.AddExpression:
                    reduced.Data.Add(Add(valueA, valueB));
                    break;
                case GrammarSymbol.SubExpression:
                    reduced.Data.Add(Sub(valueA, valueB));
                    break;
                case GrammarSymbol.MultiplyExpression:
                    reduced.Data.Add(Mul(valueA, valueB));
                    break;
                case GrammarSymbol.DivideExpression:
                    reduced.Data.Add(Div(valueA, valueB));
                    break;
            }

            return reduced;
        }

        /// <summary>
        /// Addition
        /// </summary>
        [SymbolHandler(GrammarSymbol.AddExpression)]
        public Data Add(Data pValue1, Data pValue2)
        {
            Type t1 = pValue1.Type;
            Type t2 = pValue2.Type;
            if (t1 == typeof (string) || t2 == typeof (string))
            {
                return new Data(string.Concat(pValue1.Get<string>(), pValue2.Get<string>()));
            }

            Type type = DataConverter.BestNumericType(t1, t2);
            return type == typeof (long)
                ? new Data(pValue1.Get<long>() + pValue2.Get<long>())
                : new Data(pValue1.Get<double>() + pValue2.Get<double>());
        }

        /// <summary>
        /// Division
        /// </summary>
        [SymbolHandler(GrammarSymbol.DivideExpression)]
        public Data Div(Data pValue1, Data pValue2)
        {
            return new Data(pValue1.Get<double>() / pValue2.Get<double>());
        }

        /// <summary>
        /// Multiplication
        /// </summary>
        [SymbolHandler(GrammarSymbol.MultiplyExpression)]
        public Data Mul(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == typeof (long)
                ? new Data(pValue1.Get<long>() * pValue2.Get<long>())
                : new Data(pValue1.Get<double>() * pValue2.Get<double>());
        }

        /// <summary>
        /// Subtraction
        /// </summary>
        [SymbolHandler(GrammarSymbol.SubExpression)]
        public Data Sub(Data pValue1, Data pValue2)
        {
            Type type = DataConverter.BestNumericType(pValue1.Type, pValue2.Type);
            return type == typeof (long)
                ? new Data(pValue1.Get<long>() - pValue2.Get<long>())
                : new Data(pValue1.Get<double>() - pValue2.Get<double>());
        }
    }
}