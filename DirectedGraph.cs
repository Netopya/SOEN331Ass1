using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEN331Assignment1_2
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="E">Edge type</typeparam>
    /// <typeparam name="V">Vertex Type</typeparam>
    class DirectedGraph<E,V>
    {
        private List<Node<E,V>> set;

        private class Node<E, V>
        {
            public E edge;
            public V fromVertex;
            public V toVertex;

            public Node(V fromVertex, V toVertex, E edge)
            {
                this.edge = edge;
                this.fromVertex = fromVertex;
                this.toVertex = toVertex;
            }

            public override bool Equals(object obj)
            {
                var testObj = obj as Node<E,V>;
                if (testObj != null)
                {
                    return testObj.edge.Equals(edge) && testObj.fromVertex.Equals(fromVertex) && testObj.toVertex.Equals(toVertex);
                }
                return base.Equals(obj);
            }
        }

        public DirectedGraph()
        {
            set = new List<Node<E,V>>();
        }

        public DirectedGraph<E, V> newdirectedgraph()
        {
            return new DirectedGraph<E, V>();
        }

        public DirectedGraph<E,V> insertDirectedEdge(V v, V w, E x)
        {
            Node<E, V> newNode = new Node<E, V>(v, w, x);
            if (!set.Any(a => a.Equals(newNode)))
            {
                set.Add(newNode);
            }

            return this;
        }

        public HashSet<E> incomingEdgesOf(V v)
        {
            return new HashSet<E>(set.Where(x => x.toVertex.Equals(v)).Select(x => x.edge));
        }

        public int inDegreeOf(V v)
        {
            return set.Where(x => x.toVertex.Equals(v)).Count();
        }

        public int outDegreeOf(V v)
        {
            return set.Where(x => x.fromVertex.Equals(v)).Count();
        }

        public HashSet<E> outgoingEdgesOf(V v)
        {
            return new HashSet<E>(set.Where(x => x.fromVertex.Equals(v)).Select(x => x.edge));
        }
    }
}
