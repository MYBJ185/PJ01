using System;
using Input;
using Tool.Debug;
using UnityEngine;
using UnityEngine.Serialization;
using CharacterGroundDetector = Characters.Characters.CharacterGroundDetector;

namespace Characters.Hero
{
    public class HeroController : MonoBehaviour
    {
        private CharacterGroundDetector _groundDetector;
        [FormerlySerializedAs("_inputHandler")] public InputHandler inputHandler;
        private Rigidbody _rigidbody;
        public bool CanAirJump { get; set; } = true;
        public float MoveSpeed => Mathf.Abs(_rigidbody.linearVelocity.x);
        public bool IsGrounded => _groundDetector.IsGrounded;
        public bool IsFalling => _rigidbody.linearVelocity.y < 0 && _groundDetector.IsGrounded == false;

        private float _previousDirection;
        public bool IsDirectionChanged { get; private set; }
        private void Awake()
        {
            inputHandler = GetComponent<InputHandler>();
            _rigidbody = GetComponent<Rigidbody>();
            _groundDetector = GetComponentInChildren<CharacterGroundDetector>();
        }

        private void Start()
        {
            inputHandler.EnableGameplayInputs();
            _previousDirection = Mathf.Sign(inputHandler.AxisX);
        }

        public void Move(float speed)
        {
            var normalizedSpeed = Mathf.Sign(inputHandler.AxisX);
            var inputMagnitude = Mathf.Abs(inputHandler.AxisX);

            if (!inputHandler.Move)
            {
                return;
            }

            const float directionChangeThreshold = 0.1f;

            if (!Mathf.Approximately(normalizedSpeed, _previousDirection) && Mathf.Abs(normalizedSpeed - _previousDirection) > directionChangeThreshold)
            {
                DebugConsole.Instance.Log($"Direction changed to {normalizedSpeed}", LogLevel.Info);
                _previousDirection = normalizedSpeed;
                transform.localScale = new Vector3(normalizedSpeed, 1, 1);
                IsDirectionChanged = true;
            }
            else
            {
                IsDirectionChanged = false;
            }

            SetVelocityX(speed * inputMagnitude * normalizedSpeed);
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