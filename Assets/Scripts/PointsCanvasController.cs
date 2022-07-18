using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCanvasController : MonoBehaviour
{
    [SerializeField] Text text;

    void Update()
    {
        text.text = PointsManager._POINTS_MANAGER.GetPoints().ToString();
    }
}
