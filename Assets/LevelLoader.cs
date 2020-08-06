using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public int startNumOfCoins;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Counts the number of coins from the start on the scene.
        startNumOfCoins = GameObject.FindGameObjectsWithTag("Coins").Length;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // checks for number of coins left on the scene (level)
        int numberOfCoins = GameObject.FindGameObjectsWithTag("Coins").Length;
        Debug.Log(other.gameObject.name);

        // Loads next level if player has collected atleast 80% of the coins on the scene.
        if (other.gameObject.CompareTag("Player") && (startNumOfCoins - numberOfCoins >= startNumOfCoins * 0.8))
        {
            if (gameObject.CompareTag("summer"))
            {
                LoadNextLevel("summer");

            } 
            else if (gameObject.CompareTag("winter"))
            {
                LoadNextLevel("winter");
            } 
            else if (gameObject.CompareTag("autumn"))
            {
                LoadNextLevel("autumn");
            } 
            else if (gameObject.CompareTag("Goal"))
            {
                LoadNextLevel("HUB");
            }
        }
    }
    public void LoadNextLevel(string levelName)
    {
        //Loads next scene based on current scene index, adds one to go the next scene index.
       StartCoroutine(LoadLevel(levelName));
    }

    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }
}
