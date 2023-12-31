using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool complete = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character" && !complete) 
        {
            complete = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        GameManager.instance.SetCurrentLevel(nextLevel);
        GameManager.instance.SaveGame();
        SceneManager.LoadScene(nextLevel);
    }
}
