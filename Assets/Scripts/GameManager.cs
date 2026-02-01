using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextAsset[] layouts;
    [SerializeField]
    TextAsset[] movesets;

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
        LevelManager.Instance.DrawGridTiles();
    }

    public void NextLevel()
    {
        Debug.Log("Going on to next level");
        LoadLevel(++currentLevel);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadLevel(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
