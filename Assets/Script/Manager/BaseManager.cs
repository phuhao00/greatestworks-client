using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager{

    protected GameFacade gameFacade;
    public BaseManager(GameFacade facade) {
        this.gameFacade = facade;
    }
    public virtual void OnInit() { }
    public virtual void OnDestroy() { }

}
