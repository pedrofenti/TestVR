using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeController : MonoBehaviour
{
    public enum INGREDIENTS { NONE, BURGUERBREAD, BURGUERBREADCHEESE, BURGUERBREADLETTUCE, BURGUERBREADTOMATO, BURGUER, 
        BURGUERCHEESE, BURGUERTOMATO, BURGUERLETTUCE,
        BURGUERCHEESETOMATO, BURGUERCHEESELETTUCE, BURGUERLETTUCETOMATO,
        BURGUERBREADCHEESETOMATO, BURGUERBREADCHEESELETTUCE, BURGUERBREADLETTUCETOMATO, BURGUERVEGETAL,
        BURGUERWITHALL, 
        HOTDOG, HOTDOGSAUCE, HOTDOGKETCHUP, HOTDOGMUSTARD, SAUSAGEKETCHUP, SAUSAGEMUSTARD, SAUSAGESAUCE,
        MAKIRICE, MAKISALMON, MAKIROE, SHUSHISALMON,
        CHEESECUT, LETTUCE, PATTYMEAT, TOMATOSLICE,
        HOTDOGBREAD, SAUSAGEMEAT, BOTTLEKETCHUP, BOTTLEMUSTARD, 
        RICEBALL, SALMON, ALGANORI
    };

    public List<INGREDIENTS> recipe;
    public List<GameObject> objectsRecipe;
    [SerializeField] List<GameObject> Ingredients;
    private INGREDIENTS lastIngredient;

    private Hand RighthandScript;
    private Hand LefthandScript;

    public bool isBurguer;
    public bool isHotDog;
    public bool isSushi;
    public bool isPizza;

    [Header("Debug")]
    private bool isColliding;
    private bool isTried;
    private bool anIngredientIsIn;
    public bool isGrabbingInPlate;

    private void Awake()
    {
        RighthandScript = GameObject.Find("Right Hand Model").GetComponent<Hand>();
        LefthandScript = GameObject.Find("Left Hand Model").GetComponent<Hand>();
    }

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
        anIngredientIsIn = true;
        isGrabbingInPlate = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrabbing();
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

    private void CheckIfGrabbing()
    {
        if (RighthandScript.GetIsGrabing() && !isGrabbingInPlate || LefthandScript.GetIsGrabing() && !isGrabbingInPlate)
        {
            anIngredientIsIn = false;
        }
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
                case INGREDIENTS.BURGUERBREADCHEESE:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERBREADLETTUCE:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERBREADTOMATO:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUER:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERBREADCHEESELETTUCE:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERBREADCHEESETOMATO:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERBREADLETTUCETOMATO:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERCHEESE:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERTOMATO:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERLETTUCE:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERCHEESETOMATO:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERCHEESELETTUCE:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERLETTUCETOMATO:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERVEGETAL:
                    IsBurguer();
                    break;
                case INGREDIENTS.BURGUERWITHALL:
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
                case INGREDIENTS.HOTDOG:
                    IsHotDog();
                    break;
                case INGREDIENTS.HOTDOGKETCHUP:
                    IsHotDog();
                    break;
                case INGREDIENTS.HOTDOGMUSTARD:
                    IsHotDog();
                    break;
                case INGREDIENTS.HOTDOGSAUCE:
                    IsHotDog();
                    break;
                case INGREDIENTS.SAUSAGEKETCHUP:
                    IsHotDog();
                    break;
                case INGREDIENTS.SAUSAGEMUSTARD:
                    IsHotDog();
                    break;
                case INGREDIENTS.SAUSAGESAUCE:
                    IsHotDog();
                    break;

                // Sushi
                case INGREDIENTS.RICEBALL:
                    IsSushi();
                    break;
                case INGREDIENTS.SALMON:
                    IsSushi();
                    break;
                case INGREDIENTS.ALGANORI:
                    IsSushi();
                    break;
                case INGREDIENTS.MAKIROE:
                    IsSushi();
                    break;
                case INGREDIENTS.MAKIRICE:
                    IsSushi();
                    break;
                case INGREDIENTS.MAKISALMON:
                    IsSushi();
                    break;
                case INGREDIENTS.SHUSHISALMON:
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

        bool burguerBread = false;
        bool pattyMeat = false;
        bool cheeseCut = false;
        bool lettuce = false;
        bool tomateSlice = false;
        bool burguerBreadCheese = false;
        bool burguerBreadLettuce = false;
        bool burguerBreadTomato = false;
        bool burguer = false;
        bool burguerCheese = false;
        bool burguerLettuce = false;
        bool burguerTomato = false;
        bool burguerBreadCheeseLettuce = false;
        bool burguerBreadCheeseTomato = false;
        bool burguerBreadLettuceTomato = false;
        bool burguerCheeseTomato = false;
        bool burguerCheeseLettuce = false;
        bool burguerLettuceTomato = false;
        bool burguerVegetal = false;
        //bool burguerWithAll = false;


        foreach (var item in recipe)
        {
            switch (item)
            {
                case INGREDIENTS.BURGUERBREAD:
                    burguerBread = true;
                    break;
                case INGREDIENTS.BURGUERBREADCHEESE:
                    burguerBreadCheese = true;
                    break;
                case INGREDIENTS.BURGUERBREADLETTUCE:
                    burguerBreadLettuce = true;
                    break;
                case INGREDIENTS.BURGUERBREADTOMATO:
                    burguerBreadTomato = true;
                    break;
                case INGREDIENTS.BURGUER:
                    burguer = true;
                    break;
                case INGREDIENTS.BURGUERCHEESE:
                    burguerCheese = true;
                    break;
                case INGREDIENTS.BURGUERTOMATO:
                    burguerTomato = true;
                    break;
                case INGREDIENTS.BURGUERLETTUCE:
                    burguerLettuce = true;
                    break;
                case INGREDIENTS.BURGUERCHEESETOMATO:
                    burguerCheeseTomato = true;
                    break;
                case INGREDIENTS.BURGUERCHEESELETTUCE:
                    burguerCheeseLettuce = true;
                    break;
                case INGREDIENTS.BURGUERLETTUCETOMATO:
                    burguerLettuceTomato = true;
                    break;
                case INGREDIENTS.BURGUERBREADCHEESELETTUCE:
                    burguerBreadCheeseLettuce = true;
                    break;
                case INGREDIENTS.BURGUERBREADCHEESETOMATO:
                    burguerBreadCheeseTomato = true;
                    break;
                case INGREDIENTS.BURGUERBREADLETTUCETOMATO:
                    burguerBreadLettuceTomato = true;
                    break;
                case INGREDIENTS.BURGUERVEGETAL:
                    burguerVegetal = true;
                    break;
                //case INGREDIENTS.BURGUERWITHALL:
                //    burguerWithAll = true;
                //    break;
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
        
        // Empezar con pan de Burguer
        if (burguerBread)
        {
            if (pattyMeat)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUER], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUER);
            }

            if (cheeseCut)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERBREADCHEESE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERBREADCHEESE);
            }

            if (lettuce)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERBREADLETTUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERBREADLETTUCE);
            }

            if (tomateSlice)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERBREADTOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERBREADTOMATO);
            }
        }

        // Burguers basicas
        if (burguer)
        {
            if (cheeseCut)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERCHEESE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERCHEESE);
            }

            if (tomateSlice)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERTOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERTOMATO);
            }

            if (lettuce)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERLETTUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERLETTUCE);
            }
        }

        if (burguerBreadCheese)
        {
            if (pattyMeat)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERCHEESE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERCHEESE);
            }

            if (tomateSlice)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERBREADCHEESETOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERBREADCHEESETOMATO);
            }

            if (lettuce)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERBREADCHEESELETTUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERBREADCHEESELETTUCE);
            }
        }

        if (burguerBreadTomato)
        {
            if (pattyMeat)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERTOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERTOMATO);
            }

            if (cheeseCut)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERBREADCHEESETOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERBREADCHEESETOMATO);
            }

            if (lettuce)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERBREADLETTUCETOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERBREADLETTUCETOMATO);
            }
        }

        if (burguerBreadLettuce)
        {
            if (pattyMeat)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERLETTUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERLETTUCE);
            }

            if (tomateSlice)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERBREADLETTUCETOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERBREADLETTUCETOMATO);
            }

            if (cheeseCut)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERBREADCHEESELETTUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERBREADCHEESELETTUCE);
            }
        }

        // Burguers sin carne y cositas
        if (burguerBreadCheeseLettuce)
        {
            if (pattyMeat)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERCHEESELETTUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERCHEESELETTUCE);

            }
            
            if (tomateSlice)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERVEGETAL], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERVEGETAL);
            }
        }

        if (burguerBreadCheeseTomato)
        {
            if (pattyMeat)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERCHEESETOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERCHEESETOMATO);

            }

            if (lettuce)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERVEGETAL], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERVEGETAL);
            }
        }

        if (burguerBreadLettuceTomato)
        {
            if (pattyMeat)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERLETTUCETOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERLETTUCETOMATO);

            }

            if (cheeseCut)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERVEGETAL], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERVEGETAL);
            }
        }
        
        // Burguers con carne y cositas
        if (burguerCheese)
        {
            if (tomateSlice)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERCHEESETOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERCHEESETOMATO);
            }

            if (lettuce)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERCHEESELETTUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERCHEESELETTUCE);
            }
        }

        if (burguerTomato)
        {
            if (cheeseCut)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERCHEESETOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERCHEESETOMATO);
            }

            if (lettuce)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERLETTUCETOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERLETTUCETOMATO);
            }
        }

        if (burguerLettuce)
        {
            if (cheeseCut)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERCHEESELETTUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERCHEESELETTUCE);
            }

            if (tomateSlice)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERLETTUCETOMATO], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERLETTUCETOMATO);
            }
        }

        // Burguers con carne finales
        if (burguerCheeseTomato)
        {
            if (lettuce)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERWITHALL], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERWITHALL);
            }
        }

        if (burguerCheeseLettuce)
        {
            if (tomateSlice)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERWITHALL], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERWITHALL);
            }
        }

        if (burguerLettuceTomato)
        {
            if (cheeseCut)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERWITHALL], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERWITHALL);
            }
        }

        // Burguer Vegetal 
        if (burguerVegetal)
        {
            if (pattyMeat)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.BURGUERWITHALL], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.BURGUERWITHALL);
            }
        }
    }

    private void MakeHotDog(INGREDIENTS newIngredient)
    {
        recipe.Add(newIngredient);

        bool hotDogBread = false;
        bool sausageMeat = false;
        bool bottleKetchup = false;
        bool bottleMustard = false;
        bool hotDog = false;
        bool hotDogKetchup = false;
        bool hotDogMustard = false;
        bool sausageKetchup = false;
        bool sausageMustard = false;
        bool sausageSauce = false;


        foreach (var item in recipe)
        {
            switch (item)
            {
                case INGREDIENTS.HOTDOGBREAD:
                    hotDogBread = true;
                    break;
                case INGREDIENTS.SAUSAGEMEAT:
                    sausageMeat = true;
                    break;
                case INGREDIENTS.BOTTLEKETCHUP:
                    bottleKetchup = true;
                    break;
                case INGREDIENTS.BOTTLEMUSTARD:
                    bottleMustard = true;
                    break;
                case INGREDIENTS.HOTDOG:
                    hotDog = true;
                    break;
                case INGREDIENTS.HOTDOGKETCHUP:
                    hotDogKetchup = true;
                    break;
                case INGREDIENTS.HOTDOGMUSTARD:
                    hotDogMustard = true;
                    break;
                case INGREDIENTS.SAUSAGEKETCHUP:
                    sausageKetchup = true;
                    break;
                case INGREDIENTS.SAUSAGEMUSTARD:
                    sausageMustard = true;
                    break;
                case INGREDIENTS.SAUSAGESAUCE:
                    sausageSauce = true;
                    break;
            }
        }

        // Comprobar que Ingredientes estan (son true) y hacer las combinaciones instaciando las fusiones

        // Empezar con pan de HotDog
        if (hotDogBread)
        {
            if (sausageMeat)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.HOTDOG], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.HOTDOG);
            }
        }

        // Empezar con HotDog
        if (sausageMeat)
        {
            if (hotDogBread)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.HOTDOG], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.HOTDOG);
            }

            if (bottleKetchup)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.SAUSAGEKETCHUP], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.SAUSAGEKETCHUP);
            }

            if (bottleMustard)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.SAUSAGEMUSTARD], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.SAUSAGEMUSTARD);
            }
        }

        // Pan y HotDog
        if (hotDog)
        {
            if (bottleKetchup)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.HOTDOGKETCHUP], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.HOTDOGKETCHUP);
            }

            if (bottleMustard)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.HOTDOGMUSTARD], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.HOTDOGMUSTARD);
            }
        }

        // HotDog y salsa
        if (sausageKetchup)
        {
            if (hotDogBread)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.HOTDOGKETCHUP], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.HOTDOGKETCHUP);
            }

            if (bottleMustard)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.SAUSAGESAUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.SAUSAGESAUCE);
            }
        }

        if (sausageMustard)
        {
            if (hotDogBread)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.HOTDOGMUSTARD], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.HOTDOGMUSTARD);
            }

            if (bottleKetchup)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.SAUSAGESAUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.SAUSAGESAUCE);
            }
        }

        // HotDog y salsas
        if (sausageSauce)
        {
            if (hotDogBread)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.HOTDOGSAUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.HOTDOGSAUCE);
            }
        }

        if (hotDogKetchup)
        {
            if (bottleMustard)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.HOTDOGSAUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.HOTDOGSAUCE);
            }
        }

        if (hotDogMustard)
        {
            if (bottleKetchup)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.HOTDOGSAUCE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.HOTDOGSAUCE);
            }
        }
    }

    private void MakeShushi(INGREDIENTS newIngredient)
    {
        recipe.Add(newIngredient);

        bool salmon = false;
        bool rice = false;
        bool algaNori = false;
        bool makiRice = false;
        bool makiSalmon = false;
        bool shushiSalmon = false;


        foreach (var item in recipe)
        {
            switch (item)
            {
                case INGREDIENTS.SALMON:
                    salmon = true;
                    break;
                case INGREDIENTS.RICEBALL:
                    rice = true;
                    break;
                case INGREDIENTS.ALGANORI:
                    algaNori = true;
                    break;
                case INGREDIENTS.SHUSHISALMON:
                    shushiSalmon = true;
                    break;
                case INGREDIENTS.MAKIRICE:
                    makiRice = true;
                    break;
                case INGREDIENTS.MAKISALMON:
                    makiSalmon = true;
                    break;
            }
        }

        // Comprobar que Ingredientes estan (son true) y hacer las combinaciones instaciando las fusiones

        // Empezar con simples
        if (rice)
        {
            if (salmon)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.SHUSHISALMON], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.SHUSHISALMON);
            }

            if (algaNori)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.MAKIRICE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.MAKIRICE);
            }
        }
    
        if (salmon)
        {
            if (rice)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.SHUSHISALMON], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.SHUSHISALMON);
            }

            if (algaNori)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.MAKISALMON], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.MAKISALMON);
            }
        }

        if (algaNori)
        {
            if (rice)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.MAKIRICE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.MAKIRICE);
            }

            if (salmon)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.MAKISALMON], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.MAKISALMON);
            }
        }

        // Dobletes
        if (makiSalmon)
        {
            if (rice)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.MAKIROE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.MAKIROE);
            }
        }

        if (makiRice)
        {
            if (salmon)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.MAKIROE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.MAKIROE);
            }
        }

        if (shushiSalmon)
        {
            if (algaNori)
            {
                foreach (var item in objectsRecipe)
                {
                    Destroy(item);
                }
                objectsRecipe.Clear();

                GameObject p = Instantiate(Ingredients[(int)INGREDIENTS.MAKIROE], transform.position, transform.rotation);
                objectsRecipe.Add(p);

                UpdateRecipe(INGREDIENTS.MAKIROE);
            }
        }
    }

    private void UpdateRecipe(INGREDIENTS ingredient)
    {
        recipe.Clear();
        recipe.Add(ingredient);
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

                // Mano
                case "Player":
                    isGrabbingInPlate = true;
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
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BurguerBreadTomato":
                    if (!CheckIngredient(INGREDIENTS.BURGUERBREADTOMATO))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERBREADTOMATO;
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERBREADTOMATO);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BurguerBreadLettuce":
                    if (!CheckIngredient(INGREDIENTS.BURGUERBREADLETTUCE))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERBREADLETTUCE;
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERBREADLETTUCE);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BurguerBreadCheese":
                    if (!CheckIngredient(INGREDIENTS.BURGUERBREADCHEESE))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERBREADCHEESE;
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERBREADCHEESE);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
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
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
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
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BurguerTomato":
                    if (!CheckIngredient(INGREDIENTS.BURGUERTOMATO))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERTOMATO;
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERTOMATO);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BurguerLettuce":
                    if (!CheckIngredient(INGREDIENTS.BURGUERLETTUCE))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERLETTUCE;
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERLETTUCE);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
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
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BurguerCheeseLettuce":
                    if (!CheckIngredient(INGREDIENTS.BURGUERCHEESELETTUCE))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERCHEESELETTUCE;
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERCHEESELETTUCE);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BurguerLettuceTomtato":
                    if (!CheckIngredient(INGREDIENTS.BURGUERLETTUCETOMATO))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERLETTUCETOMATO;
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERLETTUCETOMATO);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BurguerBreadCheeseTomtato":
                    if (!CheckIngredient(INGREDIENTS.BURGUERBREADCHEESETOMATO))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERBREADCHEESETOMATO;
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERBREADCHEESETOMATO);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BurguerBreadCheeseLettuce":
                    if (!CheckIngredient(INGREDIENTS.BURGUERBREADCHEESELETTUCE))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERBREADCHEESELETTUCE;
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERBREADCHEESELETTUCE);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BurguerBreadLettuceTomtato":
                    if (!CheckIngredient(INGREDIENTS.BURGUERBREADLETTUCETOMATO))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERBREADLETTUCETOMATO;
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERBREADLETTUCETOMATO);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BurguerVegetal":
                    if (!CheckIngredient(INGREDIENTS.BURGUERVEGETAL))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERVEGETAL;
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeBurguer(INGREDIENTS.BURGUERVEGETAL);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BurguerWithAll":
                    if (!CheckIngredient(INGREDIENTS.BURGUERWITHALL))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isHotDog && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BURGUERWITHALL;
                                AddToObjectRecipe(other.gameObject);

                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                //MakeBurguer(INGREDIENTS.BURGUERWITHALL);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
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
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
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
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
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
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
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
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                // HotDog
                case "HotDogBread":
                    if (!CheckIngredient(INGREDIENTS.HOTDOGBREAD))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.HOTDOGBREAD;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeHotDog(INGREDIENTS.HOTDOGBREAD);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "SausageMeat":
                    if (!CheckIngredient(INGREDIENTS.SAUSAGEMEAT))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.SAUSAGEMEAT;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeHotDog(INGREDIENTS.SAUSAGEMEAT);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BottleKetchup":
                    if (!CheckIngredient(INGREDIENTS.BOTTLEKETCHUP))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BOTTLEKETCHUP;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeHotDog(INGREDIENTS.BOTTLEKETCHUP);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "BottleMustard":
                    if (!CheckIngredient(INGREDIENTS.BOTTLEMUSTARD))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.BOTTLEMUSTARD;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeHotDog(INGREDIENTS.BOTTLEMUSTARD);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "HotDog":
                    if (!CheckIngredient(INGREDIENTS.HOTDOG))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.HOTDOG;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeHotDog(INGREDIENTS.HOTDOG);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "HotDogKetchup":
                    if (!CheckIngredient(INGREDIENTS.HOTDOGKETCHUP))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.HOTDOGKETCHUP;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeHotDog(INGREDIENTS.HOTDOGKETCHUP);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "HotDogMustard":
                    if (!CheckIngredient(INGREDIENTS.HOTDOGMUSTARD))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.HOTDOGMUSTARD;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeHotDog(INGREDIENTS.HOTDOGMUSTARD);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "HotDogSauce":
                    if (!CheckIngredient(INGREDIENTS.HOTDOGSAUCE))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.HOTDOGSAUCE;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "SausageKetchup":
                    if (!CheckIngredient(INGREDIENTS.SAUSAGEKETCHUP))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.SAUSAGEKETCHUP;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeHotDog(INGREDIENTS.SAUSAGEKETCHUP);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "SausageMustard":
                    if (!CheckIngredient(INGREDIENTS.SAUSAGEMUSTARD))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.SAUSAGEMUSTARD;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeHotDog(INGREDIENTS.SAUSAGEMUSTARD);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "SausageSauce":
                    if (!CheckIngredient(INGREDIENTS.SAUSAGESAUCE))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isSushi)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.SAUSAGESAUCE;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeHotDog(INGREDIENTS.SAUSAGESAUCE);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                // Sushi
                case "RiceBall":
                    if (!CheckIngredient(INGREDIENTS.RICEBALL))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isHotDog)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.RICEBALL;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeShushi(INGREDIENTS.RICEBALL);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "Salmon":
                    if (!CheckIngredient(INGREDIENTS.SALMON))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isHotDog)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.SALMON;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeShushi(INGREDIENTS.SALMON);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "AlgaNori":
                    if (!CheckIngredient(INGREDIENTS.ALGANORI))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isHotDog)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.ALGANORI;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeShushi(INGREDIENTS.ALGANORI);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "MakiSalmon":
                    if (!CheckIngredient(INGREDIENTS.MAKISALMON))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isHotDog)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.MAKISALMON;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeShushi(INGREDIENTS.MAKISALMON);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "MakiRice":
                    if (!CheckIngredient(INGREDIENTS.MAKIRICE))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isHotDog)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.MAKIRICE;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeShushi(INGREDIENTS.MAKIRICE);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "MakiRoe":
                    if (!CheckIngredient(INGREDIENTS.MAKIROE))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isHotDog)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.MAKIROE;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeShushi(INGREDIENTS.MAKIROE);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                case "ShushiSalmon":
                    if (!CheckIngredient(INGREDIENTS.SHUSHISALMON))
                    {
                        // No esta este ingrediente en el plato
                        // Compruebo que no se esta haciendo otra receta
                        if (!isBurguer && !isPizza && !isHotDog)
                        {
                            // Lo añado al array
                            if (CheckFirstIngredientIsNotNONE())
                            {
                                recipe[0] = INGREDIENTS.SHUSHISALMON;
                                AddToObjectRecipe(other.gameObject);
                            }
                            else
                            {
                                // Hacer la combinacion de ingredientes
                                AddToObjectRecipe(other.gameObject);
                                MakeShushi(INGREDIENTS.SHUSHISALMON);
                            }
                            isColliding = true;
                        }
                    }
                    else
                    {
                        isColliding = false;
                    }
                    anIngredientIsIn = true;
                    break;

                    // Pizza

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!anIngredientIsIn)
        {
            switch (other.gameObject.tag)
            {
                default:
                    break;
                // Mano
                case "Player":
                    isGrabbingInPlate = false;
                    break;

                // Burguer
                case "BurguerBread":
                    ResetBools();
                    break;

                case "BurguerBreadTomato":
                    ResetBools();
                    break;

                case "BurguerBreadLettuce":
                    ResetBools();
                    break;

                case "BurguerBreadCheese":
                    ResetBools();
                    break;

                case "Burguer":
                    ResetBools();
                    break;

                case "BurguerCheese":
                    ResetBools();
                    break;

                case "BurguerTomato":
                    ResetBools();
                    break;

                case "BurguerLettuce":
                    ResetBools();
                    break;

                case "BurguerCheeseTomtato":
                    ResetBools();
                    break;

                case "BurguerCheeseLettuce":
                    ResetBools();
                    break;

                case "BurguerLettuceTomtato":
                    ResetBools();
                    break;

                case "BurguerBreadCheeseTomtato":
                    ResetBools();
                    break;

                case "BurguerBreadCheeseLettuce":
                    ResetBools();
                    break;

                case "BurguerBreadLettuceTomtato":
                    ResetBools();
                    break;

                case "BurguerVegetal":
                    ResetBools();
                    break;

                case "BurguerWithAll":
                    ResetBools();
                    break;

                case "CheeseCut":
                    ResetBools();
                    break;

                case "Lettuce":
                    ResetBools();
                    break;

                case "PattyMeat":
                    ResetBools();
                    break;

                case "TomatoSlice":
                    ResetBools();
                    break;

                // HotDog
                case "HotDogBread":
                    ResetBools();
                    break;

                case "SausageMeat":
                    ResetBools();
                    break;

                case "BottleKetchup":
                    ResetBools();
                    break;

                case "BottleMustard":
                    ResetBools();
                    break;

                case "HotDog":
                    ResetBools();
                    break;

                case "HotDogKetchup":
                    ResetBools();
                    break;
                    
                case "HotDogMustard":
                    ResetBools();
                    break;

                case "HotDogSauce":
                    ResetBools();
                    break;

                case "SausageKetchup":
                    ResetBools();
                    break;

                case "SausageMustard":
                    ResetBools();
                    break;

                case "SausageSauce":
                    ResetBools();
                    break;

                // Sushi
                case "RiceBall":
                    ResetBools();
                    break;

                case "Salmon":
                    ResetBools();
                    break;

                case "AlgaNori":
                    ResetBools();
                    break;

                case "MakiSalmon":
                    ResetBools();
                    break;

                case "MakiRice":
                    ResetBools();
                    break;

                case "MakiRoe":
                    ResetBools();
                    break;

                case "ShushiSalmon":
                    ResetBools();
                    break;

                    // Pizza
            }
        }
    }

    private void ResetBools()
    {
        recipe[0] = INGREDIENTS.NONE;
        lastIngredient = recipe[0];
        objectsRecipe.Clear();

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
