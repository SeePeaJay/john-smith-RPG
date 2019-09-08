using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName; //0.0.38N1
    public int playerLevel = 1;
    public int currentExp;
    public int[] expToLevel; //0.0.39N1;
    public int maxLevel = 100; //0.0.39N1end;
    public int baseEXP = 1000; //0.0.39N3

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;

    public int strength;
    public int defense;

    public int wpnPwr;
    public string wpnName;
    public int amrPwr;
    public string amrName;

    public Sprite charImage; //0.0.38N1end



    // Start is called before the first frame update
    void Start()
    {
        expToLevel = new int[maxLevel]; //0.0.39N2;

        expToLevel[1] = baseEXP; //0.0.39N3;
        for (int i = 1; i < expToLevel.Length; i++) //0.0.39N4;
        {
            expToLevel[i] = Mathf.FloorToInt(expToLevel[i - 1] * 1.05f);
        } //0.0.39N4end
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            AddEXP(500);
    }

    public void AddEXP(int expToAdd) //0.0.40N1
    {
        currentExp += expToAdd;
        if(playerLevel < maxLevel && currentExp > expToLevel[playerLevel]) //0.0.41N2
        {
            currentExp -= expToLevel[playerLevel];
            playerLevel++;

            if (playerLevel % 2 == 0) //0.0.41N1
                strength++;
            else
                defense++;

            maxHP = Mathf.FloorToInt(maxHP * 1.05f);
            currentHP = maxHP;

            maxMP = Mathf.FloorToInt(maxHP * 1.03f);
            currentMP = maxMP;//0.0.41N1end
        }

        if (playerLevel >= maxLevel) 
            currentExp = 0; //0.0.41N3
    } //0.0.40N1end
}
