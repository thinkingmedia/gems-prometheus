using System;
using System.Collections.Generic;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;

namespace Prometheus.Parser.Executors
{
    /// <summary>
    /// Handles debug assertion checks.
    /// </summary>
    public static class ExecutorAssert
    {
        /// <summary>
        /// Checks that a node has the required number of children.
        /// </summary>
        /// <param name="pNode">The node to check.</param>
        /// <param name="pChildCount">The expected number of children.</param>
        public static void Children(Node pNode, int pChildCount)
        {
            if (pNode.Children.Count != pChildCount)
            {
                throw new AssertionException(
                    string.Format("Invalid child count. Expected <{0}> Found <{1}>", pChildCount, pNode.Children.Count),
                    pNode);
            }
        }

        /// <summary>
        /// Checks that a node has the required number of data elements.
        /// </summary>
        /// <param name="pNode">The node to check.</param>
        /// <param name="pDataCount">The expected number of children.</param>
        public static void Data(Node pNode, int pDataCount)
        {
            if (pNode.Data.Count != pDataCount)
            {
                throw new AssertionException(
                    string.Format("Invalid data count. Expected <{0}> Found <{1}>", pDataCount, pNode.Data.Count), pNode);
            }
        }

        /// <summary>
        /// Checks that the data for a node is of an expected type.
        /// </summary>
        /// <param name="pNode">The node to check</param>
        /// <param name="pIndex">The index in the data array</param>
        /// <param name="pType">The expected type</param>
        public static void DataType(Node pNode, int pIndex, Type pType)
        {
            if (pNode.Data[pIndex].GetType() != pType)
            {
                throw new AssertionException(
                    string.Format("Invalid data type. Expected <{0}> Found <{1}>", pType.FullName,
                        pNode.Data[pIndex].GetType().FullName), pNode);
            }
        }

        /// <summary>
        /// Validates that the node is structured as expected.
        /// </summary>
        /// <param name="pGrammarLookup"></param>
        /// <param name="pNode">The node to validate</param>
        public static void Node(Dictionary<GrammarSymbol, ExecutorGrammar> pGrammarLookup, Node pNode)
        {
            if (!pGrammarLookup.ContainsKey(pNode.Type))
            {
                throw new AssertionException(string.Format("Symbol <{0}> is not implemented", pNode.Type), pNode);
            }
        }
    }
}