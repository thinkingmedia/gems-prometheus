﻿using Prometheus.Nodes;
using Prometheus.Storage;

namespace Prometheus.Parser
{
    /// <summary>
    /// The currently executing cursor. Holds the current state of the parser.
    /// </summary>
    public class Cursor
    {
        /// <summary>
        /// The current node being executed.
        /// </summary>
        public Node Node;

        /// <summary>
        /// The current scope for variables.
        /// </summary>
        public StackSpace Scope;

        /// <summary>
        /// Constructor
        /// </summary>
        public Cursor()
        {
            Scope = null;
            Node = null;
        }
    }
}