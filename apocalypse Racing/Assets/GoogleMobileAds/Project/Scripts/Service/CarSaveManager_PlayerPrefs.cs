using Interfaces;
using SO;
using UnityEngine;
using Zenject;
using Game;
using System.Linq;


namespace Services
{

    public class CarSaveManager_PlayerPrefs : MonoBehaviour
    {
        [Inject] private CarScin _carsList;
        private void Awake()
        {
            InjectService.Inject(this);
        }

        
    }
}