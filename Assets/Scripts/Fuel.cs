using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public static Fuel Instance;
    public float StartFuel = 200f;
    public float FuelIncreasePerPickup = 100f;
    public float FuelDecreasePerFrame = 0.1f;

    private float _currentFuel;
    private Text _text;
    
    void Start()
    {
        Instance = this;
        _text = GetComponent<Text>();
        _currentFuel = StartFuel;
    }

    void Update()
    {
        _currentFuel -= FuelDecreasePerFrame;
        if (_currentFuel <= 0f)
        {
            Player.Instance.StopMoving();
        }
        _text.text = Mathf.Max(Mathf.RoundToInt(_currentFuel), 0f).ToString();
    }

    public void IncreaseFuel()
    {
        _currentFuel += FuelIncreasePerPickup;
    }
}
