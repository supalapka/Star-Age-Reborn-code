using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemData", menuName ="MyObjects/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public int Price;
    public int Width;
    public int Height;

}
