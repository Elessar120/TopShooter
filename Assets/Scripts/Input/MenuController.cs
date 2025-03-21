using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public Toggle keyboardToggle; 
    public Toggle touchToggle; 
    public Button StartButton;
    private void Start()
    {
        if (InputManager.Instance.currentInputType == InputType.Keyboard)
        {
            keyboardToggle.isOn = true;
            touchToggle.isOn = false;
        }
        else
        {
            keyboardToggle.isOn = false;
            touchToggle.isOn = true;
        }

        keyboardToggle.onValueChanged.AddListener(OnKeyboardToggleValueChanged);
        touchToggle.onValueChanged.AddListener(OnTouchToggleValueChanged);
        StartButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    ///   Called when the keyboard toggle value changes.
    /// </summary>
    /// <param name="isOn">Whether the toggle is on.</param>
    private void OnKeyboardToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            InputManager.Instance.SetInputType(InputType.Keyboard);
        }
    }

    /// <summary>
    ///   Called when the touch toggle value changes.
    /// </summary>
    /// <param name="isOn">Whether the toggle is on.</param>
    private void OnTouchToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            InputManager.Instance.SetInputType(InputType.Touch);
        }
    }

    private void OnDestroy()
    {
        keyboardToggle.onValueChanged.RemoveListener(OnKeyboardToggleValueChanged);
        touchToggle.onValueChanged.RemoveListener(OnTouchToggleValueChanged);
        StartButton.onClick.RemoveListener(OnStartButtonClicked);
    }
}