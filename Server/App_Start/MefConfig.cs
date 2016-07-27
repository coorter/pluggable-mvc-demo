using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server
{
    #region MefConfig

    internal class MefConfig
    {
        internal static void RegisterMef()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var compositionContainer = new CompositionContainer(assemblyCatalog);
            var mefDependecyResolver = new MefDependecyResolver(compositionContainer);

            ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(mefDependecyResolver));
        }
    }

    #endregion
    #region MefDependecyResolver

    public class MefDependecyResolver : IDependencyResolver
    {
        private readonly CompositionContainer _compositionContainer;

        public MefDependecyResolver(CompositionContainer compositionContainer)
        {
            _compositionContainer = compositionContainer;
        }

        #region Implementation of IDependencyResolver

        public object GetService(Type serviceType)
        {
            var export = _compositionContainer.GetExports(serviceType, null, null).Single();
            return export.Value;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    #endregion
    #region MefControllerFactory

    public class MefControllerFactory : DefaultControllerFactory
    {
        private readonly IDependencyResolver _dependencyResolver;

        public MefControllerFactory(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        #region Overrides of DefaultControllerFactory

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (IController) _dependencyResolver.GetService(controllerType);
        }

        #endregion
    }

    #endregion
}