using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Items/NewItems", order = 1)]
public class ScriptableObjectItems : ScriptableObject
{
    public List<Sprite> allItems;
}
