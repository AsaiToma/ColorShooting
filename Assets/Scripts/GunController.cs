using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    //回転系
    private GameObject m_startingPoint; //回転の起点
    private Vector3 m_rotateAngle = new Vector3(0f,0f,34f);  //回転角度

    //射撃関係
    [SerializeField]
    private GameObject[] m_bullets = new GameObject[3]; //弾丸(0r,1g,2b)
    private GameObject m_muzzle; //弾丸生成位置
    private float m_bulletSpeed = 1000f; //弾の速度
    private int m_bulletCost = 10; //一度の射撃での消費弾数
    private int[] m_ammoValue = new int[3]; //残弾(0r,1g,2b)
    private float m_recoveryTime = 1.0f; //残弾が回復する時間
    private int m_recoveryValue = 10; //残弾の回復量
    private float[] m_timeElapsed = new float[3]; //色ごとの時間経過、これが貯まると残弾が回復

   

    //UI関係
    private UIController m_uiController;

    //ボタン関係
    public enum Colors
    {
        red,
        green,
        blue
    }
    

    void Start()
    {
        //コンポーネント取得
        m_uiController = GetComponent<UIController>();

        //起点取得
        m_startingPoint = GameObject.FindGameObjectWithTag("GunStartingPoint");
        //弾丸生成位置取得
        m_muzzle= GameObject.FindGameObjectWithTag("Muzzle");


        //初期化
        for(int i=0; i<3; i++)
        {
            m_ammoValue[i] = 255;
        }
    }



    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            //残弾回復処理
            if (m_ammoValue[i] < 255)
            {
                m_timeElapsed[i] += Time.deltaTime; //時間経過で回復
                //一定時間経過で残弾を回復させ、UIの更新
                if(m_timeElapsed[i] >= m_recoveryTime)
                {
                    m_ammoValue[i] += m_recoveryValue;
                    m_timeElapsed[i] = 0f;

                    m_uiController.ChangeAmmoUI(m_ammoValue[i],i);
                }
            }

        }
    }

    //砲台回転関数
    public void RotateGun(float sign)
    {
        m_startingPoint.transform.Rotate(m_rotateAngle * sign);
    }

    //弾丸発射関数
    public void ShotBullet(int num)
    {
        //num =0(r),=1(g),=2(b)
        if (CheckAmmo(num))
        {
            //弾発射
            GameObject bullet = Instantiate(m_bullets[num], m_muzzle.transform.position, Quaternion.identity) as GameObject;
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.AddForce(m_startingPoint.transform.up * m_bulletSpeed);

        }
        
    }

    //残弾管理関数
    private bool CheckAmmo(int num)
    {
        if(m_ammoValue[num] - m_bulletCost < 0)
        {
            return false;
        }
        else
        {
            //残弾の値を減らす
            m_ammoValue[num] -= m_bulletCost;

            //UI更新
            m_uiController.ChangeAmmoUI(m_ammoValue[num],num);

            return true;
        }
            
    }
}
