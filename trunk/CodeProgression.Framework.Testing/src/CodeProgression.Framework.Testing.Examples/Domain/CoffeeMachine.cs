using CodeProgression.Framework.Testing.Examples.Abstractions;

namespace CodeProgression.Framework.Testing.Examples.Domain
{
    public class CoffeeMachine
    {
        readonly IGrinder _grinder;
        readonly IHopper _hopper;

        public CoffeeMachine(IGrinder grinder, IHopper hopper)
        {
            _grinder = grinder;
            _hopper = hopper;
        }

        public void PrepareCoffeeGrounds(int cupsToBrew)
        {
            if (_hopper.HasBeans())
            {
                _grinder.Grind(cupsToBrew);
            }
        }
    }
}