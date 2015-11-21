using UnityEngine;
using UnityEngine.EventSystems;

public class SceneChangeButton : MonoBehaviour, IPointerClickHandler
{
    public string NameOfNextScene;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneFader.Instance.LoadNewScene(NameOfNextScene);
    }
}
