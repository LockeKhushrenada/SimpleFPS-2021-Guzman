using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    Image bar;

    [SerializeField]
    int goToLevel = 0;

    float health = 5;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(goToLevel);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy" || collision.collider.tag == "hazard")
        {
            health -= 1;

            UpdateHUD();
        }
    }

    void UpdateHUD()
    {
        bar.fillAmount = health / 5f;
    }
}
