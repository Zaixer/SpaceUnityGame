using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance;
    public int CurrentScore { get { return Mathf.Abs(Mathf.RoundToInt(Player.Instance.Position.y)); } }
    public Text FinalScoreText;

    private Text _text;

    void Awake()
    {
        Instance = this;
        _text = GetComponent<Text>();
    }
    
    void Update()
    {
        if (Player.Instance.IsAlive)
        {
            _text.text = CurrentScore.ToString();
        }
    }

    public void SetEndScore()
    {
        FinalScoreText.text = CurrentScore.ToString();
    }
}
