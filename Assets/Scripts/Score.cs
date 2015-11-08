using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public int CurrentScore { get { return Mathf.Abs(Mathf.RoundToInt(Player.Instance.Position.y)); } }

    private Text _text;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _text = GetComponent<Text>();
    }
    
    void Update()
    {
        _text.text = CurrentScore.ToString();
    }
}
