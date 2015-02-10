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
        private List<DirectedEdge<E,V>> set;
        
        public DirectedGraph()
        {
            set = new List<DirectedEdge<E,V>>();
        }

        public static DirectedGraph<E, V> newdirectedgraph()
        {
            return new DirectedGraph<E, V>();
        }

        public DirectedGraph<E,V> insertDirectedEdge(V v, V w, E x)
        {
            DirectedEdge<E, V> newNode = new DirectedEdge<E, V>(v, w, x);
            if (!set.Any(a => a.Equals(newNode)))
            {
                set.Add(newNode);
            }

            return this;
        }

        public HashSet<DirectedEdge<E, V>> incomingEdgesOf(V v)
        {
            return new HashSet<DirectedEdge<E, V>>(set.Where(x => x.toVertex.Equals(v)));
        }

        public int inDegreeOf(V v)
        {
            return set.Where(x => x.toVertex.Equals(v)).Count();
        }

        public int outDegreeOf(V v)
        {
            return set.Where(x => x.fromVertex.Equals(v)).Count();
        }

        public HashSet<DirectedEdge<E, V>> outgoingEdgesOf(V v)
        {
            return new HashSet<DirectedEdge<E, V>>(set.Where(x => x.fromVertex.Equals(v)));
        }
    }
}
