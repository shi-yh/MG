using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using Spine.Unity;

public class LineTrigger : MonoBehaviour
{
    public GameObject failed;

    public GameObject succeed;

    public SkeletonGraphic[] anima;

    public GameObject menu;

    public GameObject[] life;

    AudioSource audio;

    private int lastLife=3;

    PlayableDirector pd;


    public void ShowMenu()
    {
        pd.Pause();

        menu.gameObject.SetActive(true);
    }

    public void HideMunu()
    {
        pd.Play();

        menu.gameObject.SetActive(false);
    }



    private void Awake()
    {
        gos = new Dictionary<int, GameObject>();

        for (int i = 0; i < 4; i++)
        {
            gos[i] = null;
        }


        Transform go = Instantiate(Resources.Load<GameObject>("Prefabs/TimeLine_"+Global.curLevel)).transform;

        go.transform.SetParent(transform.parent);

        go.transform.localPosition = Vector3.zero;

        go.localScale = Vector2.one;

        audio = go.GetComponent<AudioSource>();

        pd = go.GetComponent<PlayableDirector>();

        pd.stopped += ShowSuccess;

        audio.volume = Global.audioValue;
    }

    /// <summary>
    /// 当前被激活的物体
    /// </summary>
    public Dictionary<int, GameObject> gos;

    public void ActiveGo(int idx,GameObject go)
    {
        gos[idx] = go;
    }

    public void KeyButton(int idx)
    {
        anima[idx].AnimationState.SetAnimation(0, "animation", false);


        if (gos[idx]!=null)
        {
            GameObject go = gos[idx];

            gos[idx] = null;

            Destroy(go);


            AudioClip clip = Resources.Load<AudioClip>("Audio/0");

            audio.PlayOneShot(clip);
        }
        else
        {
            AudioClip clip = Resources.Load<AudioClip>("Audio/1");

            audio.PlayOneShot(clip);
        }
      
    }


    private void CostLife()
    {
        lastLife--;

        life[lastLife].transform.GetChild(0).gameObject.SetActive(false);


        if (lastLife <= 0)
        {
            ShowFailed();
        }
    }

    private void ShowFailed()
    {
        pd.Pause();

        failed.gameObject.SetActive(true);
    }

  

    private void ShowSuccess(PlayableDirector obj)
    {
        if (Global.curLevel==Global.maxLevel)
        {
            Global.AddMaxLevel();
        }

        succeed.gameObject.SetActive(true);

    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;

        float posx = go.transform.localPosition.x;

        int idx = GetIdxByPos(posx);

        if (gos[idx] == go)
        {
            gos[idx] = null;

            Destroy(go);

            CostLife();
        }
    }


    private int GetIdxByPos(float posx)
    {
        if (posx==-320)
        {
            return 0;
        }
        else if (posx==0)
        {
            return 1;
        }
        else if (posx == 320)
        {
            return 2;
        }

        return 0;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;

        float posx = go.transform.localPosition.x;

        ActiveGo(GetIdxByPos(posx), go);

    }

    public void Back()
    {
        SceneManager.LoadScene(1);
    }


}
