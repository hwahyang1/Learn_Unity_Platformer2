using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * [Namespace] _20220515_Platform2.Intro
 * IntroScene과 관련된 내용을 처리합니다.
 */
namespace _20220515_Platform2.Intro
{
	/*
 * [Class] IntroScene
 * IntroScene 버튼의 행동을 정의합니다.
 */
	public class IntroScene : MonoBehaviour
	{
		public void OnGameStartButtonClicked()
		{
			//SceneManager.LoadScene(1); // Build Index에 추가된 *순서*를 기준으로 불러올 경우
			SceneManager.LoadScene("GameScene"); // Build Index에 추가된 씬을 *이름*으로 불러올 경우
		}

		public void OnGameExitButtonClicked()
		{
			#if UNITY_EDITOR
				EditorApplication.ExecuteMenuItem("Edit/Play"); // 에디터의 경우 Play Mode만 종료하도록 함
			#else
				Application.Quit();
			#endif
		}
	}

}
