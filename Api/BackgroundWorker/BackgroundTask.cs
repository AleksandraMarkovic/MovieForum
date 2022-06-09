using DataAccess;
using Email.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.BackgroundWorker
{
    public class BackgroundTask 
        //: IHostedService
    {
        //private readonly IWorker _worker;

        //public BackgroundTask(IWorker worker)
        //{
        //    _worker = worker;
        //}

        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    _worker.RunMailingListWorker();
        //    return Task.CompletedTask;
        //}

        //public Task StopAsync(CancellationToken cancellationToken)
        //{
        //    return Task.CompletedTask;
        //}
    }
}
