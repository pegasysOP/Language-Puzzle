using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum RuneType
{
    On,
    Off,
    Go,
    Stop,
    Wait
}

public class RuneManager : MonoBehaviour
{

    [SerializeField] private Lexicon lexicon;
    [SerializeField] private List<Rune> runes;

    private void Awake()
    {
        lexicon.OnRuneGuessChanged += UpdateRuneLabels;
    }

    private void UpdateRuneLabels(RuneType type, string label)
    {
        foreach (Rune rune in runes)
        {
            if (rune.GetRuneType() == type)
                rune.SetText(label);
        }
    }
}