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
        //Checks if the collider is a player AND if score is equal to two.
        if (other.gameObject.CompareTag("Player") && ScoreManager.instance.getScore() >= 2)
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
