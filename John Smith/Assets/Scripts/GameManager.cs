using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GMInstance; //0.0.42N1
    public CharStats[] playerStats; //0.0.42N1

    public bool isGameMenuOpen, isDialogActive, isFadingBetweenAreas; //0.0.46C1

    private void Awake() //0.0.42N1
    {
        if (GMInstance == null) 
        {
            GMInstance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
            Destroy(gameObject); 
    } //0.0.42N1end

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameMenuOpen || isDialogActive || isFadingBetweenAreas) //0.0.46C2, 0.0.46I1
            PlayerController.PCInstance.canMove = false;
        else
            PlayerController.PCInstance.canMove = true; //0.0.46C2end
    }
}
