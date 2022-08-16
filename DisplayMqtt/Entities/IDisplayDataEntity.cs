﻿using DisplayMqtt.Leds;

namespace DisplayMqtt.Entities;

/// <summary>
/// Interface for <see cref="IDisplayDataEntity"/>.
/// </summary>
public interface IDisplayDataEntity
{
    /// <summary>
    /// Gets the display pin to use to display teh led values.
    /// </summary>
    int DisplayPin { get; init; }

    /// <summary>
    /// Gets the led values to display.
    /// </summary>
    IEnumerable<ILed> Leds { get; init; }
}