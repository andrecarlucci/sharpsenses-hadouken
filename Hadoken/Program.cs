using System;
using System.Security.Cryptography.X509Certificates;
using Dear;
using Dear.KeyboardControl;
using SharpSenses;
using SharpSenses.Gestures;

namespace Hadoken {
    class Program {
        static void Main(string[] args) {
            var win = new MrWindows();
            var k = win.Keyboard;

            Action hadouken = () => {
                k.Press(VirtualKey.Down).Wait(20);
                k.Press(VirtualKey.Right).Wait(20);
                k.Release(VirtualKey.Down);
                k.Press(VirtualKey.X).Wait(20);
                k.Release(VirtualKey.Right);
                k.Release(VirtualKey.X);
                Console.WriteLine("HADOUKEN!!!!!!!!!!!!!");
                Light.Blink();
            };

            var cam = Camera.Create();
            cam.LeftHand.Visible += (sender, eventArgs) => {
                Console.WriteLine("Ready");
            };
            var movement = Movement.Forward(cam.LeftHand, 8);
            movement.Completed += () => {
                hadouken.Invoke();
            };
            movement.Activate();

            cam.Start();
            Console.ReadLine();
        }
    }
}
