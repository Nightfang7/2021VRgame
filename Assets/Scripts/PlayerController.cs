using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem FireEffect;//宣告粒子系統
    private AudioSource FireSound;
    private RaycastHit rayHit;

    private void Start()
    {
        FireSound = GetComponent<AudioSource>();
    }

    public void FireEvent()
    {
        if (Physics.Raycast(transform.position, transform.forward, out rayHit, 100f))
        {
            FireEffect.transform.position = rayHit.point;//將粒子的位置設定在射線處
            FireEffect.transform.rotation = Quaternion.Euler(270, 0, 0);//設定粒子的轉向
            FireEffect.Stop();//停止粒子撥放
            FireEffect.Play();//重新撥放粒子特效
            FireSound.Stop();//停止聲音撥放
            FireSound.Play();//重新撥放聲音


            if(rayHit.transform.tag == "Enemy")
            {
                Destroy(rayHit.transform.gameObject);
                //Debug.Log("Bomb Distroied");
            }
        }
        Debug.Log("shoot!");
    }
}
