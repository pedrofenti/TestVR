using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderKitchenController : MonoBehaviour
{
    public GameObject tmp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plate")
        {
            tmp = other.gameObject.GetComponent<RecipeController>().objectsRecipe[0];

        }
    }
}
