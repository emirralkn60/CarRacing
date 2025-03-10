using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
public class Siralama : MonoBehaviour
{
    public int AktifYonSirasi = 1;
    SiralamaYonetim siralama;
    Genelayarlar genelayarlar;
    LapSistemYönetim lapSistem;
    public int pozisyon;
    public int lapStep ;
    void Start()
    {
        lapStep = 1;
        genelayarlar = GameObject.FindWithTag("OyunKontrol").GetComponent<Genelayarlar>();
        genelayarlar.kendinigonder(gameObject);

        if (genelayarlar.harıtanınAdı.ToString()=="Tur")
        {
            lapSistem = GameObject.FindWithTag("OyunKontrol").GetComponent<LapSistemYönetim>();
            
        }
        else
        {
            siralama = GameObject.FindWithTag("OyunKontrol").GetComponent<SiralamaYonetim>();
            siralama.kendinigonder(gameObject, AktifYonSirasi);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {


        if(genelayarlar.harıtanınAdı.ToString()== "Yarış")
        {
            if (other.CompareTag("GidisYonuObje"))
            {
                AktifYonSirasi = int.Parse(other.transform.gameObject.name);
                siralama.siralamaGuncelle(gameObject, AktifYonSirasi);

            }
        }
        
       if (gameObject.name=="Biz")
       {
         if (other.CompareTag("Finish"))
            {
                if (genelayarlar.harıtanınAdı.ToString() == "Tur")
                {
                    GetComponentInParent<CarController>().YonGidisİndex = 0;
                    AktifYonSirasi = 1;
                    if(lapStep<3)
                    {

                        lapStep++;
                        lapSistem.lapKontrolEt(lapStep);
                    }
                    else
                    {
                        lapSistem.LapGonder(gameObject);
                        genelayarlar.OyunSonu(pozisyon);
                    }
                    

                }
                else
                {
                    genelayarlar.OyunSonu(pozisyon);
                }
                

            }

       }

        
    }


    
}
