using ClockMqtt.Clocks;

namespace ClockMqtt.BinaryClock;

public interface IBinaryClockBuilder
{
    IClock CreateBinaryClock();
}