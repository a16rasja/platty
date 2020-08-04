using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    //void Update()
    //{
    //    if(this.gameObject.CompareTag("Goal"))
    //    {
    //        LoadNextLevel();
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        int numberOfCoins = GameObject.FindGameObjectsWithTag("Coins").Length;

        if (other.gameObject.CompareTag("Player") && numberOfCoins <= 0)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
