using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ayarlar : MonoBehaviour
{
    public Slider menusesSlider;
    public Slider oyunsesSlider;
    AudioSource menusesi;
    public Dropdown kalitesecenekleri;
    void Start()
    {
        menusesi = GameObject.Find("OyunKontrol").GetComponent<AudioSource>();
        menusesSlider.value = PlayerPrefs.GetFloat("menuses");
        oyunsesSlider.value = PlayerPrefs.GetFloat("oyunses");
        kalitesecenekleri.value = PlayerPrefs.GetInt("Kalite");

    }

   
    public void MenuSesDegisim()
    {
        PlayerPrefs.SetFloat("menuses", menusesSlider.value);
        menusesi.volume = menusesSlider.value;
    }
    public void OyunSesDegisim()
    {
        PlayerPrefs.SetFloat("oyunses", oyunsesSlider.value);

    }   

    public void Kalitesecim(int secilmiskalite)
    {
        PlayerPrefs.SetInt("Kalite", secilmiskalite);

        QualitySettings.SetQualityLevel(secilmiskalite);


    }


}
