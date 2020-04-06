using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //UI関係
    private GameObject[] m_AmmoTexts_Red;
    private GameObject[] m_AmmoTexts_Green;
    private GameObject[] m_AmmoTexts_Blue;
    private GameObject[] m_AmmoGauges_Red;
    private GameObject[] m_AmmoGauges_Green;
    private GameObject[] m_AmmoGauges_Blue;


    // Start is called before the first frame update
    void Start()
    {
        //残弾UI系取得
        m_AmmoTexts_Red = GameObject.FindGameObjectsWithTag("AmmoText_Red");
        m_AmmoTexts_Green = GameObject.FindGameObjectsWithTag("AmmoText_Green");
        m_AmmoTexts_Blue = GameObject.FindGameObjectsWithTag("AmmoText_Blue");
        m_AmmoGauges_Red = GameObject.FindGameObjectsWithTag("AmmoGauge_Red");
        m_AmmoGauges_Green = GameObject.FindGameObjectsWithTag("AmmoGauge_Green");
        m_AmmoGauges_Blue = GameObject.FindGameObjectsWithTag("AmmoGauge_Blue");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAmmoUI(int AmmoValue,int num)
    {
        //num =0(r), =1(g), =2(b)
        GameObject[] AmmoTexts = null;
        GameObject[] AmmoGauges = null;
        switch (num)
        {
            //赤
            case 0:
                AmmoTexts = m_AmmoTexts_Red;
                AmmoGauges = m_AmmoGauges_Red;
                break;

            //緑
            case 1:
                AmmoTexts = m_AmmoTexts_Green;
                AmmoGauges = m_AmmoGauges_Green;
                break;

            //青
            case 2:
                AmmoTexts = m_AmmoTexts_Blue;
                AmmoGauges = m_AmmoGauges_Blue;
                break;
        }

        //UI更新
        foreach(GameObject AmmoText in AmmoTexts)
        {
            AmmoText.GetComponent<Text>().text = (AmmoValue).ToString() + "  /  255";
        }

        foreach(GameObject AmmoGauge in AmmoGauges)
        {
            AmmoGauge.GetComponent<Slider>().value = AmmoValue;
        }
    }
}
