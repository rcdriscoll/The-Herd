using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //private float distance = 0f;
    public int score = 0;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI cowsUI;
    //public TextMeshProUGUI distUI;

    Vector3 lastPos;

    private void Start()
    {
        //lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("RunScene"))
        {
            //distance += (Vector3.Distance(transform.position, lastPos) / 1000);
            scoreUI.text = "Score: " + score.ToString();
            cowsUI.text = "Herd: " + SpawnObject.numCows.ToString();
            //distUI.text = distance.ToString();

        }

    }

    //Gets called when a trigger is entered
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "scoreup")
        {
            score++;
        }

        if (other.gameObject.tag == "cactus")
        {
            SpawnObject.numCows -= 10;
        }
       
        if (other.gameObject.tag == "rock")
        {
            SpawnObject.numCows -= 5;
        }
    }
}



