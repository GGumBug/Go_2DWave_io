using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private GameObject          textTitle;
    [SerializeField]
    private GameObject          textTapToPlay;

    [SerializeField]
    private GameObject          buttonContinue;

    public bool                 IsGameOver {private set; get;} = false;

    //스타트를 코루틴으로 실행해서 브레이크가 됐을때는 더이상 실행되지 않게 하는 로직
    private IEnumerator Start()
    {
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
    }

    public void GameOver()
    {
        IsGameOver = true;

        buttonContinue.SetActive(true);
    }

    public void ContinueGame()
    {
        //현재 작동중인 씬의 이름을 로드씬에 넣어주는 코드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
