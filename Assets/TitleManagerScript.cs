using UnityEngine;
using UnityEngine.InputSystem;

public class TitleManagerScript : MonoBehaviour
{
    public GameObject titleUI;
    public GameObject gameplayUI;

    public void StartGameUI()
    {
        Time.timeScale = 1f;
        titleUI.SetActive(false);
        gameplayUI.SetActive(true);
    }
}
