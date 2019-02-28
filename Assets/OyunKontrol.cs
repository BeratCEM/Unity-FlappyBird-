using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OyunKontrol : MonoBehaviour
{
    public GameObject gokyuzu1;
    public GameObject gokyuzu2;
    Rigidbody2D fizik1;
    Rigidbody2D fizik2;
    float Horizantel = 1,Vertical=1;
    Vector3 vec;
    float uzunluk=0;
    public float ArkaPlanHız = -1.5f;
    public GameObject Engel;
    public int KaçAdetEngel = 5;
    GameObject[] Engeller;
    float DegisimZaman=0;
    int sayac=0;
    bool Oyunbitti = true;


    void Start()
    {
        fizik1 = gokyuzu1.GetComponent<Rigidbody2D>();
        fizik2 = gokyuzu2.GetComponent<Rigidbody2D>();
        uzunluk = gokyuzu1.GetComponent<BoxCollider2D>().size.x;
        

        
            fizik1.velocity = new Vector2(ArkaPlanHız, 0);
            fizik2.velocity = new Vector2(ArkaPlanHız, 0);
            Engeller = new GameObject[KaçAdetEngel];

            for (int i = 0; i < Engeller.Length; i++)
            {
                Engeller[i] = Instantiate(Engel, new Vector2(-20, -20), Quaternion.identity);
                Rigidbody2D FizikEngel = Engeller[i].AddComponent<Rigidbody2D>();
                FizikEngel.gravityScale = 0;
                FizikEngel.velocity = new Vector2(ArkaPlanHız, 0);
            }
        
    }

    void Update()
    {
        if (Oyunbitti)
        {
            if (gokyuzu1.transform.position.x <= -uzunluk)
            {
                gokyuzu1.transform.position += new Vector3(uzunluk * 2, 0);
            }
            if (gokyuzu2.transform.position.x <= -uzunluk)
            {
                gokyuzu2.transform.position += new Vector3(uzunluk * 2, 0);
            }
            //---------------------------------------------------------------

            DegisimZaman += Time.deltaTime;

            if (DegisimZaman > 0.7f)
            {
                if (sayac >= Engeller.Length)
                {
                    sayac = 0;
                }
                else
                {
                    DegisimZaman = 0;
                    float Yeksenim = Random.Range(-0.6f, 1.1f);
                    Engeller[sayac].transform.position = new Vector3(18, Yeksenim);
                    sayac++;
                }
            }

        }
      

        
    }

    public void OyunBitti()
    {
        Debug.Log("CAGIRDI");
        for (int i = 0; i < Engeller.Length; i++)
        {
            Engeller[i].GetComponent<Rigidbody2D>().velocity=Vector2.zero;
            fizik1.velocity = Vector2.zero;
            fizik2.velocity = Vector2.zero;
        }
        Oyunbitti = false;
    }
}
