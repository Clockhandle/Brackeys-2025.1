using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_Management : MonoBehaviour
{
    public Animator sceneTrasis_anim;
   public void LoadScene(string name)
    { 
        currentSceneName = name;

        SceneTransition();

        Invoke(nameof(LoadSceneDelay), 1f);

    }
    string currentSceneName;
    private void LoadSceneDelay()
    {
        SceneManager.LoadScene(currentSceneName);
    }
    
    private void SceneTransition()
    {
        sceneTrasis_anim.Play("SceneAnimFadein");
    }
}
