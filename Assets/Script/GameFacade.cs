using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameFacade : MonoBehaviour

{
    private static GameFacade  _instance;
    public static GameFacade Instance { get { return _instance; } }
    // Start is called before the first frame update

    private PlayerManager playerManager;
    private UIManager uIManager;
    private RequestManager requestManager;
    private AudioManager audioManager;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);return;
        }
        _instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInit() {
        playerManager = new PlayerManager(this);
        uIManager = new UIManager(this);
        requestManager = new RequestManager(this);
        audioManager = new AudioManager(this);
    }


    public void AddRequest(UInt64 messageId ,BaseRequest request) {
        requestManager.AddRequest(messageId, request);
    }

    public void RemoveRequest(UInt64 messageId) {
        requestManager.RemoveRequest(messageId);
    }

    public void HandleResponse(UInt64 messageId ,byte[] data ) {
        requestManager.HandleResponse(messageId, data);
    }
}
