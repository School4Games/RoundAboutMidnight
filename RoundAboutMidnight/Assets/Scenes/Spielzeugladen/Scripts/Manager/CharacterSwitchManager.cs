using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CharacterSwitchManager : MonoBehaviour
{
    public static CharacterSwitchManager Instance;

    public SmoothCameraMovementSystem smoothCameraMovementScript;

    public List<Player> players;
    public Player currentPlayer;

    public void ChangeCurrentPlayer(Player p)
    {
        if (!players.Contains(p) || p == null)
            return;

        currentPlayer = p;
        smoothCameraMovementScript.target = currentPlayer.playerTransform;
    }

    void Awake()
    {
        Instance = this;
        ChangeCurrentPlayer(players[0]);
    }
}

[Serializable]
public class Player
{
    public string name;
    public float speed;
    public float jumpSpeed;

    public GameObject playerGameObject;
    public Transform playerTransform;
    public Rigidbody playerRigidbody;
    public Collider PlayerCollider;

    public static Player GetPlayerByName(string name)
    {
        return CharacterSwitchManager.Instance.players.Find(new Predicate<Player>((p) => { if (p.name == name) return true; else return false; }));
    }
}