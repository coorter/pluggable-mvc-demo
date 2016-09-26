using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Szczepanik.Lukasz.PluggableMvcDemo.Common;

namespace Szczepanik.Lukasz.PluggableMvcDemo.Server
{
    #region MefConfig

    internal class MefConfig
    {
        internal static void RegisterMef()
        {
            var path = HttpContext.Current.Server.MapPath("");
            var aggregateCatalog = new AggregateCatalog();
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var pluginCatalog = new DirectoryCatalog(PluginAssembliesCache.PluginsPath);

            aggregateCatalog.Catalogs.Add(assemblyCatalog);
            aggregateCatalog.Catalogs.Add(pluginCatalog);

            var compositionContainer = new CompositionContainer(aggregateCatalog);
            var mefDependecyResolver = new MefDependecyResolver(compositionContainer);

            ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(compositionContainer, mefDependecyResolver));
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
        private readonly CompositionContainer _compositionContainer;
        private readonly IDependencyResolver _dependencyResolver;

        public MefControllerFactory(CompositionContainer compositionContainer, IDependencyResolver dependencyResolver)
        {
            _compositionContainer = compositionContainer;
            _dependencyResolver = dependencyResolver;
        }

        #region Overrides of DefaultControllerFactory        

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            var export = _compositionContainer
                .GetExports<IController, IControllerMetadata>()
                .Single(w => w.Metadata.ControllerType == controllerType);
            return export.Value;
        }

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            var controllerType = base.GetControllerType(requestContext, controllerName);
            if (controllerType == null)
            {
                var mefControllerType = _compositionContainer.GetExports<IController, IControllerMetadata>()
                    .Where(w => w.Metadata.ControllerName == controllerName)
                    .Select(s => s.Metadata.ControllerType);
                return mefControllerType.SingleOrDefault();
            }
            return controllerType;
        }

        #endregion
    }

    #endregion
}