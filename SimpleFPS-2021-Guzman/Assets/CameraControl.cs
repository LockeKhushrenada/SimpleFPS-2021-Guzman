using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    float rotSpeed = 1;

    [SerializeField]
    Transform LookUpDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        //y = Mathf.Clamp(y * rotSpeed * Time.deltaTime * -1, -90f, 90f);
        transform.Rotate(new Vector3(0, x * rotSpeed * Time.deltaTime, 0));
        if (LookUpDown.localEulerAngles.y >= -80f && LookUpDown.localEulerAngles.y <= 80f)
        {
            LookUpDown.Rotate(new Vector3(y * rotSpeed * Time.deltaTime * -1, 0, 0));
        }
        else
        {
            if(LookUpDown.localEulerAngles.y * -1 <= -80f)
            {
                LookUpDown.Rotate(new Vector3(-1,0,0));
            }
            if (LookUpDown.localEulerAngles.y * -1 >= 80f)
            {
                LookUpDown.Rotate(-1,0,0);
            }
        }
    }
}
