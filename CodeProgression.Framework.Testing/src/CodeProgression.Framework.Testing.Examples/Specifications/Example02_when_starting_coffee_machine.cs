using CodeProgression.Framework.Testing.Examples.Abstractions;
using CodeProgression.Framework.Testing.Examples.Domain;
using Machine.Specifications;
using Rhino.Mocks;
using StructureMap.AutoMocking;

namespace CodeProgression.Framework.Testing.Examples.Specifications
{
    [Subject("with RhinoAutoMocker<CoffeeMachine>")]
    public class Example02_when_starting_coffee_machine
    {
        Establish context = () =>
            {
                CoffeeDispenser = new RhinoAutoMocker<CoffeeMachine>();
                Grinder = CoffeeDispenser.Get<IGrinder>();
                Hopper = CoffeeDispenser.Get<IHopper>();
                Hopper.Expect(x => x.IsEmpty()).Return(true);
            };

        Because of = () => CoffeeDispenser.ClassUnderTest.Brew(12);

        It should_check_if_hopper_is_empty = () => Hopper.VerifyAllExpectations();
        It should_grind_coffee = () => Grinder.AssertWasCalled(x => x.Grind(12));

        static IGrinder Grinder;
        static IHopper Hopper;
        static RhinoAutoMocker<CoffeeMachine> CoffeeDispenser;
    }
}