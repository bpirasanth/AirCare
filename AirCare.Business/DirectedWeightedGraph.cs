using AirCare.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCare.Business
{
    public class DirectedWeightedGraph<T> : IEnumerable<T>
    {
        /// <summary>
        /// A map from nodes in the graph to sets of outgoing edges. Each set of
        /// edges is represented by a map from edges to doubles.
        /// </summary>
        private IDictionary<T, Dictionary<T, Path>> graph = new Dictionary<T, Dictionary<T, Path>>();

        /// <summary>
        /// Adds a new node to the graph. If the node already exists then its a
        /// no-op.
        /// </summary>
        /// <param name="node">Adds to a graph. If node is null then this is a no-op.</param>
        /// <returns>true if node is added, false otherwise.</returns>
        public bool addNode(T node)
        {
            if (node == null)
            {
                throw new NullReferenceException("The input node cannot be null.");
            }
            if (graph.ContainsKey(node))
                return false;

            graph.Add(node, new Dictionary<T, Path>());
            return true;
        }


        /// <summary>
        /// Given the source and destination node it would add an arc from source to
        /// destination node. If an arc already exists then the value would be
        ///updated the new value.
        /// </summary>
        /// <param name="source">the source node.</param>
        /// <param name="destination">the destination node.</param>
        /// <param name="length">if length if</param>
        
        public void addEdge(T source, T destination, Path length)
        {
            if (source == null || destination == null)
            {
                throw new NullReferenceException(
                        "Source and Destination, both should be non-null.");
            }
            if (!graph.ContainsKey(source) || !graph.ContainsKey(destination))
            {
                throw new InvalidOperationException(
                        "Source and Destination, both should be part of graph");
            }
            /* A node would always be added so no point returning true or false */
            graph[source].Add(destination, length);
        }

        /// <summary>
        /// Removes an edge from the graph.
        /// </summary>
        /// <param name="source">If the source node.</param>
        /// <param name="destination">If the destination node.</param>
        public void removeEdge(T source, T destination)
        {
            if (source == null || destination == null)
            {
                throw new NullReferenceException(
                        "Source and Destination, both should be non-null.");
            }
            if (!graph.ContainsKey(source) || !graph.ContainsKey(destination))
            {
                throw new InvalidOperationException(
                        "Source and Destination, both should be part of graph");
            }
            graph[source].Remove(destination);
        }


        /// <summary>
        /// Given a node, returns the edges going outward that node, as an immutable map
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public Dictionary<T, Path> edgesFrom(T node)
        {
            if (node == null)
            {
                throw new NullReferenceException("The node should not be null.");
            }
            Dictionary<T, Path> edges = graph[node];
            if (edges == null)
            {
                throw new InvalidOperationException("Source node does not exist.");
            }
            return edges;
        }



        public IEnumerator<T> GetEnumerator()
        {
            return graph.Keys.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
