using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Player player;
    [SerializeField] private GameObject lexiconObject;

    private void Awake()
    {
        // singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        player.lexiconInputRecieved += OnLexiconInput;
    }

    private void OnLexiconInput()
    {
        lexiconObject.SetActive(!lexiconObject.activeSelf);
    }

    /// <summary>
    /// Gets the active instance of player
    /// </summary>
    /// <returns>Can return null</returns>
    public Player GetPlayer()
    {
        if (player == null)
            Debug.LogError("GameManager could not find the instance of Player");

        return player;
    }
}