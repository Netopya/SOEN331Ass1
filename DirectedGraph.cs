using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEN331Assignment1_2
{

    /// <summary>
    /// Directed Graph ADT
    /// By:
    ///     Michael Bilinsky 26992358
    ///     David Bastien
    /// 
    /// SOEN 331 Assignment 1
    /// due 2015-02-13 
    /// </summary>
    /// <typeparam name="E">Element Type</typeparam>
    /// <typeparam name="V">Vertex Type</typeparam>
    class DirectedGraph<E,V> : UndirectedGraph<E,V>
    {
        /// <summary>
        /// Creates a new directed graph
        /// </summary>
        /// <returns>The new directed graph</returns>
        public static DirectedGraph<E, V> newdirectedgraph()
        {
            return new DirectedGraph<E, V>();
        }

        /// <summary>
        /// Creates and inserts a new directed edge
        /// </summary>
        /// <param name="v">Origin vertex</param>
        /// <param name="w">Destination vertex</param>
        /// <param name="x">Element value of edge</param>
        /// <returns>Updated graph</returns>
        public DirectedGraph<E,V> insertDirectedEdge(V v, V w, E x)
        {
            //insert directed edge
            insertSpecifiedEdge(v, w, x, true);
            return this;
        }

        /// <summary>
        /// Finds all incomings edges of a vertex
        /// </summary>
        /// <param name="v">Vertex to lookup</param>
        /// <returns>Set of all edges with V as the destination</returns>
        public HashSet<Edge<E, V>> incomingEdgesOf(V v)
        {
            return new HashSet<Edge<E, V>>(edges().Where(x => x.vertices[1].Equals(v) && x.directed));
        }

        /// <summary>
        /// Counts the number of incoming edges on a vertex
        /// </summary>
        /// <param name="v">Vertex to lookup</param>
        /// <returns>Number of incoming edges</returns>
        public int inDegreeOf(V v)
        {
            //find all directed edges with v as the destination
            return incomingEdgesOf(v).Count;
        }

        /// <summary>
        /// Counts the number of outgoing edges on a vertex
        /// </summary>
        /// <param name="v">Vertex to lookup</param>
        /// <returns>Number of outgoing edges</returns>
        public int outDegreeOf(V v)
        {
            return outgoingEdgesOf(v).Count;
        }

        /// <summary>
        /// Finds all outgoing edges of a vertex
        /// </summary>
        /// <param name="v">Vertex to lookup</param>
        /// <returns>Set of all edges with V as the origin</returns>
        public HashSet<Edge<E, V>> outgoingEdgesOf(V v)
        {
            //find all directed edges with v as the origin
            return new HashSet<Edge<E, V>>(edges().Where(x => x.vertices[0].Equals(v) && x.directed));
        }
    }
}
