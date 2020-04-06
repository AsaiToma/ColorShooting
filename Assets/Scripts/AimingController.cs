using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimingController : MonoBehaviour
{
    //標準の基本情報
    private RectTransform m_aimingRT;
    private Vector3 m_aimingPos;

    //標準の位置調整パラメータ
    private Vector3 m_xGap = new Vector3(5f, 0f, 0f);
    private Vector3 m_yGap = new Vector3(0f, 1.5f, 0f);

    //標準の位置管理に使用
    public enum nowAimingPos
    {
        left,
        center,
        right
    }
    public nowAimingPos g_nowAimingPos;



    private void Start()
    {
        m_aimingRT = GetComponent<RectTransform>();

        //初期化
        m_aimingRT.position = RectTransformUtility.WorldToScreenPoint(Camera.main,m_yGap);
        g_nowAimingPos = nowAimingPos.center;
    }

    void Update()
    {
        
    }

    //標準を移動させる
    public void MoveAiming(float sign)
    { 
        //今いる場所によってm_aimingPosとg_nowAimingPosを更新
        switch (g_nowAimingPos)
        {
            case nowAimingPos.left:
                m_aimingPos = m_aimingPos + m_xGap ;
                g_nowAimingPos = nowAimingPos.center;
                break;

            case nowAimingPos.center:
                m_aimingPos = m_aimingPos + m_xGap * sign;
                switch (sign)
                {
                    case -1:
                        g_nowAimingPos = nowAimingPos.left;
                        break;

                    case 1:
                        g_nowAimingPos = nowAimingPos.right;
                        break;
                }
                break;

            case nowAimingPos.right:
                m_aimingPos = m_aimingPos - m_xGap;
                g_nowAimingPos = nowAimingPos.center;
                break;
        }
        m_aimingRT.position = RectTransformUtility.WorldToScreenPoint(Camera.main, m_aimingPos + m_yGap);
        //aimingRT.rotation = Quaternion.Euler(0f, 45f, 0f);
    }

}
