using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstacles : MonoBehaviour
{
    //障害物のプリファブ
    [SerializeField]
    private GameObject m_obstacle;

    //障害物の位置、角度、間隔調整用
    private Vector3 m_obsAngle　= new Vector3(0f, 45f, 0f);
    private Vector3 m_xGap = new Vector3(5f, 0f, 0f);
    private Vector3 m_yGap = new Vector3(0f, 1.5f, 0f);
    private Vector3 m_obsDistance = new Vector3(0f, 0f, 1f);

    

    void Start()
    {
        //障害物生成
        Vector3 obsAngle = new Vector3(0f, 0f, 0f);
        Vector3 obsPos = new Vector3(0f, 0f, 0f);
        Vector3 obsDistance = new Vector3(0f, 0f, 0f);

        for (int i = 0; i < 3; i++)
        {
            //列によって位置などを調整
            switch (i)
            {                
                case 0:
                    obsAngle = m_obsAngle * -1f;
                    obsPos = m_xGap * -1f + m_yGap;
                    obsDistance = new Vector3(-Mathf.Cos(m_obsAngle.y * Mathf.Deg2Rad), 0f, Mathf.Sin(m_obsAngle.y * Mathf.Deg2Rad)) * m_obsDistance.magnitude;
                    break;

                case 1:
                    obsAngle = new Vector3(0f, 0f, 0f);
                    obsPos = new Vector3(0f, 0f, 0f) + m_yGap;
                    obsDistance = m_obsDistance;
                    break;

                case 2:
                    obsAngle = m_obsAngle;
                    obsPos = m_xGap + m_yGap;
                    obsDistance = new Vector3(Mathf.Cos(m_obsAngle.y * Mathf.Deg2Rad ), 0f, Mathf.Sin(m_obsAngle.y * Mathf.Deg2Rad)) * m_obsDistance.magnitude;
                    break;

            }

            for (int j = 0; j < 10; j++)
            {
                //ランダムに色を決定して生成
                int obsR = Random.Range(0, 26) * 10;
                int obsG = Random.Range(0, 26) * 10;
                int obsB = Random.Range(0, 26) * 10;

                GameObject obstacle = Instantiate(m_obstacle, obsPos + obsDistance * j, Quaternion.Euler(obsAngle));
                obstacle.GetComponent<Renderer>().material.color = new Color(obsR / 255f, obsG / 255f, obsB / 255f, 1);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
