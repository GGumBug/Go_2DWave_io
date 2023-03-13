using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private CameraController    cameraController;
    [SerializeField]
    private GameObject          textTitle;
    [SerializeField]
    private GameObject          textTapToPlay;

    [SerializeField]
    private TextMeshProUGUI     textCurrentScore;
    [SerializeField]
    private TextMeshProUGUI     textBestScore;

    [SerializeField]
    private GameObject          buttonContinue;
    [SerializeField]
    private GameObject          textScoreText;

    private int                 currentScore;
    private int                 bestScore = 0;
    private float               gameOverDelayTime = 1;

    public bool                 IsGameOver {private set; get;} = false;

    //스타트를 코루틴으로 실행해서 브레이크가 됐을때는 더이상 실행되지 않게 하는 로직
    private IEnumerator Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");

        textBestScore.text = $"<size=50>BESTSCORE</size>\n<size=100>{bestScore}</size>";

        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();

                yield break;
            }

            yield return null;
        }
    }

    private void GameStart()
    {
        textTitle.SetActive(false);
        textTapToPlay.SetActive(false);

        textCurrentScore.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        ShakeCamera.Instance.OnShakeCamera(0.5f,0.1f);

        IsGameOver = true;

        StartCoroutine("OnGameOver");
    }

    private IEnumerator OnGameOver()
    {
        yield return new WaitForSeconds(gameOverDelayTime);

        if (currentScore == bestScore)
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
        }

        buttonContinue.SetActive(true);
        textScoreText.SetActive(true);
    }

    public void IncreaseScore(int score)
    {
        currentScore += score;

        textCurrentScore.text = currentScore.ToString();

        if (bestScore < currentScore)
        {
            bestScore = currentScore;
            textBestScore.text = textBestScore.text = $"<size=50>BESTSCORE</size>\n<size=100>{bestScore}</size>";
        }

        cameraController.ChangeBackGroundColor();
    }

    public void ContinueGame()
    {
        //현재 작동중인 씬의 이름을 로드씬에 넣어주는 코드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
