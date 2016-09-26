/**
 * @license
 * Copyright Łukasz Szczepanik. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://github.com/coorter/pluggable-mvc-demo/blob/master/LICENSE
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
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
            string path = HttpContext.Current.Server.MapPath("");
            AggregateCatalog aggregateCatalog = new AggregateCatalog();
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            DirectoryCatalog pluginCatalog = new DirectoryCatalog(PluginAssembliesCache.PluginsPath);

            aggregateCatalog.Catalogs.Add(assemblyCatalog);
            aggregateCatalog.Catalogs.Add(pluginCatalog);

            CompositionContainer compositionContainer = new CompositionContainer(aggregateCatalog);
            MefDependecyResolver mefDependecyResolver = new MefDependecyResolver(compositionContainer);

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
            Type controllerType = base.GetControllerType(requestContext, controllerName);
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