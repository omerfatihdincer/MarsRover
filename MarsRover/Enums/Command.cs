using System.ComponentModel;

namespace MarsRover.Enums
{
    public enum Command
    {
        [Description("Right")]
        R = 'R',

        [Description("Left")]
        L = 'L',

        [Description("Move")]
        M = 'M',
    }
}
