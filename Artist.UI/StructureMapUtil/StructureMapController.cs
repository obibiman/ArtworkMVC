using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace Artist.UI.StructureMapUtil
{
    public class StructureMapController : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return base.GetControllerInstance(requestContext,
                controllerType);
            return ObjectFactory.GetInstance(controllerType) as Controller;
        }
    }
}