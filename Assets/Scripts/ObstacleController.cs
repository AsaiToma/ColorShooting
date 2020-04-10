using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float m_RValue;
    private float m_GValue;
    private float m_BValue;
    private Renderer m_obsRenderer;
    private Color m_obsColor;


    // Start is called before the first frame update
    void Start()
    {
        m_obsRenderer = GetComponent<Renderer>();

        //現在の自身の色取得
        m_RValue = m_obsRenderer.material.color.r;
        m_GValue = m_obsRenderer.material.color.g;
        m_BValue = m_obsRenderer.material.color.b;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string bulletColor = collision.gameObject.tag;

        switch (bulletColor)
        {
            case "RedBullet":
                m_RValue += 10f / 255f;
                //Debug.Log("r=" + m_RValue);
                break;

            case "GreenBullet":
                m_GValue += 10f / 255f;
                //Debug.Log("g=" + m_GValue);
                break;

            case "BlueBullet":
                m_BValue += 10f / 255f;
                //Debug.Log("b=" + m_BValue);
                break;
        }
        
        m_obsRenderer.material.color = new Color(m_RValue, m_GValue, m_BValue, 1);
        Debug.Log(m_obsRenderer.material.color);
        Destroy(collision.gameObject);
    }
}
