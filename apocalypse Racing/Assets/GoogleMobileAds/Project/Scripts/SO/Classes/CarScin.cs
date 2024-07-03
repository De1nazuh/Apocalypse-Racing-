using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Core.Car;
using Interfaces;
using System.Linq;

namespace SO
{

    [CreateAssetMenu(fileName = "CarsContainer", menuName = "Container/Cars")]

    public class CarScin : ScriptableObject, ICarSaveManager
    {
        public List<CarData> carsList;
        [SerializeField] private CarData _currentCar;

        public Action<CarData> onCarSelected { get; set; }


        public CarData GetCurrentCar()
        {
            //Найти имя машины по уиолчанию
            string defaultCarName = "";
            
            foreach(CarData car in carsList)
            {
                if(car.isDefault == true)
                {
                    defaultCarName = car.name;
                    break;
                }
            }

            //Найти имя сохраненной выбранной машины, если нет сохранения, то дай "defaultCarName"
            string savedCarName = PlayerPrefs.GetString("CurrentCar", defaultCarName);
            foreach (CarData car in carsList)
            {
                if (car.name == savedCarName)
                {
                    _currentCar = car;
                    break;
                }
            }

            return _currentCar;
        }

        public void SetCurrentCar(CarData car)
        {
            _currentCar = car;

            PlayerPrefs.SetString("CurrentCar", car.name);

            onCarSelected?.Invoke(car);
        }
    }

    [Serializable]

    public record CarData
    {
        public string name;
        public Sprite icon;
        public bool isDefault;
        public CarMovement prefab;
        public bool isOpen;
    }
}