using CodeProgression.Framework.Testing.Examples.Abstractions;
using CodeProgression.Framework.Testing.Examples.Domain;
using Machine.Specifications;
using Rhino.Mocks;

namespace CodeProgression.Framework.Testing.Examples.Specifications
{
    [Subject("using vanilla RhinoMocks")]
    public class Example01_when_starting_coffee_machine
    {
        Establish context = () =>
            {
                Grinder = MockRepository.GenerateMock<IGrinder>();
                Hopper = MockRepository.GenerateMock<IHopper>();
                Hopper.Expect(x => x.IsEmpty()).Return(true);
                _coffeeMachine = new CoffeeMachine(Grinder, Hopper);
            };

        Because of = () => _coffeeMachine.Brew(12);

        It should_check_if_hopper_is_empty = () => Hopper.VerifyAllExpectations();
        It should_grind_coffee = () => Grinder.AssertWasCalled(x => x.Grind(12));

        static IGrinder Grinder;
        static IHopper Hopper;
        static CoffeeMachine _coffeeMachine;
    }
}