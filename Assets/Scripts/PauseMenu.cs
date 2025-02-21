using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    //private void Update()
    //{
    //    //if (Input.GetKeyDown(KeyCode.Escape))
    //    //{
    //    //    Pause_game();
    //    //    Cursor.lockState = CursorLockMode.None;
    //    //    Cursor.visible = true;
    //    //}
    //}
    public void Pause_game()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }


    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

    }

    


}
