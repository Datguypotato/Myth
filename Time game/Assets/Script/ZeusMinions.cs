using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

/*summary
 * this is part of the zeus mini-game
 * it is a navmeshagent that goes to different point on the ground
 * if it collides with the lightning sphere collider it will be destroyed
 * 
*/
public class ZeusMinions : MonoBehaviour
{
    NavMeshAgent agent;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent == null)
        {
            Debug.Log("THere is no navmeshagent on this object!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.destination == null || agent.remainingDistance < 1)
        {
            agent.destination = new Vector3(Random.Range(-15, 15), 1, Random.Range(-10, 10));
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lightning"))
        {
            Debug.Log("I fucking died");
        }
    }
}
