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
        [SerializeField] private GameObject _lockedState;
        [SerializeField] private GameObject _selectedState;
        [Inject] private ICarSaveManager _carSaveManager;

        private bool _isCarOpen => _carData.isDefault == true || _carData.isOpen == true;

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

          
            CheckIsOpen();
            CheckSelected(_carSaveManager.GetCurrentCar());

            _carData.onChanged += CheckIsOpen;
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

            _carData.onChanged -= CheckIsOpen;

        }

        private void Select()
        {
            if(_isCarOpen == true)
            {
                _carSaveManager.SetCurrentCar(_carData);
            }
            else
            {
                _carSaveManager.OpenCar(_carData);
            }
        }

        private void CheckIsOpen()
        {
            // _lockedState.SetActive(_carData.isDefault == true || _carData.isDefault == true);

            if (_isCarOpen == true)
            {
                _lockedState.SetActive(true);
            }
            else
            {
                _lockedState.SetActive(false);
            }
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