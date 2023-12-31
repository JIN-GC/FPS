using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public int ShotSpeed;//飛ばす力    
    public GameObject bulletPerfab;// 弾のプレハブ
    public int Maxremainingbullets;
    public int remainingbullets;//マガジン内の残弾

    float timer = 0.0f;
    public float interval;


    private void Start()
    {
        remainingbullets = Maxremainingbullets;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && timer <= 0.0f)
        {
            Shot();
            timer = interval;
        }

        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }

    }
    public void Shot()
    {
        if (remainingbullets > 0)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPerfab, transform.position,
                Quaternion.Euler(
                    transform.position.x + Random.Range(-1.5f, 1.5f),
                    transform.position.y + Random.Range(-1.5f, 1.5f),
                    transform.position.z
                )
            );

            Rigidbody bulletOBJ = bullet.GetComponent<Rigidbody>();
            bulletOBJ.AddForce(this.transform.forward * ShotSpeed);
            bulletOBJ.AddTorque(new Vector3(transform.position.x, transform.position.y, transform.position.z));
            remainingbullets -= 1;
        }
        else
        {
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3.0f);
        remainingbullets = Maxremainingbullets;
    }
}
