using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadView : MonoBehaviour
{

    public Image load;

    AsyncOperation async;


    private void OnEnable()
    {

        UIControl.audioSource.clip = Resources.Load<AudioClip>("Audio/转场音效");

        UIControl.audioSource.Play();



        StartCoroutine(Load());

        load.DOFillAmount(1, 1.2f).onComplete+=()=> {

            async.allowSceneActivation = true;
        };


    }

    private IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync(2);

        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            //load.fillAmount = async.progress;

            yield return null;
        }


    }


}
