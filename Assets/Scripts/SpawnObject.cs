using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnObject : MonoBehaviour
{
    public GameObject prefab;
    public Camera mainCamera;
    public static int numCows = 0;
    public TextMeshProUGUI numberCows;
    public TextMeshProUGUI timerText;
    private int countDownTime = 10;

    void Start()
    {
        StartCoroutine(Countdown());

    }

    void Update()
    {
        if (countDownTime != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 touchPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
                Instantiate(prefab, touchPos, Quaternion.identity);
                numCows++;

            }

            //MOBILE CONTROLS FIX
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0f;
                transform.position = touchPosition;
            }
        }

        numberCows.text = "Herd Size " + numCows.ToString();
    }

    IEnumerator Countdown()
    {
        while (countDownTime > 0)
        {
            timerText.text = countDownTime.ToString();

            yield return new WaitForSeconds(1);

            countDownTime--;
        }

        //display done for 2 seconds
        timerText.text = "DONE!";
        yield return new WaitForSeconds(2);

        //set done to false which deletes it from screen and will ultimately switch scenes
        timerText.gameObject.SetActive(false);


        //switch scenes once countdown is done
        if (timerText.gameObject.activeSelf == false)
        {
            SceneManager.LoadScene("RunScene");
        }
    }
}

