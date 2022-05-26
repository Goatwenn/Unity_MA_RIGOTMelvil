using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactArea : MonoBehaviour
{
    private GameManager gm;

    [SerializeField] private SphereCollider zone ;
    [SerializeField] private Light pointLight;

    
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update (){
       zone.radius = gm.hitArea;
       pointLight.intensity = gm.lightIntensity ;

    }

   
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ennemis")
        {
            //Debug.Log("Toucher");
            Destroy(other.gameObject);
            gm.Upgrade();
        }
    }
}
