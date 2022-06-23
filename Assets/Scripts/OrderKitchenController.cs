using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderKitchenController : MonoBehaviour
{
    [SerializeField] ComputerScreenController computerScreenController;
    [SerializeField] RecipesManager recipeManager;
    private RecipeController recipeController;
    private GameObject tmpObjectInRecipe;

    [Header("VFX")]
    [SerializeField] ParticleSystem NegativeFiftyPoints;
    [SerializeField] ParticleSystem FiftyPoints;
    [SerializeField] ParticleSystem HundredPoints;
    [SerializeField] ParticleSystem HundredFiftyPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plate")
        {
            // pillo lo que tenga el plato
            recipeController = other.gameObject.GetComponent<RecipeController>();
            tmpObjectInRecipe = recipeController.GetObjectRecipe();

            // destruir el gameobject y el plato
            Destroy(other.transform.parent.gameObject);
            recipeController.DestroyRecipe();

            if (recipeManager.CheckIfRecipeIsOnDemand(tmpObjectInRecipe)) 
            // comprobar si existe el pedido o no
            {
                // sumar puntos
                PointsManager._POINTS_MANAGER.ScorePoints(computerScreenController.GetFillAmountFromAnObject(tmpObjectInRecipe));

                // emite la cantidad de puntos 
                EmitParticle(computerScreenController.GetFillAmountFromAnObject(tmpObjectInRecipe));

                // borrarla del canvas y de la lista de recetas
                computerScreenController.DestoyRecipeFromList(tmpObjectInRecipe);
            }
            else
            {
                PointsManager._POINTS_MANAGER.SubstractPoints(PointsManager._POINTS_MANAGER.failedRecipePoints);
                EmitParticle(-1);
            }
        }
    }

    private void EmitParticle(float value)
    {
        if (value > 0.6f)
        {
            HundredFiftyPoints.Play();
        }
        else if (value < 0.6f && value > 0.3f)
        {
            HundredPoints.Play();
        }
        else if (value < 0.3f && value >= 0f)
        {
            FiftyPoints.Play();
        }
        else
        {
            NegativeFiftyPoints.Play();
        }
    }
}
