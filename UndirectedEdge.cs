using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEN331Assignment1_2
{
    class UndirectedEdge<E,V>
    {
        public HashSet<V> vertices { get; private set; }
        public E element { get; set; }

        /// <summary>
        /// Constructor to create an edge
        /// </summary>
        /// <param name="v">First vertex</param>
        /// <param name="w">Second vertex</param>
        /// <param name="x">Edge</param>
        public UndirectedEdge(V v, V w, E x)
        {
            vertices = new HashSet<V> { v, w };
            element = x;
        }

        public override bool Equals(object obj)
        {
            var testObj = obj as UndirectedEdge<E, V>;
            if (testObj != null)
            {
                //equal if verticies are the same or edge values are duplicated
                return vertices.SetEquals(testObj.vertices) || element.Equals(testObj.element);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override String ToString()
        {
            return "{{" + string.Join(", ", vertices.Select(x => x).ToArray()) + "} " + element + "}";
        }
    }
}
