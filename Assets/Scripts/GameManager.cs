using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public DeathMenu deathMenu;
   // public GameObject completeLevelUI;

    // complete level - we are not completing levels because it is endless sliding
    //public void CompleteLevel()
    //{
    //    Debug.Log("Level Won");
    //    completeLevelUI.SetActive(true);
    //}

    // end game function
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            

            //need to set score on death
            deathMenu?.ToggleEndMenu(0f);
        }

    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
