using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("AnimalDefenseScene");
    }
}
