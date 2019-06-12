using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MiniGame minigamescript;

    public string[] sceneNames;
    public bool gameDone;
    public int score;
    public int lives;

    public List<GameObject> livesGo;
    public Sprite spriteBoom;

    bool startGame;
    Scene activeLevel;
    Canvas mainmenuCanvas;



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

        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(LoseLife());
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

    IEnumerator LoseLife()
    {
        //show all lives left
        for (int i = 0; i < livesGo.Count; i++)
        {
            livesGo[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.5f);
        //change sprite to losing health
        lives--;
        SpriteRenderer rend = livesGo[lives].GetComponent<SpriteRenderer>();
        rend.sprite = spriteBoom;

        yield return new WaitForSeconds(1);
        //actually lose health
        livesGo[lives].GetComponent<SpriteRenderer>().sprite = null;
        livesGo.Remove(livesGo[lives]);
        yield return new WaitForSeconds(0.5f);
        //hide all lives left
        for (int i = 0; i < livesGo.Count; i++)
        {
            livesGo[i].SetActive(false);
        }
    }
}
