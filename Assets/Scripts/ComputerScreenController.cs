using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScreenController : MonoBehaviour
{
    [SerializeField] RecipesManager recipesManager;

    private bool tmpLevel;
    private bool BurguerLevel;
    private bool HotdogLevel;
    private bool SushiLevel;

    // Start is called before the first frame update
    void Start()
    {
        tmpLevel = recipesManager.GetWichRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
