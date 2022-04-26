using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FryFoodController : MonoBehaviour
{
    [SerializeField]
    private GameObject finalFood;
    [SerializeField]
    public GameObject foodCanvas;
    [SerializeField]
    public Slider slider;
    [SerializeField]
    private float speed;

    private FryingPanController fryingPan;

    private bool isFrying;

    private void Awake()
    {
        fryingPan = GameObject.FindGameObjectWithTag("KitchenStove").GetComponent<FryingPanController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        foodCanvas.SetActive(false);
        isFrying = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfFrying();
    }

    private void CheckIfFrying()
    {
        if (isFrying && fryingPan.getFrying())
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
        if (other.gameObject.tag == "FryingPan")
        {
            isFrying = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "FryingPan")
        {
            isFrying = false;
        }
    }
}
