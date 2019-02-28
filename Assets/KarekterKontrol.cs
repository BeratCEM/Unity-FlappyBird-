using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KarekterKontrol : MonoBehaviour
{
    public Text puanTEXT;
    public Sprite[] KusSprite;
    SpriteRenderer SpriteRender;
    bool İleriGerikont = true;
    int KusSayac;
    float AnimasyonHızıZaman;
    Rigidbody2D fizik;
    Vector2 vec;
    float Horizontal=1, Vertical=1;
    int puan=0;
    int enYuksekpuan=0;
    bool EngelCarptı = true;
    OyunKontrol oyunkonTrol;
    AudioSource []sesler;

    void Start()
    {
        SpriteRender = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();
        oyunkonTrol = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<OyunKontrol>();
        sesler = GetComponents<AudioSource>();
        enYuksekpuan = PlayerPrefs.GetInt("kayit");
        Debug.Log("en yuksekpuan=  "+enYuksekpuan);
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0) && EngelCarptı == true)
        {
            fizik.velocity = new Vector2(0,0);
            fizik.AddForce(new Vector2(0,170));
            sesler[0].Play();
        }

        if(fizik.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 37.5f);
        }

        else
        {
            transform.eulerAngles = new Vector3(0, 0, -37.5f);
        }

        Animasyon();
    }
    float zaman = 1;
    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "ENgel")
        {
            EngelCarptı = false;
            oyunkonTrol.OyunBitti();
            sesler[2].Play();
            GetComponent<CircleCollider2D>().enabled = false;

            if (puan > enYuksekpuan)
            {
                enYuksekpuan = puan;
                PlayerPrefs.SetInt("kayit", enYuksekpuan);
            }
            Invoke("AnaMenuyeDon",2);
           

            
        }
        if(other.gameObject.tag == "puan")
        {
            puan++;
            puanTEXT.text ="Skor: " + puan;
            sesler[1].Play();
            PlayerPrefs.SetInt("puan",puan);
        }


    }

    void AnaMenuyeDon()
    {
        SceneManager.LoadScene("AnaMenu");

    }


    void Animasyon()
    {
        AnimasyonHızıZaman += Time.deltaTime;
        if (AnimasyonHızıZaman > 0.1f)
        {
            AnimasyonHızıZaman = 0;

            if (İleriGerikont == true)
            {

                SpriteRender.sprite = KusSprite[KusSayac];// 0 1 2 

                KusSayac++;

                if (KusSayac == KusSprite.Length)
                {

                    KusSayac--;
                    İleriGerikont = false;

                }
            }
            else //if(İleriGerikont == false)  önemliii
            {

                KusSayac--;
                SpriteRender.sprite = KusSprite[KusSayac];
                if (KusSayac == 0)
                {
                    KusSayac++;
                    İleriGerikont = true;
                }




            }

        }
    }
}

