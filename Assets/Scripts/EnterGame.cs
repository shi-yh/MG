using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterGame : MonoBehaviour
{
    private void OnEnable()
    {
        UIControl.audioSource.clip = Resources.Load<AudioClip>("Audio/背景bgm");

        UIControl.audioSource.Play();


        if (Global.maxLevel<=0)
        {
            transform.GetChild(2).transform.localPosition = Vector2.zero;
            transform.GetChild(3).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(2).transform.localPosition = new Vector2(0,100);
            transform.GetChild(3).gameObject.SetActive(true);
        }
    }


    public void ClearSave()
    {
        Global.Clear();
    }



}
