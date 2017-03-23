using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour {

    private static List<NPC> _all;
    private static List<FriendlyNPC> _friendlies;
    private static List<HostileNPC> _hostiles;

    public static List<NPC> all {
        get {
            if (_all == null)
                _all = new List<NPC>(FindObjectsOfType<NPC>());
            return _all;
        }
    }

    public static List<FriendlyNPC> friendlies {
        get {
            if(_friendlies == null) {
                _friendlies = new List<FriendlyNPC>(FindObjectsOfType<FriendlyNPC>());
            }
            return _friendlies;
        }
    }

    public static List<HostileNPC> hostiles {
        get {
            if(_hostiles == null) {
                _hostiles = new List<HostileNPC>(FindObjectsOfType<HostileNPC>());
            }
            return _hostiles;
        }
    }

	void Start () {
        if (_all != null)
            _all.Add(this);
	}

    protected virtual void OnDestroy() {
        if (_all != null)
            _all.Remove(this);
        print("Original is called");
    }
}
