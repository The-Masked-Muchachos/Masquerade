using UnityEngine;
using UnityEngine.UI;

public class LevelNameDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject[] LevelNames;

    public void LoadLevel(int number)
    {
        foreach (GameObject levelName in LevelNames)
        {
            levelName.GetComponent<Image>().enabled = false;
        }

        LevelNames[number].GetComponent<Image>().enabled = true;
    }
}
