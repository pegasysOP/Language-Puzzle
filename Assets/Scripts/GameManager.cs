using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Player player;
    [SerializeField] private CameraController activeCamera;
    [SerializeField] private GameObject lexiconPanel;

    public delegate void CameraChanged();
    public CameraChanged cameraChanged;

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
        lexiconPanel.SetActive(!lexiconPanel.activeSelf);
    }

    /// <summary>
    /// Gets the active instance of Player
    /// </summary>
    /// <returns>Can return null</returns>
    public Player GetPlayer()
    {
        if (player == null)
            Debug.LogError("GameManager could not find the instance of Player");

        return player;
    }

    /// <summary>
    /// Gets the active instance of CameraController
    /// </summary>
    /// <returns>can return null</returns>
    public CameraController GetActiveCamera()
    {
        if (activeCamera == null)
            Debug.LogError("GameManager could not find the instance of CameraController");

        return activeCamera;
    }
}