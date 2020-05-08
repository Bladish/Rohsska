using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Lantern", menuName = "Lantern")]
public class Lantern : ScriptableObject
{
    public string name;
    public Color color;
    public int id;
}
