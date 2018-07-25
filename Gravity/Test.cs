using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using TTools;

namespace Gravity {
    class Test {
        public static List<PhysicsBody> AllBodies = new List<PhysicsBody> ();

        GameWindow window;

        public Test (GameWindow window) {
            this.window = window;
            Start ();
        }

        void Start () {
            window.Load += Loaded;
            window.Resize += Resize;
            window.RenderFrame += RenderFrame;
            window.Run (1 / 60);
        }

        void Resize (object o, EventArgs e) {
            GL.Viewport (0, 0, window.Width, window.Height);
            GL.MatrixMode (MatrixMode.Projection);
            GL.LoadIdentity ();
            Matrix4 matrix = Matrix4.Perspective(45.0f, window.Width/window.Height, 1.0f, 1000.0f);
            GL.LoadMatrix(ref matrix);
            GL.MatrixMode (MatrixMode.Modelview);
        }

        void RenderFrame (object o, EventArgs e) {
            GL.LoadIdentity();
            GL.Clear (ClearBufferMask.ColorBufferBit);
            
            window.SwapBuffers();
        }

        void Loaded (object o, EventArgs e) {
            GL.ClearColor (0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}