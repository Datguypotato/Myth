using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public MiniGame minigamescript;

    public string[] sceneNames;
    public bool gameDone;
    public int score;
    public int lives;

    bool startGame;
    Scene activeLevel;
    Canvas mainmenuCanvas;

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
        mainmenuCanvas = GameObject.FindObjectOfType<Canvas>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame && SceneManager.sceneCount == 1)
        {
            SceneManager.LoadSceneAsync(sceneNames[1], LoadSceneMode.Additive);
            mainmenuCanvas.gameObject.SetActive(false);
        }

        if(minigamescript == null)
        {
            minigamescript = GameObject.FindObjectOfType<MiniGame>();
        }

        if (minigamescript != null && minigamescript.gameDone)
        {
            DG(minigamescript.playerWin);
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

        minigamescript = null;
        SceneManager.UnloadSceneAsync(sceneNames[1]);
        mainmenuCanvas.gameObject.SetActive(true);

    }
    //startgame for button
    public void SG()
    {
        startGame = true;
    }
}
