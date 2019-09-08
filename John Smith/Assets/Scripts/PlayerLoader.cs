using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public GameObject player; //0.0.19N1

    // Start is called before the first frame update
    void Start() 
    {
        if (PlayerController.PCInstance == null) //0.0.19N2
            Instantiate(player); //0.0.19N2end
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
