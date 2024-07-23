using System.Collections.Generic;
using UnityEngine;

namespace FInputHandler
{ 
    public class InputHandler : MonoBehaviour
{
    private Dictionary<KeyCode, string> keyToAction = new Dictionary<KeyCode, string>();
    private Dictionary<string, ActionType> actionType = new Dictionary<string, ActionType>();
    private Queue<string> bufferedActions = new Queue<string>();

    void Start()
    {
        // 设置按键映射和动作类型
        SetKeyMapping(KeyCode.W, "Move_Forward", ActionType.Instant);
        SetKeyMapping(KeyCode.J, "Jump", ActionType.Instant);
        SetKeyMapping(KeyCode.C, "Combo_Attack", ActionType.Buffered);
    }

    void Update()
    {
        // 处理即时输入
        foreach (var key in keyToAction.Keys)
        {
            if (Input.GetKeyDown(key))
            {
                HandleInput(key);
            }
        }

        // 处理缓冲输入
        ProcessBufferedActions();
    }

    public void SetKeyMapping(KeyCode key, string action, ActionType actionType)
    {
        keyToAction[key] = action;
        this.actionType[action] = actionType;
    }

    private void HandleInput(KeyCode key)
    {
        if (keyToAction.ContainsKey(key))
        {
            string action = keyToAction[key];
            ActionType actionType = this.actionType[action];

            if (actionType == ActionType.Instant)
            {
                ProcessInstantAction(action);
            }
            else if (actionType == ActionType.Buffered)
            {
                bufferedActions.Enqueue(action);
            }
        }
    }

    private void ProcessInstantAction(string action)
    {
        ExecuteAction(action);
    }

    private void ProcessBufferedActions()
    {
        if (CanExecuteBufferedAction() && bufferedActions.Count > 0)
        {
            string action = bufferedActions.Dequeue();
            ExecuteAction(action);
        }
    }

    private void ExecuteAction(string action)
    {
        // 根据动作名称执行对应的逻辑
        Debug.Log($"Executing action: {action}");
    }

    private bool CanExecuteBufferedAction()
    {
        // 检查当前是否可以执行缓冲动作
        return true;
    }

    public void ClearBufferedActions()
    {
        bufferedActions.Clear();
    }
}
}


