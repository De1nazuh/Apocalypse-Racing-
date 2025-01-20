using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Core.Car
{
    public class CarMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _FrontWheel;
        [SerializeField] private Rigidbody2D _BackWheel;

        [SerializeField] private float _Speed = 10f;
        [Inject] private AudioService _audioService;


        private void Update()
        {
            if (Input.GetKey(KeyCode.D) == true) { SetMovement(1); _audioService.PlayAudio("CarSound"); }
            else if (Input.GetKey(KeyCode.A) == true) { SetMovement(-1); _audioService.PlayAudio("CarSound"); }
            else { SetMovement(0);/* _audioService.StopAudio("CarSound");*/ }
        }
        private void SetMovement(int direction)
        {
            var movement = Vector2.right *_Speed * direction * Time.deltaTime;
            _FrontWheel.velocity += movement;
            _BackWheel.velocity += movement;
        }
    }
}