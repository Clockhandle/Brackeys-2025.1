using UnityEngine;

public class BottleOfWater : MonoBehaviour
{
    public GameOver gameOver;
    public void ActivateTransition()
    {
        PlayerState.IsLooking = false;
        PlayerState.IsMoving = false;
        gameObject.SetActive(true);
        Invoke(nameof(ActivateGameOver), 7f);
    }

    void ActivateGameOver()
    {
        gameOver.gameObject.SetActive(true);
        gameOver.GameOverTrigger();
    }
}
