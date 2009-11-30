using CodeProgression.Framework.Testing.Examples.Abstractions;
using CodeProgression.Framework.Testing.Examples.Domain;
using Machine.Specifications;
using Rhino.Mocks;

namespace CodeProgression.Framework.Testing.Examples.Specifications
{
    [Subject(typeof(CoffeeMachine), "using SpecificationFor<CoffeeMachine>")]
    public class Example04_when_preparing_coffee_grounds : SpecificationFor<CoffeeMachine>
    {
        Establish context = () =>
            {
                Grinder = AutoMocker.Get<IGrinder>();
                Hopper = AutoMocker.Get<IHopper>();
                Hopper.Expect(x => x.HasBeans()).Return(true);
            };

        Because of = () => ClassUnderTest.PrepareCoffeeGrounds(12);

        It should_check_if_hopper_has_beans = () => Hopper.VerifyAllExpectations();
        It should_grind_coffee = () => Grinder.AssertWasCalled(x => x.Grind(12));

        protected static IGrinder Grinder;
        protected static IHopper Hopper;
    }
}