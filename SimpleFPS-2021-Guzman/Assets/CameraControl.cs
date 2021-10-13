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
        float x = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime * -1;
        transform.Rotate(new Vector3(0, x * rotSpeed * Time.deltaTime, 0));
        LookUpDown.Rotate(new Vector3(y * rotSpeed * Time.deltaTime * -1, 0, 0));
        y = Mathf.Clamp(LookUpDown.eulerAngles.y, -90f, 90f);
    }
}
