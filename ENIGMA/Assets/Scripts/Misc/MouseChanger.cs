using UnityEngine;

public class MouseChanger : MonoBehaviour
{
    public Texture2D cursorTexture;
    void Start()
    {

        Cursor.SetCursor(cursorTexture, new Vector3(0, 0, 0), CursorMode.Auto);
    }
}
