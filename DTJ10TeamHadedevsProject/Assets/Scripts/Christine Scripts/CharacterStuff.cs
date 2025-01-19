using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStuff", menuName = "Scriptable Objects/CharacterStuff")]
public class CharacterStuff : ScriptableObject
{
    public string Name;
    public int ID;

    public List<AnimationClip> Animations = new List<AnimationClip>();
}
