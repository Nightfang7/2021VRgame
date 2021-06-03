using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//宣告使用Unity的AI

public class MonsterController : MonoBehaviour
{
    public GameObject MyTarget;//宣告要搜尋的目標物
    private NavMeshAgent MyAgent;//宣告循跡代理人
    private Animator ani;//宣告動畫控制

    // 當腳本開始執行時會執行以下內容
    void Start()
    {
        MyAgent = GetComponent<NavMeshAgent>();//取得循跡代理人
        ani = GetComponent<Animator>();//取得動畫
        ani.SetBool("Run", true);
    }

    // 每一個影格會追一遍
    void Update()
    {
        //判定我和怪獸的距離
        float distance = Vector3.Distance(transform.position, MyTarget.transform.position);
        //Debug.Log(distance);

        MyAgent.SetDestination(MyTarget.transform.position);//追蹤

        if (distance>=20)
        {
            ani.SetBool("Run", false);
            MyAgent.ResetPath();
        }else if (distance < 20 && distance > 5)
        {
            ani.SetBool("Run", true);
            MyAgent.SetDestination(MyTarget.transform.position);//追蹤
        }
        else
        {
            ani.SetTrigger("Attack");
            MyAgent.SetDestination(MyTarget.transform.position);//追蹤
            MyAgent.stoppingDistance = 3.0f;
        }
    }
}
