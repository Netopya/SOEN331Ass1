﻿using System;
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
            Console.WriteLine(string.Join(" ", myGraph.edges().ToArray()));
            Console.WriteLine("Vertices: " + myGraph.countAllVertices());
            Console.WriteLine("Edges: " + myGraph.countAllEdges());

            Console.WriteLine("Distance between Lasalle and Lachine: " + myGraph.getEdge(lasalle, lachine));
            Console.WriteLine("Distance between Emard and Lachine: " + myGraph.getEdge(emard, lachine));

            Console.WriteLine("Distances incident on Lasalle: " + string.Join(" ",myGraph.incidentEdges(lasalle).ToArray()));

            Console.WriteLine("Opposite to lasalle at 100: " + myGraph.opposite(lasalle, 100));
            Console.WriteLine("Opposite to lasalle at 700: " + myGraph.opposite(lasalle, 700));

            Console.WriteLine("End vertices on 300: " + string.Join(" ",myGraph.endVerticies(300)));

            Console.WriteLine("Are adjacent? lachine verdun? " + myGraph.areAdjacent(lachine, verdun));
            Console.WriteLine("Are adjacent? lachine verdun? " + myGraph.areAdjacent(emard, lachine));

            myGraph.removeEdge(100);

            Console.WriteLine(string.Join(" ", myGraph.vertices().Select(x => x.name).ToArray()));
            Console.WriteLine(string.Join(" ", myGraph.edges().ToArray()));

            if (myGraph.vertices().Any())
            {

            }
            Console.Read();
        }
    }
}