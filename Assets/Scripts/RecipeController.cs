using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeController : MonoBehaviour
{
    public enum INGREDIENTS { NONE, BURGUERBREAD, BURGUER, BURGUERCHEESE, BURGUERCHEESETOMATO, CHEESECUT, LETTUCE, PATTYMEAT, TOMATOSLICE, HOTDOGBREAD, SAUSAGEMEAT, BOTTLEKETCHUP, BOTTLEMUSTARD, RICEBALL, SALMON };

    public List<INGREDIENTS> recipe;
    public List<GameObject> objectsRecipe;
    private INGREDIENTS lastIngredient;

    private bool isBurguer;
    private bool isHotDog;
    private bool isSushi;
    private bool isPizza;

    private bool isColliding;
    private bool isTried;

    // Start is called before the first frame update
    void Start()
    {
        objectsRecipe = new List<GameObject>();
        recipe = new List<INGREDIENTS>();
        recipe.Add(INGREDIENTS.NONE);
        lastIngredient = recipe[0];
        ResetBools();

        isColliding = false;
        isTried = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetRecipe();

        if (isColliding && !isTried)
        {
            isTried = true;
            StartCoroutine(SetIsColliding());
        }
    }

    IEnumerator SetIsColliding()
    {
        yield return new WaitForSeconds(1f);
        isColliding = false;
        isTried = false;
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

        if (burguerBread && pattyMeat && cheeseCut)
        {
            foreach (var item in objectsRecipe)
            {
                Destroy(item);
            }
            objectsRecipe.Clear();

            Object p = Resources.Load("BurgerCheese Variant");
            Instantiate(p, transform.position, transform.rotation);

            objectsRecipe.Add((GameObject)p);
        }

        if (burguerBread && pattyMeat)
        {
            foreach (var item in objectsRecipe)
            {
                Destroy(item);
            }
            objectsRecipe.Clear();

            Object p = Resources.Load("Burger Variant");
            Instantiate(p, transform.position, transform.rotation);

            objectsRecipe.Add((GameObject)p);
        }

        // Comprobar que Ingredientes estan (son true) y hacer las combinaciones instaciando las fusiones

    }

    private void AddToObjectRecipe(GameObject other)
    {
        GameObject tmp = other;
        objectsRecipe.Add(tmp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isColliding)
        {
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
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERBREAD);
                            }
                            isColliding = true;
                        }
                        break;
                    }
                    else
                    {
                        isColliding = false;
                    }
                    break;

                case "Burguer":
                    if (!CheckIngredient(INGREDIENTS.BURGUER))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUER;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUER);
                            }
                        }
                        break;
                    }
                    break;

                case "BurguerCheese":
                    if (!CheckIngredient(INGREDIENTS.BURGUERCHEESE))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERCHEESE;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERCHEESE);
                            }
                        }
                        break;
                    }
                    break;

                case "BurguerCheeseTomtato":
                    if (!CheckIngredient(INGREDIENTS.BURGUERCHEESETOMATO))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERCHEESETOMATO;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERCHEESETOMATO);
                            }
                        }
                        break;
                    }
                    break;

                case "CheeseCut":
                    if (!CheckIngredient(INGREDIENTS.CHEESECUT))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.CHEESECUT;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.CHEESECUT);
                            }
                            isColliding = true;
                        }
                        break;
                    }
                    break;

                case "Lettuce":
                    if (!CheckIngredient(INGREDIENTS.LETTUCE))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.LETTUCE;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.LETTUCE);
                            }
                        }
                        break;
                    }
                    break;

                case "PattyMeat":
                    if (!CheckIngredient(INGREDIENTS.PATTYMEAT))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.PATTYMEAT;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.PATTYMEAT);
                            }
                            isColliding = true;
                        }
                        break;
                    }
                    break;

                case "TomatoSlice":
                    if (!CheckIngredient(INGREDIENTS.TOMATOSLICE))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.TOMATOSLICE;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.TOMATOSLICE);
                            }
                        }
                        break;
                    }
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
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {

        }

        //ResetBools();

        Debug.Log("ha salido " + other.gameObject.tag + " del plato");
    }

    private void ResetBools()
    {
        recipe[0] = INGREDIENTS.NONE;
        lastIngredient = recipe[0];

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
