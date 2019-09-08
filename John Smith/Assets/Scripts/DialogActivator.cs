using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    public string[] lines;
    private bool canActivateDialogue; //0.0.34N2
    public bool isPerson = true; //0.0.37N1

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (canActivateDialogue && Input.GetButtonDown("Fire1") && !DialogManager.DMInstance.dialogBox.activeInHierarchy) //0.0.34N4
            DialogManager.DMInstance.ShowDialog(lines, isPerson); //0.0.34N4end; 0.0.37N3
    }

    private void OnTriggerEnter2D(Collider2D collision) //0.0.34N2
    {
        if (collision.tag == "Player")
            canActivateDialogue = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            canActivateDialogue = false;
    } //0.0.34N2end
}
