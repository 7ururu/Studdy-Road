using UnityEngine;

public class Knight : Character {

    public override void MakeAction() {
        base.MakeAction();
        Debug.Log("ACTION");
    }
}