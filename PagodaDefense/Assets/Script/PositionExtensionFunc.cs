using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExtensionFunc
{
    public static class PositionExtensionFunc
    {
        public static Vector3 NewX(this Vector3 pos, float value)
        {
            pos = new Vector3(value, pos.y, pos.z);
            return pos;
        }
        public static Vector3 NewY(this Vector3 pos, float value)
        {
            pos = new Vector3(pos.x, value, pos.z);
            return pos;
        }
        public static Vector3 NewZ(this Vector3 pos, float value)
        {
            pos = new Vector3(pos.x, pos.y, value);
            return pos;
        }
    }
}

