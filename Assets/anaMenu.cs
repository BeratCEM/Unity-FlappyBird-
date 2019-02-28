using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class anaMenu : MonoBehaviour
{
    int enyuksekPuan=0;
    int puan=0;
    public Text Enyuksekpu;
    public Text pUan;
     void Start()
    {
        enyuksekPuan = PlayerPrefs.GetInt("kayit");
        Enyuksekpu.text = "En Yüksek Skor: " + enyuksekPuan;
        puan = PlayerPrefs.GetInt("puan");
        Debug.Log("puan" + puan);
        pUan.text = "Skor: " + puan;
    }

    public void OyunaBasla()
    {
        SceneManager.LoadScene("level");
    }

    public void OyundanCik()
    {
        Application.Quit();
    }
}
