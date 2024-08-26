using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Player icon", menuName = "Player Icon")]
public class PlayerIcon : ScriptableObject
{
    [Header("Informazioni")]
    public Image goblinImage;
    public Image dwarfImage;
    public Sprite goblinSprite;
    public Sprite dwarfSprite;
    public Color borderColor;
}
