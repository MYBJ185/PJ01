using System;
using Input;
using UnityEngine;
using CharacterGroundDetector = Characters.Characters.CharacterGroundDetector;
namespace Characters.Hero
{
    public class HeroController : MonoBehaviour
    {
        private CharacterGroundDetector _groundDetector;
        private InputHandler _inputHandler;
        private Rigidbody _rigidbody;
        public float MoveSpeed => Mathf.Abs(_rigidbody.linearVelocity.x);
        
        public bool IsGrounded => _groundDetector.IsGrounded;
        public bool IsFalling => _rigidbody.linearVelocity.y < 0 && _groundDetector.IsGrounded == false;
        private void Awake()
        {
            _inputHandler = GetComponent<InputHandler>();
            _rigidbody = GetComponent<Rigidbody>();
            _groundDetector = GetComponentInChildren<CharacterGroundDetector>();
        }

        private void Start()
        {
            _inputHandler.EnableGameplayInputs();
        }

        public void Move(float speed)
        {   
            var normalizedSpeed = (_inputHandler.AxisX) / Math.Abs(_inputHandler.AxisX + 0.01f);
            
            if (_inputHandler.Move)
            {
                transform.localScale = new Vector3(normalizedSpeed, 1, 1);
            }
            SetVelocityX(speed * normalizedSpeed);
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