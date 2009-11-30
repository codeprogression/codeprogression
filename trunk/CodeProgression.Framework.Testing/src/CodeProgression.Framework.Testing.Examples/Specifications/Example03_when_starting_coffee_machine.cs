using CodeProgression.Framework.Testing.Examples.Abstractions;
using CodeProgression.Framework.Testing.Examples.Domain;
using Machine.Specifications;
using Rhino.Mocks;
using StructureMap.AutoMocking;

namespace CodeProgression.Framework.Testing.Examples.Specifications
{
    [Subject("with rhino automocker base")]
    public class Example03_when_starting_coffee_machine : with_ram_dispenser
    {
        Establish context = () => Hopper.Expect(x => x.IsEmpty()).Return(true);

        Because of = () => CoffeeDispenser.ClassUnderTest.Brew(12);

        It should_check_if_hopper_is_empty = () => Hopper.VerifyAllExpectations();
        It should_grind_coffee = () => Grinder.AssertWasCalled(x => x.Grind(12));

    }

    [Subject("with RhinoAutoMocker<T>")]
    public class with_ram_dispenser
    {

        protected static IGrinder Grinder;
        protected static IHopper Hopper;
        protected static RhinoAutoMocker<CoffeeMachine> CoffeeDispenser;

        Establish context = () =>
        {

            CoffeeDispenser = new RhinoAutoMocker<CoffeeMachine>();
            Grinder = CoffeeDispenser.Get<IGrinder>();
            Hopper = CoffeeDispenser.Get<IHopper>();
        };
    }
}