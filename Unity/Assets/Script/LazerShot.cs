using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShot : MonoBehaviour
{
    [SerializeField]private GameObject impact;
    [SerializeField]private GameObject lazer;

    void Update() {
        Shoot();
    }


    void Shoot()
    {
        if (Input.GetKey("space"))
        {
            //Creation RayCast
            RaycastHit hit;
            Ray ray = new Ray(transform.position, -transform.position);
            Debug.DrawRay(transform.position, -transform.position, Color.red);

            //Variable dans laquelle on "stock" la layer
            int layer_mask = LayerMask.GetMask("Planet");

            if(Physics.Raycast(ray, out hit, 6, layer_mask, QueryTriggerInteraction.Ignore)){
                
                // Active + Deplace la sphére d'impact
                impact.SetActive (true);
                impact.transform.position = hit.point;
                lazer.GetComponent<ParticleSystem>().Play();
            }
        }
        else if (Input.GetKeyUp("space"))
        {
            // Desactive 
            impact.SetActive (false);
            lazer.GetComponent<ParticleSystem>().Stop();
        }
    }
}
