using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipesManager : MonoBehaviour
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

    private List<BURGERRECIPES> BurguerList = new List<BURGERRECIPES>();
    private List<HOTDOGRECIPES> HotdogList = new List<HOTDOGRECIPES>();
    private List<SUSHIRECIPES> SushiList = new List<SUSHIRECIPES>();

    [Header("Level")]
    [SerializeField] bool BurguerLevel;
    [SerializeField] bool HotdogLevel;
    [SerializeField] bool SushiLevel;
    private int burguer = 0;
    private int hotdog = 1;
    private int sushi = 2;
    private bool canGetANewRecipe = true;
    private int maxTimer = 3;

    // Update is called once per frame
    void Update()
    {
        if (BurguerLevel && canGetANewRecipe)
        {
            StartCoroutine(CreateRecipes(burguer));
        }
        else if (HotdogLevel && canGetANewRecipe)
        {
            StartCoroutine(CreateRecipes(hotdog));
        }
        else if (SushiLevel && canGetANewRecipe)
        {
            StartCoroutine(CreateRecipes(sushi));
        }
    }

    IEnumerator CreateRecipes(int recipe)
    {
        canGetANewRecipe = false;
        System.Random time = new System.Random();
        int finaltimer = time.Next(0, maxTimer++);
        yield return new WaitForSeconds(finaltimer);

        switch (recipe)
        {
            case 0: // Burguers
                {
                    System.Random random = new System.Random();
                    Array values = Enum.GetValues(typeof(BURGERRECIPES));
                    BURGERRECIPES randomBar = (BURGERRECIPES)values.GetValue(random.Next(values.Length));
                    BurguerList.Add(randomBar);
                    canGetANewRecipe = true;
                    break;
                }

            case 1: // Hotdogs
                {
                    System.Random random = new System.Random();
                    Array values = Enum.GetValues(typeof(HOTDOGRECIPES));
                    HOTDOGRECIPES randomBar = (HOTDOGRECIPES)values.GetValue(random.Next(values.Length));
                    HotdogList.Add(randomBar);
                    canGetANewRecipe = true;
                    break;
                }

            case 2: // Sushi
                {
                    System.Random random = new System.Random();
                    Array values = Enum.GetValues(typeof(SUSHIRECIPES));
                    SUSHIRECIPES randomBar = (SUSHIRECIPES)values.GetValue(random.Next(values.Length));
                    SushiList.Add(randomBar);
                    canGetANewRecipe = true;
                    break;
                }

            default:
                break;
        }
    }

    public List<BURGERRECIPES> GetBurguerList()
    {
        return BurguerList;
    }

    public List<HOTDOGRECIPES> GetHotdogList()
    {
        return HotdogList;
    }

    public List<SUSHIRECIPES> GetSushiList()
    {
        return SushiList;
    }

    public bool GetWichRecipe()
    {
        if (BurguerLevel)
        {
            return BurguerLevel;
        }
        else if (HotdogLevel)
        {
            return HotdogLevel;
        }
        else if (SushiLevel)
        {
            return SushiLevel;
        }

        return true;
    }
}
