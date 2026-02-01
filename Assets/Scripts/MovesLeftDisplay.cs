using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovesLeftDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cursors;

    [SerializeField]
    private Button undoButton;

    public void LoadCursors(int moves)
    {
        for (int i = 0; i < cursors.Length; i++)
        {
            cursors[i].GetComponent<Image>().enabled = false;
        }

        Debug.Log("Loading " + moves + " cursors");
        for (int i = 0; i < moves; i++)
        {
            cursors[i].GetComponent<Image>().enabled = true;
        }

        if (LevelManager.Instance.CurrentMoveNumber == 0) undoButton.interactable = false;
        else undoButton.interactable = true;
    }
}
