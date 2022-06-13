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

    public List<BURGERRECIPES> BurguerList = new List<BURGERRECIPES>();
    public List<HOTDOGRECIPES> HotdogList = new List<HOTDOGRECIPES>();
    public List<SUSHIRECIPES> SushiList = new List<SUSHIRECIPES>();
    
    public List<GameObject>  ObjectBurguerList = new List<GameObject>();
    public List<GameObject> ObjectHotdogList = new List<GameObject>();
    public List<GameObject> ObjectSushiList = new List<GameObject>();

    [Header("Level")]
    [SerializeField] bool BurguerLevel;
    [SerializeField] bool HotdogLevel;
    [SerializeField] bool SushiLevel;

    [Header("Recipes")]
    [SerializeField] GameObject[] BurguerRecipes;
    [SerializeField] GameObject[] HotdogRecipes;
    [SerializeField] GameObject[] SushiRecipes;

    private int burguer = 0;
    private int hotdog = 1;
    private int sushi = 2;
    private bool canGetANewRecipe = true;
    private int minTimer = 6;
    private int maxTimer = 6;

    private void Start()
    {
        ObjectBurguerList.Add(BurguerRecipes[0]);
        BurguerList.Add(BURGERRECIPES.BURGUER);
        ObjectHotdogList.Add(HotdogRecipes[0]);
        HotdogList.Add(HOTDOGRECIPES.HOTDOG);
        ObjectSushiList.Add(SushiRecipes[0]);
        SushiList.Add(SUSHIRECIPES.MAKIRICE);
    }

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
        int finaltimer = time.Next(minTimer, maxTimer++);
        yield return new WaitForSeconds(finaltimer);

        switch (recipe)
        {
            case 0: // Burguers
                {

                    System.Random random = new System.Random();
                    Array values = Enum.GetValues(typeof(BURGERRECIPES));
                    BURGERRECIPES randomBar = (BURGERRECIPES)values.GetValue(random.Next(values.Length));
                    BurguerList.Add(randomBar);
                    AddCorrectGameObjectToList(1, (int)randomBar);
                    canGetANewRecipe = true;
                    break;
                }

            case 1: // Hotdogs
                {
                    System.Random random = new System.Random();
                    Array values = Enum.GetValues(typeof(HOTDOGRECIPES));
                    HOTDOGRECIPES randomBar = (HOTDOGRECIPES)values.GetValue(random.Next(values.Length));
                    HotdogList.Add(randomBar);
                    AddCorrectGameObjectToList(2, (int)randomBar);
                    canGetANewRecipe = true;
                    break;
                }

            case 2: // Sushi
                {
                    System.Random random = new System.Random();
                    Array values = Enum.GetValues(typeof(SUSHIRECIPES));
                    SUSHIRECIPES randomBar = (SUSHIRECIPES)values.GetValue(random.Next(values.Length));
                    SushiList.Add(randomBar);
                    AddCorrectGameObjectToList(3, (int)randomBar);
                    canGetANewRecipe = true;
                    break;
                }

            default:
                break;
        }
    }

    private void AddCorrectGameObjectToList(int enumList, int recipe)
    {
        switch (enumList)
        {
            default:
                break;
            case 1: // Burger 
                ObjectBurguerList.Add(BurguerRecipes[recipe]);
                break;

            case 2: // Hotdog
                ObjectHotdogList.Add(HotdogRecipes[recipe]);
                break;

            case 3: // Sushi
                ObjectSushiList.Add(SushiRecipes[recipe]);
                break;
        }
    }

    public void RemoveGameObjectFromList(int list, string recipe, int recipeNum)
    {
        switch (list)
        {
            default:
                break;
            case 1:
                foreach (var item in ObjectBurguerList)
                {
                    if (item.name == recipe)
                    {
                        ObjectBurguerList.Remove(item);
                        break;
                    }
                }
                foreach (var item in BurguerList)
                {
                    if ((int)item == recipeNum)
                    {
                        BurguerList.Remove(item);
                        break;
                    }
                }
                break;
            case 2:
                foreach (var item in ObjectHotdogList)
                {
                    if (item.name == recipe)
                    {
                        ObjectHotdogList.Remove(item);
                        break;
                    }
                }
                foreach (var item in HotdogList)
                {
                    if ((int)item == recipeNum)
                    {
                        HotdogList.Remove(item);
                        break;
                    }
                }
                break;
            case 3:
                foreach (var item in ObjectSushiList)
                {
                    if (item.name == recipe)
                    {
                        ObjectSushiList.Remove(item);
                        break;
                    }
                }
                foreach (var item in SushiList)
                {
                    if ((int)item == recipeNum)
                    {
                        SushiList.Remove(item);
                        break;
                    }
                }
                break;
        }
    }

    public bool GetIfCanGetANewRecipe()
    {
        return canGetANewRecipe;
    }

    public int GetBurguerList()
    {
        if (BurguerList.Count > 0)
            return (int)BurguerList[BurguerList.Count - 1];
        else return 0;
    }

    public int GetHotdogList()
    {
        if (HotdogList.Count > 0)
            return (int)HotdogList[HotdogList.Count - 1];
        else return 0;
    }

    public int GetSushiList()
    {
        if (SushiList.Count > 0)
            return (int)SushiList[SushiList.Count - 1];
        else return 0;
    }

    public int GetWichRecipe()
    {
        if (BurguerLevel)
        {
            return burguer;
        }
        else if (HotdogLevel)
        {
            return hotdog;
        }
        else if (SushiLevel)
        {
            return sushi;
        }

        return -1;
    }

    public bool CheckIfRecipeIsOnDemand(GameObject recipe)
    {
        int objNum = 0;
        switch (GetWichRecipe())
        {
            default:
                break;
            case 0:
                foreach (var item in ObjectBurguerList)
                {
                    if (item.tag == recipe.tag)
                    {
                        RemoveGameObjectFromList(1, recipe.tag, objNum);
                        return true;
                    }
                    objNum++;
                }
                break;
            case 1:
                foreach (var item in ObjectHotdogList)
                {
                    if (item.tag == recipe.tag)
                    {
                        RemoveGameObjectFromList(1, recipe.tag, objNum);
                        return true;
                    }
                    objNum++;
                }
                break;
            case 2:
                foreach (var item in ObjectSushiList)
                {
                    if (item.tag == recipe.tag)
                    {
                        RemoveGameObjectFromList(1, recipe.tag, objNum);
                        return true;
                    }
                    objNum++;
                }
                break;
        }
        return false;
    }

}
