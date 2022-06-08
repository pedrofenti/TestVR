using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager _POINTS_MANAGER;

    public int points = 0;
    public int failedRecipePoints = 75;
    public int perfectRecipePoints = 150;
    public int mediumRecipePoints = 100;
    public int chillRecipePoints = 50;

    private void Awake()
    {
        if (_POINTS_MANAGER != null && _POINTS_MANAGER != this)
        {
            Destroy(_POINTS_MANAGER);
        }
        else
        {
            _POINTS_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }

    public void SubstractPoints(int value)
    {
        points -= value;
    }

    public void ScorePoints(int value)
    {
        points += value;
    }
}
