using CodeProgression.Framework.Testing.Examples.Abstractions;
using CodeProgression.Framework.Testing.Examples.Domain;
using Machine.Specifications;
using Rhino.Mocks;

namespace CodeProgression.Framework.Testing.Examples.Specifications
{
    [Subject("with SpecificationFor<CoffeeMachine>")]
    public class Example04_when_starting_coffee_machine : SpecificationFor<CoffeeMachine>
    {
        Establish context = () =>
            {
                Grinder = Factory.Get<IGrinder>();
                Hopper = Factory.Get<IHopper>();
                Hopper.Expect(x => x.IsEmpty()).Return(true);
            };

        Because of = () => ClassUnderTest.Brew(12);

        It should_check_if_hopper_is_empty = () => Hopper.VerifyAllExpectations();
        It should_grind_coffee = () => Grinder.AssertWasCalled(x => x.Grind(12));

        protected static IGrinder Grinder;
        protected static IHopper Hopper;

    }
}