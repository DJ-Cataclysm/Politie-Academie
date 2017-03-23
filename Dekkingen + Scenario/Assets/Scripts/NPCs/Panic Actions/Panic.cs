using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.NPCs.Panic_Actions {
    public interface Panic {
        GameObject target { get; }
    }
}
