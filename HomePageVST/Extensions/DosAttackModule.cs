using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;

namespace HomePageVST.Extensions
{
    public class DosAttackModule : IHttpModule
    {
        private static Dictionary<string, short> _ipAdresses = new Dictionary<string, short>();
        private static Stack<string> _banned = new Stack<string>();
        private static Timer _timer = CreateTimer();
        private const int BANNED_REQUESTS = 10;
        private const int REDUCTION_INTERVAL = 1000;
        private const int RELEASE_INTERVAL = 60 * 1000;

        private void context_BeginRequest(object sender, EventArgs e)
        {
            string ip = HttpContext.Current.Request.UserHostAddress;
            if (_banned.Contains(ip))
            {
                HttpContext.Current.Response.StatusCode = 403;
                HttpContext.Current.Response.End();
            }
            var requestBase = new HttpRequestWrapper(HttpContext.Current.Request);
            var isAjaxRequest = requestBase.IsAjaxRequest();
            if (isAjaxRequest)
            {
                CheckIpAddress(ip);
            }
        }

        private static void CheckIpAddress(string ip)
        {
            if (!_ipAdresses.ContainsKey(ip))
            {
                _ipAdresses[ip] = 1;
            }
            else if (_ipAdresses[ip] == BANNED_REQUESTS)
            {
                _banned.Push(ip);
                _ipAdresses.Remove(ip);
            }
            else
            {
                _ipAdresses[ip]++;
            }
        }

        private static Timer CreateTimer()
        {
            Timer timer = GetTimer(REDUCTION_INTERVAL);
            timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
            return timer;
        }

        private static Timer GetTimer(int interval)
        {
            Timer timer = new Timer();
            timer.Interval = interval;
            timer.Start();
            return timer;
        }

        private static void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            foreach (string key in _ipAdresses.Keys.ToList())
            {
                _ipAdresses[key]--;
                if (_ipAdresses[key] == 0)
                {
                    _ipAdresses.Remove(key);
                }
            }
        }

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }
    }
}