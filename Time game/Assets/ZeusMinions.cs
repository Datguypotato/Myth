using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ZeusMinions : MonoBehaviour
{
    NavMeshAgent agent;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.destination == null || agent.remainingDistance < 1)
        {
            agent.destination = new Vector3(Random.Range(-20, 20), 1, Random.Range(-10, 10));
        }
      
    }
}
