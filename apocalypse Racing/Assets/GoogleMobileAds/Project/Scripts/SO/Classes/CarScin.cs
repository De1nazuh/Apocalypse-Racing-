using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Core.Car;

namespace SO
{

    [CreateAssetMenu(fileName = "CarsContainer", menuName = "Container/Cars")]

    public class CarScin : ScriptableObject
    {
        public CarData[] carsList;
    }

    [Serializable]

    public class CarData
    {
        public string name;
        //public Sprite icon;
        public CarMovement prefab;
        public bool isOpen;
    }
}