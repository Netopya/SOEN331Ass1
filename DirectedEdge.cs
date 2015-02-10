using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEN331Assignment1_2
{
    class DirectedEdge<E,V>
    {
        public E edge;
        public V fromVertex;
        public V toVertex;

        public DirectedEdge(V fromVertex, V toVertex, E edge)
        {
            this.edge = edge;
            this.fromVertex = fromVertex;
            this.toVertex = toVertex;
        }

        public override bool Equals(object obj)
        {
            var testObj = obj as DirectedEdge<E, V>;
            if (testObj != null)
            {
                return testObj.edge.Equals(edge) && testObj.fromVertex.Equals(fromVertex) && testObj.toVertex.Equals(toVertex);
            }
            return base.Equals(obj);
        }
    }
}
