using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent Foe;

    public GameObject Player;

    public float EnemyDistance = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Foe = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        float rayDistance;
        Vector3 rayForward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, rayForward, Color.green);

        //Recognize Player(s):
        if(Physics.Raycast(transform.position,(rayForward), out hit))
        {
            if(hit.collider.gameObject.name == "EthanPrefab(Clone)")
            {
                Player = hit.collider.gameObject;
            }
        }

        float distance = Vector3.Distance(transform.position, Player.transform.position);

        // Follow player

        if(distance < EnemyDistance)
        {
            Vector3 directToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - directToPlayer;

            Foe.SetDestination(newPos);
        }
        else
        {
            transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }
    }
}
