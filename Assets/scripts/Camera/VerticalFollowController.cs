using Cinemachine;
using UnityEngine;

namespace Camera
{
    public class VerticalFollowController : MonoBehaviour
    {
        public Transform player; // 角色的Transform
        public CinemachineVirtualCamera virtualCamera; // Cinemachine虚拟相机
        public float verticalThreshold = 1f; // 垂直方向的跟随阈值
        public float horizontalThreshold = 1f; // 水平方向的跟随阈值
        public float followSpeed = 2f; // 跟随的速度

        private float _initialCameraY; // 相机初始的Y位置
        private float _initialCameraX; // 相机初始的X位置
        private float _initialPlayerY; // 玩家初始的Y位置
        private float _initialPlayerX; // 玩家初始的X位置

        void Start()
        {
            if (virtualCamera != null && player != null)
            {
                _initialCameraY = virtualCamera.transform.position.y;
                _initialCameraX = virtualCamera.transform.position.x;
                _initialPlayerY = player.position.y;
                _initialPlayerX = player.position.x;
            }
        }

        void LateUpdate()
        {
            if (player == null || virtualCamera == null)
                return;

            var playerDeltaY = player.position.y - _initialPlayerY;
            var playerDeltaX = player.position.x - _initialPlayerX;
            var cameraTargetY = _initialCameraY;
            var cameraTargetX = _initialCameraX;

            if (Mathf.Abs(playerDeltaY) > verticalThreshold)
            {
                cameraTargetY += (playerDeltaY - verticalThreshold * Mathf.Sign(playerDeltaY));
            }

            if (Mathf.Abs(playerDeltaX) > horizontalThreshold)
            {
                cameraTargetX += (playerDeltaX - horizontalThreshold * Mathf.Sign(playerDeltaX));
            }

            Vector3 cameraPosition = virtualCamera.transform.position;
            cameraPosition.y = Mathf.Lerp(cameraPosition.y, cameraTargetY, followSpeed * Time.deltaTime);
            cameraPosition.x = Mathf.Lerp(cameraPosition.x, cameraTargetX, followSpeed * Time.deltaTime);
            virtualCamera.transform.position = cameraPosition;
        }
    }
}