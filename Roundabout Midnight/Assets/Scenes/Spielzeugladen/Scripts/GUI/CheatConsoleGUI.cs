using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheatConsoleGUI : MonoBehaviour {

    public static CheatConsoleGUI Instance;

    public Rect cheatConsoleRect;
    public string cheatText;
    public bool cheatSystemEnabled;
    public List<string> cheatLog;

    public bool logMethodExecutions;

    private Vector2 logScrollPos;

    public void WriteConsoleLog(string msg)
    {
        cheatLog.Add(msg);
    }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        WriteConsoleLog("Cheatconsole started...\n\"Help(full : Bool)\" for detailed informations.");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            cheatSystemEnabled = !cheatSystemEnabled;
        }
    }

	void OnGUI()
    {
        if (!cheatSystemEnabled)
        {
            return;
        }
            
        GUILayout.BeginArea(cheatConsoleRect);
        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        cheatText = GUILayout.TextField(cheatText, 50);
        if (GUILayout.Button("Execute"))
        {
            if (logMethodExecutions)
                WriteConsoleLog("Execute: " + cheatText);
            CheatConsoleManager.Instance.ExecuteCommand(cheatText);
        }
        GUILayout.EndHorizontal();

        logScrollPos = GUILayout.BeginScrollView(logScrollPos);
        foreach (var c in cheatLog)
        {
            GUILayout.Label(c);
        }
        GUILayout.EndScrollView();

        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
