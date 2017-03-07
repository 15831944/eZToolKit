using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eZstd;

namespace SplineInterp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //

            eZDataGridViewXY.KeyDelete = true;
            eZDataGridViewXY.SupportPaste = true;
            eZDataGridViewXY.ManipulateRows = true;
            eZDataGridViewXY.ShowRowNumber = true;

            eZDataGridViewID.KeyDelete = true;
            eZDataGridViewID.SupportPaste = true;
            eZDataGridViewID.ManipulateRows = true;
            eZDataGridViewID.ShowRowNumber = true;


            ColumnX.ValueType = typeof(double);
            ColumnY.ValueType = typeof(double);
            ColumnI.ValueType = typeof(double);
            ColumnD.ValueType = typeof(double);
        }

        private void eZDataGridViewXY_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(@"Enter numbers", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void eZDataGridViewID_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(@"Enter numbers", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        double[] _interpY;
        private void button1_Click(object sender, EventArgs e)
        {
            var srcXY = new SortedDictionary<double, double>();
            List<double> refinedX = new List<double>();

            DataGridViewCell cell;
            double value, valueX, valueY;
            object cellValue, cellValueX, cellValueY;
            foreach (DataGridViewRow r in eZDataGridViewXY.Rows)
            {
                cellValueX = r.Cells[0].Value;
                cellValueY = r.Cells[1].Value;
                if ((cellValueX != null && double.TryParse(cellValueX.ToString(), out valueX)) &&
                    (cellValueY != null && double.TryParse(cellValueY.ToString(), out valueY)))
                {
                    if (!srcXY.ContainsKey(valueX))
                    {

                        srcXY.Add(valueX, valueY);
                    }
                }
            }

            foreach (DataGridViewRow r in eZDataGridViewID.Rows)
            {
                cellValue = r.Cells[0].Value;
                if (cellValue != null && double.TryParse(cellValue.ToString(), out value))
                {
                    refinedX.Add(value);
                }
            }

            //
            var srcX = srcXY.Keys;
            var srcY = srcXY.Values;
            if ((srcX.Max() < refinedX.Max()) && (srcX.Min() > refinedX.Min()))
            {
                MessageBox.Show(@"the range of the refined X must be within the range of the source X", @"Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _interpY = SplineInterpolation.Execute(srcX.ToArray(), srcY.ToArray(), refinedX.ToArray());
                if (_interpY != null && _interpY.Length <= eZDataGridViewID.RowCount)
                {
                    for (int i = 0; i < _interpY.Length; i++)
                    {
                        cell = eZDataGridViewID.Rows[i].Cells[1];
                        cell.Value = _interpY[i];
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Something went wrong while calculating the interpolated Y", @"Warning",
               MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}

