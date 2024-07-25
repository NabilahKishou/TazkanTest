using System;
using System.Collections.Generic;
using UnityEngine;

namespace NabilahKishou.TazkanTest
{
    [CreateAssetMenu(fileName = "ColorDirectory", menuName = "Scriptable Objects/Color Directory")]
    public class ColorDirectory : ScriptableObject
    {
        public List<Colored> _colorDirectory;
        public Color GetColor(Colorway way) => _colorDirectory.Find((c) => c.key == way).color;
    }

    [Serializable]
    public class Colored
    {
        public Colorway key;
        public Color color;
    }

    public enum Colorway
    {
        Red,
        Green,
        Blue,
        Yellow
    }
}