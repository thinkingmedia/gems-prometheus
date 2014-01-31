﻿using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Runtime.Creators;

namespace Prometheus.Runtime
{
    /// <summary>
    /// All the string functions
    /// </summary>
    public class StringManipulation : PrometheusObject
    {
        /// <summary>
        /// Converts to upper case.
        /// </summary>
        [SymbolHandler(GrammarSymbol.UpperCommand)]
        public Data ToUpper(Data pValue)
        {
            return new Data(GrammarSymbol.StringDouble, pValue.Value.ToUpper());
        }

        /// <summary>
        /// Converts to lower case.
        /// </summary>
        [SymbolHandler(GrammarSymbol.LowerCommand)]
        public Data ToLower(Data pValue)
        {
            return new Data(GrammarSymbol.StringDouble, pValue.Value.ToLower());
        }

        /// <summary>
        /// Converts to trims spaces
        /// </summary>
        [SymbolHandler(GrammarSymbol.TrimCommand)]
        public Data Trim(Data pValue)
        {
            return new Data(GrammarSymbol.StringDouble, pValue.Value.Trim());
        }
    }
}