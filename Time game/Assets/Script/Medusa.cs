﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/* summary
 * this is the scripts take care of everything from medusa related
 */
public class Medusa : MiniGame
{
    [Header("Players")]
    public float t;
    public float desiredY;
    public Material stoneMat;
    public MeshRenderer[] hands;

    [Header("Medusa")]
    public GameObject medusaGo;
    Animator medusaAnim;
    public float lookatTime;

    public AudioSource medusaFx;
    public AudioClip turnToStone;

    float playerlookatTime;
    public bool medusaLooking;

    public Text tapText;

    float lerpMultiply = 15;

    // Start is called before the first frame update
    void Start()
    {
        //GetGm();

        lookatTime = Random.Range(2, 6) + Time.time;
        playerlookatTime = lookatTime - 1;
        medusaAnim = medusaGo.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameDone)
        {
#if UNITY_EDITOR
            //putting hands up
            #region player

            if (Input.GetKey(KeyCode.Space))
            {
                t += Time.deltaTime * lerpMultiply;
            }
            else
            {
                t -= Time.deltaTime * lerpMultiply;
            }

            t = Mathf.Clamp(t, 0, 1);
            desiredY = Mathf.Lerp(0.7f, 2, t);
            transform.position = new Vector3(transform.position.x, desiredY, -9);
            #endregion
#endif

#if UNITY_IOS
            #region Player
        if (Input.touchCount > 0)
        {
            t += Time.deltaTime * lerpMultiply;
        }
        else
        {
            t -= Time.deltaTime * lerpMultiply;
        }

        t = Mathf.Clamp(t, 0, 1);
        desiredY = Mathf.Lerp(0.7f, 1.2f, t);
        transform.position = new Vector3(transform.position.x, desiredY, -9);
            #endregion
#endif


            MedusaControl();

            WinCheck();
        }

        }


        //TODO Make it so the IEnumerator change the text
        IEnumerator BlinkRed()
    {
        //setup for player
        medusaLooking = true;
        //Renderer rend = medusaGo.GetComponent<Renderer>();
        //rend.material.color = Color.red;
        medusaAnim.SetBool("StartLook", true);
        medusaFx.PlayDelayed(0.2f);
        yield return new WaitForSeconds(1);
        //meduslooking
        //rend.material.color = Color.green;
        medusaLooking = false;
        tapText.text = "";
    }

    void MedusaControl()
    {
        if (lookatTime < Time.time && !gameDone)
        {
            StartCoroutine(BlinkRed());
            //Debug.Log("LookatTime is smaller than time");
        }

        if (playerlookatTime < Time.time)
        {
            tapText.text = "Tap the screen!";
        }
        else
        {
            tapText.text = "";
        }
    }

    void WinCheck()
    {

        //lose
        if (!medusaLooking && t > .8 && playerlookatTime > Time.time || medusaLooking && t < .8)
        {
            hands[0].material = stoneMat;
            hands[1].material = stoneMat;
            medusaFx.PlayOneShot(turnToStone);

            Lose();
        }

        //win
        if (t > .8 && medusaLooking)
        {
            Win();
        }
    }
}
