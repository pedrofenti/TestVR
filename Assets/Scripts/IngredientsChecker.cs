using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsChecker : MonoBehaviour
{
    [SerializeField] IngredientsSpawner ingredientsSpawner;

    [SerializeField] GameObject ingredient;
    [SerializeField] int socketNum;

    private bool canSpawn;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                ingredientsSpawner.SpawnAnIngredient(socketNum);
                timer = 0;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ingredient.tag)
        {
            canSpawn = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ingredient.tag)
        {
            canSpawn = true;
        }
    }
}
