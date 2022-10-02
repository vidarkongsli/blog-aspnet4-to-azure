using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace Kongsli.LegacyNetFramework.Web.DependencyInjection
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        private readonly Container _container;

        public StructureMapControllerFactory(Container container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return null;
            }

            return _container.GetInstance(controllerType) as Controller;
        }
    }
}