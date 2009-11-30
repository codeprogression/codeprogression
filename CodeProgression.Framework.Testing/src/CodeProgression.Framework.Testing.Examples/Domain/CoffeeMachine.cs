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

        public void Brew(int capacityInCups)
        {
            if (_hopper.IsEmpty())
            {
                _grinder.Grind(capacityInCups);
            }
        }
    }
}