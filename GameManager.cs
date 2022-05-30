using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool GameHasEnded = false;
    public GameObject StartUI;
    public GameObject WinUI;
    public float LevelDelay = 3f;
    public float AnimDelay = 2f;
    public Animator fadeAnim;

    public void LoadNextLevel()
    {

        Invoke("AnimFade", AnimDelay);
        Invoke("LoadLevel", LevelDelay);


    }



    public void LoadLevel()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AnimFade()
    {
        fadeAnim.SetTrigger("FadeOut");
    }

}
