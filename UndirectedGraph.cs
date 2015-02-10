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
        private List<Node<E,V>> set;
        private HashSet<V> verticesList;

        /// <summary>
        /// Helper class to represent two verticies connected with an edge
        /// </summary>
        /// <typeparam name="E">Edge type</typeparam>
        /// <typeparam name="V">Vertex type</typeparam>
        private class Node<E, V>
        {
            public HashSet<V> vertices { get; private set; }
            public E edge { get; set; }

            /// <summary>
            /// Constructor to create a node
            /// </summary>
            /// <param name="v">First vertex</param>
            /// <param name="w">Second vertex</param>
            /// <param name="x">Edge</param>
            public Node(V v, V w, E x)
            {
                vertices = new HashSet<V> { v, w };
                edge = x;
            }

            public override bool Equals(object obj)
            {
                var testObj = obj as Node<E,V>;
                if (testObj != null)
                {
                    //equal if verticies are the same or edge values are duplicated
                    return vertices.SetEquals(testObj.vertices) || edge.Equals(testObj.edge);
                }
                else
                {
                    return base.Equals(obj);
                }
            }
        }

        public UndirectedGraph()
        {
            set = new List<Node<E,V>>();
            verticesList = new HashSet<V>();
        }

        public static UndirectedGraph<E, V> newgraph() {
            return new UndirectedGraph<E,V>();
        }

        public HashSet<V> vertices()
        {
            return new HashSet<V>(verticesList);
        }

        public HashSet<E> edges()
        {
            return new HashSet<E>(set.Select(x => x.edge));
        }

        public int countAllVertices()
        {
            return verticesList.Count;
        }

        public int countAllEdges()
        {
            return edges().Count;
        }
        
        public E getEdge(V v, V w)
        {
            Node<E,V> edge = set.FirstOrDefault(x => x.vertices.SetEquals(new HashSet<V> {v,w}));

            if (edge == null)
            {
                Console.WriteLine("Exception. No edge can be found connected by both vertices");
                return default(E);
            }

            return edge.edge;
        }

        public HashSet<E> incidentEdges(V v)
        {
            return new HashSet<E>(set.Where(x => x.vertices.Contains(v)).Select(x => x.edge));
        }

        public V opposite(V v, E e)
        {
            Node<E, V> node = set.FirstOrDefault(x => x.vertices.Contains(v) && x.edge.Equals(e));
            if (node == null)
            {
                Console.WriteLine("Exception. Specified edge is not connnected to specified vertex");
                return default(V);
            }

            return node.vertices.FirstOrDefault(x => !x.Equals(v));
        }

        public HashSet<V> endVerticies(E e)
        {
            return new HashSet<V>(set.FirstOrDefault(x => x.edge.Equals(e)).vertices);
        }

        public bool areAdjacent(V v, V w)
        {
            return set.Any(x => x.vertices.SetEquals(new List<V>() { v, w }));
        }

        public UndirectedGraph<E,V> insertVertex(V v)
        {
            verticesList.Add(v);
            return this;
        }

        public UndirectedGraph<E, V> removeVertex(V v)
        {
            HashSet<V> orphans = new HashSet<V>(set.Where(x => x.vertices.Contains(v)).SelectMany(x => x.vertices));
            orphans.Remove(v);
            set.RemoveAll(x => x.vertices.Contains(v));
            HashSet<V> vertices = this.vertices();
            orphans = new HashSet<V>(orphans.Except(vertices));

            foreach (V orphan in orphans)
            {
                verticesList.Add(orphan);
            }

            return this;
        }

        public UndirectedGraph<E, V> insertEdge(V v, V w, E x)
        {
            Node<E, V> newNode = new Node<E, V>(v, w, x);
            if (!set.Any(a => a.Equals(newNode)))
            {
                set.Add(newNode);
                verticesList.Add(v);
                verticesList.Add(w);
            }

            return this;
        }

        public UndirectedGraph<E, V> removeEdge(E e)
        {
            HashSet<V> orphans = new HashSet<V>(set.Where(x => x.edge.Equals(e)).SelectMany(x => x.vertices));
            set.RemoveAll(x => x.edge.Equals(e));
            HashSet<V> vertices = this.vertices();
            orphans = new HashSet<V>(orphans.Except(vertices));

            foreach (V orphan in orphans)
            {
                verticesList.Add(orphan);
            }

            return this;
        }        

        public E getEdgeElem(E e)
        {
            return set.FirstOrDefault(x => x.edge.Equals(e)).edge;
        }

        public UndirectedGraph<E, V> replaceEdgeElem(E e, E x) 
        {
            set.First(y => y.edge.Equals(e)).edge = x;
            return this;
        }

    }
}