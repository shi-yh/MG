using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public static AudioSource audioSource;

    public void SwitchView(int viewIdx)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i==viewIdx)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);

            }
        }
    }

    public void ShowMenu()
    {
        transform.GetChild(transform.childCount - 1).gameObject.SetActive(true);
    }

    public void HideMenu()
    {
        transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);
    }

    private void Awake()
    {    
        Global.Load();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        SwitchView(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Global.AddMaxLevel();
        }
    }

}
