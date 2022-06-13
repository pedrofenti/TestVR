using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderKitchenController : MonoBehaviour
{
    [SerializeField] ComputerScreenController computerScreenController;
    [SerializeField] RecipesManager recipeManager;
    private RecipeController recipeController;
    private GameObject tmp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plate")
        {
            // pillo lo que tenga el plato
            recipeController = other.gameObject.GetComponent<RecipeController>();
            tmp = recipeController.GetObjectRecipe();

            // destruir el gameobject y el plato
            Destroy(other.transform.parent.gameObject);
            recipeController.DestroyRecipe();

            if (recipeManager.CheckIfRecipeIsOnDemand(tmp)) 
            // comprobar si existe el pedido o no
            {
                // sumar puntos
                PointsManager._POINTS_MANAGER.ScorePoints(computerScreenController.GetFillAmountFromAnObject(tmp));

                // borrarla del canvas y de la lista de recetas
                computerScreenController.DestoyRecipeFromList(tmp);
            }
            else
            {
                PointsManager._POINTS_MANAGER.SubstractPoints(PointsManager._POINTS_MANAGER.failedRecipePoints);
            }
        }
    }
}
