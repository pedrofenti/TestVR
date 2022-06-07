using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScreenController : MonoBehaviour
{
    public enum BURGERRECIPES
    {
        BURGUER, BURGUERCHEESE, BURGUERTOMATO, BURGUERLETTUCE,
        BURGUERCHEESETOMATO, BURGUERCHEESELETTUCE, BURGUERLETTUCETOMATO, BURGUERWITHALL
    }

    public enum HOTDOGRECIPES
    {
        HOTDOG, HOTDOGSAUCE, HOTDOGKETCHUP, HOTDOGMUSTARD
    }

    public enum SUSHIRECIPES
    {
        MAKIRICE, MAKISALMON, MAKIROE, SHUSHISALMON
    }

    [SerializeField] RecipesManager recipesManager;
    [SerializeField] Transform content;
 
    [Header("Burguers")]
    [SerializeField] GameObject[] BurguerOptions;

    [Header("Hotdogs")]
    [SerializeField] GameObject[] HotdogOptions;

    [Header("Sushi")]
    [SerializeField] GameObject[] SushiOptions;

    private int tmpLevel;
    private bool BurguerLevel;
    private bool HotdogLevel;
    private bool SushiLevel;

    private int burguerRcp;
    private int hotdogRcp;
    private int sushiRcp;

    // Start is called before the first frame update
    void Start()
    {
        tmpLevel = recipesManager.GetWichRecipe();
        SetLevel();
    }

    private void SetLevel()
    {
        switch (tmpLevel)
        {
            case 0:
                BurguerLevel = true;
                break;
            case 1:
                HotdogLevel = true;
                break;
            case 2:
                SushiLevel = true;
                break;
            default:
                Debug.Log("Set a Recipe Level between Burgers, Sushi or HotDogs!");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BurguerLevel && recipesManager.GetIfCanGetANewRecipe())
        {
            burguerRcp = recipesManager.GetBurguerList();
            ManageRecipeOption(burguerRcp);
        }
        else if (HotdogLevel && recipesManager.GetIfCanGetANewRecipe())
        {
            hotdogRcp = recipesManager.GetHotdogList();
            ManageRecipeOption(hotdogRcp);
        }
        else if (SushiLevel && recipesManager.GetIfCanGetANewRecipe())
        {
            sushiRcp = recipesManager.GetSushiList();
            ManageRecipeOption(sushiRcp);
        }
    }

    private void ManageRecipeOption(int recipe)
    {
        if (BurguerLevel)
        {
            Instantiate(BurguerOptions[recipe], content);
        }
        else if (HotdogLevel)
        {

        }
        else if (SushiLevel)
        {

        }
    }
}
