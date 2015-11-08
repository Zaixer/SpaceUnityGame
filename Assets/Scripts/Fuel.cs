using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public int CurrentFuel { get { return _collectedFuel - Mathf.Abs(Mathf.RoundToInt(Player.Instance.Position.y)); } }

    private Text _text;
    private int _collectedFuel = 100;
    
    void Start()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = CurrentFuel.ToString();
    }
}
