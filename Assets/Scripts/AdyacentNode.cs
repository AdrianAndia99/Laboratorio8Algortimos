using System.Collections;
using UnityEngine;

public class AdyacentNode : MonoBehaviour
{
    public struct AdjacentNode
    {
        public NodeControl Node;
        public float Weight;

        public AdjacentNode(NodeControl node, float weight)
        {
            Node = node;
            Weight = weight;
        }
    }
}