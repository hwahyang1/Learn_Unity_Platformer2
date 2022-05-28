using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/*
 * [Class] ScriptView
 * 대사의 출력을 관리합니다.
 */
public class ScriptView : MonoBehaviour
{
	[SerializeField]
	private Text message;

	[SerializeField]
	private Image continueBtn;

	[SerializeField, Range(0f, 1f)]
	private float textSpeed = 0.1f;

	[SerializeField, Range(0.01f, 5f)]
	private float blinkSpeed = 0.25f;

	private bool isShowMessage = false; // 현재 메시지 출력중인지 여부
	private bool isEnd = false; // 메시지 출력 종료 여부

	[HideInInspector]
	public bool isShowWindow = false; // 현재 대사창이 표시되었는지 여부

	private void Start()
	{
		gameObject.SetActive(false);
	}

	private void Update()
	{
		// 특정 키를 누르거나 클릭하면 출력 중인 대사를 스킵하도록 설정
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
			if (isShowMessage)
			{
				isShowMessage = false;
			}

			if (continueBtn.gameObject.activeInHierarchy)
			{
				isEnd = true;
			}
		}
	}

	private IEnumerator ShowMessage(string message)
	{
		isShowMessage = true;
		isShowWindow = true;
		isEnd = false;

		this.message.text = "";
		for (int i = 0; i < message.Length; i++)
		{
			yield return new WaitForSeconds(textSpeed);
			this.message.text += message[i];

			if (!isShowMessage)
			{
				this.message.text = message;
				break;
			}
		}
	}
}
