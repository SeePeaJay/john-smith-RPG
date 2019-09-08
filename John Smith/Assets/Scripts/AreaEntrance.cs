using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string location; //0.0.17N3

    // Start is called before the first frame update
    void Start()
    {
        if (location == PlayerController.PCInstance.destination) //0.0.17N4
            PlayerController.PCInstance.transform.position = transform.position; //0.0.17N4end

        UIFade.UIFInstance.SetFadeFromBlack(); //0.0.29N5
        GameManager.GMInstance.isFadingBetweenAreas = false; //0.0.46C5
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
