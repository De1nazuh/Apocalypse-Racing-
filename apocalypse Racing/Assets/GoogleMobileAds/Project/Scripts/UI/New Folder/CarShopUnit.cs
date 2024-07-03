using Game;
using Interfaces;
using SO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace UI
{
    public class CarShopUnit : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _carNameText;
        [SerializeField] private Image _CarIcon;
        [SerializeField] private Button _selectButton;

        [SerializeField] private GameObject _selectedState;
        [Inject] private ICarSaveManager _carSaveManager;

        private CarData _carData;

        private void Awake()
        {
            InjectService.Inject(this);
        }
        public void Setup(CarData carData)
        {
            _carData = carData;

            _carNameText.text = carData.name;
            _CarIcon.sprite = carData.icon;

            CheckSelected(_carSaveManager.GetCurrentCar());
        }

        private void OnEnable()
        {
            _selectButton.onClick.AddListener(Select);
            _carSaveManager.onCarSelected += CheckSelected;
        }

        private void OnDisable()
        {
            _selectButton.onClick.RemoveListener(Select);
            _carSaveManager.onCarSelected -= CheckSelected;
        }

        private void Select()
        {
            _carSaveManager.SetCurrentCar(_carData);
        }

        private void CheckSelected(CarData carData)
        {
            //_selectedState.SetActive(_CarData == CarData);
            if(_carData == carData)
            {
                _selectedState.SetActive(true);
            }
            else
            {
                _selectedState.SetActive(false);
            }
        }
    }
}