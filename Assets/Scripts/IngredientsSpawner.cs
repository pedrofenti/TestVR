using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsSpawner : MonoBehaviour
{
    [SerializeField] GameObject ingredient;
    [SerializeField] GameObject[] sockets;

    // Start is called before the first frame update
    void Start()
    {
        InitIngredients();
    }

    private void InitIngredients()
    {
        for (int i = 0; i < sockets.Length; i++)
        {
            Instantiate(ingredient, sockets[i].transform.position, sockets[i].transform.rotation);
        }
    }

    public void SpawnAnIngredient(int num)
    {
        Instantiate(ingredient, sockets[num].transform.position, sockets[num].transform.rotation);
    }
}
