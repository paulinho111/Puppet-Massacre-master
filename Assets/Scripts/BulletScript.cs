using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BulletScript : MonoBehaviour {

    public float BulletSpeed;
    public ParticleSystem EnemyDeath;
    public GameManager scoretext;

    // Use this for initialization
    void Start () {
        scoretext = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);
 
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            scoretext.score = scoretext.score + 1;
            Destroy(col.gameObject);
            Destroy(Instantiate(EnemyDeath, col.gameObject.transform.position, col.gameObject.transform.rotation) as GameObject);
            
          
        }
    }
}
 