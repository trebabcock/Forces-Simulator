using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Gravity {
    class Program {
        static void Main(string[] args) {
            GameWindow window = new GameWindow (1280, 720, OpenTK.Graphics.GraphicsMode.Default, "N-body Simulator v0.0.1", GameWindowFlags.Default, DisplayDevice.Default);
            Simulation sim = new Simulation (window);
        }
    }
}
