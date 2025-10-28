using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples;

/**
 * In general, the .NET garbage collector automatically manages the allocation and release of memory for objects. However, 
 * when a class uses unmanaged resources – such as files, network connections, and user interface components – a finalizer 
 * should be used to free up those resources when they are no longer needed.
 * 
 */

public class MyFinalizers
{
    public static void Run()
    {
        Console.WriteLine("[main] Constructing");

        MyDisposable m = new MyDisposable(0);
        MyMethod(1);

        Console.WriteLine("[main] Disposing [object 0]");
        m.Dispose();

        Console.WriteLine("[main] GC Collecting");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("[main] Done");
    }

    private static void MyMethod(int i)
    {
        new MyDisposable(i);
    }
}

public class MyDisposable : IDisposable
{
    private int _id;

    public MyDisposable(int id)
    {
        _id = id;
        Console.WriteLine($"[object {_id}] Constructed");
    }

    private bool disposed = false;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Console.WriteLine($"[object {_id}] Disposing by Dispose()");
            }
            else
            {
                Console.WriteLine($"[object {_id}] Disposing by ~Finalizer");
            }
            Console.WriteLine($"[object {_id}] Disposed");
            disposed = true;
        }
        else
            Console.WriteLine($"[object {_id}] Already disposed!");
    }

    ~MyDisposable()
    {
        Dispose(false);
    }
}