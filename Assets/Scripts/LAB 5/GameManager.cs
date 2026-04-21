using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CustomDoubleLinkedList snapshotSystem = new();

    public Player player;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }
    [Button]
    public void SaveTurn()
    {
        snapshotSystem.SaveTurn();
        Debug.Log("Saving turn: " + snapshotSystem.Count);

        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<Enemy>().MoveTowardsPlayer();
        }
    }
    [Button]
    public void LoadTurn()
    {
        if (snapshotSystem.pivot == null) return;

        snapshotSystem.LoadTurn(player);
    }
    [Button]
    public void NextTurn()
    {
        snapshotSystem.MoveForward();
        snapshotSystem.LoadTurn(player);
    }
    [Button]
    public void PrevTurn()
    {
        snapshotSystem.MoveBackwards();
        snapshotSystem.LoadTurn(player);
    }

 
}