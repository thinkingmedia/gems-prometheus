﻿using System.Collections.Generic;
using System.Linq;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser;
using Prometheus.Properties;

namespace Prometheus.Storage
{
    /// <summary>
    /// Executing blocks place their variables into this class
    /// to limit their scope.
    /// Each stack gets a ID counter from the previous stack.
    /// </summary>
    public class StackSpace : StorageSpace
    {
        /// <summary>
        /// The parser's cursor
        /// </summary>
        private Cursor _cursor;

        /// <summary>
        /// The parent scope
        /// </summary>
        private iMemorySpace _parent;

        /// <summary>
        /// Constructor
        /// </summary>
        public StackSpace(Cursor pCursor)
        {
            _cursor = pCursor;
            _parent = _cursor.Stack;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public StackSpace(Cursor pCursor, Dictionary<string, DataType> pStorage)
            : base(pStorage)
        {
            _cursor = pCursor;
            _parent = _cursor.Stack;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            _cursor.Stack = _parent;

            _cursor = null;
            _parent = null;

            base.Dispose();
        }

        /// <summary>
        /// Looks for the identifier in the current scope, and
        /// all parent scopes.
        /// </summary>
        /// <param name="pName">The name to find</param>
        /// <returns>The data object or Null if not found.</returns>
        public override DataType Get(string pName)
        {
            DataType d = base.Get(pName);
            if (d != null)
            {
                return d;
            }
            if (_parent != null)
            {
                return _parent.Get(pName);
            }
            throw new IdentifierInnerException(string.Format(Errors.IdentifierNotDefined, pName));
        }

        /// <summary>
        /// Prints a list of all variables.
        /// </summary>
        public override IEnumerable<MemoryItem> Dump(int pIndent = 0)
        {
            return _parent == null 
                ? base.Dump(pIndent) 
                : _parent.Dump(pIndent + 1).Union(base.Dump(pIndent));
        }

        /// <summary>
        /// Looks for the identifier in the current scope, and
        /// all parent scopes.
        /// </summary>
        /// <param name="pName">The identifier to find</param>
        /// <param name="pDataType">The data to assign to the identifier</param>
        public override bool Set(string pName, DataType pDataType)
        {
            if (base.Set(pName, pDataType))
            {
                return true;
            }
            if (_parent != null)
            {
                return _parent.Set(pName, pDataType);
            }
            throw new IdentifierInnerException(string.Format(Errors.IdentifierNotDefined, pName));
        }
    }
}