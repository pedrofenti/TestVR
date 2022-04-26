using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPanController : MonoBehaviour
{
    private bool isFrying;

    // Start is called before the first frame update
    void Start()
    {
        isFrying = false;
    }
    public bool getFrying()
    {
        return isFrying;
    }

    public void Activate()
    {
        isFrying = true;
    }

    public void Deactivate()
    {
        isFrying = false;
    }
}
