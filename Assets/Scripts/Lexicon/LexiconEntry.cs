using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LexiconEntry : MonoBehaviour
{
    [SerializeField] private Image rune;

    [Header("Tag")]
    [SerializeField] private TextMeshProUGUI tagText;
    [SerializeField] private Image arrowTop;
    [SerializeField] private Image arrowBottom;
    [SerializeField] private List<TagType> tags;

    private int tagIndex;

    public delegate void EntryInputChanged(string input);
    public EntryInputChanged entryInputChanged;

    public void Init(Sprite runeImage, int tagIndex)
    {
        rune.sprite = runeImage;
        this.tagIndex = tagIndex;
        SetTagUI(tagIndex);
    }

    private void SetTagUI(int tagIndex)
    {
        TagType tagType = tags[tagIndex];

        arrowTop.color = tagType.color;
        arrowBottom.color = tagType.color;
        
        tagText.color = tagType.color;
        tagText.text = tagType.name;
    }

    public void OnTagClick()
    {
        tagIndex += 1;
        if (tagIndex >= tags.Count)
            tagIndex = 0;

        SetTagUI(tagIndex);
    }

    public void OnEntryInputChanged(string input)
    {
        entryInputChanged(input);
    }
}

[System.Serializable]
public struct TagType
{
    public string name;
    public Color color;
}