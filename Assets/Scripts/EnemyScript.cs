using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    Transform target;
    NavMeshAgent agent;
   

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
      
    }
    

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            
            Destroy(col.gameObject);
        }    
    }
}
