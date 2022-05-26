using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    [SerializeField] private GameObject Capsule;
    private GameManager gm;

    void Start(){

        gm = FindObjectOfType<GameManager>();

        float x = Random.Range(0f, 360f);
        float y = Random.Range(0f, 360f);
        float z = Random.Range(0f, 360f);

        transform.Rotate(x,y,z);
    }

    void Update() 
    {
        if(Capsule == null){
            
            Destroy(gameObject);

            gm.currentEnnemis -= 1;
            gm.totalKill += 1;
        }
    }
}
