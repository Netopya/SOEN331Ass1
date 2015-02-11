using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEN331Assignment1_2
{
    /// <summary>
    /// Undirected Graph ADT
    /// By:
    ///     Michael Bilinsky 26992358
    ///     David Bastien
    /// 
    /// SOEN 331 Assignment 1
    /// due 2015-02-13 
    /// </summary>
    /// <typeparam name="E">Element type</typeparam>
    /// <typeparam name="V">Vertex type</typeparam>
    class UndirectedGraph<E, V>
    {
        private List<Edge<E,V>> edgeList;
        private HashSet<V> vertexList;

        public UndirectedGraph()
        {
            //contructor initializes lists
            edgeList = new List<Edge<E, V>>();
            vertexList = new HashSet<V>();
        }

        /// <summary>
        /// Method to create a new undirected graph
        /// </summary>
        /// <returns>New graph</returns>
        public static UndirectedGraph<E, V> newgraph() {
            return new UndirectedGraph<E,V>();
        }

        /// <summary>
        /// Returns a set of all vertices in the graph
        /// </summary>
        /// <returns>Set of all vertices</returns>
        public HashSet<V> vertices()
        {
            return new HashSet<V>(vertexList);
        }

        /// <summary>
        /// Returns a set of all edges in the graph
        /// </summary>
        /// <returns>Set of all edges</returns>
        public HashSet<Edge<E,V>> edges()
        {
            return new HashSet<Edge<E, V>>(edgeList);
        }

        /// <summary>
        /// Counts vertices in the graph
        /// </summary>
        /// <returns>The number of vertices in the graph</returns>
        public int countAllVertices()
        {
            return vertexList.Count;
        }

        /// <summary>
        /// Counts edges in the graph
        /// </summary>
        /// <returns>The number of edges in the graph</returns>
        public int countAllEdges()
        {
            return edges().Count;
        }

        /// <summary>
        /// Gets the edge located between two verticies. Prints an exception if no edge connected between
        /// both verticies
        /// </summary>
        /// <param name="v">Vertex 1</param>
        /// <param name="w">Vertex 2</param>
        /// <returns>Edge between vertex 1 and 2, null if no edge found</returns>
        public Edge<E, V> getEdge(V v, V w)
        {
            HashSet<V> lookupVerticies = new HashSet<V> { v, w };
            Edge<E, V> edge = edgeList.FirstOrDefault(x => x.vertices.Except(lookupVerticies).Any());

            if (edge == null)
            {
                Console.WriteLine("Exception. No edge can be found connected by both verticies");
                return null;
            }

            return edge;
        }

        /// <summary>
        /// Gets all edges connected by a vertex
        /// </summary>
        /// <param name="v">Vertex connected to edges</param>
        /// <returns>Set of all edges connected by v</returns>
        public HashSet<Edge<E, V>> incidentEdges(V v)
        {
            return new HashSet<Edge<E, V>>(edgeList.Where(x => x.vertices.Contains(v)));
        }

        /// <summary>
        /// Gets the vertex on the opposite side of an edge from the specified vertex
        /// </summary>
        /// <param name="v">Vertex</param>
        /// <param name="e">Edge</param>
        /// <returns>Vertex connected to edge from specified vertex, default of V if no vertex found</returns>
        public V opposite(V v,Edge<E, V> e)
        {
            Edge<E, V> edge = edgeList.FirstOrDefault(x => x.vertices.Contains(v) && x.Equals(e));
            if (edge == null)
            {
                Console.WriteLine("Exception. Specified edge is not connnected to specified vertex");
                return default(V);
            }

            //vertex that is not the one specified (the opposite one)
            return edge.vertices.FirstOrDefault(x => !x.Equals(v));
        }

        /// <summary>
        /// Finds vertices connected to an edge
        /// </summary>
        /// <param name="e">Edge to lookup</param>
        /// <returns>Set of verticies connected to edge e</returns>
        public HashSet<V> endVerticies(Edge<E, V> e)
        {
            return new HashSet<V>(edgeList.FirstOrDefault(x => x.Equals(e)).vertices);
        }

        /// <summary>
        /// Determines if two verticies are connected by an edge
        /// </summary>
        /// <param name="v">vertex 1</param>
        /// <param name="w">vertex 2</param>
        /// <returns>Whether vertex 1 and 2 are adjecent</returns>
        public bool areAdjacent(V v, V w)
        {
            //check if the the difference of two sets of vertices contains any elements
            HashSet<V> verticiesQuery = new HashSet<V> { v, w };
            return edgeList.Any(x => x.vertices.Except(verticiesQuery).Any());
        }

        /// <summary>
        /// Inserts a vertex into the graph
        /// </summary>
        /// <param name="v">New vertex to insert</param>
        /// <returns>Updated graph</returns>
        public UndirectedGraph<E,V> insertVertex(V v)
        {
            vertexList.Add(v);
            return this;
        }

        /// <summary>
        /// Removes vertex from the graph allong with all connected edges
        /// </summary>
        /// <param name="v">Vertex to remove</param>
        /// <returns>Updated graph</returns>
        public UndirectedGraph<E, V> removeVertex(V v)
        {
            //Remove all edges connected to vertex
            edgeList.RemoveAll(x => x.vertices.Contains(v));
            vertexList.Remove(v);

            return this;
        }

        /// <summary>
        /// Create and insert new edge with an element between two verticies
        /// </summary>
        /// <param name="v">Vertex 1</param>
        /// <param name="w">Vertex 2</param>
        /// <param name="x">Value Element of the edge</param>
        /// <returns>Updated graph</returns>
        public UndirectedGraph<E, V> insertEdge(V v, V w, E x)
        {
            //insert an undirected edge
            insertSpecifiedEdge(v, w, x, false);

            return this;
        }
        
        /// <summary>
        /// Removes the edge between two verticies
        /// </summary>
        /// <param name="v">Vertex 1</param>
        /// <param name="w">Vertex 2</param>
        /// <returns>Updated graph</returns>
        public UndirectedGraph<E, V> removeEdge(V v, V w)
        {
            edgeList.Remove(getEdge(v, w));
            return this;
        }

        /// <summary>
        /// Gets the element of an edge
        /// </summary>
        /// <param name="e">Edge to lookup</param>
        /// <returns>Element value of edge</returns>
        public E getEdgeElem(Edge<E, V> e)
        {
            return e.element;
        }

        /// <summary>
        /// Replaces the element of an edge with a new element
        /// </summary>
        /// <param name="e">Edge with old element</param>
        /// <param name="x">New element</param>
        /// <returns>Updated graph</returns>
        public UndirectedGraph<E, V> replaceEdgeElem(Edge<E, V> e, E x) 
        {
            if (!edgeList.Any(y => y.element.Equals(x)))
            {
                e.element = x;
            }
            else
            {
                edgeList.Remove(e);
            }
            
            return this;
        }

        /// <summary>
        /// Helper method to create and insert a new edge while specifying whether it is directed
        /// or undirected
        /// </summary>
        /// <param name="v">Vertex 1 (origin)</param>
        /// <param name="w">Vertex 2 (destination)</param>
        /// <param name="x">Element value of edge</param>
        /// <param name="directed">Directed or not</param>
        protected void insertSpecifiedEdge(V v, V w, E x, bool directed)
        {
            Edge<E, V> newNode = new Edge<E, V>(v, w, x, directed);
            //no duplicate edges allowed
            if (!edgeList.Any(a => a.Equals(newNode)))
            {
                edgeList.Add(newNode);
                vertexList.Add(v);
                vertexList.Add(w);
            }
        }
    }
}