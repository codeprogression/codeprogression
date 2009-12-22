using Machine.Specifications;

namespace CodeProgression.Framework.Testing.Examples.Regression
{

    public class when_injecting_a_stub_from_a_subclassed_specification : SpecificationFor<ClassWithDependency>
    {
        Establish context = () =>
            {
                _dependency = new Dependency();
                AutoMocker.Inject(_dependency);
            };
        Because of = () => _result = ClassUnderTest.GetDependencyValue();
        It dependency_should_be_injected_dependency = () => ClassUnderTest.Dependency.ShouldBeOfType(typeof (Dependency));
        It result_should_be_from_injected_dependency = () => _result.ShouldBeTrue();
        static bool _result;
        static IDependency _dependency;
    }

    public class ClassWithDependency
    {
        public IDependency Dependency{ get; set;}
        
        public bool GetDependencyValue()
        {
            return Dependency.Value;
        }

        public ClassWithDependency(IDependency dependency)
        {
            Dependency = dependency;
        }
    }
    public class Dependency : IDependency
    {
        public bool Value
        {
            get { return true; }
        }
    }

    public interface IDependency
    {
        bool Value{ get; }
    }
}