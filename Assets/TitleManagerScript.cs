using UnityEngine;
using UnityEngine.InputSystem;

public class TitleManagerScript : MonoBehaviour
{
    public GameObject titleUI;
    public GameObject gameplayUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Time.timeScale = 1f;
            titleUI.SetActive(false);
            gameplayUI.SetActive(true);
            enabled = false;
        }
    }
}
