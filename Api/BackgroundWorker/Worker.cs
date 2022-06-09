using Application.DTOs;
using BusinessLogic.Interfaces;
using DataAccess;
using Email.DTOs;
using Email.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Api.BackgroundWorker
{
    public class Worker : IWorker
    {
        //private readonly IEmailSender _sender;
        //private readonly IServiceScopeFactory _serviceScopeFactory;

        //public Worker(IEmailSender sender, IServiceScopeFactory serviceScopeFactory)
        //{
        //    _sender = sender;
        //    _serviceScopeFactory = serviceScopeFactory;
        //}

        //public void DoWork(IUserLogic userLogic, IMovieLogic movieLogic)
        //{
        //    var users = userLogic.GetUsersBackground();
        //    // Earliest date
        //    DateTime? date = users.Min(x => x.LastLogin);
        //    // Movies added after the passed date
        //    var movies = movieLogic.GetMoviesBackground((DateTime)date).ToList();

        //    if(users != null)
        //    {
        //        foreach (User user in users)
        //        {
        //            EmailRegister email = new EmailRegister();
        //            email.SendTo = user.Email;
        //            email.Subject = "New movies";
        //            StringBuilder sb = new StringBuilder();
        //            sb.Append("<div style='background-color:#202124; padding:2%;'><h3 style='color:#ffffff;'>Movies added while you where away: </h3></div>");
        //            foreach (ShowMovie movie in movies)
        //            {
        //                sb.Append("<div style='display:flex; flex-direction:row; justify-content:space-around;'>");
        //                sb.AppendFormat(@"<div> <img src='C:\Users\amarkovic\source\repos\Movies\Api\wwwroot\Images\{0}' /> </div>", movie.Poster);
        //                sb.AppendFormat("<div><h4>{0} ({1})</h4><p>{2}</p></div>", movie.Title, movie.Year, movie.Description);
        //                sb.Append("</div>");
        //            }
        //            email.Content = sb.ToString();

        //            _sender.Send(email);
        //        }
        //    }
        //}

        //public void RunMailingListWorker()
        //{
        //    new Thread(() =>
        //    {
        //        Thread.CurrentThread.IsBackground = true;
        //        int errorCount = 0;

        //        while (true)
        //        {
        //            //Logger.Log.InfoFormat("Close visits that passed with no show / finished status");

        //            // next run at 03:00:00 next day
        //            TimeSpan sleepTillNextRun = DateTime.Now.Date.AddDays(1).AddHours(3) - DateTime.Now;

        //            try
        //            {
        //                using (var scope = this._serviceScopeFactory.CreateScope())
        //                {
        //                    var userLogic = scope.ServiceProvider.GetService<IUserLogic>();
        //                    var movieLogic = scope.ServiceProvider.GetService<IMovieLogic>();
        //                    DoWork(userLogic, movieLogic);
        //                }

        //            }
        //            catch (Exception ex)
        //            {
        //                //Logger.Log.Error(ex);

        //                if (++errorCount == 5)
        //                    throw;
        //                else
        //                    // retry in next hour
        //                    sleepTillNextRun = TimeSpan.FromHours(0.5);
        //            }

        //            Thread.Sleep(sleepTillNextRun);
        //        }
        //    }).Start();
        //}
    }
}
