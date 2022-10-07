// <copyright file="CircleDataModel.cs" company="SeminarioIA">
// Copyright (c) SeminarioIA. All rights reserved.
// </copyright>

using SimpleAnnPlayground.Utils;

namespace SimpleAnnPlayground.Data.Models
{
    /// <summary>
    /// Represents a data model with two concentric groups of data.
    /// </summary>
    internal class CircleDataModel : DataModel
    {
        /// <inheritdoc/>
        public override DataTable GenerateData(int count, int noise)
        {
            var table = new DataTable();
            table.AddLabel("X1", DataType.Input);
            table.AddLabel("X2", DataType.Input);
            table.AddLabel("Y", DataType.Output);

            count -= noise;
            count /= 2;
            double radio, angle, x1, x2;
            int y;
            for (int index = 0; index < count; index++)
            {
                // Blue
                radio = Util.GetRandom(start: 0, end: 4, digits: 3);
                angle = Util.GetRandom(start: 0, end: 360, digits: 2);
                (x1, x2) = Util.ToRect(radio, angle);
                y = 0;
                table.AddRegister(index * 2, x1, x2, y);

                // Orange
                radio = Util.GetRandom(start: 6, end: 9, digits: 3);
                angle = Util.GetRandom(start: 0, end: 360, digits: 2);
                (x1, x2) = Util.ToRect(radio, angle);
                y = 1;
                table.AddRegister(index * 2 + 1, x1, x2, y);
            }

            count *= 2;
            for (int index = 0; index < noise; index++)
            {
                // Noise
                radio = Util.GetRandom(start: 3, end: 6, digits: 3);
                angle = Util.GetRandom(start: 0, end: 360, digits: 2);
                (x1, x2) = Util.ToRect(radio, angle);

                // Orange / Blue
                y = radio < 4.5 ? 1 : 0;
                table.AddRegister(count + index, x1, x2, y);
            }

            return table;
        }
    }
}
