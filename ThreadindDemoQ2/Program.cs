using System;
using System.Threading;
public class EntryPoint
{
    static private int count = 0;
    static private object theLock = new Object();
    private static void threadFunc()
    {
        for (int i = 0; i < 10; i++)
        {
            try
            {
                //int val = Interlocked.Increment(ref count);
                Monitor.Enter(theLock);
                count++;
                Console.WriteLine(count + " printed by thread: " + Thread.CurrentThread.ManagedThreadId);
            }
            finally
            {
                Monitor.Exit(theLock);
            }
        }
    }
    public static void Main(string[] args)
    {
        Thread[] threads = new Thread[10];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(new ThreadStart(threadFunc));
            threads[i].Start();
        }
        
    }

}