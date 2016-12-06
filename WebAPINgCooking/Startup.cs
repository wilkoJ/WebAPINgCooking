using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.IO;
using Newtonsoft.Json;
using WebAPINgCooking.Scripts;

[assembly: OwinStartup(typeof(WebAPINgCooking.Startup))]

namespace WebAPINgCooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
