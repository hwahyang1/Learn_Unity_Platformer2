using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
 * [Namespace] _20220515_Platform2.Game.Managers
 * 
 */
namespace _20220515_Platform2.Game.Managers
{
	/*
	 * [Enum] ItemCode
	 * 게임 내의 아이템 목록을 정의합니다.
	 */
	public enum ItemCode
	{
		None,
		Axe,
		Staff,
		Book
	}

	/*
	 * [Class] ItemManager
	 * 게임 내의 아이템을 관리합니다.
	 */
	public class ItemManager : MonoBehaviour
	{
		/* Singleton design pattern: PPT 참고 */

		private static ItemManager instance = null;

		[SerializeField]
		[Tooltip("ItemCode에 등록한 순서대로 이미지를 등록하세요.")]
		private List<Sprite> itemImages = new List<Sprite>();

		[SerializeField]
		[Tooltip("ItemCode에 등록한 순서대로 아이템 이름을 등록하세요.")]
		private List<string> itemNames = new List<string>();

		public static ItemManager Instance
		{
			get
			{
				if (instance == null)
				{
					// 프로젝트 전체 검색
					instance = FindObjectOfType<ItemManager>();

					if (instance == null)
					{
						instance = new GameObject("ItemManager").AddComponent<ItemManager>();
					}
				}

				return instance;
			}

			/*set
			{
				instance = value;
			}*/
		}

		private void Awake()
		{
			ItemManager[] managers = FindObjectsOfType<ItemManager>();

			if (managers.Length != 1) // 0이 될수는 없음 (최소한 자기 자신은 있기 때문)
			{
				Destroy(gameObject);
				return;
			}

			DontDestroyOnLoad(gameObject);
		}

		public Sprite GetItemSprite(ItemCode code)
		{
			return itemImages[(int)code];
		}

		public string GetItemName(ItemCode code)
		{
			return itemNames[(int)code];
		}
	}
}
