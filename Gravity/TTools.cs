using System;

namespace TTools {
    public struct Vector2D {
        public double x { get; set; }
        public double y { get; set; }

        // Returns distance between two vectors
        public static double Distance (Vector2D one, Vector2D two) {
            return Math.Sqrt (Math.Pow (two.x - one.x, 2) + Math.Pow (two.y - one.y, 2));
        }

        // Subtract one vector from another
        public static Vector2D operator - (Vector2D one, Vector2D two) {
            return new Vector2D (one.x - two.x, one.y - two.y);
        }

        // Subtract scalar from vector
        public static Vector2D operator - (Vector2D vector, double scalar) {
            return new Vector2D (vector.x - scalar, vector.y - scalar);
        }

        // Add two vectors together
        public static Vector2D operator + (Vector2D one, Vector2D two) {
            return new Vector2D (one.x + two.x, one.y + two.y);
        }

        // Add scalar to vector
        public static Vector2D operator + (Vector2D vector, double scalar) {
            return new Vector2D (vector.x + scalar, vector.y + scalar);
        }

        // Multiply vector by scalar
        public static Vector2D operator * (Vector2D vector, double scalar) {
            return new Vector2D (vector.x * scalar, vector.y * scalar);
        }

        public static Vector2D operator * (double scalar, Vector2D vector) {
            return new Vector2D (vector.x * scalar, vector.y * scalar);
        }

        public static Vector2D operator * (Vector2D one, Vector2D two) {
            return new Vector2D (one.x * two.x, one.y * two.y);
        }

        public static Vector2D operator / (Vector2D vector, double scalar) {
            return new Vector2D (vector.x / scalar, vector.y / scalar);
        }

        public static Vector2D LPerpendicular (Vector2D vector) {
            return new Vector2D (vector.y, -vector.x);
        }

        public static Vector2D RPerpendicular (Vector2D vector) {
            return new Vector2D (-vector.y, vector.x);
        }

        public static bool operator > (Vector2D one, Vector2D two) {
            return ((one.x + one.y) / 2) > ((two.x + two.y) / 2);
        }

        public static bool operator < (Vector2D one, Vector2D two) {
            return !(one > two);
        }

        public static bool operator == (Vector2D one, Vector2D two) {
            return (one.x == two.x) && (one.y == two.y);
        }

        public static bool operator != (Vector2D one, Vector2D two) {
            return !(one == two);
        }

        public override bool Equals (object obj) {
            return base.Equals (obj);
        }

        // Returns the dot product of two vectors
        public static double Dot (Vector2D one, Vector2D two) {
            return ((one.x * two.x) + (one.y * two.y));
        }

        public override string ToString () {
            return string.Format ($"({this.x}, {this.y})");
        }

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public static Vector2D Zero = new Vector2D (0, 0);
        public static Vector2D Up = new Vector2D (0, 1);
        public static Vector2D Down = new Vector2D (0, -1);
        public static Vector2D Left = new Vector2D (-1, 0);
        public static Vector2D Right = new Vector2D (1, 0);
        public static Vector2D UR = new Vector2D (1 / Math.Sqrt (2), 1 / Math.Sqrt (2));
        public static Vector2D DR = new Vector2D (1 / Math.Sqrt (2), -1 / Math.Sqrt (2));
        public static Vector2D DL = new Vector2D (-1 / Math.Sqrt (2), -1 / Math.Sqrt (2));
        public static Vector2D UL = new Vector2D (-1 / Math.Sqrt (2), 1 / Math.Sqrt (2));

        // Constructor
        public Vector2D (double x, double y) {
            this.x = x;
            this.y = y;
        }
    }

    public struct Vector3 {
        double x { get; set; }
        double y { get; set; }
        double z { get; set; }

        // Returns distance between two vectors
        public static double Distance (Vector3 one, Vector3 two) {
            return Math.Sqrt (Math.Pow (two.x - one.x, 2) + Math.Pow (two.y - one.y, 2) + Math.Pow (two.z - one.z, 2));
        }

        // Subtract one vector from another
        public static Vector3 operator - (Vector3 one, Vector3 two) {
            return new Vector3 (one.x - two.x, one.y - two.y, one.z - two.z);
        }

        // Subtract scalar from vector
        public static Vector3 operator - (Vector3 vector, double scalar) {
            return new Vector3 (vector.x - scalar, vector.y - scalar, vector.z - scalar);
        }

        // Add two vectors together
        public static Vector3 operator + (Vector3 one, Vector3 two) {
            return new Vector3 (one.x + two.x, one.y + two.y, one.z + two.z);
        }

        // Add scalar to vector
        public static Vector3 operator + (Vector3 vector, double scalar) {
            return new Vector3 (vector.x + scalar, vector.y + scalar, vector.z + scalar);
        }

        // Multiply vector by scalar
        public static Vector3 operator * (Vector3 vector, double scalar) {
            return new Vector3 (vector.x * scalar, vector.y * scalar, vector.z * scalar);
        }

        // Returns the dot product of two vectors
        public static double Dot (Vector3 one, Vector3 two) {
            return ((one.x * two.x) + (one.y * two.y) + (one.z * two.z));
        }

        // Constructor
        public Vector3 (double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public struct TVector {
        public Vector2D One { get; set; }
        public Vector2D Two { get; set; }

        public TVector (Vector2D one, Vector2D two) {
            One = one;
            Two = two;
        }

        public static Vector2D Transformation (TVector tv, Vector2D input) {
            return new Vector2D (Vector2D.Dot(tv.One, input), Vector2D.Dot(tv.Two, input));
        }

        public static TVector Flip (TVector tv) {
            return new TVector (new Vector2D(tv.One.x, tv.Two.x), new Vector2D(tv.One.y, tv.Two.y));
        }

        public static TVector Transform (TVector tv1, TVector tv2) {
            return new TVector (Transformation(tv1, Flip(tv2).One), Transformation(tv1, Flip(tv2).Two));
        }
    }
}