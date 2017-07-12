using System.Collections.Generic;
using Twitter;
using UnityEngine;

namespace UseTwitter
{
	/// <summary>
	/// http://qiita.com/toofu/items/075efed6ab1f23e94388
	/// </summary>
	public class AccecssTwitter : MonoBehaviour {
		void Awake () {
			Oauth.consumerKey       = "sy0H1Dzml4mjWTnWKGLzzDbNY";
			Oauth.consumerSecret    = "XxU87c6bo1prODrKVL9rRuFLwRUwxaX2phKnmx9rK1ZMu1luHc";
			Oauth.accessToken       = "45102673-mzOwGWMZcsxUqvVaYs7tFgjWpTv7DSHz8X8iOyJ84";
			Oauth.accessTokenSecret = "dbNWtiUTn4j0P4RqoObMVOh2mBQUsykYXHcZdbe2DZ6Cn";
		}
		
		void Start() {
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters ["status"] = "Tweet from Unity";  // ツイートするテキスト
			StartCoroutine (Client.Post ("statuses/update", parameters, Callback));
		}

		void Callback(bool success, string response) {
			if (success) {
				Tweet tweet = JsonUtility.FromJson<Tweet> (response); // 投稿したツイートが返ってくる
			} else {
				Debug.Log (response);
			}
		}
	}
}