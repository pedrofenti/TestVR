using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotController : MonoBehaviour
{
    private bool isBoiling;

    // Start is called before the first frame update
    void Start()
    {
        isBoiling = false;
    }
    public bool getBoiling()
    {
        return isBoiling;
    }

    public void Activate()
    {
        isBoiling = true;
    }

    public void Deactivate()
    {
        isBoiling = false;
    }
}
