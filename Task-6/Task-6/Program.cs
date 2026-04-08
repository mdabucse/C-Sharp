using System;

class Counter
{
    public delegate void ThresholdReachedHandler(int value);
    public event ThresholdReachedHandler ThresholdReached;

    private int count = 0;
    private int threshold;

    public Counter(int threshold)
    {
        this.threshold = threshold;
    }

    public void Increment()
    {
        count++;
        Console.WriteLine($"Current Count: {count}");

        if (count == threshold)
        {
            ThresholdReached?.Invoke(count);
        }
    }
}

class Program
{
    static void ShowMessage(int value)
    {
        Console.WriteLine($"Threshold reached at {value}!");
    }

    static void ShowWarning(int value)
    {
        Console.WriteLine($"Warning! Limit hit: {value}");
    }

    static void LogEvent(int value)
    {
        Console.WriteLine($"Logging: Counter reached {value}");
    }

    static void Main(string[] args)
    {
        Counter counter = new Counter(5);

        counter.ThresholdReached += ShowMessage;
        counter.ThresholdReached += ShowWarning;
        counter.ThresholdReached += LogEvent;

        for (int i = 0; i < 10; i++)
        {
            counter.Increment();
            System.Threading.Thread.Sleep(500);
        }
    }
}