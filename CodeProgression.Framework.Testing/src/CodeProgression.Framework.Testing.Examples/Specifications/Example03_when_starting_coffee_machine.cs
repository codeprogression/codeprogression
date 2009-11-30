using CodeProgression.Framework.Testing.Examples.Abstractions;
using CodeProgression.Framework.Testing.Examples.Domain;
using Machine.Specifications;
using Rhino.Mocks;
using StructureMap.AutoMocking;

namespace CodeProgression.Framework.Testing.Examples.Specifications
{
    [Subject(typeof(CoffeeMachine), "using RhinoAutoMocker base")]
    public class Example03_when_preparing_coffee_grounds : with_rhinoautomocker
    {
        Establish context = () => Hopper.Expect(x => x.HasBeans()).Return(true);

        Because of = () => CoffeeMachine.ClassUnderTest.PrepareCoffeeGrounds(12);

        It should_check_if_hopper_has_beans = () => Hopper.VerifyAllExpectations();
        It should_grind_coffee = () => Grinder.AssertWasCalled(x => x.Grind(12));
    }

    [Subject("with RhinoAutoMocker<T>")]
    public class with_rhinoautomocker
    {
        protected static IGrinder Grinder;
        protected static IHopper Hopper;
        protected static RhinoAutoMocker<CoffeeMachine> CoffeeMachine;

        Establish context = () =>
        {
            CoffeeMachine = new RhinoAutoMocker<CoffeeMachine>();
            Grinder = CoffeeMachine.Get<IGrinder>();
            Hopper = CoffeeMachine.Get<IHopper>();
        };
    }
}