using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrimaryFoodController : MonoBehaviour
{
    [SerializeField]
    private GameObject finalFood;
    [SerializeField]
    private GameObject foodCanvas;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float speed;

    private bool isCutting;
    private bool isOnCuttingBoard;

    // Start is called before the first frame update
    void Start()
    {
        foodCanvas.SetActive(false);
        isCutting = false;
        isOnCuttingBoard = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnCuttingBoard) CheckIfCutting();
    }

    private void CheckIfCutting()
    {
        if (isCutting)
        {
            foodCanvas.SetActive(true);
            slider.value += Time.deltaTime * speed;

            if (slider.value == 1)
            {
                Instantiate(finalFood, transform.position, transform.rotation);
                foodCanvas.SetActive(false);
                slider.value = 0;
                Destroy(gameObject);
            }
        }
        else
        {
            slider.value -= Time.deltaTime * speed;

            if (slider.value == 0)
            {
                foodCanvas.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.tag)
        {
            default:
                break;

            case "CuttingBoard":
                isOnCuttingBoard = true;
                break;

            case "Knife":
                isCutting = true;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            default:
                break;

            case "CuttingBoard":
                isOnCuttingBoard = false;
                break;

            case "Knife":
                isCutting = false;
                break;
        }
    }
}
