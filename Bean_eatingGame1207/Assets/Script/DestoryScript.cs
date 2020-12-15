using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryScript : MonoBehaviour
{
    private float speed = 1.25f;
    public static int num = 0;
    public static bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "target")
        {
            Destroy(this.gameObject);
        }
        if(other .transform .tag == "points")
        {
            Destroy(other.gameObject);
            num++;
        }
        if (other.transform.tag == "mub"||other .transform .tag =="mua"||other .transform .tag =="muc")
        {
            win = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.up * 90f);//水平旋转
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.down * 90f);//水平旋转
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(Vector3.up * 180f);//水平旋转
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //transform.Translate(new Vector3(0, Input.GetAxis("Jump") * 0.2f, 0));//按空格键向上跳
    }
}
