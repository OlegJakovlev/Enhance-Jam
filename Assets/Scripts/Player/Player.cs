using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour
{
    private float _score;
    

    private Dictionary<string, int> cubesCollected = new Dictionary<string, int>()
    {
        { "Small", 0 },
        { "Big", 0 },
        { "Enormous", 0 }
    };

    [SerializeField] private float _maxScore = 100;

    private Movement controller;
    private float _weight;

    // Lighting
    [SerializeField] private Light _lighting;
    [SerializeField] private Gradient _gradient;

    private void Awake()
    {
        controller = GetComponent<Movement>();
    }

    public void IncrementOnlyScore(int _points)
    {
        _score += _points;
    }

    public void IncrementScore(int _points)
    {
        AddToCollectedItems(_points);
        //IncrementOnlyScore(_points);
        _weight += _points;
        UpdateColor();
    }

    private void UpdateColor()
    {
        _lighting.color = _gradient.Evaluate(_weight / _maxScore);
    }

    private void AddToCollectedItems(int points)
    {
        switch (points)
        {
            case (5):
                ++cubesCollected["Small"];
                break;

            case (15):
                ++cubesCollected["Big"];
                break;

            case (35):
                ++cubesCollected["Enormous"];
                break;
        }
    }

    public string GetCube()
    {
        List<string> availableCubes = new List<string>();

        if (cubesCollected["Small"] > 0)
        {
            availableCubes.Add("Small");
        }
        if (cubesCollected["Big"] > 0)
        {
            availableCubes.Add("Big");
        }
        if (cubesCollected["Enormous"] > 0)
        {
            availableCubes.Add("Enormous");
        }

        if (availableCubes.Count <= 0) return "";

        int index = Random.Range(0, availableCubes.Count);
        string result = availableCubes[index];

        int difference = 0;
        if (result == "Small")
        {
            difference = 5;
        }
        if (result == "Big")
        {
            difference = 15;
        }
        if (result == "Enormous")
        {
            difference = 35;
        }

        controller.IncreaseSpeed(difference);
        _weight -= difference;

        UpdateColor();

        cubesCollected[result]--;

        return result;
    }

    public float GetScore()
    {
        return _score;
    }
}
