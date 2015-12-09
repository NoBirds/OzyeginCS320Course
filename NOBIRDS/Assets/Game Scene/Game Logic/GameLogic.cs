﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameLogic : MonoBehaviour
{
    public static bool pause = false;
    public static bool mute = false;
    public static bool gameOver = false;
    public static bool isScrolling = true;
    public static int score = 0; 
    public static float scrollingSpeed = 3f;
    private static float fixedScrollingSpeed = scrollingSpeed;
    public static Vector3 scrollingVelocity;

    public static string getCurrentScene()
    {
        return Application.loadedLevel == 0 ? "GUI" : "Game Scene";
    }

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        Debug.Log("fuck you!!!!");
        scrollingVelocity = Vector3.down * (scrollingSpeed) * Time.deltaTime;
	}

    // Update is called once per frame
    void FixedUpdate () { 
        if (score >= 10000)
            GameOver();
        
        //isScrolling = true;
    }
    public static void setPaused(bool paused)
    {
        pause = paused;
        Time.timeScale = pause ? 0 : 1;
    }

    public static void setMuted(bool muted)
    {
        mute = !muted;
    }
     
    public static void startGame()
    {
        gameOver = false;
        score = 0;
        Time.timeScale = 1;
        Application.LoadLevel("Game Scene");
    }

    public static void GameOver()
    {
        gameOver = true;
        Application.LoadLevel("GUI");
    }

    public static void scored(int point)
    {
        score += point;
    }

    public static void recordHighScore(string playerName)
    { 
        DataManager.recordPlayer(score, playerName); 
    }

    public static void stopScrolling()
    {
        isScrolling = false;
    }

    public static void bonusToken()
    {
        isScrolling = false;
    }
}
