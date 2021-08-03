using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseChapter : MonoBehaviour
{
    public Transform content;

    private void OnEnable()
    {
        for (int i = 0; i <= Global.maxLevel; i++)
        {
            content.GetChild(i).GetComponent<Button>().interactable = true;
        }
    }

    public void SetLevel(int level)
    {
        Global.curLevel = level;
    }
}
