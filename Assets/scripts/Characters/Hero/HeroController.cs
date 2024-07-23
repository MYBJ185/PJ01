using System;
using Input;
using UnityEngine;

namespace Characters.Hero
{
    public class HeroController : MonoBehaviour
    {
        private InputHandler _inputHandler;
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _inputHandler = GetComponent<InputHandler>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _inputHandler.EnableGameplayInputs();
        }

        public void Move(float speed)
        {
            SetVelocityX(speed * _inputHandler.AxisX);
        }
        
        public void SetVelocity(Vector3 velocity)
        {
            _rigidbody.linearVelocity = velocity;
        }
        
        public void SetVelocityX(float x)
        {
            _rigidbody.linearVelocity = new Vector3(x, _rigidbody.linearVelocity.y, _rigidbody.linearVelocity.z);
        }
        
        public void SetVelocityY(float y)
        {
            _rigidbody.linearVelocity = new Vector3(_rigidbody.linearVelocity.x, y, _rigidbody.linearVelocity.z);
        }
    }
}