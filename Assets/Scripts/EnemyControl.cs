using System.Collections;
using UnityEngine;
using static AdyacentNode;

public class EnemyControl : MonoBehaviour
{
    public GameObject objective;
    public Vector2 speedReference;
    public float energy = 100f;
    public float restDuration = 2f;
    public float energyRecoveryRate = 50f;
    private bool isResting = false;

    void Update()
    {
        if (!isResting)
        {
            transform.position = Vector2.SmoothDamp(transform.position, objective.transform.position, ref speedReference, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node" && !isResting)
        {
            NodeControl nodeControl = collision.gameObject.GetComponent<NodeControl>();
            if (nodeControl != null)
            {
                AdjacentNode adjacentNode = nodeControl.GetRandomAdjacentNode();
                objective = adjacentNode.Node.gameObject;
                energy -= adjacentNode.Weight;

                if (energy <= 0)
                {
                    StartCoroutine(Rest());
                }
            }
        }
    }
    private IEnumerator Rest()
    {
        isResting = true;
        float restTime = 0f;

        while (restTime < restDuration)
        {
            energy += energyRecoveryRate * Time.deltaTime;
            restTime += Time.deltaTime;
            yield return null;
        }

        energy = Mathf.Min(energy, 100f);
        isResting = false;
    }
}