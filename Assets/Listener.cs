using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener : MonoBehaviour
{
    public float startTime = 0f;
    public int holdTime = 5; // 5 seconds
    public float currentTime = 0;
    public int timePercent = 0;

    public Timer timer;
    public LevelLoader ll;
    public KeyCode key = KeyCode.Escape;

    void Start()
    {
        //Sets timer to start percentage if timer exists
        if(timer)
        {
            timer.SetTime(timePercent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Only listens to key down if timer should be active
        if (holdTime > 0)
        {
            // Sets a start time when key is pressed
            if (Input.GetKeyDown(key))
            {
                startTime = Time.time;
            }

            // stops timer and sets the percent to 0
            if (Input.GetKeyUp(key))
            {
                startTime = 0f;
                timePercent = 0;
            }

            // Checks if key is held
            if (Input.GetKey(key))
            {
                // Calculate percentage of the time a button should be held
                currentTime = Time.time - startTime;
                timePercent = (int)((currentTime / holdTime) * 100);

                // Loads scene 'HUB' if key is held longer than or equal to holdTime
                if (currentTime >= holdTime)
                {
                    ll.LoadNextLevel("HUB");
                }
            }

            // Sets the current percent value to timer
            timer.SetTime(timePercent);
        }
    }
}
