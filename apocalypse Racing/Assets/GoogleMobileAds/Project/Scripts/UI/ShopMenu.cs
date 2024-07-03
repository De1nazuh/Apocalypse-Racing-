
using SO;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Game;
using Game.UI;


namespace UI
{
    public class ShopMenu : UIBase
    {
        public Button BackButton;

        public Transform contentParent;
        public CarShopUnit carShopUnit_Prefab;

        [Inject] private CarScin _carsList;

        private void OnEnable()
        {
            InjectService.Inject(this);
            ClearCars();
            SpawnCar();
        
        }

        private void ClearCars()
        {
            foreach (var car in contentParent.GetComponentsInChildren<CarShopUnit>())
            {
                Destroy(car.gameObject);
            }
        }
        private void SpawnCar()
        {
            foreach (CarData car in _carsList.carsList)
            {
                CarShopUnit carCopy = Instantiate(carShopUnit_Prefab);
                carCopy.transform.parent = contentParent;
                carCopy.Setup(car);
            }
        }


    }
}