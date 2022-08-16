using System.Text;

namespace ClockMqtt.Leds
{
    /// <summary>
    /// A record to store color values for a single led.
    /// </summary>
    public record Led : ILed
    {
        /// <summary>
        /// Instantiates a <see cref="Led"/>.
        /// </summary>
        /// <param name="red">A <see cref="byte"/> that represents the red value of the RGB led.</param>
        /// <param name="green">A <see cref="byte"/> that represents the green value of the RGB led.</param>
        /// <param name="blue">A <see cref="byte"/> that represents the blue value of the RGB led.</param>
        public Led(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        /// <inheritdoc/>
        public byte Red { get; }

        /// <inheritdoc/>
        public byte Green { get; }

        /// <inheritdoc/>
        public byte Blue { get; }

        /// <inheritdoc/>
        public string ColorString =>
            new StringBuilder("#")
                .Append(Red.ToString("X2"))
                .Append(Green.ToString("X2"))
                .Append(Blue.ToString("X2"))
                .ToString();
    }
}
