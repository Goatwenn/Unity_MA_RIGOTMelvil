using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{

    private Transform pivot;
    private GameManager gm;

    private int up;
    private int down;
    private int left;
    private int right;

    private void Start(){
        // Get Transform -----------------------------------------
        pivot = this.gameObject.transform;
        // Get GameManager -----------------------------------------
        gm = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        // Input -----------------------------------------
        if (Input.GetKey("z")){up = 1;} else {up = 0;}
        if (Input.GetKey("s")){down = 1;} else {down = 0;}
        if (Input.GetKey("d")){left = 1;} else {left = 0;}
        if (Input.GetKey("q")){right = 1;} else {right = 0;}

        //Controles -------------------------------
        pivot.Rotate(gm.rotaSpeed * Time.deltaTime * up,0,0);
        pivot.Rotate(-gm.rotaSpeed * Time.deltaTime * down,0,0);
        pivot.Rotate(0,-gm.rotaSpeed * Time.deltaTime * left,0);
        pivot.Rotate(0,gm.rotaSpeed * Time.deltaTime * right,0);

    }
    
}
