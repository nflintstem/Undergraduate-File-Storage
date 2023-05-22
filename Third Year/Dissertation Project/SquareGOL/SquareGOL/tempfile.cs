using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SquareGOL
{
    class tempfile
    {
        #region triangle
        //private const float TriangleHeight = 10;

        //// Selected triangles.
        //private List<PointF> Triangles = new List<PointF>();

        //// Redraw the grid.
        //private void picGrid_Paint(object sender, PaintEventArgs e)
        //{
        //    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        //    // Draw the selected triangles.
        //    foreach (PointF point in Triangles)
        //    {
        //        e.Graphics.FillPolygon(Brushes.Gold,
        //            TriangleToPoints(TriangleHeight, point.X, point.Y));
        //    }

        //    // Draw the grid.
        //    DrawTriangularGrid(e.Graphics, Pens.Black,
        //        0, GOLbox.ClientSize.Width,
        //        0, GOLbox.ClientSize.Height,
        //        TriangleHeight);

        //    //// Used to draw Figure 1.
        //    //PointF[] tri_points = TriangleToPoints(TriangleHeight, 2, 1.5f);
        //}

        //// Draw a triangular grid for the indicated area.
        //private void DrawTriangularGrid(Graphics gr, Pen pen,
        //    float xmin, float xmax, float ymin, float ymax,
        //    float height)
        //{
        //    float width = TriangleWidth(height);
        //    int row = 0;
        //    for (float y = 0; y <= ymax + width / 2; y += height)
        //    {
        //        float x = 0;
        //        if (row % 2 == 0) x = width / 2;

        //        PointF[] points =
        //        {
        //            new PointF(x, y),
        //            new PointF(x + width / 2, y + height),
        //            new PointF(x - width / 2, y + height),
        //        };
        //        for (; x <= xmax; x += width)
        //        {
        //            gr.DrawPolygon(pen, points);
        //            gr.FillPolygon(Brushes.Black, points);
        //            points[0].X += width;
        //            points[1].X += width;
        //            points[2].X += width;
        //        }
        //        row++;
        //    }
        //}

        //// Display the row and column under the mouse.
        //private void picGrid_MouseMove(object sender, MouseEventArgs e)
        //{
        //    float row, col;
        //    PointToTriangle(e.X, e.Y, TriangleHeight, out row, out col);
        //    this.Text = "(" + row + ", " + col + ")";
        //}

        //// Add the clicked triangle to the Triangles list.
        //private void picGrid_MouseClick(object sender, MouseEventArgs e)
        //{
        //    float row, col;
        //    PointToTriangle(e.X, e.Y, TriangleHeight, out row, out col);
        //    Triangles.Add(new PointF(row, col));
        //    GOLbox.Refresh();
        //}

        //// Return the width of a triangle.
        //private float TriangleWidth(float height)
        //{
        //    return (float)(2 * height / Math.Sqrt(3));
        //}

        //// Return the row and column of the triangle at this point.
        //private void PointToTriangle(float x, float y, float height, out float row, out float col)
        //{
        //    float width = TriangleWidth(height);
        //    row = (int)(y / height);
        //    col = (int)(x / width);

        //    float dy = (row + 1) * height - y;
        //    float dx = x - col * width;
        //    if (row % 2 == 1) dy = height - dy;
        //    if (dy > 1)
        //    {
        //        if (dx < width / 2)
        //        {
        //            // Left half of triangle.
        //            float ratio = dx / dy;
        //            if (ratio < 1f / Math.Sqrt(3)) col -= 0.5f;
        //        }
        //        else
        //        {
        //            // Right half of triangle.
        //            float ratio = (width - dx) / dy;
        //            if (ratio < 1f / Math.Sqrt(3)) col += 0.5f;
        //        }
        //    }
        //}

        //// Return the points that define the indicated triangle.
        //private PointF[] TriangleToPoints(float height, float row, float col)
        //{
        //    float width = TriangleWidth(height);
        //    float y = row * height;
        //    float x = (col + 0.5f) * width;

        //    // See if this triangle should be drawn
        //    // right-side up or upside down.
        //    bool whole_col = (Math.Abs(col - (int)col) < 0.1);
        //    bool rightside_up;
        //    if ((int)row % 2 == 0)
        //    {
        //        // Even row.
        //        rightside_up = whole_col;
        //    }
        //    else
        //    {
        //        // Odd row.
        //        rightside_up = !whole_col;
        //    }

        //    // Draw the triangle.
        //    if (rightside_up)
        //        return new PointF[]
        //            {
        //                new PointF(x, y),
        //                new PointF(x + width / 2, y + height),
        //                new PointF(x - width / 2, y + height),
        //            };
        //    else
        //        return new PointF[]
        //            {
        //                new PointF(x, y + height),
        //                new PointF(x + width / 2, y),
        //                new PointF(x - width / 2, y),
        //            };
        //}
        #endregion

        #region hexagon
        //        // The height of a hexagon.
        //        private const float HexHeight = 50;

        //        // Selected hexagons.
        //        private List<PointF> Hexagons = new List<PointF>();

        //        // Redraw the grid.
        //        private void picGrid_Paint(object sender, PaintEventArgs e)
        //        {#
        //
        //        float x = (points[0].X + points[3].X) / 2;
        //        float y = (points[1].Y + points[4].Y) / 2;
        //            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        //            // Draw the selected hexagons.
        //            foreach (PointF point in Hexagons)
        //            {
        //                e.Graphics.FillPolygon(Brushes.LightBlue,
        //                    HexToPoints(HexHeight, point.X, point.Y));
        //            }

        //            // Draw the grid.
        //            DrawHexGrid(e.Graphics, Pens.Black,
        //                0, picGrid.ClientSize.Width,
        //                0, picGrid.ClientSize.Height,
        //                HexHeight);
        //        }

        //        // Draw a hexagonal grid for the indicated area.
        //        // (You might be able to draw the hexagons without
        //        // drawing any duplicate edges, but this is a lot easier.)
        //        private void DrawHexGrid(Graphics gr, Pen pen,
        //            float xmin, float xmax, float ymin, float ymax,
        //            float height)
        //        {
        //            // Loop until a hexagon won't fit.
        //            for (int row = 0; ; row++)
        //            {
        //                // Get the points for the row's first hexagon.
        //                PointF[] points = HexToPoints(height, row, 0);

        //                // If it doesn't fit, we're done.
        //                if (points[4].Y > ymax) break;

        //                // Draw the row.
        //                for (int col = 0; ; col++)
        //                {
        //                    // Get the points for the row's next hexagon.
        //                    points = HexToPoints(height, row, col);

        //                    // If it doesn't fit horizontally,
        //                    // we're done with this row.
        //                    if (points[3].X > xmax) break;

        //                    // If it fits vertically, draw it.
        //                    if (points[4].Y <= ymax)
        //                    {
        //                        gr.DrawPolygon(pen, points);
        //                    }
        //                }
        //            }
        //        }

        //        // Add the clicked hexagon to the Hexagons list.
        //        private void picGrid_MouseClick(object sender, MouseEventArgs e)
        //        {
        //            int row, col;
        //            PointToHex(e.X, e.Y, HexHeight, out row, out col);
        //            Hexagons.Add(new PointF(row, col));


        //            picGrid.Refresh();
        //        }

        //        // Return the width of a hexagon.
        //        private float HexWidth(float height)
        //        {
        //            return (float)(4 * (height / 2 / Math.Sqrt(3)));
        //        }

        //        // Return the row and column of the hexagon at this point.
        //        private void PointToHex(float x, float y, float height,
        //            out int row, out int col)
        //        {
        //            // Find the test rectangle containing the point.
        //            float width = HexWidth(height);
        //            col = (int)(x / (width * 0.75f));

        //            if (col % 2 == 0)
        //                row = (int)Math.Floor(y / height);
        //            else
        //                row = (int)Math.Floor((y - height / 2) / height);

        //            // Find the test area.
        //            float testx = col * width * 0.75f;
        //            float testy = row * height;
        //            if (col % 2 != 0) testy += height / 2;

        //            // See if the point is above or
        //            // below the test hexagon on the left.
        //            bool is_above = false, is_below = false;
        //            float dx = x - testx;
        //            if (dx < width / 4)
        //            {
        //                float dy = y - (testy + height / 2);
        //                if (dx < 0.001)
        //                {
        //                    // The point is on the left edge of the test rectangle.
        //                    if (dy < 0) is_above = true;
        //                    if (dy > 0) is_below = true;
        //                }
        //                else if (dy < 0)
        //                {
        //                    // See if the point is above the test hexagon.
        //                    if (-dy / dx > Math.Sqrt(3)) is_above = true;
        //                }
        //                else
        //                {
        //                    // See if the point is below the test hexagon.
        //                    if (dy / dx > Math.Sqrt(3)) is_below = true;
        //                }
        //            }

        //            // Adjust the row and column if necessary.
        //            if (is_above)
        //            {
        //                if (col % 2 == 0) row--;
        //                col--;
        //            }
        //            else if (is_below)
        //            {
        //                if (col % 2 != 0) row++;
        //                col--;
        //            }
        //        }

        //        // Return the points that define the indicated hexagon.
        //        private PointF[] HexToPoints(float height, float row, float col)
        //        {
        //            // Start with the leftmost corner of the upper left hexagon.
        //            float width = HexWidth(height);
        //            float y = height / 2;
        //            float x = 0;

        //            // Move down the required number of rows.
        //            y += row * height;

        //            // If the column is odd, move down half a hex more.
        //            if (col % 2 != 0) y += height / 2;

        //            // Move over for the column number.
        //            x += col * (width * 0.75f);

        //            // Generate the points.
        //            return new PointF[]
        //                {
        //                    new PointF(x, y),
        //                    new PointF(x + width * 0.25f, y - height / 2),
        //                    new PointF(x + width * 0.75f, y - height / 2),
        //                    new PointF(x + width, y),
        //                    new PointF(x + width * 0.75f, y + height / 2),
        //                    new PointF(x + width * 0.25f, y + height / 2),
        //                };
        //        }

        #endregion
    }
}
