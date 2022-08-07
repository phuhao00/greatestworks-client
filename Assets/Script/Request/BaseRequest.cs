using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BaseRequest : MonoBehaviour
{
    private UInt64 messageId =0;
    public virtual void  Awake()
    {
        GameFacade.Instance.AddRequest(messageId, this);
        
    }
    public virtual void SendRequest() { }
    public virtual void OnResponse(byte[] data) { }
    public virtual void OnDestroy() {
        GameFacade.Instance.RemoveRequest(messageId);
    }
  
    
}
