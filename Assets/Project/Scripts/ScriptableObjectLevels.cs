using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level/NewLevel", order = 1)]
public class ScriptableObjectLevels : ScriptableObject
{
    public int _countPilars;
    public int _countLines;
    public int _INDEX;
    public bool _isComplete;
}
