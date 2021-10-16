using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    Transform gunBarrel;

    [SerializeField]
    float bulletSpeed;

    [SerializeField]
    Image bar;

    int ammo = 5;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0)
        {
            Vector3 bulletDirection = transform.forward * bulletSpeed;
            GameObject b = Instantiate(bullet, gunBarrel.position , transform.rotation);
            b.GetComponent<Rigidbody>().velocity = bulletDirection;

            ammo -= 1;
            UpdateHUD();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ammo")
        {
            ammo += 5;
            if(ammo >= 5)
            {
                ammo = 5;
            }

            UpdateHUD();

            Destroy(collision.collider.gameObject);
        }
    }

    void UpdateHUD()
    {
        bar.fillAmount = ammo / 5f;
    }
}
