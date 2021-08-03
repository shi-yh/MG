using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(3).GetComponent<Image>().DOFade(0.2f, 1.5f).SetLoops(-1, LoopType.Yoyo);
    }

    public void ChangeScene()
    {
        AsyncOperation ao= SceneManager.LoadSceneAsync(1);

        ao.allowSceneActivation = true;

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
