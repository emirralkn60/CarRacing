using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class haritayonetimi : MonoBehaviour
{
    string secilmilolanharita;
    public Button baslaButonu;
    public GameObject LoadingPanel;
    public Slider LoadingSlider;
    public void SecilenHarita(string haritaisim)
    {
        secilmilolanharita = haritaisim;
      

    }
    private void Update()
    {
        if (secilmilolanharita!=null)
        {
            baslaButonu.interactable = true;
        }
    }
    public void basla()
    {
        StartCoroutine(Sahneyuklemeloading(secilmilolanharita));
         
    }

    IEnumerator Sahneyuklemeloading(string Haritaadimiz)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(Haritaadimiz);
        LoadingPanel.SetActive(true);
        while (!operation.isDone)
        {
            float ilerleme = Mathf.Clamp01(operation.progress / .9f);
            LoadingSlider.value = ilerleme;
            yield return null;

        }

    }
}
