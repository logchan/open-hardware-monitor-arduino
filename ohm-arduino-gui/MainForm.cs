using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using OpenHardwareMonitor.Hardware;

namespace ohm_arduino_gui
{
    public partial class MainForm : Form
    {
        private int _cpuCores = 0;
        private List<PortInfo> _ports = new List<PortInfo>();
        private readonly Computer _computer = new Computer();
        private readonly UpdaterVisitor _updater = new UpdaterVisitor();
        private readonly SensorVisitor _sensorVisitor;
        private readonly Dictionary<string, float> _sensorData = new Dictionary<string, float>();

        private class PortInfo
        {
            public string Name { get; set; }
            public string Caption { get; set; }
        }

        public MainForm()
        {
            _sensorVisitor = new SensorVisitor(ProcessSensor);

            InitializeComponent();
            if (Initialize())
            {
                mainTimer.Enabled = true;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void Log(string message)
        {
            message = $"[{DateTime.Now:HH:mm:ss.fff}] {message}";
            logBox.AppendText(message);
            logBox.AppendText(Environment.NewLine);
            logBox.Select(logBox.Text.Length, 0);
            logBox.ScrollToCaret();
        }

        private void Log(Exception ex, string title)
        {
            Log($"Exception {title} ({ex.GetType().FullName}): {ex.Message}");
        }

        private bool Initialize()
        {
            try
            {
                _computer.Open();
                _computer.CPUEnabled = true;
                _computer.GPUEnabled = true;
                _computer.RAMEnabled = true;

                var portNames = SerialPort.GetPortNames();
                using (var searcher = new ManagementObjectSearcher
                    ("SELECT * FROM WIN32_SerialPort"))
                {
                    var ports = searcher.Get().Cast<ManagementBaseObject>().ToList();
                    _ports = (from portName in portNames
                        join port in ports on portName equals port["DeviceID"].ToString()
                        select new PortInfo
                        {
                            Name = portName,
                            Caption = port["Caption"].ToString()
                        }).ToList();
                }

                foreach (var port in _ports)
                {
                    comPortCombo.Items.Add($"{port.Caption}");
                }

                if (comPortCombo.Items.Count > 0)
                {
                    var index = _ports.FindIndex(p => p.Caption.ToLower().Contains("arduino"));
                    if (index < 0)
                    {
                        throw new Exception("No Arduino port is found");
                    }

                    comPortCombo.SelectedIndex = index;
                }
                else
                {
                    throw new Exception("No COM port available");
                }

                return true;
            }
            catch (Exception ex)
            {
                Log(ex, "initializing");
                return false;
            }
        }

        private void SendData(string data)
        {
            if (_ports.Count < 1 || comPortCombo.SelectedItem == null)
                return;

            try
            {
                var info = _ports[comPortCombo.SelectedIndex];
                var port = new SerialPort(info.Name);
                port.Open();
                port.Write(data);
                port.Close();

                Log("Sent data of length " + data.Length);
            }
            catch (Exception ex)
            {
                Log(ex, "sending data");
            }
        }

        private string GetSensorData(string key)
        {
            return _sensorData.ContainsKey(key) ? _sensorData[key].ToString("###") : "NA";
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                _sensorData.Clear();
                _computer.Traverse(_updater);
                _computer.Traverse(_sensorVisitor);

                var str =
                    "CPU " + (_cpuCores > 0 ? String.Join(",", from cpuId in Enumerable.Range(1, _cpuCores) select GetSensorData("cpu" + cpuId)) : GetSensorData("cpu")) + "\n" +
                    "GPU " + GetSensorData("gpu");
                SendData(str);
            }
            catch (Exception ex)
            {
                Log(ex, "updating sensor data");
            }
        }

        private void sendTestDataBtn_Click(object sender, EventArgs e)
        {
            SendData(DateTime.Now.ToString("HH:mm:ss.fff"));
        }

        private void ProcessSensor(ISensor sensor)
        {
            if (sensor.SensorType != SensorType.Temperature || !sensor.Value.HasValue)
            {
                return;
            }

            var value = sensor.Value.Value;

            if (sensor.Name.StartsWith("CPU Core #"))
            {
                if (Int32.TryParse(sensor.Name.Substring(10), out var id))
                {
                    _sensorData["cpu" + sensor.Name.Substring(10)] = value;
                    if (id > _cpuCores)
                    {
                        _cpuCores = id;
                    }
                }
                
                return;
            }

            switch (sensor.Name)
            {
                case "CPU Package":
                    _sensorData["cpu"] = value;
                    break;
                case "GPU Core":
                    _sensorData["gpu"] = value;
                    break;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _computer.Close();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (!Visible)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/logchan/open-hardware-monitor-arduino");
        }

        private void showWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
