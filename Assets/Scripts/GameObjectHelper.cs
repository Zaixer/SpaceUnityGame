using UnityEngine;

public class GameObjectHelper
{
    private const string ClonedObjectSuffix = "(Clone)";

    public static string GetOriginalResourceName(GameObject gameObject)
    {
        var index = gameObject.name.LastIndexOf(ClonedObjectSuffix);
        var isCloned = index != -1;
        return isCloned ? gameObject.name.Remove(index, ClonedObjectSuffix.Length) : gameObject.name;
    }
}
