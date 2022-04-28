using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoilFoodController : MonoBehaviour
{
    [SerializeField]
    private GameObject finalFood;
    [SerializeField]
    private GameObject foodCanvas;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float speed;

    private PotController potController;

    private bool isBoiling;

    private void Awake()
    {
        potController = GameObject.FindGameObjectWithTag("BoilKitchenStove").GetComponent<PotController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        foodCanvas.SetActive(false);
        isBoiling = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfBoiling();
    }

    private void CheckIfBoiling()
    {
        if (isBoiling && potController.getBoiling())
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
        if (other.gameObject.tag == "Pot")
        {
            isBoiling = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pot")
        {
            isBoiling = false;
        }
    }
}
