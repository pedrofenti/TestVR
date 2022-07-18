using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager _POINTS_MANAGER;

    public int points = 0;
    public int failedRecipePoints = 50;
    public int outOfTimeRecipePoints = 75;
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

    public void ScorePoints(float value)
    {
        if (value > 0.6f)
        {
            points += perfectRecipePoints;
        }
        else if(value < 0.6f && value > 0.3f)
        {
            points += mediumRecipePoints;
        }
        else if (value < 0.3f)
        {
            points += chillRecipePoints;
        }
    }

    public int GetPoints()
    {
        return points;
    }
}
