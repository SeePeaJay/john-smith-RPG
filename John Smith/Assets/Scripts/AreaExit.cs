using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //0.0.15N3

public class AreaExit : MonoBehaviour
{
    public string loadingSceneFileName; //0.0.15N1
    public string destination; //0.0.17N1

    public float newSceneLoadTime = 1f; //0.0.29N1
    public bool shouldWaitToLoad; //0.0.29N1

    // Start is called before the first frame update
    void Start()
    {
   
    }
     
    // Update is called once per frame
    void Update()
    {
        if (shouldWaitToLoad) //0.0.29N3
            newSceneLoadTime -= Time.deltaTime;
        if (newSceneLoadTime <= 0)
        {
            shouldWaitToLoad = false;
            SceneManager.LoadScene(loadingSceneFileName); //0.0.29N3end
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //0.0.15N2; 0.0.15I1
    {
        if(collision.tag == "Player")
        {
            //SceneManager.LoadScene(loadingSceneName); //0.0.15N4
            shouldWaitToLoad = true;
            UIFade.UIFInstance.SetFadeToBlack(); //0.0.29N2
            GameManager.GMInstance.isFadingBetweenAreas = true; //0.0.46C5

            PlayerController.PCInstance.destination = destination; //0.0.17.N2, 0.0.17I1
        }
    }
}
