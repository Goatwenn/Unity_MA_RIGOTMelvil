using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

// Variables Satelite ------------------------------
[Header("--- Satelite States ---")]
    public float rotaSpeed = 10f;
    public float hitArea = 0.5f;
    public float lightIntensity ;
    [SerializeField] private float lightMultiplieur = 1 ;
    
    


// Variables Ennemi ------------------------------
[Header("--- Ennemis ---")]
    public Ennemi prefab;
    public GameObject ennemiLayer;
    [Space(5)]
    public int currentEnnemis;
    [SerializeField] private int maxEnnemi = 200;
    [Space(5)]
    [SerializeField] private int currentTier;
    public int totalKill;
    public AnimationCurve tier_Curve;


// Variables States ------------------------------
[Header("--- States ---")]

    public Text Tier ;
    public Text Kills ;
    [Space(5)]
    public Text Ms_Niv ;
    public Text Bs_Niv ;
    public Text Rs_Niv ;
    [SerializeField] private int [] Nivs ;

    // Variables Upgrade ------------------------------
    [Header("--- Upgrade ---")]
    public AnimationCurve upgradeCurve;
    [SerializeField] private float dropChance ;
    [SerializeField] private float chances; 

    void Update()
    {
        lightIntensity =  lightMultiplieur * hitArea ;

        // Instantiate Ennemi ------------------------------
        if (currentEnnemis < maxEnnemi){
            Ennemi ennemi = Instantiate(prefab, ennemiLayer.transform.position , new Quaternion(),ennemiLayer.transform);
            currentEnnemis += 1;
            

        // Update Text ------------------------------
            Kills.text = "Kill: " + totalKill ;
            
            if (totalKill >= 10){
                 currentTier = (int)tier_Curve.Evaluate(totalKill);  
            }
            else {
                 currentTier = 0 ;
            }

            Tier.text = "Tier: " + currentTier ;
        } 


        Ms_Niv.text = "Niv: " + Nivs [0] ;
        Bs_Niv.text = "Niv: " + Nivs [1] ;
        Rs_Niv.text = "Niv: " + Nivs [2];
        //jenesaispasquoi_Niv.text = "Niv: " + Nivs [3];
        // ECT ...

        rotaSpeed = (0.5f * Nivs [0]) + 10f;
        hitArea = (0.01f * Nivs [1]) + 0.1f;
        // reloadSpeed = (1f * Nivs [2]) +10f;
        //jenesaispasquoi_Niv.text = (7.5f * Nivs [3]) +2f;
        // ECT...


    }

    public void Upgrade() {

        // Check a combien est la courbe
        dropChance = (float)upgradeCurve.Evaluate(currentTier);
        // Gener au Piff un nombre entre 0 et 3
        chances = Random.Range(0f, 3f);

        // En suite on commence par verifier si Chance est plus petit que dropchance (sur la curve sa fait sense)
        if (chances <= dropChance){

            // et on check combien d'upgrade on gagne d'un coup.
            if (chances > 2){
                Nivs [(int)Random.Range(0, 3)] += 1 ;
                Debug.Log("UPGRAD + 3");
            }
            else if (chances > 1  ){
                Nivs [(int)Random.Range(0, 3)] += 1 ;
                Debug.Log("UPGRAD + 2");
            }
            else{
                Nivs [(int)Random.Range(0, 3)] += 1 ;
                Debug.Log("UPGRAD + 1");
            }

            // sa permet de faire gagner de plus en plus d' upgrade en fonction des Tier
        }
    }
}
