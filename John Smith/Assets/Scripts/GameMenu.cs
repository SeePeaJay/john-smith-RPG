using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //0.0.47C1

public class GameMenu : MonoBehaviour
{
    public GameObject theMenu; //0.0.45C1

    private CharStats[] playerStats; //0.0.47C2
    public Text[] nameTexts, hpTexts, mpTexts, lvlTexts, expTexts; //0.0.47C3
    public Slider[] expSlider;
    public Image[] charImage;
    public GameObject[] charStatScreens; //0.0.47C3end

    public GameObject[] menuWindows; //0.0.49C1

    // Start is called before the first frame update
    void Start()
    {
        theMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2")) //0.0.45C1
            if (theMenu.activeInHierarchy)
            {
                //theMenu.SetActive(false);
                //GameManager.GMInstance.isGameMenuOpen = false; //0.0.46C3
                CloseMenu(); //0.0.49C4
            }
            else
            {
                theMenu.SetActive(true);
                UpdateMainStats(); //0.0.47C2
                GameManager.GMInstance.isGameMenuOpen = true; //0.0.46C3
            } //0.0.45C1end 
    }

    public void UpdateMainStats() //0.0.47C2
    {
        playerStats = GameManager.GMInstance.playerStats;

        for (int i = 0; i < playerStats.Length; i++) //0.0.47C4
            if (playerStats[i].gameObject.activeInHierarchy)
            {
                charStatScreens[i].SetActive(true);

                nameTexts[i].text = playerStats[i].charName;
                hpTexts[i].text = "HP: " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
                mpTexts[i].text = "MP: " + playerStats[i].currentMP + "/" + playerStats[i].maxMP;
                lvlTexts[i].text = "Lvl: " + playerStats[i].playerLevel;
                expTexts[i].text = "" + playerStats[i].currentExp + "/" + playerStats[i].expToLevel[playerStats[i].playerLevel];
                expSlider[i].maxValue = playerStats[i].expToLevel[playerStats[i].playerLevel];
                expSlider[i].value = playerStats[i].currentExp;
                charImage[i].sprite = playerStats[i].charImage;
            }
            else
            {
                charStatScreens[i].SetActive(false);
            } //0.0.47C4end
    } //0.0.47C2end

    public void ToggleWindow(int windowID) //0.0.49C2
    {
        for (int i = 0; i < menuWindows.Length; i++)
            if (i == windowID)
                menuWindows[i].SetActive(!menuWindows[i].activeInHierarchy);
            else
                menuWindows[i].SetActive(false);
    } //0.0.49C2end

    public void CloseMenu() //0.0.49C3
    {
        for (int i = 0; i < menuWindows.Length; i++)
            menuWindows[i].SetActive(false);
        theMenu.SetActive(false);
        GameManager.GMInstance.isGameMenuOpen = false;
    } //0.0.49C3end
}