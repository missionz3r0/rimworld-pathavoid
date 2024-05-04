using UnityEngine;
using Verse;

namespace PathAvoid
{
    public class PathAvoidDef : Def
    {
        public string name;

        public int level;

        public string desc;

        public Color color;

        public Color colorOfIcon;

        public KeyBindingDef hotKey;
    }

    public class MapSettingsDef : Def
    {
        public string name;
        public KeyBindingDef hotKey;
    }
}
