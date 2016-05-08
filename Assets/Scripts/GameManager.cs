using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Transform[] EnemySpawner;
    public GameObject[] enemies;

    public float NumEnemies = 10;
    public Text NumEnemies_txt;

    public float SpawnWait;
    public int StartCntDown;
 
    public float WaveWait;

    public float CurWave;
    public float Wave;
    public Text WaveCount_txt;

    public int score;
    public Text ScoreText;

     PlayerScript playerHealthReference;
    public Slider HealthBar;

    float StartCountDown =5;
    // Use this for initialization
    void Start()
    {
        StartCoroutine("WaveControl");
        ScoreText = GameObject.FindGameObjectWithTag("Score_Num").GetComponent<Text>();
        playerHealthReference = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text ="ScoreNumber: " + score.ToString();
        WaveCount_txt.text = "Number Of Wave:" + CurWave.ToString();
        NumEnemies_txt.text = "WaveEnemiesNum:" + NumEnemies.ToString();
        HealthBar.value = playerHealthReference.PlayerHeath;
        StartCountDown -= Time.deltaTime;
    }
    IEnumerator WaveControl()
    {
        yield return new WaitForSeconds(StartCntDown);
        while (true)
        {
            for (int i = 0; i < NumEnemies; i++)
            {
                int randomSpawneersIndex = Random.Range(0, EnemySpawner.Length);
                int randomEnemiesIndex = Random.Range(0, enemies.Length);
                Instantiate(enemies[randomEnemiesIndex], EnemySpawner[randomSpawneersIndex].position, EnemySpawner[randomSpawneersIndex].rotation);
                yield return new WaitForSeconds(SpawnWait);
            }
            yield return new WaitForSeconds(WaveWait);
            NumEnemies = NumEnemies + 2;
            CurWave = Wave + 1;
        }
    }
}
