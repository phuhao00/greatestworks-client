using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RequestManager:BaseManager
{
    public RequestManager(GameFacade facade) : base(facade) { }

    private Dictionary<UInt64, BaseRequest> requestDict = new Dictionary<UInt64, BaseRequest>();

    public void AddRequest(UInt64 messageId, BaseRequest req) {
        requestDict.Add(messageId, req);
    }

    public void RemoveRequest(UInt64 messageId)
    {
        requestDict.Remove(messageId);
    }

    public void HandleResponse(UInt64  messageId,byte[] data) {

        BaseRequest req;
        requestDict.TryGetValue(messageId,out req);
        if (req == null) {

            Debug.LogError("can not  get  Reequet instance ,messageId:"+messageId);
            return;
        }
        req.OnResponse(data);
    }
}
