using OpenHardwareMonitor.Hardware;

namespace ohm_arduino_gui
{
    public class UpdaterVisitor : IVisitor
    {
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }

        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (var subHw in hardware.SubHardware)
            {
                subHw.Accept(this);
            }
        }

        public void VisitParameter(IParameter parameter)
        {

        }

        public void VisitSensor(ISensor sensor)
        {

        }
    }
}
