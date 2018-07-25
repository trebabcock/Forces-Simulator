using System;

namespace Gravity {
    public static class Globals {
        public static double G () {
            return ((6.67408) * (Math.Pow (10, -11)));
            //return 66.74;
        }

        public static double Acceleration (double mass, double radius) {
            return G () * mass / Math.Pow (radius, 2);
        }
    }
}
