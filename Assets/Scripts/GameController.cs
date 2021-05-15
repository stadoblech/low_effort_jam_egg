using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Cinemachine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    OnPlayerEventsScriptable playerEvents;

    [SerializeField]
    float endGameDelayTimes;

    

    [SerializeField]
    string nextSceneName;

    [SerializeField]
    GameObject brokenEggModel;

    [Header("UI")]
    public GameObject UI;
    public Text endLabel;
    public string wonText, LostText;

    GameObject playerModel;
    CinemachineFreeLook cineCam;

    void Start()
    {
        UI.SetActive(false);
        playerModel = GameObject.FindGameObjectWithTag("Player");
        cineCam = GameObject.FindGameObjectWithTag("3dCam").GetComponent<CinemachineFreeLook>();
        playerEvents.OnPlayerKilled += playerKilled;
        playerEvents.OnPlayerFinishedLevel += playerFinishedLevel;
    }

    private void OnDisable()
    {
        playerEvents.OnPlayerKilled -= playerKilled;
        playerEvents.OnPlayerFinishedLevel -= playerFinishedLevel;
    }

    void playerKilled()
    {
        setupEndGlobal(false);
        StartCoroutine(restartSceneCoroutine(false));
    }

    void playerFinishedLevel()
    {
        setupEndGlobal(true);
        StartCoroutine(restartSceneCoroutine(true));
    }

    IEnumerator restartSceneCoroutine(bool won)
    {
        yield return new WaitForSeconds(endGameDelayTimes);
        if (won)
            SceneManager.LoadScene(nextSceneName);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void setupEndGlobal(bool won)
    {
        if (won)
        {
            UI.SetActive(true);
            endLabel.text = wonText;
        }
        Instantiate(brokenEggModel, playerModel.transform.position, Quaternion.identity);
        playerModel.SetActive(false);
        cineCam.enabled = false;
    }

}
