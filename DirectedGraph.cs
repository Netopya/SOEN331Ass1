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
    class DirectedGraph<E,V> : UndirectedGraph<E,V>
    {
        //private List<DirectedEdge<E,V>> set;
        
        public DirectedGraph()
        {
            //set = new List<DirectedEdge<E,V>>();
        }

        public static DirectedGraph<E, V> newdirectedgraph()
        {
            return new DirectedGraph<E, V>();
        }

        public DirectedGraph<E,V> insertDirectedEdge(V v, V w, E x)
        {
            //insertEdge(v, w, x);
            insertSpecifiedEdge(v, w, x, true);
            /*
            DirectedEdge<E, V> newNode = new DirectedEdge<E, V>(v, w, x);
            if (!set.Any(a => a.Equals(newNode)))
            {
                set.Add(newNode);
            }*/

            return this;
        }

        public HashSet<Edge<E, V>> incomingEdgesOf(V v)
        {
            return new HashSet<Edge<E, V>>(edges().Where(x => x.vertices[1].Equals(v) && x.directed));
        }

        public int inDegreeOf(V v)
        {
            return edges().Where(x => x.vertices[1].Equals(v) && x.directed).Count();
        }

        public int outDegreeOf(V v)
        {
            return edges().Where(x => x.vertices[0].Equals(v) && x.directed).Count();
        }

        public HashSet<Edge<E, V>> outgoingEdgesOf(V v)
        {
            return new HashSet<Edge<E, V>>(edges().Where(x => x.vertices[0].Equals(v) && x.directed));
        }
    }
}
