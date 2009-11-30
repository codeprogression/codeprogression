using CodeProgression.Framework.Testing.Examples.Abstractions;
using CodeProgression.Framework.Testing.Examples.Domain;
using Machine.Specifications;
using Rhino.Mocks;

namespace CodeProgression.Framework.Testing.Examples.Specifications
{
    [Subject(typeof(CoffeeMachine), "using vanilla Rhino.Mocks")]
    public class Example01_when_preparing_coffee_grounds
    {
        Establish context = () =>
            {
                Grinder = MockRepository.GenerateMock<IGrinder>();
                Hopper = MockRepository.GenerateMock<IHopper>();
                Hopper.Expect(x => x.HasBeans()).Return(true);
                CoffeeMachine = new CoffeeMachine(Grinder, Hopper);
            };

        Because of = () => CoffeeMachine.PrepareCoffeeGrounds(12);

        It should_check_if_hopper_has_beans = () => Hopper.VerifyAllExpectations();
        It should_grind_coffee = () => Grinder.AssertWasCalled(x => x.Grind(12));

        static IGrinder Grinder;
        static IHopper Hopper;
        static CoffeeMachine CoffeeMachine;
    }
}