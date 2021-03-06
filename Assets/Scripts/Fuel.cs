﻿using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public static Fuel Instance;
    public float StartFuel = 100f;
    public float FuelIncreasePerPickup = 50f;
    public float FuelDecreasePerFrame = 0.1f;

    private float _currentFuel;
    private Text _text;
    
    void Awake()
    {
        Instance = this;
        _text = GetComponent<Text>();
        _currentFuel = StartFuel;
    }

    void Update()
    {
        if (Player.Instance.IsAlive)
        {
            _currentFuel -= FuelDecreasePerFrame;
            _text.text = Mathf.Max(Mathf.RoundToInt(_currentFuel), 0f).ToString();
            if (_currentFuel <= 0f)
            {
                Player.Instance.EndGame();
            }
        }
    }

    public void IncreaseFuel()
    {
        _currentFuel += FuelIncreasePerPickup;
    }
}
