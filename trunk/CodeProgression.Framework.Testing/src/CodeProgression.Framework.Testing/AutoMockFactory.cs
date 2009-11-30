using System;
using StructureMap.AutoMocking;

namespace CodeProgression.Framework.Testing
{
    public static class AutoMockFactory
    {
        /// <summary>
        /// Default mock type is RhinoMocksAAA
        /// </summary>
        public static ClassUnderTest<TARGETCLASS> CreateTarget<TARGETCLASS>() where TARGETCLASS : class
        {
            return CreateTarget<TARGETCLASS>(AutoMockType.RhinoMocksAAA);
        }

        public static ClassUnderTest<TARGETCLASS> CreateTarget<TARGETCLASS>(AutoMockType framework) where TARGETCLASS : class
        {
            AutoMocker<TARGETCLASS> mocker;
            ServiceLocator serviceLocator;
            switch (framework)
            {
                case AutoMockType.RhinoMocksAAA:
                    mocker = new RhinoAutoMocker<TARGETCLASS>(MockMode.AAA);
                    serviceLocator = new RhinoMocksAAAServiceLocator();
                    break;
                case AutoMockType.RhinoMocksClassic:
                    mocker = new RhinoAutoMocker<TARGETCLASS>(MockMode.RecordAndReplay);
                    serviceLocator = new RhinoMocksClassicServiceLocator();
                    break;
                case AutoMockType.Moq:
                    mocker = new MoqAutoMocker<TARGETCLASS>();
                    serviceLocator = new MoqServiceLocator();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("framework");
            }
            return new ClassUnderTest<TARGETCLASS>(mocker, serviceLocator);
        }
        
    }
}