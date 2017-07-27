using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.DataGridView;

namespace PenawaranKurikulum.Lib
{
    class DragandDrop
    {
        private Rectangle dragBoxFromMouseDown;

        public void DragMove(MouseEventArgs e, DataGridView dgv, dynamic value)
        {
            if (value == null)
            {
                return;
            }
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dgv.DoDragDrop(value, DragDropEffects.Copy);
                }
            }
        }

        public HitTestInfo DragMouseDownFirst(MouseEventArgs e, DataGridView dgv)
        {
            // Get the index of the item the mouse is below.
            var hittestInfo = dgv.HitTest(e.X, e.Y);
            if (hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1)
            {
                return hittestInfo;
            }
            return null;
        }

        public void DragMouseDownSecond(MouseEventArgs e, DataGridView dgv, HitTestInfo hitTestInfo, dynamic value)
        {
            if (hitTestInfo.RowIndex != -1 && hitTestInfo.ColumnIndex != -1)
            {
                if (value != null)
                {
                    // Remember the point where the mouse down occurred. 
                    // The DragSize indicates the size that the mouse can move 
                    // before a drag event should be started.                
                    Size dragSize = SystemInformation.DragSize;

                    // Create a rectangle using the DragSize, with the mouse position being
                    // at the center of the rectangle.
                    dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                }
            }
            else
            {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }

        public HitTestInfo DragDrop(DragEventArgs e, DataGridView dgv)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = dgv.PointToClient(new Point(e.X, e.Y));

            // If the drag operation was a copy then add the row to the other control.
            if (e.Effect == DragDropEffects.Copy)
            {
                var hittest = dgv.HitTest(clientPoint.X, clientPoint.Y);
                if (hittest.ColumnIndex != -1 && hittest.RowIndex != -1)
                {
                    return hittest;
                }
            }
            return null;
        }
    }
}
