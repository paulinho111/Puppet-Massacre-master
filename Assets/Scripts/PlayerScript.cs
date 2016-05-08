using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {


    // speed is the rate at which the object will rotate
    public float RotationSpeed;
    public float MovementSpeed;
    public GameObject Bullet;
    public Transform BulletShotter;
    public int PlayerHeath = 10;

    void Start()
    {
        BulletShotter = GameObject.FindGameObjectWithTag("BulletSpawner").transform;
    }
    void Update()
    {
        CamaraMovement();
        PlayerMovement();
        ShootInput();
    }
    void CamaraMovement()
    {
        // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.

        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);

        }
    }
    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -MovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -MovementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime);
        }

    }
    void ShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Destroy(Instantiate(Bullet, BulletShotter.position, BulletShotter.rotation), 25 * Time.deltaTime);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            TakingDamage();
            Destroy(col.gameObject);
            if (PlayerHeath == 0)
            {
                Destroy(gameObject);
            } 
            
        }
    }
    void TakingDamage()
    {
        PlayerHeath = PlayerHeath - 1;
        print("taking damage");
    }
}
