using UnityEngine;
using UnityEngine.EventSystems;

public class StartButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject LoadingImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneFader.Instance.StartNextLevel("Game");
    }
}
