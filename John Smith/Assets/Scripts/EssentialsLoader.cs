using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject playerPrefab; //0.0.30N2
    public GameObject canvasPrefab; //0.0.30N2end
    public GameObject gameManagerPrefab; //0.0.42N2

    public static EssentialsLoader essentialInstance;

    void Awake() //0.0.30N3
    {
        if (essentialInstance == null)
        {
            essentialInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    } //0.0.30N3end

    // Start is called before the first frame update
    void Start() 
    {
        DontDestroyOnLoad(gameObject); //0.0.30N4
        if (PlayerController.PCInstance == null)
        {
            Instantiate(playerPrefab);
            //PlayerController.PCInstance = Instantiate(playerPrefab).GetComponent<PlayerController>();
        }
        if (UIFade.UIFInstance == null)
        {
            Instantiate(canvasPrefab);
            //UIFade.UIFInstance = Instantiate(canvasPrefab).GetComponent<UIFade>();
        }
        if (GameManager.GMInstance == null) //0.0.42N2
            Instantiate(gameManagerPrefab); //0.0.30N4end
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
