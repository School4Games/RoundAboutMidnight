using UnityEngine;
using System.Collections;

public class CursorSystem : MonoBehaviour {

    public Texture2D originalCursor;

    private int cursorSizeX = 32;
    private int cursorSizeY = 32;

    public bool showOriginal = false;

    void Awake()
    {
        Screen.showCursor = false;
    }

    void OnGUI()
    {
        if(showOriginal)
        {
            GUI.DrawTexture(new Rect(Input.mousePosition.x - cursorSizeX / 2 + cursorSizeX / 2, (Screen.height - Input.mousePosition.y) - cursorSizeY / 2 + cursorSizeY / 2, cursorSizeX, cursorSizeY), originalCursor);
        }
    }
}
