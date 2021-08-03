using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour
{
    public GameObject[] maps;


    private void OnEnable()
    {
        maps[Global.maxLevel].SetActive(true);
    }









}
