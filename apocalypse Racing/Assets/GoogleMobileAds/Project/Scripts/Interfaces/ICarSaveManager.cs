using SO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface ICarSaveManager
    {
        public Action<CarData> onCarSelected {  get; set; }

        public CarData GetCurrentCar();
        public void SetCurrentCar(CarData car);
    }
}