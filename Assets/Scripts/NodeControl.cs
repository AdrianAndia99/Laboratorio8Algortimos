using UnityEngine;
using static AdyacentNode;

public class NodeControl : MonoBehaviour
{
    public SimplyLinkedList<AdjacentNode> adjacentNodes;

    void Start()
    {
        adjacentNodes = new SimplyLinkedList<AdjacentNode>();
    }

    public void AddAdjacentNode(NodeControl node, float weight)
    {
        AdjacentNode adjacentNode = new AdjacentNode(node, weight);
        adjacentNodes.InsertNodeAtEnd(adjacentNode);
    }

    public AdjacentNode GetRandomAdjacentNode()
    {
        int index = Random.Range(0, adjacentNodes.Length);
        SimplyLinkedList<AdjacentNode>.Node node = adjacentNodes.GetNodeAtPosition(index);
        return node.Value;
    }
}