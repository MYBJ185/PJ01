using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputHandler : MonoBehaviour
    {
        private PlayerInput _playerInput;
        [SerializeField] private float jumpInputBufferTime = 0.5f;
        private WaitForSeconds _jumpInputBufferWaitForSeconds;
        [SerializeField] private Vector2 axes;
        private Vector2 Axes => axes = _playerInput.GamePlay.Axes.ReadValue<Vector2>();

        public bool HasJumpInputBuffer {get; set;}
        
        [SerializeField] private bool jump;
        public bool Jump => jump = _playerInput.GamePlay.Jump.WasPressedThisFrame();
        public bool IsPressingJump => _playerInput.GamePlay.Jump.IsPressed();
        [SerializeField] private bool stopJump;
        public bool StopJump => stopJump = _playerInput.GamePlay.Jump.WasReleasedThisFrame();

        [SerializeField] private bool move;
        public bool Move => AxisX != 0f || AxisY != 0f;

        [SerializeField] private float axisX;
        [SerializeField] private float axisY;
        public float AxisX => axisX = Axes.x;
        public float AxisY => axisY = Axes.y;
        private string _message = "";
        private void OnEnable()
        {
            _playerInput.GamePlay.Jump.canceled += delegate
            {
                HasJumpInputBuffer = false;
            };
        }

        private void OnGUI()
        {
            // 定义字体样式
            var style = new GUIStyle
            {
                fontSize = 50,
                fontStyle = FontStyle.Bold
            };

            // 显示 "Has Jump Input Buffer"
            var rect1 = new Rect(1600, 200, 400, 100);;
            GUI.Label(rect1, _message, style);
        }
        private void Update()
        {   
            _message = HasJumpInputBuffer ? "Has Jump Input Buffer : True" :  "Has Jump Input Buffer :";
        }


        private void Awake() 
        {
            _playerInput = new PlayerInput();
            _jumpInputBufferWaitForSeconds = new WaitForSeconds(jumpInputBufferTime);
            // 解除现有的 Jump 绑定
            var jumpAction = _playerInput.GamePlay.Jump;
            jumpAction.ApplyBindingOverride("");
            jumpAction.AddBinding("<Keyboard>/z");
            jumpAction.AddBinding("<XInputController>/buttonSouth");

            // 修改键盘上下左右的绑定为
            //var axesAction = _playerInput.GamePlay.Axes;
            //axesAction.ApplyBindingOverride("");
            //axesAction.AddCompositeBinding("2DVector")
            //    .With("Up", "<Keyboard>/e")
            //    .With("Down", "<Keyboard>/d")
            //    .With("Left", "<Keyboard>/s")
            //    .With("Right", "<Keyboard>/f");

            // 修改Xbox手柄的上下左右绑定为十字键
            //axesAction.AddCompositeBinding("2DVector")
            //    .With("Up", "<XInputController>/dpad/up")
            //    .With("Down", "<XInputController>/dpad/down")
            //    .With("Left", "<XInputController>/dpad/left")
            //    .With("Right", "<XInputController>/dpad/right");

            EnableGameplayInputs();
        }
        
        public void EnableGameplayInputs()
        {
            _playerInput.GamePlay.Enable();
            //Cursor.lockState = CursorLockMode.Locked;
        }
        
        public void SetJumpInputBuffer()
        {
            StopCoroutine(nameof(JumpInputBufferCoroutine));
            StartCoroutine(nameof(JumpInputBufferCoroutine));
        }
        
        IEnumerator JumpInputBufferCoroutine()
        {
            HasJumpInputBuffer = true;
            yield return _jumpInputBufferWaitForSeconds;
            HasJumpInputBuffer = false;   
        }
    }
}
