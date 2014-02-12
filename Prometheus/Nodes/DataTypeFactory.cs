﻿using System;
using System.Collections.Generic;
using Prometheus.Compile;
using Prometheus.Exceptions.Compiler;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes
{
    /// <summary>
    /// Handles create data objects during compile time.
    /// </summary>
    public static class DataTypeFactory
    {
        /// <summary>
        /// A list of symbols that represent terminals that indicate a data type.
        /// </summary>
        private static readonly HashSet<GrammarSymbol> _dataTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.StringDouble,
                                                                        GrammarSymbol.StringSingle,
                                                                        GrammarSymbol.Number,
                                                                        GrammarSymbol.Decimal,
                                                                        GrammarSymbol.Boolean,
                                                                        GrammarSymbol.Identifier,
                                                                        //GrammarSymbol.Type,
                                                                        GrammarSymbol.QualifiedID,
                                                                        GrammarSymbol.ValidID,
                                                                        GrammarSymbol.MemberName
                                                                    };

        /// <summary>
        /// Takes a raw string value from the grammar and creates a string type.  Supports inline 
        /// flags and different types of quote marks.
        /// </summary>
        /// <param name="pValue">The raw string</param>
        /// <returns>The string object</returns>
        /// <exception cref="UnexpectedErrorException">If empty string</exception>
        public static StringType CreateString(string pValue)
        {
#if DEBUG
            if (string.IsNullOrWhiteSpace(pValue))
            {
                throw new UnexpectedErrorException("Unexpected empty string.");
            }
#endif
            StringType.eMODE mode = pValue[0] == '"' ? StringType.eMODE.ANYWHERE : StringType.eMODE.WORD_BOUNDARIES;
            StringType.eFLAGS flags = StringType.eFLAGS.NONE;

            string str = pValue.Substring(1);
            int tail = 1;
            for (int i = str.Length-1; i > 0; i--)
            {
                if (str[i] == '"' || str[i] == '\'')
                    break;
                switch (str[i])
                {
                    case 'i':
                        flags |= StringType.eFLAGS.IGNORE_CASE;
                        break;
                    case 'c':
                        flags |= StringType.eFLAGS.NO_CACHING;
                        break;
                    case 'f':
                        flags |= StringType.eFLAGS.MATCH_FIRST;
                        break;
                    default:
                        continue;
                }
                tail++;
            }
            str = str.Substring(0, str.Length - tail);
            return new StringType(str, mode, flags);
        }

        /// <summary>
        /// Creates a data object and adjusts the value is needed.
        /// </summary>
        public static DataType Create(Location pLocation, GrammarSymbol pSymbol, string pValue)
        {
            switch (pSymbol)
            {
                    // drop the quotes
                case GrammarSymbol.StringDouble:
                case GrammarSymbol.StringSingle:
                    return CreateString(pValue);

                case GrammarSymbol.Number:
                    return new NumericType(Convert.ToInt64(pValue));

                case GrammarSymbol.Decimal:
                    return new NumericType(Convert.ToDouble(pValue));

                case GrammarSymbol.Boolean:
                    pValue = pValue.ToLower();
                    switch (pValue)
                    {
                        case "true":
                        case "on":
                        case "yes":
                        case "always":
                            return new BooleanType(true);
                        case "false":
                        case "off":
                        case "no":
                        case "never":
                            return new BooleanType(false);
                    }
                    break;

                case GrammarSymbol.Identifier:
                    return new IdentifierType(pValue);

                case GrammarSymbol.MemberName:
                    return new IdentifierType(pValue.Substring(1));
            }

            throw new UnsupportedDataTypeException(string.Format("{0} is not a supported data type.", pSymbol),
                pLocation);
        }

        /// <summary>
        /// Checks if a symbol is a data type.
        /// </summary>
        public static bool isDataType(GrammarSymbol pSymbol)
        {
            return _dataTypes.Contains(pSymbol);
        }
    }
}