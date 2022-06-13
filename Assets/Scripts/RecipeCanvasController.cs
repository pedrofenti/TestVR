using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeCanvasController : MonoBehaviour
{
    [SerializeField] int list;
    [SerializeField] string objectName;
    [SerializeField] int objectNum;
    [SerializeField] Image timer; 
    [SerializeField] float spendTime;
    private float counter = 1;

    private float colorCounter = 1;
    private float colorSpendTime = 15;

    private RecipesManager recipesManager;

    private void Awake()
    {
        recipesManager = FindObjectOfType<RecipesManager>().GetComponent<RecipesManager>();
    }

    void Update()
    {
        counter -= Time.deltaTime / spendTime;

        // Size of the image
        timer.fillAmount = Mathf.Lerp(0, 1, counter);
        if (timer.fillAmount <= 0)
        {
            PointsManager._POINTS_MANAGER.SubstractPoints(PointsManager._POINTS_MANAGER.outOfTimeRecipePoints);
            recipesManager.RemoveGameObjectFromList(list, objectName, objectNum);
            Destroy(gameObject);
        }

        // Color change
        if (timer.color.r == 1)
        {
            colorCounter += Time.deltaTime / colorSpendTime;
            timer.color = new Color(1, Mathf.Lerp(1, 0, colorCounter), 0);
        }
        else
        {
            timer.color = new Color(Mathf.Lerp(1, 0, colorCounter), 1, 0);
            colorCounter -= Time.deltaTime / colorSpendTime;
        } 
    }

    public float GetTimerFillAmount() { return timer.fillAmount; }

    public void DestroyObject() { Destroy(gameObject); }
}
