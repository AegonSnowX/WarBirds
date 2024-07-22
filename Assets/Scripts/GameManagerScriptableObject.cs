using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameManagerScriptableObject", order = 1)]
public class GameManagerScriptableObject : ScriptableObject
{
    public string prefabName;
    public float speed;
}
