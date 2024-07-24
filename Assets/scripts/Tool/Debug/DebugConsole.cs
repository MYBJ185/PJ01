using UnityEngine;
using TMPro;

namespace Tool.Debug
{
    public class DebugConsole : MonoBehaviour
    {
        public GameObject logPrefab;
        public GameObject content;
        public TextMeshProUGUI inputField;
        public int maxLogCount = 15;

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

        private void Start()
        {
            DebugConsole.Instance.Log("This is a test log", LogLevel.Info);
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
                UnityEngine.Debug.Log("DebugConsole initialized");
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Log(string message, LogLevel level)
        {
            if (_instance)
            {
                UnityEngine.Debug.LogError("DebugConsole instance is not initialized.");
                return;
            }

            if (content.transform.childCount >= maxLogCount)
            {
                Destroy(content.transform.GetChild(0).gameObject);
            }

            var logInstance = Instantiate(logPrefab, content.transform);
            var textComponent = logInstance.GetComponentInChildren<TextMeshProUGUI>();

            if (textComponent&& level == LogLevel.Null)
            {
                textComponent.text = message;
            }
            else if (textComponent)
            {
                textComponent.text = $"[{level}] {message}";
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