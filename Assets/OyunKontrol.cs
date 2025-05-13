using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    AudioSource menusesi;
    private static OyunKontrol oyunkontrolinstance;

    private void Awake()
    {
        DontDestroyOnLoad(this);


        if (oyunkontrolinstance == null)
        {
            oyunkontrolinstance = this;

        } else
        {
            Destroy(gameObject);

        }
    }
    void Start()
    {
        menusesi = GetComponent<AudioSource>();      

        if (PlayerPrefs.HasKey("menuses"))
        {

            menusesi.volume = PlayerPrefs.GetFloat("menuses");
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Kalite"));
        }
        else
        {
            // oyun ilk kez açılıyor
            PlayerPrefs.SetFloat("menuses", 1);
            PlayerPrefs.SetFloat("oyunses", 1);
            PlayerPrefs.SetInt("Kalite", 3);
         
        }

    }

   
}
