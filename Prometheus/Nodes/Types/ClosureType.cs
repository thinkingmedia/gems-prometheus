﻿using System.Collections.Generic;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Holds a reference to a function and the object that should be used
    /// as the "this" reference. The compiled flag just means that the function
    /// has been created as an object in the heap.
    /// </summary>
    public class ClosureType : DataType
    {
        /// <summary>
        /// The function
        /// </summary>
        public readonly FunctionType Function;

        /// <summary>
        /// Name of the instance object.
        /// </summary>
        private readonly string _name;

        /// <summary>
        /// Reference to "this"
        /// </summary>
        private readonly InstanceType _this;

        /// <summary>
        /// Constructor
        /// </summary>
        public ClosureType(InstanceType pThis, IEnumerable<DataType> pParameters, Node pBlock)
        {
            _name = IdentifierType.THIS;
            _this = pThis;
            Function = new FunctionType(pBlock, pParameters);
        }

        /// <summary>
        /// Returns "closure"
        /// </summary>
        public override string ToString()
        {
            return "closure";
        }

        /// <summary>
        /// Creates the variables to be sent when executing the function.
        /// </summary>
        public Dictionary<string, DataType> CreateArguments(DataType[] pArgs = null)
        {
            Dictionary<string, DataType> variables = (pArgs != null)
                ? Function.CreateArguments(pArgs)
                : new Dictionary<string, DataType>();
            variables.Add(_name, _this);
            return variables;
        }
    }
}