using UnityEngine;
using System.Collections;

public class SeedControl : MonoBehaviour {
    private CreateSeeds seed;
	// Use this for initialization
	void Start () {
        seed = GameObject.Find("Main Camera").GetComponent<CreateSeeds>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<RectTransform>().anchoredPosition.x > 300.0f)
        {
            Destroy(this.gameObject);
            seed.isDestroyed();
        }
	
	}
}
