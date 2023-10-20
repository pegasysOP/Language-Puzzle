using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LexiconEntry : MonoBehaviour
{
    [SerializeField] private Image rune;
    private RuneType type;

    [Header("Tag")]
    [SerializeField] private TextMeshProUGUI tagText;
    [SerializeField] private Image arrowTop;
    [SerializeField] private Image arrowBottom;
    [SerializeField] private List<TagType> tags;

    private int tagIndex;

    public delegate void EntryInputChanged(RuneType type, string input);
    public EntryInputChanged InputChanged;

    public void Init(RuneType type, Sprite runeImage, int tagIndex)
    {
        this.type = type;
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
        InputChanged(type, input);
    }
}

[System.Serializable]
public struct TagType
{
    public string name;
    public Color color;
}