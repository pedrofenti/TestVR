using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryFoodController : MonoBehaviour
{
    [SerializeField]
    GameObject FoodCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Knife")
        {
            Debug.Log("cutting");
        }
    }
}
