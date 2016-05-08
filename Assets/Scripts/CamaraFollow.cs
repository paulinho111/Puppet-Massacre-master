using UnityEngine;
using System.Collections;

public class CamaraFollow : MonoBehaviour {

    public Transform target;

    public float posx = 0;
    public float posy = 0;
    public float posz = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        while (target != null)
        {
            Vector3 NewCamaraPosition = new Vector3(target.position.x + posx, target.position.y + posy, target.position.z + posz);
            transform.position = NewCamaraPosition;

        }
    }
}
