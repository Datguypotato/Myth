using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeusGameManager : MiniGame
{
    public GameObject MinionsPrefab;
    public int amountMinions;
    

    // Start is called before the first frame update
    void Start()
    {
        GetGm();

        for (int i = 0; i < amountMinions; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(-15, 15), 1, Random.Range(-10, 10));
            Instantiate(MinionsPrefab, randomPos, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameDone)
        {
            if(GameObject.FindObjectOfType<ZeusMinions>() == null)
            {
                if(gm!=null)
                    gm.DG(true);
                gameDone = true;
                Debug.Log("You won");
            }
            else if(timeTillEnd < Time.time)
            {
                if(gm!=null)
                    gm.DG(false);
                gameDone = true;
                Debug.Log("You lost");
            }
        }
    }


}
