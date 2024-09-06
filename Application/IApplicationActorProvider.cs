using System;
using System.Collections.Generic;
using System.Text;

namespace ProjASP.Application
{
    public interface IApplicationActorProvider
    {
        IApplicationActor GetActor();
    }
}
