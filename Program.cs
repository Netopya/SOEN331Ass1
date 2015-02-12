using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOEN331Assignment1_2
{
    class Program
    {
        private class city
        {
            public string name;
                        
            public override string ToString()
            {
                return name;
            }
        }

        static void Main(string[] args)
        {
            UndirectedGraph<int, city> myGraph = UndirectedGraph<int, city>.newgraph();

            city lasalle = new city { name = "Lasalle" };
            city lachine = new city { name = "Lachine" };
            city verdun = new city { name = "Verdun" };
            city emard = new city { name = "Emard" };
            city bruno = new city { name = "Saint Bruno" };

            myGraph.insertVertex(bruno);
            myGraph.insertVertex(lasalle);

            Console.WriteLine("Verticies count: " + myGraph.countAllVertices());

            myGraph.insertEdge(lasalle, verdun, 100);
            myGraph.insertEdge(lachine, lasalle, 300);
            myGraph.insertEdge(lasalle, emard, 500);
            myGraph.insertEdge(emard, verdun, 100);
            myGraph.insertEdge(lachine, verdun, 600);
            myGraph.insertEdge(emard, lasalle, 500); //dup
            
            
            

            Console.WriteLine(string.Join(" ", myGraph.vertices().Select(x => x.name).ToArray()));
            //Console.WriteLine(string.Join(" ", myGraph.edges().ToArray()));
            Console.WriteLine("Vertices: " + myGraph.countAllVertices());
            Console.WriteLine("Edges: " + myGraph.countAllEdges());

            Console.WriteLine("Distance between Lasalle and Lachine: " + myGraph.getEdge(lasalle, lachine));
            Console.WriteLine("Distance between Emard and Lachine: " + myGraph.getEdge(emard, lachine));

            Console.WriteLine("Distances incident on Lasalle: " + string.Join(" ",myGraph.incidentEdges(lasalle)));

            Console.WriteLine("Opposite to lasalle at 100: " + myGraph.opposite(lasalle, myGraph.getEdge(lasalle, verdun)));
            Console.WriteLine("Opposite to lasalle at 700: " + myGraph.opposite(lasalle, myGraph.getEdge(lasalle, lachine)));

            Console.WriteLine("End vertices on 300: " + string.Join(" ", myGraph.endVerticies(myGraph.getEdge(lachine, lasalle))));

            Console.WriteLine("Are adjacent? lachine verdun? " + myGraph.areAdjacent(lachine, verdun));
            Console.WriteLine("Are adjacent? lachine verdun? " + myGraph.areAdjacent(emard, lachine));

            myGraph.removeEdge(lasalle, verdun);

            Console.WriteLine(string.Join(" ", myGraph.vertices().Select(x => x.name).ToArray()));
            //Console.WriteLine(string.Join(" ", myGraph.edges().ToArray()));

            if (myGraph.vertices().Any())
            {

            }

            //UndirectedGraph Axioms
            myGraph = UndirectedGraph<int, city>.newgraph(); //reset graph
            Console.WriteLine("\nUndirectedGraph Axioms --->");
            Console.WriteLine("1. New graph has no vertices: " + !myGraph.vertices().Any());
            Console.WriteLine("2. New graph has no edges: " + !myGraph.edges().Any());
            Console.WriteLine("3. Zero vertices in new graph: " + myGraph.countAllVertices());
            Console.WriteLine("4. Zero edges in new graph: " + myGraph.countAllEdges());
            myGraph.insertVertex(lasalle);
            myGraph.insertVertex(lachine);
            Console.WriteLine("5. Adding two different vertices: " + myGraph.countAllVertices());
            myGraph = UndirectedGraph<int, city>.newgraph(); //reset graph
            myGraph.insertVertex(lasalle);
            myGraph.insertVertex(lasalle);
            Console.WriteLine("6. Adding two same vertices: " + myGraph.countAllVertices());
            myGraph = UndirectedGraph<int, city>.newgraph(); //reset graph
            myGraph.insertVertex(lasalle);
            myGraph.removeVertex(lasalle);
            Console.WriteLine("7. Adding and removing a vertex: " + myGraph.countAllVertices());    //NO
            myGraph = UndirectedGraph<int, city>.newgraph(); //reset graph
            myGraph.insertEdge(lasalle, verdun, 100);
            myGraph.removeEdge(lasalle, verdun);
            Console.WriteLine("8. Adding and removing an edge: " + myGraph.countAllEdges());
            myGraph = UndirectedGraph<int, city>.newgraph(); //reset graph
            myGraph.insertEdge(lasalle, verdun, 100);
            Console.WriteLine("9. Adjacent when directly connected: " + myGraph.areAdjacent(lasalle, verdun));
            myGraph = UndirectedGraph<int, city>.newgraph(); //reset graph
            myGraph.insertEdge(lasalle, verdun, 100);
            myGraph.insertEdge(lasalle, emard, 200);
            Console.WriteLine("10. IncidentEdges on Lasalle: {" + string.Join(", ", myGraph.incidentEdges(lasalle).Select(x => x)) + "}");    //NO
            myGraph = UndirectedGraph<int, city>.newgraph(); //reset graph
            myGraph.insertEdge(lasalle, verdun, 100);
            myGraph.insertEdge(lasalle, emard, 200);
            Console.WriteLine("11. Opposite vertex of Verdun: " + myGraph.opposite(verdun,myGraph.getEdge(lasalle,verdun)));    //SHOULD NOT BE THE ELEMENT 100, BUT THE ACTUAL EDGE
            Console.WriteLine("12. EndVertices: {" + string.Join(", ", myGraph.endVerticies(myGraph.getEdge(lasalle,verdun)).Select(x => x)) + "}");
            Console.WriteLine("13. GetEdgeElem: " + myGraph.getEdgeElem(myGraph.getEdge(lasalle, verdun)));
            myGraph.replaceEdgeElem(myGraph.getEdge(lasalle, verdun), 300);
            Console.WriteLine("14. ReplaceEdgeElem from 100 to 300: " + myGraph.getEdgeElem(myGraph.getEdge(lasalle, verdun)));

            //DirectedGraph Axioms
            DirectedGraph<int,city> myGraph2 = DirectedGraph<int,city>.newdirectedgraph();
            Console.WriteLine("\nDirectedGraph Axioms --->");
            Console.WriteLine("1. New directed graph has no vertices: " + !myGraph2.vertices().Any());
            Console.WriteLine("2. New directed graph has no edges: " + !myGraph2.edges().Any());
            Console.WriteLine("3. Zero vertices in new graph: " + myGraph2.countAllVertices());
            Console.WriteLine("4. Zero edges in new graph: " + myGraph2.countAllEdges());
            city beloeil = new city { name = "beloeil" };
            city hilaire = new city { name = "hilaire" };
            myGraph2.insertDirectedEdge(beloeil, hilaire, 23);
            Console.WriteLine("5. Incoming edges: " + string.Join(", ", myGraph2.incomingEdgesOf(hilaire).Select(x => x)));
            Console.WriteLine("6. Indegree is 1: " + myGraph2.inDegreeOf(hilaire));
            Console.WriteLine("7. Outdegree is 1: " + myGraph2.outDegreeOf(beloeil));
            Console.WriteLine("8. Outgoing edges: " + string.Join(", ", myGraph2.outgoingEdgesOf(beloeil).Select(x => x)));
            city hyacinthe = new city { name = "hyacinthe" };
            myGraph2.insertDirectedEdge(hyacinthe, hilaire, 23);
            Console.WriteLine("9.Indegree is 2: " + myGraph2.inDegreeOf(hilaire));
            Console.WriteLine("9.Outdegree is 2: " + myGraph2.outDegreeOf(beloeil));

            Console.Read();
        }
    }
}
