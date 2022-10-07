// <copyright file="PlaneDataModel.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Utils;

namespace SimpleAnnPlayground.Data.Models
{
    /// <summary>
    /// Represents data separated by a plane.
    /// </summary>
    internal class PlaneDataModel : DataModel
    {
        /// <inheritdoc/>
        public override DataTable GenerateData(int count, int noise)
        {
            var table = new DataTable();
            table.AddLabel("X1", DataType.Input);
            table.AddLabel("X2", DataType.Input);
            table.AddLabel("Y", DataType.Output);

            count /= 2;
            double x1, x2;
            double y;
            for (int index = 0; index < count; index++)
            {
                // Blue
                x1 = Util.GetRandom(start: -9.9, end: 9.9, digits: 3);
                x2 = Util.GetRandom(start: -9.9, end: 9.9, digits: 3);
                if (x1 + x2 < (-noise / 10.0)) (x2, x1) = (-x1, -x2);
                y = (20.0 - (x1 + x2)) / 40.0;
                y = y / 1.5;
                if (y is < 0.0 or > 1.0) throw new OverflowException();
                table.AddRegister(index * 2, x1, x2, y);

                // Orange
                x1 = Util.GetRandom(start: -9.9, end: 9.9, digits: 3);
                x2 = Util.GetRandom(start: -9.9, end: 9.9, digits: 3);
                if (x1 + x2 > (noise / 10.0)) (x2, x1) = (-x1, -x2);
                y = (20.0 - (x1 + x2)) / 40.0;
                y = (y + 0.5) / 1.5;
                if (y is < 0.0 or > 1.0) throw new OverflowException();
                table.AddRegister(index * 2 + 1, x1, x2, y);
            }

            return table;
        }
    }
}
