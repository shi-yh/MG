using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Video;

public class MainView : MonoBehaviour
{
    Transform chapter;

    Transform pre;

    Transform talk;

    int idx = 0;


    private void OnEnable()
    {
        chapter = Instantiate(Resources.Load<GameObject>("Prefabs/chapter_" + Global.curLevel)).transform;
        chapter.SetParent(transform);
        chapter.localPosition = Vector2.zero;
        chapter.localScale = Vector2.one;


        talk = chapter.GetChild(0);


        AudioClip ac = chapter.GetComponent<AudioSource>().clip;

        chapter.GetComponent<AudioSource>().enabled = false;

        UIControl.audioSource.clip = ac;
        UIControl.audioSource.Play();


        for (int i = 0; i < talk.transform.childCount; i++)
        {
            talk.GetChild(i).GetComponentInChildren<Button>().onClick.AddListener(NextPart);
        }


        ShowPrew();
        //NextPart();
    }

    private void ShowPrew()
    {
        VideoPlayer vp = chapter.GetComponent<VideoPlayer>();

        vp.targetCamera = Camera.main;

        vp.Play();

        vp.loopPointReached += OnVideoEnd;



    }

    private void OnVideoEnd(VideoPlayer source)
    {
        chapter.GetComponent<VideoPlayer>().enabled = false;
        NextPart();
    }

    private void NextPart()
    {
        ///关闭上一段剧情
        if (idx > 0)
        {
            talk.GetChild(idx - 1).gameObject.SetActive(false);
        }


        //如果剧情结束了
        if (idx>= talk.childCount)
        {
            if (Global.curLevel!=0)
            {
                transform.parent.GetComponent<UIControl>().SwitchView(3);
            }
            else
            {
                Global.AddMaxLevel();
                transform.parent.GetComponent<UIControl>().SwitchView(1);

                

            }



            return;
        }

      
        ///开启下一段剧情
        GameObject obj = talk.GetChild(idx).gameObject;
       
        Text txt = obj.GetComponentInChildren<Text>();

        if (txt != null)
        {


            string str = txt.text;

            txt.text = "";


            txt.DOText(str, str.Length / 10.0f);
        }

        talk.GetChild(idx).gameObject.SetActive(true);


        idx++;
    }


    private void OnDisable()
    {
        Destroy(chapter.gameObject);

        idx = 0;
    }



}
