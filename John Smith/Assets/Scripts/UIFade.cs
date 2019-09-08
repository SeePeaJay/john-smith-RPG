using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //0.0.28N1; 0.0.28I1

public class UIFade : MonoBehaviour
{
    public static UIFade UIFInstance; //0.0.28N4

    public Image fadeScreen; //0.0.28N1
    private bool shouldFadeFromBlack;
    private bool shouldFadeToBlack; //0.0.28N1end

    public float fadeSpeed = 1f; //0.0.28N2

    private void Awake() //0.0.30N5
    {
        if (UIFInstance == null) //0.0.30N1
        {
            UIFInstance = this; //0.0.28N4
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject); //0.0.30N1end
    } //0.0.30N5end

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime)); //0.0.28N2; 0.0.28I2
            if (fadeScreen.color.a == 0f) //0.0.28N3
                shouldFadeToBlack = false; //0.0.28N3; 0.0.28I3
        }
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime)); //0.0.28N2; 0.0.28I2
            if (fadeScreen.color.a == 1f) //0.0.28N3
                shouldFadeFromBlack = false; //0.0.28N3; 0.0.28I3
        }
            
    }

    public void SetFadeFromBlack() //0.0.28N5
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

    public void SetFadeToBlack()
    {
        shouldFadeFromBlack = false;
        shouldFadeToBlack = true;
    } //0.0.28N5end
}
