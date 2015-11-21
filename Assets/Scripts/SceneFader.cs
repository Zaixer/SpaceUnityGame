using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance;
    public float FadeSpeed = 1f;

    private Image _image;
    private bool _isStartingScene = true;
    private bool _isEndingScene;
    private string _nameOfNextScene;
    
    void Awake()
    {
        Instance = this;
        _image = GetComponentInChildren<Image>();
        _image.color = Color.black;
    }


    void Update()
    {
        if (_isStartingScene)
        {
            ContinueFadingToClear();
            if (_image.color.a < 0.01f)
            {
                _image.color = Color.clear;
                _image.enabled = false;
                _isStartingScene = false;
            }
        }
        else if (_isEndingScene)
        {
            ContinueFadingToBlack();
            if (_image.color.a > 0.99f)
            {
                Application.LoadLevel(_nameOfNextScene);
            }
        }
    }

    public void LoadNewScene(string nameOfNexScene)
    {
        _image.enabled = true;
        _nameOfNextScene = nameOfNexScene;
        _isStartingScene = false;
        _isEndingScene = true;
    }

    private void ContinueFadingToClear()
    {
        _image.color = Color.Lerp(_image.color, Color.clear, FadeSpeed * Time.deltaTime);
    }
    
    private void ContinueFadingToBlack()
    {
        _image.color = Color.Lerp(_image.color, Color.black, FadeSpeed * Time.deltaTime);
    }
}
