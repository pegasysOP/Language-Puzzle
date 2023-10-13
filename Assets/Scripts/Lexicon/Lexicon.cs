using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lexicon : MonoBehaviour
{
    [SerializeField] private LexiconEntry lexiconEntryPrefab;
    [SerializeField] private Transform entryTransform;

    private List<LexiconEntry> entries = new List<LexiconEntry>();

    [SerializeField] private List<Sprite> runes;

    private void Start()
    {
        for (int i = 0; i < runes.Count; i++)
        {
            LexiconEntry entry = Instantiate(lexiconEntryPrefab, entryTransform);
            entry.Init(runes[i], Random.Range(0, 3));
            entries.Add(entry);
        }
    }
}