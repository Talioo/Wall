using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action Select;
    public Action StartGame;
    public Action<bool> GameOver;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogError($"Duplicated {GetType()}!");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Select?.Invoke();
        StartGame?.Invoke();
    }

    public void StopGame(bool result)
    {
        GameOver?.Invoke(result);
    }
}
