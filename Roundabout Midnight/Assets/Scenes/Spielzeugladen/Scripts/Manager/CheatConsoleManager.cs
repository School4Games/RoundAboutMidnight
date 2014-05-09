using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Reflection;

public class CheatConsoleManager : MonoBehaviour
{
    public static CheatConsoleManager Instance;

    public List<Command> availableCommands;

    public void ExecuteCommand(string consoletext)
    {
        consoletext = consoletext.TrimStart();
        consoletext = consoletext.TrimEnd();

        string commandname = "";
        string[] parameter = new string[0];
        try
        {
            commandname = consoletext.Split('(')[0];
            parameter = consoletext.Split('(')[1].Replace(")", "").Replace(", ", ",").Split(',');
        }
        catch
        {
            CheatConsoleGUI.Instance.WriteConsoleLog("Error: The command is not parseable.");
        }

        Command calledCommand = ResolveCommandName(commandname);
        if (calledCommand == null)
        {
            CheatConsoleGUI.Instance.WriteConsoleLog("Error: The called command wasnt found.");
        }

        List<ParameterValue> parameterValues = new List<ParameterValue>();
        for (int i = 0; i < parameter.Length; i++)
        {
            try
            {
                if (calledCommand.parameter[i].type == ParameterType.Float)
                {
                    float value = float.Parse(parameter[i]);
                    parameterValues.Add(new ParameterValue(value));
                }
                else if (calledCommand.parameter[i].type == ParameterType.Int)
                {
                    int value = int.Parse(parameter[i]);
                    parameterValues.Add(new ParameterValue(value));
                }
                else if (calledCommand.parameter[i].type == ParameterType.String)
                {
                    string value = parameter[i]; // Kein parsen notwendig, da der Quelltyp dem Zieltyp gleicht.
                    parameterValues.Add(new ParameterValue(value));
                }
                else if (calledCommand.parameter[i].type == ParameterType.Bool)
                {
                    bool value = bool.Parse(parameter[i]);
                    parameterValues.Add(new ParameterValue(value));
                }
            }
            catch (Exception ex)
            {
                CheatConsoleGUI.Instance.WriteConsoleLog("Error: Executing \"" + consoletext + "\n created an error:\n" + ex.Message);
            }
        }

        calledCommand.CallCommandMethod(parameterValues);
    }

    private Command ResolveCommandName(string name)
    {
        return availableCommands.Find(new Predicate<Command>((c) => { if (c.name == name) return true; else return false; }));
    }
    void Awake()
    {
        Instance = this;
        Command.commandMethodsType = this.GetType();
    }

    #region Command-Methods
    public void Help(bool full)
    {
        if (full)
        {
            foreach (var command in availableCommands)
            {
                CheatConsoleGUI.Instance.WriteConsoleLog(command.name + "(");
                foreach (var pm in command.parameter)
                {
                    CheatConsoleGUI.Instance.WriteConsoleLog(pm.name + " : " + pm.type.ToString());
                }
                CheatConsoleGUI.Instance.WriteConsoleLog(")");
                CheatConsoleGUI.Instance.WriteConsoleLog("\n");
            }
        }
        else
        {
            foreach (var command in availableCommands)
            {
                CheatConsoleGUI.Instance.WriteConsoleLog(command.name + "()");
                CheatConsoleGUI.Instance.WriteConsoleLog("\n");
            }
        }
    }
    public void Print(string message)
    {
        CheatConsoleGUI.Instance.WriteConsoleLog("Print: " + message);
    }
    public void Clear()
    {
        CheatConsoleGUI.Instance.cheatLog.Clear();
    }
    // Name der Methode muss mit der in der Liste availableCommands von eben übereinstimmen!
    public void SetGameObjectPosition(string objname, float x, float y, float z)
    {
        // Und hier kommt rein, was ausgeführt werden soll.
        GameObject.Find(objname).transform.position = new Vector3(x, y, z);
    }
    public void GetGameObjectPosition(string objname)
    {
        CheatConsoleGUI.Instance.WriteConsoleLog(GameObject.Find(objname).transform.position.ToString());
    }

    #endregion
}

// Stellt ein ausführbares Kommando dar.
[Serializable]
public class Command
{
    public static Type commandMethodsType;

    public string name;
    public List<Parameter> parameter;

    public void CallCommandMethod(List<ParameterValue> fulfilledparameters)
    {
        object[] args = new object[fulfilledparameters.Count];
        for (int i = 0; i < args.Length; i++)
		{
            args[i] = fulfilledparameters[i].value;
		}

        commandMethodsType.GetMethod(name).Invoke(CheatConsoleManager.Instance, args);
    }
}

// Stellt einen zu erfüllenden Parameter dar.
[Serializable]
public class Parameter
{
    public string name;
    public ParameterType type;

    public Parameter(string _name, ParameterType _type)
    {
        name = _name;
        type = _type;
    }
}
// Stellt einen erfüllten Parameter dar.
public class ParameterValue
{
    public object value;

    public ParameterValue(object _value)
    {
        value = _value;
    }
}
// Stellt den Typ eines zu erfüllenden Parameter dar.
[Serializable]
public enum ParameterType
{
    Int,
    Float,
    String,
    Bool
}