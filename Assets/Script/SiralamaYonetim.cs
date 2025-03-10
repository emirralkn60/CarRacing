using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class araba
{
    public GameObject gelenobje;
    public int pozisyon;
    public araba(GameObject disgelenobje,int dispozisyon)
    {
        gelenobje = disgelenobje;
        pozisyon = dispozisyon;
    }

}

public class SiralamaYonetim : MonoBehaviour
{
    public List<araba> arabalar = new List<araba>();
    public TextMeshProUGUI sira;

    public void kendinigonder(GameObject gelenobje,int aktifyonu)
    {

        arabalar.Add(new araba(gelenobje, aktifyonu));


        if (arabalar.Count==4)
        {
            siralamakontrolet();

        }
    }
    public void siralamaGuncelle(GameObject gelenaraba, int pozisyon)
    {
        for (int i = 0; i < arabalar.Count; i++)
        {

            if (arabalar[i].gelenobje == gelenaraba)
            {

                arabalar[i].pozisyon = pozisyon;
            }

        }

        siralamakontrolet();

    }

    public void siralamakontrolet()
    {
        arabalar = arabalar.OrderBy(w => w.pozisyon).ToList();


        sira.text = "";
        /*
         * Bmw-4<br>
         * Biz-6<br>
         * Cayman-8<br
         * 911siyah-10<br>
         * 
         * */
        for (int i = 0; i < arabalar.Count; i++)
        {

            switch(i)
            {
                case 0:
                    if (arabalar[i].gelenobje.name=="Biz")
                    {
                        sira.text = "4/4";
                        arabalar[i].gelenobje.GetComponent<Siralama>().pozisyon = 4;

                    }
                    break;
                case 1:
                    if (arabalar[i].gelenobje.name == "Biz")
                    {
                        sira.text = "3/4";
                        arabalar[i].gelenobje.GetComponent<Siralama>().pozisyon = 3;

                    }

                    break;
                case 2:
                    if (arabalar[i].gelenobje.name == "Biz")
                    {
                        sira.text = "2/4";
                        arabalar[i].gelenobje.GetComponent<Siralama>().pozisyon = 2;

                    }

                    break;
                case 3:
                    if (arabalar[i].gelenobje.name == "Biz")
                    {
                        sira.text = "1/4";
                        arabalar[i].gelenobje.GetComponent<Siralama>().pozisyon = 1;

                    }
                    break;

            }

        }
      
      /*

        foreach (var araba in arabalar)
        {
            sira.text += araba.gelenobje.name + "-" + araba.pozisyon + "<br>";
        }*/


    }
  

}
