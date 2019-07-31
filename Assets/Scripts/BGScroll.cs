using UnityEngine;

public class BGScroll : MonoBehaviour {
    Material material;
    Vector2 offset;
    public float speed = 0.5f;
	// Use this for initialization
	void Awake () {
        material = GetComponent<SpriteRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        offset = new Vector2(Time.deltaTime * speed, 0);

        material.mainTextureOffset += offset;
	}
}
