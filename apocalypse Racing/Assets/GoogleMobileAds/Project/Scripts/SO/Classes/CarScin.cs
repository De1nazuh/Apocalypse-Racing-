using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Core.Car;
using Interfaces;
using System.Linq;
using Zenject;

namespace SO
{

    [CreateAssetMenu(fileName = "CarsContainer", menuName = "Container/Cars")]

    public class CarScin : ScriptableObject, ICarSaveManager
    {
        public Action<CarData> onCarSelected { get; set; }

        public List<CarData> carsList = new();
        [SerializeField] private CarData _currentCar;

        [Inject] private IRewardedAd _rewardedAd;



        public CarData GetCurrentCar()
        {
            string defaultCarName = carsList.Find(x => x.isDefault == true).name;
            //Найти имя сохраненной выбранной машины, если нет сохранения, то дай "defaultCarName"
            string savedCarName = PlayerPrefs.GetString("CurrentCar", defaultCarName);
            _currentCar = carsList.Find (x=> x.name == savedCarName);

            /* Тоже самое
             * //Найти имя машины по уиолчанию
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
            }*/

            return _currentCar;
        }

        public void OpenCar(CarData car)
        {
            _rewardedAd.ShowRewarded(() =>
            {
                car.isOpen = true;
                                      //["BlueCar_opened"]
                PlayerPrefs.GetString(car.name + "_opened", true.ToString());
                car.onChanged?.Invoke();
            });
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
        public Action onChanged;

        public string name;
        public Sprite icon;
        public bool isDefault;
        public CarMovement prefab;
        public bool isOpen;
    }
}