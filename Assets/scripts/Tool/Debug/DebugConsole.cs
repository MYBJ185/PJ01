using Characters.Hero;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

namespace Tool.Debug
{
    public class DebugConsole : MonoBehaviour
    {
        public GameObject logPrefab;
        public GameObject content;
        public TextMeshProUGUI inputField;
        public int maxLogCount = 15;
        public TextMeshProUGUI axisX;
        public TextMeshProUGUI axisY;
        public HeroController heroController;
        private static DebugConsole _instance;

        public static DebugConsole Instance
        {
            get
            {
                if (_instance == null)
                {
                    UnityEngine.Debug.LogError("DebugConsole instance is not initialized.");
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                //UnityEngine.Debug.Log("DebugConsole initialized");
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            axisX.text = $"AxisX: {heroController.inputHandler.AxisX}";
            axisY.text = $"AxisY: {heroController.inputHandler.AxisY}";
        }

        public void Log(string message, LogLevel level)
        {
            if (_instance == null)
            {
                //UnityEngine.Debug.LogError("DebugConsole instance is not initialized.");
                return;
            }

            // 批量删除多余的日志
            int excessCount = content.transform.childCount - maxLogCount + 1;
            if (excessCount > 0)
            {
                for (int i = 0; i < excessCount; i++)
                {
                    Destroy(content.transform.GetChild(i).gameObject);
                }
            }

            var logInstance = Instantiate(logPrefab, content.transform);
            var textComponent = logInstance.GetComponentInChildren<TextMeshProUGUI>();

            if (textComponent != null)
            {
                if (level == LogLevel.Null)
                {
                    textComponent.text = message;
                }
                else
                {
                    textComponent.text = $"[{level}] {message}";
                }
            }
        }

        public void LogInput()
        {
            Log($"Arcgros >>> {inputField.text}", LogLevel.Null);
        }
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error,
        Null
    }
}
