using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scipts.Planets
{
    public static class PlanetsFuncLib
    {
        public static List<KeyValuePair<string,float>> PlanetSpeed = new List<KeyValuePair<string, float>>();
        public static bool IsInited = false;

        private static float slower = 100f;

        public static float GetPlanetSpeed(string name)
        {
            var planet = PlanetSpeed.FirstOrDefault(x => x.Key == name);
            return planet.Value;
        }

        public static void Init()
        {
            PlanetSpeed.Add(new KeyValuePair<string, float>("Earth", 29.78f / slower));
            PlanetSpeed.Add(new KeyValuePair<string, float>("Mercury", 47.36f / slower));
            PlanetSpeed.Add(new KeyValuePair<string, float>("Venus", 35.02f / slower));
            PlanetSpeed.Add(new KeyValuePair<string, float>("Neptune", 5.43f / slower));
            PlanetSpeed.Add(new KeyValuePair<string, float>("Saturn", 9.69f / slower));
            PlanetSpeed.Add(new KeyValuePair<string, float>("Uranus", 6.81f / slower));
            PlanetSpeed.Add(new KeyValuePair<string, float>("Mars", 24.43f / slower));
            PlanetSpeed.Add(new KeyValuePair<string, float>("Jupiter", 13.07f / slower));
            IsInited = true;

        }
    }
}
