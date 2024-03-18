using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("here");
        SceneManager.LoadScene("AnimalDefenseScene");
    }
}
