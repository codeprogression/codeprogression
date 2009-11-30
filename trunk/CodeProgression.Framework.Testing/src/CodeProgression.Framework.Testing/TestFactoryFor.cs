using System;
using StructureMap.AutoMocking;

namespace CodeProgression.Framework.Testing
{
    public class TestFactoryFor<CLASSUNDERTEST> where CLASSUNDERTEST : class
    {
        readonly IAutoMocker<CLASSUNDERTEST> _mocker;
        readonly ServiceLocator _serviceLocator;

        public TestFactoryFor(IAutoMocker<CLASSUNDERTEST> mocker, ServiceLocator serviceLocator)
        {
            _mocker = mocker;
            _serviceLocator = serviceLocator;
        }

        public AutoMockedContainer Container
        {
            get { return _mocker.Container; }
        }

        /// <summary>
        ///Gets an instance of the ClassUnderTest with mock objects (or stubs) pushed in for all of its dependencies
        /// </summary>
        public CLASSUNDERTEST Instance
        {
            get { return _mocker.ClassUnderTest; }
        }
        /// <summary>
        ///Gets an instance of the ClassUnderTest with mock objects (or stubs) pushed in for all of its dependencies
        /// </summary>
        public CLASSUNDERTEST ClassUnderTest
        {
            get { return _mocker.ClassUnderTest; }
        }

        /// <summary>
        /// Use this with EXTREME caution.  This will replace the active "Container" in accessed
        /// by ObjectFactory with the AutoMockedContainer from this instance
        /// </summary>
        public void MockObjectFactory()
        {
            _mocker.MockObjectFactory();
        }

        /// <summary>
        /// Calling this method will immediately create a "Partial" mock
        /// for the ClassUnderTest using the "Greediest" constructor.
        /// </summary>
        public void PartialMockTheClassUnderTest()
        {
            _mocker.PartialMockTheClassUnderTest();
        }

        /// <summary>
        /// Gets the mock object for type T that would be injected into the constructor function
        /// of the ClassUnderTest
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() where T : class
        {
            return _mocker.Get<T>();
        }

        /// <summary>
        /// Method to specify the exact object that will be used for 
        /// "pluginType."  Useful for stub objects and/or static mocks
        /// </summary>
        /// <param name="pluginType"></param>
        /// <param name="stub"></param>
        public void Inject(Type pluginType, object stub)
        {
            _mocker.Inject(pluginType, stub);
        }

        /// <summary>
        /// Method to specify the exact object that will be used for 
        /// "pluginType."  Useful for stub objects and/or static mocks
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        public void Inject<T>(T target)
        {
            _mocker.Inject(target);
        }

        /// <summary>
        /// Adds an additional mock object for a given T
        /// Useful for array arguments to the ClassUnderTest
        /// object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T AddAdditionalMockFor<T>() where T : class
        {
            return _mocker.AddAdditionalMockFor<T>();
        }

        /// <summary>
        /// So that Aaron Jensen can use his concrete HubService object
        /// Construct whatever T is with all mocks, and make sure that the
        /// ClassUnderTest gets built with a concrete T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void UseConcreteClassFor<T>()
        {
            _mocker.UseConcreteClassFor<T>();
        }

        /// <summary>
        /// Creates, returns, and registers an array of mock objects for type T.  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        /// <returns></returns>
        public T[] CreateMockArrayFor<T>(int count) where T : class
        {
            return _mocker.CreateMockArrayFor<T>(count);
        }

        /// <summary>
        /// Allows you to "inject" an array of known objects for an 
        /// argument of type T[] in the ClassUnderTest
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stubs"></param>
        public void InjectArray<T>(T[] stubs)
        {
            _mocker.InjectArray(stubs);
        }

        public T Mock<T>() where T : class
        {
            return _serviceLocator.Service<T>();
        }
        public object Mock(Type serviceType)
        {
            return _serviceLocator.Service(serviceType);
        }
        public T PartialMock<T>() where T : class
        {
            return _serviceLocator.PartialMock<T>();
        }


    }
}