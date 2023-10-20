using TMPro;
using UnityEngine;

public class Rune : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TextMeshPro labelText;

    [Header("Colours")]
    [SerializeField] private Color baseColor;
    [SerializeField] private Color activeColor;

    [Space(10)]
    [SerializeField] private RuneType runeType;

    public void SetText(string text)
    {
        labelText.text = text;
    }

    public RuneType GetRuneType()
    {
        return runeType;
    }
}
