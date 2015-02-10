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
    /// <typeparam name="E">Edge type</typeparam>
    /// <typeparam name="V">Vertex type</typeparam>
    class UndirectedGraph<E, V>
    {
        private List<UndirectedEdge<E,V>> edgeList;
        private HashSet<V> vertexList;

        public UndirectedGraph()
        {
            edgeList = new List<UndirectedEdge<E, V>>();
            vertexList = new HashSet<V>();
        }

        public static UndirectedGraph<E, V> newgraph() {
            return new UndirectedGraph<E,V>();
        }

        public HashSet<V> vertices()
        {
            return new HashSet<V>(vertexList);
        }

        public HashSet<E> edges()
        {
            return new HashSet<E>(edgeList.Select(x => x.element));
        }

        public int countAllVertices()
        {
            return vertexList.Count;
        }

        public int countAllEdges()
        {
            return edges().Count;
        }

        public UndirectedEdge<E, V> getEdge(V v, V w)
        {
            UndirectedEdge<E, V> edge = edgeList.FirstOrDefault(x => x.vertices.SetEquals(new HashSet<V> { v, w }));

            if (edge == null)
            {
                Console.WriteLine("Exception. No edge can be found connected by both vertices");
                return default(UndirectedEdge<E, V>);
            }

            return edge;
        }

        public HashSet<UndirectedEdge<E, V>> incidentEdges(V v)
        {
            return new HashSet<UndirectedEdge<E, V>>(edgeList.Where(x => x.vertices.Contains(v)));
        }

        public V opposite(V v,UndirectedEdge<E, V> e)
        {
            UndirectedEdge<E, V> edge = edgeList.FirstOrDefault(x => x.vertices.Contains(v) && x.Equals(e));
            if (edgeList == null)
            {
                Console.WriteLine("Exception. Specified edge is not connnected to specified vertex");
                return default(V);
            }

            return edge.vertices.FirstOrDefault(x => !x.Equals(v));
        }

        public HashSet<V> endVerticies(UndirectedEdge<E, V> e)
        {
            return new HashSet<V>(edgeList.FirstOrDefault(x => x.Equals(e)).vertices);
        }

        public bool areAdjacent(V v, V w)
        {
            return edgeList.Any(x => x.vertices.SetEquals(new List<V>() { v, w }));
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
            UndirectedEdge<E, V> newNode = new UndirectedEdge<E, V>(v, w, x);
            if (!edgeList.Any(a => a.Equals(newNode)))
            {
                edgeList.Add(newNode);
                vertexList.Add(v);
                vertexList.Add(w);
            }

            return this;
        }

        public UndirectedGraph<E, V> removeEdge(V v, V w)
        {
            edgeList.Remove(getEdge(v, w));
            return this;
        }

        public E getEdgeElem(UndirectedEdge<E, V> e)
        {
            return e.element;
        }

        public UndirectedGraph<E, V> replaceEdgeElem(UndirectedEdge<E, V> e, E x) 
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