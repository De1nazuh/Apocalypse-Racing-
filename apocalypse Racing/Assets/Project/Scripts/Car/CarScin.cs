using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CarsContainer", menuName = "Container/Cars")]

public class Test : ScriptableObject
{
    public List<Auto> cars = new List<Auto>();
}

[Serializable]
public class Auto
{
    public string name;
    public Sprite icon;
    public bool isOpen;
}