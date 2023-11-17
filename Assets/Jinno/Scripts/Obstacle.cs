using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Obstacle : MonoBehaviour
{

    // 障害物の耐久ポイント
    public int damagePoint = 30;
    int damageA = 10;
    int damageB = 5;


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("接触");
        if (collision.gameObject.tag == "bullet")
        {
            damagePoint -= damageA;
            dispPoints(damagePoint.ToString());
            if (damagePoint < 0)
            {
                // gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
        // else // if (collision.gameObject.tag == "player")
        // {
        //     damagePoint -= damageB;
        //     if (damagePoint < 0)
        //     {
        //         // gameObject.SetActive(false);
        //         Destroy(gameObject);
        //     }
        // }
    }
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("接触中");
    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("離脱");
    }

    // テキストエリア
    public TextMeshProUGUI damageText;

    IEnumerator dispPoints(string damagePoint)
    {
        string dispTextArea = damagePoint;
        dispTextArea += string.Format("-{0} point");
        // テキストエリアを画面にセット
        damageText.text = dispTextArea;
        // 指定した秒数だけ処理を待つ(1.0秒)
        yield return new WaitForSeconds(10.0f);
        dispTextArea = "";
    }

}
