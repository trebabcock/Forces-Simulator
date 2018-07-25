using System;
using System.Collections.Generic;
using TTools;
using OpenTK.Graphics;
using System.Threading.Tasks;

namespace Gravity {
    public class PhysicsBody {
        public double Mass { get; set; }
        public double Radius { get; set; }
        public Vector2D Position { get; set; }
        public Vector2D Velocity { get; set; }
        public Color4 Color { get; set; }
        public double Force { get; set; }
        public int ID { get; set; }

        public PhysicsBody (double mass, double radius, Vector2D pos, Vector2D vel, Color4 color, int id) {
            Mass = mass;
            Radius = radius;
            Position = pos;
            Velocity = vel;
            Color = color;
            ID = id;
        }

        public void Move () {
            List<PhysicsBody> toDestroy = new List<PhysicsBody> ();
            foreach (PhysicsBody pb in Simulation.AllBodies) {
                if (pb != this) {
                    if (Vector2D.Distance (this.Position, pb.Position) <= (this.Radius + pb.Radius)) {
                        if (this.Mass < pb.Mass) {
                            pb.Position += this.Velocity;
                            pb.Mass += this.Mass;
                            pb.Velocity += this.Mass * this.Velocity / pb.Mass;
                            toDestroy.Add (this);
                            break;
                        }
                    }
                    Vector2D vAccel = ((pb.Position - this.Position) / Vector2D.Distance (pb.Position, this.Position)) * Globals.Acceleration (pb.Mass, Vector2D.Distance (this.Position, pb.Position));
                    this.Velocity += vAccel;
                }
            }
            if (toDestroy.Count > 0) {
                if (toDestroy.Contains (this)) {
                    Destroy (this);
                } else {
                    Destroy (toDestroy[0]);
                    this.Position += this.Velocity;
                }
            } else {
                this.Position += this.Velocity;
            }
            foreach (PhysicsBody pb in toDestroy) {
                Console.WriteLine ($"Destroyed {pb.ID.ToString ()}");
            }
            Console.WriteLine (this.ToString ());
            toDestroy.Clear ();
        }

        public void Destroy (PhysicsBody body) {
            Simulation.AllBodies.Remove (body);
        }

        public static bool operator == (PhysicsBody one, PhysicsBody two) {
            return one.GetHashCode () == two.GetHashCode ();
        }

        public static bool operator != (PhysicsBody one, PhysicsBody two) {
            return !(one == two);
        }

        public override bool Equals (object obj) {
            return base.Equals (obj);
        }

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override string ToString () {
            return ($"Mass: {this.Mass}\nRadius: {this.Radius}\nPosition: ({this.Position.x}, {this.Position.y})\nVelocity: ({this.Velocity.x}, {this.Velocity.y})\nID: {this.ID}\n\n");
        }
    }
}
