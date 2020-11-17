
using UnityEngine;
/// <summary>
/// 设计随机事件
/// </summary>
public class Createnemy : MonoBehaviour
{
    float CreatTime = 5f; //设计创造狼的时间
    GameObject Goldeater; //申请一个狼的模块

    void Update()
    {
        CreatTime -= Time.deltaTime;    //开始倒计时
        if (CreatTime <= 0)    //如果倒计时为0 的时候
        {
            CreatTime = Random.Range(3, 10);     //随机3到9秒内
            GameObject obj = (GameObject)Resources.Load("Prefabs/WolfNormal");    //加载预制体到内存
            Goldeater = Instantiate<GameObject>(obj);    //实例化敌人
            Goldeater.transform.position = new Vector3(Random.Range(5f, 5f), 0f, Random.Range(5f, 5f));    //随机生成狼的位置
        }

    }
}