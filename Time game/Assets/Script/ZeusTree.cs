using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeusTree : MonoBehaviour
{

    public Material matBlack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lightning"))
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material = matBlack;
            Debug.Log("Lightning connected");
        }
    }
}
