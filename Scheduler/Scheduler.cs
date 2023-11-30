using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduler;

public class Scheduler
{
    private readonly SemaphoreSlim _semaphore = new(3);
    private readonly Queue<Process> _processQueue = new();

    public async Task Run(List<Process> processes)
    {
        foreach (var process in processes)
        {
            _processQueue.Enqueue(process);
        }

        while (_processQueue.Count > 0)
        {
            var batchTasks = new List<Task>();

            for (int i = 0; i < 3 && _processQueue.Count > 0; i++)
            {
                var process = _processQueue.Dequeue();
                batchTasks.Add(RunProcessAsync(process));
            }

            await Task.WhenAll(batchTasks);

            await Task.Delay(1000);
        }
    }

    private async Task RunProcessAsync(Process process)
    {
        await _semaphore.WaitAsync();

        try
        {
            process.Start();
            await process
                .WaitForExitAsync();
        }
        finally
        {
            _semaphore.Release();
        }
    }
}