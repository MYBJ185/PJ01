using UnityEngine;
using UnityEngine.InputSystem;

namespace FInputHandler
{
    public class InputHandler : MonoBehaviour
    {
        private PlayerInput _playerInput;

        [SerializeField] private Vector2 axes;
        private Vector2 Axes => axes = _playerInput.GamePlay.Axes.ReadValue<Vector2>();

        [SerializeField] private bool jump;
        public bool Jump => jump = _playerInput.GamePlay.Jump.WasPressedThisFrame();

        [SerializeField] private bool stopJump;
        public bool StopJump => stopJump = _playerInput.GamePlay.Jump.WasReleasedThisFrame();

        [SerializeField] private bool move;
        public bool Move => move = AxisX != 0f;

        [SerializeField] private float axisX;
        private float AxisX => axisX = Axes.x;

        private void Awake() 
        {
            _playerInput = new PlayerInput();

            // 解除现有的 Jump 绑定
            var jumpAction = _playerInput.GamePlay.Jump;
            jumpAction.ApplyBindingOverride("");
            jumpAction.AddBinding("<Keyboard>/j");
            jumpAction.AddBinding("<XInputController>/buttonEast");

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

        private void EnableGameplayInputs()
        {
            _playerInput.GamePlay.Enable();
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
