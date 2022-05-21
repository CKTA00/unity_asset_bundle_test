using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelController : MonoBehaviour
{
    public LoadModel loader;
    public InputField pathUI;

    //private void Awake()
    //{
    //    loader = new LoadModel();
    //}
    public void OnLoad(GameObject obj)
    {
        Debug.Log("OnLoad callback: No implementation!");
    }

    public void LoadModelFromFile()
    {
        loader.GetBundleObject(pathUI.text, OnLoad, gameObject.transform);
    }
}
