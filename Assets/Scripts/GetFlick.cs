using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlick : MonoBehaviour
{
    //フリックの始めとリリース座標
    private Vector3 m_startPos;
    private Vector3 m_releasePos;

    //どれくらいの距離であればフリックと見做すかの基準値
    private float m_flickBorder = 30f;

    //標準移動関数呼び出し用
    private AimingController m_aimingController;

    //砲台回転用
    private GameObject m_Gun;
    private GunController m_gunController;

    private void Start()
    {
        //AimingController取得
        m_aimingController = GetComponent<AimingController>();

        //砲台関係取得
        m_Gun = GameObject.FindGameObjectWithTag("Gun");
        m_gunController = m_Gun.GetComponent<GunController>();
    }

    void Update()
    {
        //タップの始点と終点を取得
        if (Input.GetMouseButtonDown(0))
        {
            m_startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            m_releasePos = Input.mousePosition;
            GetDirection();
        }
    }

    private void GetDirection()
    {
        //フリック距離を判定
        float distX = m_releasePos.x - m_startPos.x;

        //フリック方向判定(既に右にあれば右には、左にあれば左には行かない)
        if(distX > m_flickBorder && m_aimingController.g_nowAimingPos != AimingController.nowAimingPos.right)
        {
            //右フリック
            m_aimingController.MoveAiming(1f);
            m_gunController.RotateGun(-1f);

        }else if(distX < -m_flickBorder && m_aimingController.g_nowAimingPos != AimingController.nowAimingPos.left)
        {
            //左フリック
            m_aimingController.MoveAiming(-1f);
            m_gunController.RotateGun(1f);
        }
    }
}
