// <copyright file="TwoGroupsDataModel.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Utils;

namespace SimpleAnnPlayground.Data.Models
{
    /// <summary>
    /// Represents two groups of data in a plane.
    /// </summary>
    internal class TwoGroupsDataModel : DataModel
    {
        /// <inheritdoc/>
        public override DataTable GenerateData(int count, int noise)
        {
            var table = new DataTable();
            table.AddLabel("X1", DataType.Input);
            table.AddLabel("X2", DataType.Input);
            table.AddLabel("Y", DataType.Output);

            count /= 2;
            double radio, angle, x1, x2;
            int y;
            for (int index = 0; index < count; index++)
            {
                // Blue
                radio = Util.GetRandom(start: 0.0, end: 3.0 + noise / 20.0, digits: 3);
                angle = Util.GetRandom(start: 0, end: 360, digits: 2);
                (x1, x2) = Util.ToRect(radio, angle);
                y = 0;
                table.AddRegister(index * 2, x1 + 3, x2 + 3, y);

                // Orange
                radio = Util.GetRandom(start: 0.0, end: 3.0 + noise / 20.0, digits: 3);
                angle = Util.GetRandom(start: 0, end: 360, digits: 2);
                (x1, x2) = Util.ToRect(radio, angle);
                y = 1;
                table.AddRegister(index * 2 + 1, x1 - 3, x2 - 3, y);
            }

            return table;
        }
    }
}
