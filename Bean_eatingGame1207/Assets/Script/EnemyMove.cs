using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform[] endPoint;
    int index = 0;
    private float timer = 0;
    private float timere = 0;
    private float speeds = 0.65f;
    private float temp = 0.0f;
    private bool isbool = false;
    public GameObject enemyObj;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(endPoint[index].position);//获取目标点位置
        temp = nav.speed;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other .transform .tag == "Jr")
        {
            GameObject bzs = Instantiate(Resources.Load("bz", typeof(GameObject)) as GameObject);
            Destroy(other.gameObject);
            bzs.transform.SetParent(transform);
            bzs.transform.localPosition = Vector3.zero;
            Destroy(bzs, 1);
            nav.speed = speeds;
            enemyObj.SetActive(true);
            isbool = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isbool==true)
        {
            timere += Time.deltaTime;
            if (timere >= 20.0f)
            {
                isbool = false;
                timere = 0f;
                nav.speed = temp;
                enemyObj.SetActive(false);
            }
        }
        
        if (nav.remainingDistance <= 0.01f)
        {
            timer += Time.deltaTime;
            if (timer >= 0.1f)
            {
                timer = 0;
                index++;
                index %= endPoint.Length;
                nav.SetDestination(endPoint[index].position);
            }
        }
    }
}
