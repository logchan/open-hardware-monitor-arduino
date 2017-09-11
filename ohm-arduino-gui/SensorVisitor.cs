using OpenHardwareMonitor.Hardware;

namespace ohm_arduino_gui
{
    public class SensorVisitor : IVisitor
    {
        private readonly SensorEventHandler _handler;

        public SensorVisitor(SensorEventHandler handler)
        {
            _handler = handler;
        }

        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }

        public void VisitHardware(IHardware hardware)
        {
            hardware.Traverse(this);
        }

        public void VisitParameter(IParameter parameter)
        {
        }

        public void VisitSensor(ISensor sensor)
        {
            _handler(sensor);
        }
    }
}
