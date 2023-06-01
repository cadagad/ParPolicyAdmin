using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParPolicyAdmin.UserControls
{
    public partial class ucLateReturns : UserControl
    {
        int _activeProjectId = 0;

        public ucLateReturns(int projectId)
        {
            InitializeComponent();

            _activeProjectId = projectId;
        }
    }
}
