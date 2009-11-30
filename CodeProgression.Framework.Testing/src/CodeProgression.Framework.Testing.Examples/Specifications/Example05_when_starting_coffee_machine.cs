using CodeProgression.Framework.Testing.Examples.Abstractions;
using CodeProgression.Framework.Testing.Examples.Domain;
using Machine.Specifications;
using Rhino.Mocks;

namespace CodeProgression.Framework.Testing.Examples.Specifications
{
    [Subject("with coffee dispenser base (container)")]
    public class Example05_when_starting_coffee_machine : with_coffee_dispenser
    {
        Establish context = () => Hopper.Expect(x => x.IsEmpty()).Return(true);

        Because of = () => ClassUnderTest.Brew(12);

        It should_check_if_hopper_is_empty = () => Hopper.VerifyAllExpectations();

        It should_grind_coffee = () => Grinder.AssertWasCalled(x => x.Grind(12));

    }

    [Subject("with SpecificationFor<CoffeeMachine>")]
    public class with_coffee_dispenser : SpecificationFor<CoffeeMachine>
    {

        protected static IGrinder Grinder;
        protected static IHopper Hopper;

        Establish context = () =>
        {
            Grinder = Factory.Get<IGrinder>();
            Hopper = Factory.Get<IHopper>();
        };
    }
}