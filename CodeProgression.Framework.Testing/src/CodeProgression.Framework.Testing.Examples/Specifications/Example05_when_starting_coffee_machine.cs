using CodeProgression.Framework.Testing.Examples.Abstractions;
using CodeProgression.Framework.Testing.Examples.Domain;
using Machine.Specifications;
using Rhino.Mocks;

namespace CodeProgression.Framework.Testing.Examples.Specifications
{
    [Subject(typeof(CoffeeMachine), "using coffee machine base")]
    public class Example05_when_preparing_coffee_grounds : with_coffee_machine
    {
        Establish context = () => Hopper.Expect(x => x.HasBeans()).Return(true);

        Because of = () => ClassUnderTest.PrepareCoffeeGrounds(12);

        It should_check_if_hopper_has_beans = () => Hopper.VerifyAllExpectations();
        It should_grind_coffee = () => Grinder.AssertWasCalled(x => x.Grind(12));
    }

    [Subject("with SpecificationFor<CoffeeMachine>")]
    public class with_coffee_machine : SpecificationFor<CoffeeMachine>
    {
        protected static IGrinder Grinder;
        protected static IHopper Hopper;

        public with_coffee_machine()
        {
            Grinder = AutoMocker.Get<IGrinder>();
            Hopper = AutoMocker.Get<IHopper>();
        }
    }
}