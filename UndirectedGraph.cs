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
            edgeList = new List<Edge<E, V>>();
            vertexList = new HashSet<V>();
        }

        public static UndirectedGraph<E, V> newgraph() {
            return new UndirectedGraph<E,V>();
        }

        public HashSet<V> vertices()
        {
            return new HashSet<V>(vertexList);
        }

        public HashSet<Edge<E,V>> edges()
        {
            return new HashSet<Edge<E, V>>(edgeList);
        }

        public int countAllVertices()
        {
            return vertexList.Count;
        }

        public int countAllEdges()
        {
            return edges().Count;
        }

        public Edge<E, V> getEdge(V v, V w)
        {
            Edge<E, V> edge = edgeList.FirstOrDefault(x => x.vertices.Except(new HashSet<V> { v, w }).Any());

            if (edge == null)
            {
                Console.WriteLine("Exception. No edge can be found connected by both vertices");
                return default(Edge<E, V>);
            }

            return edge;
        }

        public HashSet<Edge<E, V>> incidentEdges(V v)
        {
            return new HashSet<Edge<E, V>>(edgeList.Where(x => x.vertices.Contains(v)));
        }

        public V opposite(V v,Edge<E, V> e)
        {
            Edge<E, V> edge = edgeList.FirstOrDefault(x => x.vertices.Contains(v) && x.Equals(e));
            if (edge == null)
            {
                Console.WriteLine("Exception. Specified edge is not connnected to specified vertex");
                return default(V);
            }

            return edge.vertices.FirstOrDefault(x => !x.Equals(v));
        }

        public HashSet<V> endVerticies(Edge<E, V> e)
        {
            return new HashSet<V>(edgeList.FirstOrDefault(x => x.Equals(e)).vertices);
        }

        public bool areAdjacent(V v, V w)
        {
            return edgeList.Any(x => x.vertices.Except(new List<V>() { v, w }).Any());
        }

        public UndirectedGraph<E,V> insertVertex(V v)
        {
            vertexList.Add(v);
            return this;
        }

        public UndirectedGraph<E, V> removeVertex(V v)
        {
            edgeList.RemoveAll(x => x.vertices.Contains(v));
            vertexList.Remove(v);

            return this;
        }

        public UndirectedGraph<E, V> insertEdge(V v, V w, E x)
        {
            insertSpecifiedEdge(v, w, x, false);

            return this;
        }

        protected void insertSpecifiedEdge(V v, V w, E x, bool directed)
        {
            Edge<E, V> newNode = new Edge<E, V>(v, w, x, directed);
            if (!edgeList.Any(a => a.Equals(newNode)))
            {
                edgeList.Add(newNode);
                vertexList.Add(v);
                vertexList.Add(w);
            }
        }

        public UndirectedGraph<E, V> removeEdge(V v, V w)
        {
            edgeList.Remove(getEdge(v, w));
            return this;
        }

        public E getEdgeElem(Edge<E, V> e)
        {
            return e.element;
        }

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

        
    }
}