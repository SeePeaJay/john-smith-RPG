using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //0.0.31N1

public class DialogManager : MonoBehaviour
{
    public Text dialogText; //0.0.32N1
    public Text nameText; 
    public GameObject dialogBox; 
    public GameObject nameBox; 

    public string[] dialogLines; //0.0.32N1end
    public int currentLine; //0.0.32N2

    public static DialogManager DMInstance; //0.0.34N1

    // Start is called before the first frame update
    void Start()
    {
        if (DMInstance == null) //0.0.34N1
        {
            DMInstance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
            Destroy(gameObject); //0.0.34N1end
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogBox.activeInHierarchy) //0.0.33N1
            if(Input.GetButtonUp("Fire1")) //0.0.33N2
            {
                CheckIfName();
                if (currentLine < dialogLines.Length) //0.0.33N3
                {
                    dialogText.text = dialogLines[currentLine];
                    currentLine++;
                } //0.0.33N3end
                else //0.0.33N4
                {
                    dialogBox.SetActive(false); //0.0.33N4end
                    //PlayerController.PCInstance.canMove = true; //0.0.35N4
                    GameManager.GMInstance.isDialogActive = false; //0.0.46C4
                }
                    
            }
    }

    public void ShowDialog(string[] newLines, bool isPerson) //0.0.34N3; 0.0.37N2
    {
        dialogLines = newLines;
        currentLine = 0;

        nameBox.SetActive(isPerson); //0.0.37N2

        CheckIfName(); //0.0.36N2;
        dialogText.text = dialogLines[currentLine]; //0.0.36N2end
        dialogBox.SetActive(true);
        //PlayerController.PCInstance.canMove = false; //0.0.35N4
        GameManager.GMInstance.isDialogActive = true; //0.0.46C4
    } //0.0.34N3end

    public void CheckIfName() //0.0.36N1
    {
        if(currentLine < dialogLines.Length && dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", ""); //0.0.36N3
            currentLine++;
        }
    } //0.0.36N1end
}
