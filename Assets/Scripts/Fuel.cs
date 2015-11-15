using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public static Fuel Instance;

    private const float FuelDecreasePerFrame = 0.1f;
    private float _currentFuel = 100f;
    private Text _text;
    
    void Start()
    {
        Instance = this;
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _currentFuel -= FuelDecreasePerFrame;
        if (_currentFuel <= 0f)
        {
            Application.LoadLevel("Menu");
        }
        _text.text = Mathf.RoundToInt(_currentFuel).ToString();
    }

    public void IncreaseFuel(float amount)
    {
        _currentFuel += amount;
    }
}
