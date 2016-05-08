using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public Text title;
	// Use this for initialization
	void Start () {
        title.text = "Room Massacre";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void loadLevel()
    {
        SceneManager.LoadScene("InputExp");
    }
    public void loadLevel2()
    {
        SceneManager.LoadScene("PuppetMassacre");
    }
}
