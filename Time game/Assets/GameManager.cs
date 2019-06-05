using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string[] sceneNames;
    public bool gameDone;
    public int score;
    public int lives;

    bool startGame = true;
    Scene activeLevel;

    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame && SceneManager.sceneCount == 1)
        {
            SceneManager.LoadSceneAsync(sceneNames[0], LoadSceneMode.Additive);
        }
    }
    //donegame
    public void DG(bool playerwin)
    {
        if (playerwin)
        {
            score++;
        }
        else
        {
            lives--;
        }

        SceneManager.UnloadSceneAsync(sceneNames[0]);
        

    }
    //startgame
    public void SG()
    {
        startGame = true;
    }
}
