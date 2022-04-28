using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeController : MonoBehaviour
{
    private enum INGREDIENTS { NONE, BURGUERBREAD, BURGUER, BURGUERCHEESE, BURGUERCHEESETOMATO, CHEESECUT, LETTUCE, PATTYMEAT, TOMATOSLICE, HOTDOGBREAD, SAUSAGEMEAT, BOTTLEKETCHUP, BOTTLEMUSTARD, RICEBALL, SALMON };

    private List<INGREDIENTS> recipe;
    private INGREDIENTS lastIngredient;

    private bool isBurguer;
    private bool isHotDog;
    private bool isSushi;
    private bool isPizza;

    // Start is called before the first frame update
    void Start()
    {
        recipe = new List<INGREDIENTS>();
        recipe.Add(INGREDIENTS.NONE);
        lastIngredient = recipe[0];
        ResetBools();
    }

    // Update is called once per frame
    void Update()
    {
        GetRecipe();
    }

    private void GetRecipe()
    {
        if (lastIngredient != recipe[0])
        {
            lastIngredient = recipe[0];

            switch (recipe[0])
            {
                default:
                    ResetBools();
                    break;

                // Burguer
                case INGREDIENTS.BURGUERBREAD:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUER:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERCHEESE:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERCHEESETOMATO:
                    IsBurguer();
                    break;
                case INGREDIENTS.CHEESECUT:
                    IsBurguer();
                    break;
                case INGREDIENTS.LETTUCE:
                    IsBurguer();
                    break;
                case INGREDIENTS.PATTYMEAT:
                    IsBurguer();
                    break;
                case INGREDIENTS.TOMATOSLICE:
                    IsBurguer();
                    break;

                // HotDog
                case INGREDIENTS.HOTDOGBREAD:
                    IsHotDog();
                    break;
                case INGREDIENTS.SAUSAGEMEAT:
                    IsHotDog();
                    break;
                case INGREDIENTS.BOTTLEKETCHUP:
                    IsHotDog();
                    break;
                case INGREDIENTS.BOTTLEMUSTARD:
                    IsHotDog();
                    break;

                // Sushi
                case INGREDIENTS.RICEBALL:
                    IsSushi();
                    break;
                case INGREDIENTS.SALMON:
                    IsSushi();
                    break;

                    // Pizza
            }
        }
    }

    private bool CheckIngredient(INGREDIENTS i)
    {
        foreach (var item in recipe)
        {
            if (i == item) return true;
        }
        return false;
    }

    private bool CheckFirstIngredientIsNotNONE()
    {
        if (recipe[0] == INGREDIENTS.NONE) 
            return true;

        return false;
    }

    private void MakeBurguer(INGREDIENTS newIngredient)
    {
        recipe.Add(newIngredient);

        bool burguer = false;
        bool burguerBread = false;
        bool burguerCheese = false;
        bool burguerCheeseTomato = false;
        bool pattyMeat = false;
        bool cheeseCut = false;
        bool lettuce = false;
        bool tomateSlice = false;

        foreach (var item in recipe)
        {
            switch (item)
            {
                case INGREDIENTS.BURGUERBREAD:
                    burguerBread = true;
                    break;
                case INGREDIENTS.BURGUER:
                    burguer = true;
                    break;
                case INGREDIENTS.BURGUERCHEESE:
                    burguerCheese = true;
                    break;
                case INGREDIENTS.BURGUERCHEESETOMATO:
                    burguerCheeseTomato = true;
                    break;
                case INGREDIENTS.PATTYMEAT:
                    pattyMeat = true;
                    break;
                case INGREDIENTS.CHEESECUT:
                    cheeseCut = true;
                    break;
                case INGREDIENTS.LETTUCE:
                    lettuce = true;
                    break;
                case INGREDIENTS.TOMATOSLICE:
                    tomateSlice = true;
                    break;

            }
        }

        // Comprobar que Ingredientes estan (son true) y hacer las combinaciones instaciando las fusiones

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);

        switch (other.gameObject.tag)
        {
            default:
                break;

            // Burguer
            case "BurguerBread":
                if (!CheckIngredient(INGREDIENTS.BURGUERBREAD))
                {
                    // No esta este ingrediente en el plato
                    // Compruebo que no se esta haciendo otra receta
                    if (!isHotDog && !isPizza && !isSushi)
                    {
                        // Lo añado al array
                        if (CheckFirstIngredientIsNotNONE())
                        {
                            recipe[0] = INGREDIENTS.BURGUERBREAD;
                        }
                        else
                        {
                            // Hacer la combinacion de ingredientes
                            MakeBurguer(INGREDIENTS.BURGUERBREAD);

                            
                        }
                    }
                    break;
                }

                // Ya Esta el ingrediente en el plato
                Debug.Log("Ya esta en el plato");
                break;
                
            case "Burguer":

                break;
            case "BurguerCheese":

                break;
            case "BurguerCheeseTomtato":

                break;
            case "CheeseCut":

                break;
            case "Lettuce":

                break;
            case "PattyMeat":

                break;
            case "TomatoSlice":

                break;

            // HotDog
            case "HotDogBread":

                break;
            case "SausageMeat":

                break;
            case "BottleKetchup":

                break;
            case "BottleMustard":

                break;

            // Sushi
            case "RiceBall":

                break;
            case "Salmon":

                break;

            // Pizza

        }
    }

    private void OnTriggerExit(Collider other)
    {
        ResetBools();
    }

    private void ResetBools()
    {
        isBurguer = false;
        isHotDog = false;
        isSushi = false;
        isPizza = false;
    }

    private void IsBurguer()
    {
        isHotDog = false;
        isSushi = false;
        isPizza = false;
        isBurguer = true;
    }

    private void IsHotDog()
    {
        isSushi = false;
        isPizza = false;
        isBurguer = false;
        isHotDog = true;
    }

    private void IsSushi()
    {
        isPizza = false;
        isBurguer = false;
        isHotDog = false;
        isSushi = true;
    }

    private void IsPizza()
    {
        isBurguer = false;
        isHotDog = false;
        isSushi = false;
        isPizza = true;
    }
}
