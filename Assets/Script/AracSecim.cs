using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AracSecim : MonoBehaviour
{
    public GameObject[] Arabalar;
    public Text ArabaAd;
    int aktifaracindex=0;
    public ParticleSystem GecisEfekti;
    void Start()
    {
        Arabalar[aktifaracindex].SetActive(true);
        ArabaAd.text = Arabalar[aktifaracindex].GetComponent<Aracbilgileri>().aracadi;
    }

    public void ileri()
    {
        if (aktifaracindex != Arabalar.Length - 1 )
        {
            Arabalar[aktifaracindex].SetActive(false);
            aktifaracindex++;
            Arabalar[aktifaracindex].SetActive(true);
            ArabaAd.text = Arabalar[aktifaracindex].GetComponent<Aracbilgileri>().aracadi;
            GecisEfekti.Play();
        }
        else
        {
            Arabalar[aktifaracindex].SetActive(false);
            aktifaracindex = 0;
            Arabalar[aktifaracindex].SetActive(true);
            ArabaAd.text = Arabalar[aktifaracindex].GetComponent<Aracbilgileri>().aracadi;
            GecisEfekti.Play();
        }

    }

    public void geri()
    {
        if (aktifaracindex != 0)
        {
            Arabalar[aktifaracindex].SetActive(false);
            aktifaracindex--;
            Arabalar[aktifaracindex].SetActive(true);
            ArabaAd.text = Arabalar[aktifaracindex].GetComponent<Aracbilgileri>().aracadi;
            GecisEfekti.Play();
        }
        else
        {
            Arabalar[aktifaracindex].SetActive(false);
            aktifaracindex = Arabalar.Length - 1;
            Arabalar[aktifaracindex].SetActive(true);
            ArabaAd.text = Arabalar[aktifaracindex].GetComponent<Aracbilgileri>().aracadi;
            GecisEfekti.Play();
        }

    }

    public void basla()
    {
        PlayerPrefs.SetInt("SecilenArac", aktifaracindex);
        SceneManager.LoadScene("HaritaSecim");
    }
}
