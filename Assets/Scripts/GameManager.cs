using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextAsset[] layouts;
    [SerializeField]
    private TextAsset[] movesets;
    [SerializeField]
    private LevelNameDisplay levelNameDisplay;
    
    [SerializeField]
    private GameObject restartButton;
    [SerializeField]
    private CenterBackground background;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(GameManager).ToString());
                    _instance = singleton.AddComponent<GameManager>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return _instance;
        }
    }

    private int currentLevel = 0;

    private void LoadLevel(int level)
    {
        Board.Instance.LoadFromTextAsset(layouts[level]);
        LevelManager.Instance.LoadLevelFromTextAsset(movesets[level]);
        GetComponent<CenterCamera>().Center();
        background.Center();
        LevelManager.Instance.DrawGridTiles();
        levelNameDisplay.LoadLevel(level);
    }

    public void NextLevel()
    {
        Debug.Log("Going on to next level");
        if (currentLevel + 1 > layouts.Length - 1)
        {
            SceneManager.LoadScene("Victory");
        }
        else
        {
            LoadLevel(++currentLevel);
            GetComponent<AudioSource>().Play();
        }
        
    }

    public void StartGame()
    {
        LoadLevel(0);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    public void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void HideRestartButton()
    {
        restartButton.SetActive(false);
    }
}
