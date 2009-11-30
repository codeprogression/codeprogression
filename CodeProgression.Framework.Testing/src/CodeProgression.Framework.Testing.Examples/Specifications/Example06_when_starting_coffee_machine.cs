using CodeProgression.Framework.Testing.Examples.Abstractions;
using CodeProgression.Framework.Testing.Examples.Domain;
using Machine.Specifications;
using Moq;
using It=Machine.Specifications.It;

namespace CodeProgression.Framework.Testing.Examples.Specifications
{
    [Subject(typeof(CoffeeMachine), "using moq base")]
    public class Example06_when_preparing_coffee_grounds : with_moq_coffee_machine
    {
        Establish context = () => Hopper.Setup(x=>x.HasBeans()).Returns(true);

        Because of = () => ClassUnderTest.PrepareCoffeeGrounds(12);

        It should_check_if_hopper_has_beans = () => Hopper.Verify();
        It should_grind_coffee = () => Grinder.Verify(x=>x.Grind(12));
    }

    [Subject("using SpecificationFor<CoffeeMachine>(AutoMockType.Moq)")]
    public class with_moq_coffee_machine : SpecificationFor<CoffeeMachine>
    {
        protected static Mock<IGrinder> Grinder;
        protected static Mock<IHopper> Hopper;

        public with_moq_coffee_machine() : base(AutoMockType.Moq)
        {
            Grinder = Mock.Get(AutoMocker.Get<IGrinder>());
            Hopper = Mock.Get(AutoMocker.Get<IHopper>());
        }
    }
}