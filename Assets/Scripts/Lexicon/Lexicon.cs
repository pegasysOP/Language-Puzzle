using System.Collections.Generic;
using UnityEngine;

public class Lexicon : MonoBehaviour
{
    [SerializeField] private LexiconEntry lexiconEntryPrefab;
    [SerializeField] private Transform entryTransform;

    private List<LexiconEntry> entries = new List<LexiconEntry>();

    [SerializeField] private List<Sprite> runes;

    public delegate void RuneGuessChanged(RuneType type, string input);
    public RuneGuessChanged OnRuneGuessChanged;

    private void Start()
    {
        for (int i = 0; i < runes.Count; i++)
        {
            LexiconEntry entry = Instantiate(lexiconEntryPrefab, entryTransform);
            entry.Init((RuneType)i, runes[i], Random.Range(0, 3));
            entry.InputChanged += OnEntryChanged;
            entries.Add(entry);
        }
    }

    private void OnEntryChanged(RuneType type, string entry)
    {
        OnRuneGuessChanged(type, entry);
    }
}