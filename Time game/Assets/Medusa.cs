using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Medusa : MonoBehaviour
{
    [Header("Players")]
    public float t;
    public float desiredY;

    [Header("Medusa")]
    public GameObject medusaGo;
    public float lookatTime;

    float playerlookatTime;
    bool medusaLooking;

    public Text tapText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        #region player
        //putting hands up
        if (Input.GetKey(KeyCode.Space))
        {
            t += Time.deltaTime * 15;
        }
        else
        {
            t -= Time.deltaTime * 15;
        }



        t = Mathf.Clamp(t, 0, 1);
        desiredY = Mathf.Lerp(0.7f, 1.2f, t);
        transform.position = new Vector3(transform.position.x, desiredY, -9);
        #endregion

        #region medusa
        if (lookatTime < Time.time)
        {
            lookatTime = Random.Range(2, 6) + Time.time;
            playerlookatTime = lookatTime - 1;
            StartCoroutine(BlinkRed());
            Debug.Log("LookatTime is smaller than time");
        }
        #endregion

        if(playerlookatTime < Time.time)
        {
            tapText.text = "Press space!";
        }
        else
        {
            tapText.text = "";
        }
    }

    IEnumerator BlinkRed()
    {
        medusaLooking = true;
        Renderer rend = medusaGo.GetComponent<Renderer>();
        rend.material.color = Color.red;
        yield return new WaitForSeconds(1);
        rend.material.color = Color.green;
        medusaLooking = false;
    }
}
