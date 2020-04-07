using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AutomationSimulator
{
    public class Controller
    {
        static int flag = 0;
        static double t = 0;
        static double d = 0;
        public static Outputs Update(Inputs inputs)
        {
            Outputs r = new Outputs();

            if (inputs.PositioningEnabled && flag == 1 && Convert.ToInt32(t) != 0)
            {
                //distance = speed x time
                //t = inputs.CurrentTimeInMilliseconds;

                r.MoveLeft = true;
                r.MoveRight = false;
                r.MoveSpeed = Configuration.MotorSpeedFast;
                t--;
                if ((Configuration.MotorSpeedSlow * (inputs.CurrentTimeInMilliseconds - t)) == d)
                {
                }
            }
            else if (inputs.PositioningEnabled && inputs.ProximitySensorMiddle && flag == 0)
            {
                t = t + 0.5;
                //t = inputs.CurrentTimeInMilliseconds;
                r.MoveRight = true;
                r.MoveSpeed = Configuration.MotorSpeedSlow;
                d += Configuration.MotorSpeedSlow * (inputs.CurrentTimeInMilliseconds - t);
            }
            else if (inputs.PositioningEnabled && inputs.ProximitySensorRight)
            {
                t++;
                //t = inputs.CurrentTimeInMilliseconds;
                r.MoveLeft = true;
                r.MoveRight = false;
                //r.MoveSpeed = Configuration.MotorSpeedSlow;
                flag = 1;

            }
            else if (inputs.PositioningEnabled && flag == 0)
            {
                t++;
                //t = inputs.CurrentTimeInMilliseconds;
                r.MoveRight = true;
                r.MoveSpeed = Configuration.MotorSpeedFast;
                d += Configuration.MotorSpeedFast * (inputs.CurrentTimeInMilliseconds - t);
            }
            else
            {
                r.MoveLeft = false;
                r.MoveRight = false;
            }
            // TODO!
            //return default(Outputs);
            return r;
        }
    }

}
