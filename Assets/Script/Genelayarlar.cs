using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using TMPro;


public enum HaritaTuru
{
   Yarış,
   Tur
}
public class Genelayarlar : MonoBehaviour
{
    public HaritaTuru harıtanınAdı = HaritaTuru.Yarış;
    public GameObject[] Araclar;
    public GameObject Spawnnoktasi;
    public GameObject[] YapayZekaSpawnNoktalari;
    public GameObject[] YapayZekaAraclari;
    public AudioSource[] seslerimiz;
    public GameObject OyunSonuPanel;

    List<GameObject> olusanarabalar = new List<GameObject>();
    public TextMeshProUGUI gerisayim;
    float saniye = 3f;
    bool sayac = true;
    Coroutine sayacim;

    
    void Start()
    {       
        baslangicislemleri();
        sayacim = StartCoroutine(SayacKontrol());
        seslerimiz[0].volume = PlayerPrefs.GetFloat("oyunses");
    }

    void baslangicislemleri()
    {
        gerisayim.text = saniye.ToString();
        GameObject arabam = Instantiate(Araclar[PlayerPrefs.GetInt("SecilenArac")], Spawnnoktasi.transform.position, Spawnnoktasi.transform.rotation);
        GameObject.FindWithTag("MainCamera").GetComponent<kameraKontrol>().target[0] = arabam.transform.Find("PozisyonAl");
        GameObject.FindWithTag("MainCamera").GetComponent<kameraKontrol>().target[1] = arabam.transform.Find("Pivot");
        GameObject.FindWithTag("OyunKontrol").GetComponent<KameraGecisKontrol>().kameralar[1] = arabam.transform.Find("Kameralar/OnKaput").gameObject;
        GameObject.FindWithTag("OyunKontrol").GetComponent<KameraGecisKontrol>().kameralar[2] = arabam.transform.Find("Kameralar/Aracici").gameObject;

        for (int i = 0; i < 3; i++)
        {
            int randomdeger = Random.Range(0, YapayZekaAraclari.Length - 1);

            GameObject OlusanArac = Instantiate(YapayZekaAraclari[randomdeger], YapayZekaSpawnNoktalari[i].transform.position, YapayZekaSpawnNoktalari[i].transform.rotation);
            OlusanArac.GetComponent<YapayZekaController>().spawnNoktasiİndex = i;
        }

    }

    public void kendinigonder(GameObject gelenobje)
    {
        olusanarabalar.Add(gelenobje);
    }
    public void OyunSonu(int pozisyon)
    {       
       OyunSonuPanel.SetActive(true);
       OyunSonuPanel.transform.Find("Panel/sira").GetComponent<TextMeshProUGUI>().text = pozisyon.ToString() + ". Bitirdin";
    }

    IEnumerator SayacKontrol()
    {
        while(sayac)
        {

            yield return new WaitForSeconds(1f);
            saniye--;
            gerisayim.text = Mathf.Round(saniye).ToString();
            seslerimiz[1].Play();
            if (saniye < 0)
            {

                foreach (var araba in olusanarabalar)
                {
                    if (araba.gameObject.name == "Biz")
                    {
                        araba.GetComponentInParent<CarUserControl>().enabled = true;

                    }
                    else
                    {

                        araba.GetComponentInParent<CarAIControl>().m_Driving = true;
                    }

                }
                gerisayim.enabled = false;
                sayac = false;
                StopCoroutine(sayacim);


            }
        }

    }

    /*
    private void  ///Update()
    {

        if (sayac)
        {
            saniye -= Time.deltaTime;
            gerisayim.text = Mathf.Round(saniye).ToString();
            seslerimiz[1].Play();
            if (saniye < 0)
            {

                foreach (var araba in olusanarabalar)
                {
                    if (araba.gameObject.name == "Biz")
                    {
                        araba.GetComponentInParent<CarUserControl>().enabled = true;

                    }
                    else
                    {

                        araba.GetComponentInParent<CarAIControl>().m_Driving = true;
                    }

                }
                gerisayim.enabled = false;
                sayac = false;


            }

        }
        

    }
    */
}
