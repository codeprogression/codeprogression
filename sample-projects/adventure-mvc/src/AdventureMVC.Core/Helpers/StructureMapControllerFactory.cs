using System.Web.Mvc;
using StructureMap;

namespace AdventureMVC.Core.Helpers
{
    public class StructureMapControllerFactory:DefaultControllerFactory
    {
        protected override IController GetControllerInstance(System.Type controllerType)
        {
            try
            {
                return ObjectFactory.GetInstance(controllerType) as Controller;
            }
            catch (StructureMapException)
            {
                System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
                throw;
            }
        }
    }
}