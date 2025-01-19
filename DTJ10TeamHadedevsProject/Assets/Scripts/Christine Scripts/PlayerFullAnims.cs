using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerFullAnims", menuName = "Scriptable Objects/PlayerFullAnims")]

public class PlayerFullAnims : ScriptableObject
{
    public Parts[] parts;

    [System.Serializable]

    public class Parts
    {
        public string name;
        public CharacterStuff part;
    }
}
