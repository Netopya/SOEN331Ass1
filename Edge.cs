using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEN331Assignment1_2
{
    class Edge<E,V>
    {
        public V[] vertices { get; private set; }
        public E element { get; set; }
        public readonly bool directed;


        public Edge(V v, V w, E x, bool directed)
        {
            vertices = new V[] {v,w};
            element = x;
            this.directed = directed;
        }

        public override bool Equals(object obj)
        {
            var testObj = obj as UndirectedEdge<E, V>;
            if (testObj != null)
            {
                return element.Equals(testObj.element);
                /*
                if (element.Equals(testObj.element))
                {
                    return true;
                }*/
                /*
                if (!directed)
                {
                    return !testObj.directed && vertices.Except(testObj.vertices).Any();
                }
                else
                {
                    return testObj.directed && vertices.SequenceEqual(testObj.vertices);
                }*/
                
                
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return element.GetHashCode();
        }

        public override String ToString()
        {
            return "{{" + string.Join(", ", vertices.Select(x => x).ToArray()) + "} " + element + "}";
        }
    }
}
