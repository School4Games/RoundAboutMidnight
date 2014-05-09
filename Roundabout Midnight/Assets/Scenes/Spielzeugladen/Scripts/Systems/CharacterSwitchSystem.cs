using UnityEngine;
using System.Collections.Generic;
using System;

public class CharacterSwitchSystem : MonoBehaviour {

    public CursorSystem cursorSystem;

    public GUIStyle selectedBoxStyle, unselectedBoxStyle;

    public float clampRadius;
    public Vector2 mousePosition;
    public List<WeaponWheelButton> buttons;
    public WeaponWheelButton currentlySelectedButton;
    public bool weaponWheelOpened;

    void Start()
    {
        #region Button-adding
        WeaponWheelButton test1 = new WeaponWheelButton();
        test1.name = "Ball 1";
        test1.rect = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 100, 100);
        test1.OnClickButton += HandleOnClickButton;

        buttons.Add(test1);

        WeaponWheelButton test2 = new WeaponWheelButton();
        test2.name = "Ball 2";
        test2.rect = new Rect(Screen.width / 2 - 50, Screen.height / 2 - 125, 100, 100);
        test2.OnClickButton += HandleOnClickButton2;

        buttons.Add(test2);

        WeaponWheelButton test3 = new WeaponWheelButton();
        test3.name = "Ball 3";
        test3.rect = new Rect(Screen.width / 2 - 250, Screen.height / 2 - 125, 100, 100);
        test3.OnClickButton += HandleOnClickButton3;

        buttons.Add(test3);
        #endregion
    }

    void HandleOnClickButton(WeaponWheelButton me)
    {
        CharacterSwitchManager.Instance.ChangeCurrentPlayer(Player.GetPlayerByName(me.name));
    }
    void HandleOnClickButton2(WeaponWheelButton me)
    {
        CharacterSwitchManager.Instance.ChangeCurrentPlayer(Player.GetPlayerByName(me.name));
    }
    void HandleOnClickButton3(WeaponWheelButton me)
    {
        CharacterSwitchManager.Instance.ChangeCurrentPlayer(Player.GetPlayerByName(me.name));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            weaponWheelOpened = true;
            cursorSystem.showOriginal = true;
            CharacterSwitchManager.Instance.smoothCameraMovementScript.enabled = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            weaponWheelOpened = false;
            cursorSystem.showOriginal = false;
            CharacterSwitchManager.Instance.smoothCameraMovementScript.enabled = true;

            currentlySelectedButton.Click();
        }

        if (Input.GetMouseButtonDown(1) && currentlySelectedButton != null)
            currentlySelectedButton.Click();

        if (!weaponWheelOpened)
            return;

        if (currentlySelectedButton != null)
            currentlySelectedButton.usedGUIStyle = selectedBoxStyle;
        foreach (var b in buttons)
        {
            if (b != currentlySelectedButton)
                b.usedGUIStyle = unselectedBoxStyle;
        }

        mousePosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        #region Check
        SortButtons();
        currentlySelectedButton = buttons[0];
        #endregion
    }

    void OnGUI()
    {
        if (!weaponWheelOpened)
            return;

        Vector2 mouse = new Vector2(Mathf.Clamp(mousePosition.x, Screen.width / 2 - (clampRadius / 2), Screen.width / 2 + (clampRadius / 2)), Mathf.Clamp(mousePosition.y, Screen.height / 2 - (clampRadius / 2), Screen.height / 2 + (clampRadius / 2)));
        GUI.Box(new Rect(mouse.x - 5, mouse.y - 5, 10, 10), "");

        foreach (var b in buttons)
        {
            GUI.Box(b.rect, "", b.usedGUIStyle);
            GUI.Label(b.rect, b.name, b.usedGUIStyle);
        }
    }

    void SortButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            for (int j = i; j < buttons.Count; j++)
            {
                if (Vector2.Distance(buttons[j].rect.center, mousePosition) < Vector2.Distance(buttons[i].rect.center, mousePosition))
                {
                    WeaponWheelButton temp = buttons[i];
                    buttons[i] = buttons[j];
                    buttons[j] = temp;
                }
            }
        }
    }
}

[Serializable]
public class WeaponWheelButton
{
    public string name;
    public Texture2D icon;
    public Rect rect;
    public GUIStyle usedGUIStyle;

    public delegate void OnClickButtonHandler(WeaponWheelButton me);
    public event OnClickButtonHandler OnClickButton;

    public void Click()
    {
        if (OnClickButton != null)
            OnClickButton(this);
    }
}
