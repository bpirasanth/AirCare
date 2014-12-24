using AirCare.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirCare.Business
{
    class FindAllPaths<T>
    {
        private DirectedWeightedGraph<T> Graph;

        public FindAllPaths(DirectedWeightedGraph<T> graph)
        {
            if (graph == null)
            {
                throw new NullReferenceException("The input graph cannot be null.");
            }
            this.Graph = graph;
        }

        private void Validate(T source, T destination)
        {

            if (source == null)
            {
                throw new NullReferenceException("The source: " + source
                        + " cannot be  null.");
            }
            if (destination == null)
            {
                throw new NullReferenceException("The destination: " + destination
                        + " cannot be  null.");
            }
            if (source.Equals(destination))
            {
                throw new ArgumentException("The source and destination: "
                        + source + " cannot be the same.");
            }
        }

        public IList<List<T>> GetAllPaths(T source, T destination)
        {
            Validate(source, destination);

            IList<List<T>> paths = new List<List<T>>();
            Recursive(source, destination, paths, new HashSet<T>());
            return paths;
        }

        private void Recursive(T current, T destination, IList<List<T>> paths, HashSet<T> path)
        {
            path.Add(current);

            if (current.Equals(destination))
            {
                paths.Add(new List<T>(path));
                path.Remove(current);
                return;
            }

            Dictionary<T, Path>.KeyCollection edges = Graph.edgesFrom(current).Keys;

            foreach (T t in edges)
            {
                if (!path.Contains(t))
                {
                    Recursive(t, destination, paths, path);
                }
            }

            path.Remove(current);

        }
    }
}
