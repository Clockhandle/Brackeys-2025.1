using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void GameOverTrigger()
    {
        gameObject.SetActive(true);
        PlayerState.IsLooking = false;
        PlayerState.IsMoving = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Demo");
        PlayerState.IsLooking = true;
        PlayerState.IsMoving = true;
        PlayerState.HasKey = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
