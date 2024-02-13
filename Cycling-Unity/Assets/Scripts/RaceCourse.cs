using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Cycling.Game
{
    public class RaceCourse
    {
        public List<List<Vector2>> Lanes = new List<List<Vector2>>();

        public RaceCourse(List<Vector2> nodes, int numLanes)
        {
            CreateFirstLane(nodes);
            CreateRemainingLanes(nodes, numLanes);
        }
        
        private void CreateRemainingLanes(List<Vector2> nodes, int numLanes)
        {
            for (int j = 1; j < numLanes; j++)
            {
                var lane = new List<Vector2>();
                
                for (int i = 0; i < nodes.Count; i++)
                {
                    var node = nodes[i];
                    var nextNode = nodes[i + 1];
                    var direction = nextNode - node;
                    var perpendicular = new Vector2(-direction.Y, direction.X);
                    perpendicular = Vector2.Normalize(perpendicular);
                    lane.Add(node + perpendicular * j);
                }
                Lanes.Add(lane);
            }
        }

        private void CreateFirstLane(List<Vector2> nodes)
        {
            Lanes.Add(new List<Vector2>());
            foreach (var node in nodes)
            {
                Lanes[0].Add(node);
            }
        }
    }
}