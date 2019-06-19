using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public MiniGame minigamescript;

    public bool gameDone;
    public int score;
    public string[] sceneNames;

    public GameObject mainmenuButton;
    public GameObject[] Arrows;
    public GameObject storyBoard;

    [Header("Lives variable")]

    [Range(1, 3)]
    public int lives;
    public Sprite spriteBoom;
    public List<GameObject> livesGo;

    int sceneNumber;
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

        if(minigamescript == null)
        {
            minigamescript = GameObject.FindObjectOfType<MiniGame>();
        }
        else
        {
            if (minigamescript.gameDone)
            {
                StartCoroutine(ChangelevelAndLife(minigamescript.playerWin));
            }

        }

    }


    //function for button
    public void ChangeScene()
    {
        lives = 3;

        StartCoroutine(LoadScene());
    }

    public void Story()
    {
        Arrows[0].SetActive(!Arrows[0].activeInHierarchy);
        Arrows[1].SetActive(!Arrows[1].activeInHierarchy);
        storyBoard.SetActive(!storyBoard.activeInHierarchy);
        mainmenuButton.SetActive(!mainmenuButton.activeInHierarchy);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator ChangelevelAndLife(bool playerwin)
    {
        minigamescript = null;
        AsyncOperation ao = SceneManager.UnloadSceneAsync(sceneNames[sceneNumber]);

        yield return ao;
        yield return new WaitForSeconds(1);

        //show all lives left
        for (int i = 0; i < livesGo.Count; i++)
        {
            livesGo[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.5f);

        if (!playerwin && lives > 0)
        {
            //change sprite to losing health
            lives--;

            Animator anim = livesGo[lives].GetComponent<Animator>();
            anim.enabled = true;
            yield return new WaitForSeconds(1);

            //actually lose health
            anim.enabled = false;
            livesGo[lives].GetComponent<SpriteRenderer>().sprite = null;
            livesGo.Remove(livesGo[lives]);
            yield return new WaitForSeconds(0.5f);
        }

        //hide all lives left
        if(livesGo != null)
        {
            for (int i = 0; i < livesGo.Count; i++)
            {
                livesGo[i].SetActive(false);
            }
        }

        yield return new WaitForSeconds(1);

        if(lives > 0)
        {
            ChangeScene();
        }
        else
        {
            Debug.Log("Done Game");
            mainmenuCanvas.gameObject.SetActive(true);
        }
    }

    IEnumerator LoadScene()
    {
        mainmenuCanvas.gameObject.SetActive(false);
        sceneNumber = Random.Range(0, sceneNames.Length);
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneNames[sceneNumber], LoadSceneMode.Additive);
        yield return ao;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneNames[sceneNumber]));
    }
}
