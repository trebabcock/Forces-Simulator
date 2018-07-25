using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using TTools;

namespace Gravity {
    class Simulation {
        public static List<PhysicsBody> AllBodies = new List<PhysicsBody> ();

        GameWindow window;

        public Simulation (GameWindow window) {
            this.window = window;
            Start ();
        }

        void Start () {
            window.Load += Loaded;
            window.Resize += Resize;
            //AllBodies.Add (new PhysicsBody (30000000000, 50, new Vector2D ((window.Width / 2), (window.Height / 2)), new Vector2D (0.01, 0.01), Color4.DarkSlateGray, 0));
            //AllBodies.Add (new PhysicsBody (1000000000, 5, new Vector2D ((window.Width / 2) - 160, (window.Height * 0.75) - 5), new Vector2D (0, -0.1), Color4.Blue, 1));
            //AllBodies.Add (new PhysicsBody (1000000000, 5, new Vector2D ((window.Width / 2) + 160, (window.Height * 0.75) - 5), new Vector2D (-0.05, -0.5), Color4.Cyan, 2));
            //AllBodies.Add (new PhysicsBody (1000000000, 5, new Vector2D ((window.Width / 2) - 160, (window.Height * 0.25) - 5), new Vector2D (0.05, 0.5), Color4.Turquoise, 3));
            //AllBodies.Add (new PhysicsBody (1000000000, 5, new Vector2D ((window.Width / 2) + 160, (window.Height * 0.25) - 5), new Vector2D (0, 0.1), Color4.DarkTurquoise, 4));
            AllBodies.Add (new PhysicsBody (1000000000000, 5, new Vector2D (100, window.Height / 2), Vector2D.Zero, Color4.DarkTurquoise, 0));
            AllBodies.Add (new PhysicsBody (999999999999, 5, new Vector2D (1100, window.Height / 2), Vector2D.Zero, Color4.DarkTurquoise, 1));
            window.RenderFrame += RenderFrame;
            window.Run (1 / 60);
        }

        void Resize (object o, EventArgs e) {
            GL.Viewport (0, 0, window.Width, window.Height);
            GL.MatrixMode (MatrixMode.Projection);
            GL.LoadIdentity ();
            GL.Ortho (0.0, window.Width, 0.0, window.Height, -1.0, 1.0);
            GL.MatrixMode (MatrixMode.Modelview);
        }

        void RenderFrame (object o, EventArgs e) {
            GL.Clear (ClearBufferMask.ColorBufferBit);
            for (int i = 0;i < AllBodies.Count;i++) {
                GL.Begin (PrimitiveType.Polygon);
                GL.Color4 (AllBodies[i].Color);
                for (int j = 0;j < 360;j++) {
                    GL.Vertex2 (AllBodies[i].Position.x + Math.Cos (j) * AllBodies[i].Radius, AllBodies[i].Position.y + Math.Sin (j) * AllBodies[i].Radius);
                }
                GL.End ();
                AllBodies[i].Move ();
                // Console.WriteLine (AllBodies[i].ToString ());
            }
            //DrawLine ();
            window.SwapBuffers ();
        }

        void DrawLine () {
            GL.Begin (PrimitiveType.Quads);
            GL.Color4 (Color4.DarkSlateGray);
            GL.Vertex2 (0, 0);
            GL.Vertex2 (window.Width, 0);
            GL.Vertex2 (window.Width, window.Height);
            GL.Vertex2 (0, window.Height);
            GL.End ();
            window.SwapBuffers ();
        }

        void Loaded (object o, EventArgs e) {
            GL.ClearColor (0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}