using System.Collections;
using System.Collections.Generic;
using DigitalRuby.LightningBolt;
using UnityEngine;

/* summary
 * This handles everything of the power of zeus
 * the lightning is a linerenderer and has a sphere trigger on the ground
 * timebetweenlightning is basicaly like a cooldown
*/
public class ZeusPower : MonoBehaviour
{

    public GameObject thunderPrefab;
    public float timeBetweenLightning;

    float lightningCooldown;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && lightningCooldown < Time.time)
        {
            RaycastHit hit;
            Ray ray = gameObject.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            lightningCooldown = Time.time + timeBetweenLightning;

            if (Physics.Raycast(ray, out hit, 20f))
            {
                if(hit.collider != null)
                {
                    GameObject temp = Instantiate(thunderPrefab, hit.point, transform.rotation);
                    Destroy(temp, .2f);
                    LightningBoltScript lightningbolt = temp.GetComponent<LightningBoltScript>();
                    //Debug.Log(hit.point);
                }
            }
        }

        Debug.DrawRay(transform.position, Input.mousePosition, Color.black);
    }
}
