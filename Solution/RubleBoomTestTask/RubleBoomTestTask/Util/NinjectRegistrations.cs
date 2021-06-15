using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using BLL.Interfaces;
using BLL.Services;

namespace RubleBoomTestTask.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ITicketLogic>().To<TicketLogic>();
            //Bind<IPositionLogic>().To<PositionLogic>();
        }
    }
}