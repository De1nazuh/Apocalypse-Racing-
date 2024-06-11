using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameStart : MonoBehaviour
    {


        [Inject , SerializeField] private GameObject _mainMenu;
        [Inject, SerializeField] private Sprite _item;
        private GameStateChanger _gameStateChanger = new();
        

        //начало игры
        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            //_gameStateChanger.ChangeState(new MainMenu_GameState());
        }
    }
}