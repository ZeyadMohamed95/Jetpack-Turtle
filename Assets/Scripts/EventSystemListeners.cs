using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemListeners : MonoBehaviour
{

    public static EventSystemListeners main;
    public List<GameObject> listeners;

	// Use this for initialization
    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Debug.LogWarning("EventSystemListeners re-creation attempted, destroying the new one");
            Destroy(gameObject);
        }
    }

	// Update is called once per frame
    void Start()
    {
        // Look for every object tagged as a listener
        if (listeners == null)
        {
            listeners = new List<GameObject>();
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Listener");

        listeners.AddRange(gos);

    }
    public void AddListener(GameObject go)
    {
        // Don't add if already there
        if (!listeners.Contains(go))
        {
            listeners.Add(go);
        }
    }

}
