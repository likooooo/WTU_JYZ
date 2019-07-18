using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMC.Controller;
using SMC.Model.Controller;
using System.Windows.Forms;
namespace SMC.Wrapper
{
    public class SMC_Wrapper
    {

        ComboBox cmbPorts;
        SMC_Controller_Model model;


        /**构造函数
         * **/
        public SMC_Wrapper(ComboBox cmbPorts)
        {
            string[] ports = SMCController.ScanSeraPort();
            foreach (string s in ports)
            {
                cmbPorts.Items.Add(s);
            }
            this.cmbPorts = cmbPorts;
            this.cmbPorts.TextChanged += new System.EventHandler(this.cmbPorts_TextChanged);
        }


        /**cmbBox的事件，一旦选择了之后，就初始化串口
         * **/
        private void cmbPorts_TextChanged(object sender, EventArgs e)
        {
            string port = cmbPorts.Text;
            if (!cmbPorts.Items.Contains(port)) return;
            byte comport = Convert.ToByte(port.Replace("COM", ""));
            model = new SMC_Controller_Model(comport);
            SMCController.Connect_Controller(model);
        }


        public void MoveLeftX()
        {
            model.AXIS_X.MoveLeft();
        }

        private void MoveRightX()
        {
            model.AXIS_X.MoveRight();
        }

        private void MoveLeftY()
        {
            model.AXIS_Y.MoveLeft();
        }

        private void MoveRightY()
        {
            model.AXIS_Y.MoveRight();
        }

        private void MoveLeftZ()
        {
            model.AXIS_Z.MoveLeft();
        }

        private void MoveRightZ()
        {
            model.AXIS_Z.MoveRight();
        }

        private void MoveLeftU()
        {
            model.AXIS_U.MoveLeft();
        }

        private void MoveRightU()
        {
            model.AXIS_U.MoveRight();
        }

        private void StopX()
        {
            model.AXIS_X.StopMove();
        }


        private void StopY()
        {
            model.AXIS_Y.StopMove();
        }

        private void StopZ()
        {
            model.AXIS_Z.StopMove();
        }

        private void StopU()
        {
            model.AXIS_U.StopMove();
        }

        public void Close()
        {
            SMCController.Close_Controller();
        }

        public void Reset()
        {
            SMCController.Reset();
        }

        public void Reset_X()
        {
            model.AXIS_X.Reset();
        }

        private void Reset_Y()
        {
            model.AXIS_Y.Reset();
        }

        private void Reset_Z()
        {
            model.AXIS_Z.Reset();
        }

        private void MoveToX()
        {
            model.AXIS_X.MoveTo(100);
        }
    }
}
