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

        //testing
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    StartCoroutine(LoseLife());
        //}
    }
    //donegame
    //public void DG(bool playerwin)
    //{
    //    minigamescript = null;
    //    SceneManager.UnloadSceneAsync(sceneNames[sceneNumber]);
    //    mainmenuCanvas.gameObject.SetActive(true);

    //    if (playerwin)
    //    {
    //        score++;
    //    }
    //    else
    //    {
    //        //StartCoroutine(Changelevel());
    //    }
    //}

    //function for button
    public async void ChangeScene()
    {
        StartCoroutine(LoadScene());
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

        if (!playerwin)
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
        else
        {

        }

        //hide all lives left
        for (int i = 0; i < livesGo.Count; i++)
        {
            livesGo[i].SetActive(false);
        }

        yield return new WaitForSeconds(1);

        ChangeScene();
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
