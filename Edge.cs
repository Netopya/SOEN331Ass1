using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEN331Assignment1_2
{
    /// <summary>
    /// Edge containing an element connected by two verticies
    /// 
    /// By:
    ///     Michael Bilinsky 26992358
    ///     David Bastien
    /// 
    /// SOEN 331 Assignment 1
    /// due 2015-02-13 
    /// </summary>
    /// <typeparam name="E">Element type</typeparam>
    /// <typeparam name="V">Vertex type</typeparam>
    class Edge<E,V>
    {
        public V[] vertices { get; private set; }
        public E element { get; set; }
        public readonly bool directed;

        /// <summary>
        /// Edge constructor, order of verticies is important when directed it true
        /// </summary>
        /// <param name="v">Vertex 1 (origin)</param>
        /// <param name="w">Vertex 2 (destination)</param>
        /// <param name="x">Element value of the edge</param>
        /// <param name="directed">Whether the edge is directed or not</param>
        public Edge(V v, V w, E x, bool directed)
        {
            vertices = new V[] {v,w};
            element = x;
            this.directed = directed;
        }

        /// <summary>
        /// Edges are equal if their element values are equal
        /// </summary>
        /// <param name="obj">Object to test</param>
        /// <returns>Whether the object is equal to this</returns>
        public override bool Equals(object obj)
        {
            var testObj = obj as UndirectedEdge<E, V>;
            if (testObj != null)
            {
                return element.Equals(testObj.element);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        /// <summary>
        /// Equality is defined based on element value
        /// </summary>
        /// <returns>Edge's hashcode</returns>
        public override int GetHashCode()
        {
            return element.GetHashCode();
        }

        /// <summary>
        /// Converts and edge to a string representation
        /// </summary>
        /// <returns>String showing contents of the edge</returns>
        public override String ToString()
        {
            return "{{" + string.Join(", ", vertices.Select(x => x).ToArray()) + "} " + element + "}";
        }
    }
}
