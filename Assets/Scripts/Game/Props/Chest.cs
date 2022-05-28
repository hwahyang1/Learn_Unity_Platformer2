using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using _20220515_Platform2.Game.Player;

/*
 * [Namespace] _20220515_Platform2.Game.Prop
 * Prop GameObject와 관련된 내용을 처리합니다.
 */
namespace _20220515_Platform2.Game.Props
{
	/*
	 * [Class] Chest
	 * 상자의 상호작용을 관리합니다.
	 */
	public class Chest : EventProp
	{
		[SerializeField]
		private Sprite[] images = new Sprite[2];

		private SpriteRenderer render;

		private void Start()
		{
			render = GetComponent<SpriteRenderer>();
		}

		public override void OnInteract(PlayerInventory inventory)
		{
			if (!isUsed)
			{
				isUsed = true;

				StartCoroutine("OnChestInteract"); // C#에서는 Invoke가 가능해서 생길 수 있는 구조
				//StartCoroutine(OnChestInteract());
				GiveAllItems(inventory);
			}
		}

		/*
		 * 루틴 (Routine): 유니티가 실행하는 스크립트의 *주된* 흐름
		 * 코루틴 (Coroutine): 
		 * 
		 * 루틴이 코루틴 실행 -> 코루틴 작업 시작 -> 루틴을 멈출만한 일이 생기면 일정 조건과 함께 실행 흐름을 루틴에게 양보
		 * => 병렬 처리가 되는 것 *처럼* 보이게 됨.
		 * 
		 * IEnumerator라는 인터페이스를 사용하여 코루틴 생성
		 * 근데 얘 메소드라서 리턴을 해줘야 하는데 yield return을 사용함
		 * (현재 작업 중인 코루틴 값을 루틴에게 리턴 -> 실행 흐름을 양보)
		 */
		private IEnumerator OnChestInteract()
		{
			render.sprite = images[1];

			// 실행 흐름을 잠시 넘겨줬다가 아래 시간 후 실행 흐름을 다시 가져옴
			yield return new WaitForSeconds(2.5f);

			render.sprite = images[0];
		}
	}
}