using Ninject.Modules;
using VedaYOU.Core.Interfaces;
using VedaYOU.Core.Services;

namespace VedaYOU.Infrastructure
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IPageService>().To<PageService>();
        }
    }
}