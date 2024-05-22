using UnityEngine;
public class GraphController : MonoBehaviour
{
    public GameObject nodePrefab;
    public TextAsset nodePositionsTxt;
    public string[] arrayNodePositions;
    public string[] currentNodePositions;
    public SimplyLinkedList<GameObject> allNodes;

    public TextAsset nodeConnectionsTxt;
    public string[] arrayNodeConnections;
    public string[] currentNodeConnections;

    public EnemyControl enemy;

    void Start()
    {
        allNodes = new SimplyLinkedList<GameObject>();
        CreateNodes();
        CreateConnections();
        SelectInitialNode();
    }
    void CreateNodes()
    {
        if (nodePositionsTxt != null)
        {
            arrayNodePositions = nodePositionsTxt.text.Split('\n');
            for (int i = 0; i < arrayNodePositions.Length; i++)
            {
                currentNodePositions = arrayNodePositions[i].Split(",");
                Vector2 position = new Vector2(float.Parse(currentNodePositions[0]), float.Parse(currentNodePositions[1]));
                GameObject tmp = Instantiate(nodePrefab, position, transform.rotation);
                allNodes.InsertNodeAtEnd(tmp);
            }
        }
    }
    void CreateConnections()
    {
        if (nodeConnectionsTxt != null)
        {
            arrayNodeConnections = nodeConnectionsTxt.text.Split('\n');
            for (int i = 0; i < arrayNodeConnections.Length; i++)
            {
                currentNodeConnections = arrayNodeConnections[i].Split(",");
                for (int j = 0; j < currentNodeConnections.Length; j++)
                {
                    string[] connection = currentNodeConnections[j].Split(":");
                    int nodeIndex = int.Parse(connection[0]);
                    float weight = float.Parse(connection[1]);
                    GameObject currentNode = allNodes.GetValueAtPosition(i);
                    GameObject adjacentNode = allNodes.GetValueAtPosition(nodeIndex);
                    currentNode.GetComponent<NodeControl>().AddAdjacentNode(adjacentNode.GetComponent<NodeControl>(), weight);
                }
            }
        }
    }
    void SelectInitialNode()
    {
        int index = Random.Range(0, allNodes.Length);
        enemy.objective = allNodes.GetValueAtPosition(index);
    }

    void Update()
    {
    }
}