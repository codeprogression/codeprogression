namespace CodeProgression.Framework.Testing
{
    public abstract class SpecificationFor<T> where T: class
    {
        protected static ClassUnderTest<T> AutoMocker;
        protected static T ClassUnderTest;

        protected SpecificationFor()
        {
            AutoMocker = AutoMockFactory.CreateTarget<T>();
            AutoMocker.PartialMockTheClassUnderTest();
            ClassUnderTest = AutoMocker.Instance;
        }

        protected SpecificationFor(AutoMockType type)
        {
            AutoMocker = AutoMockFactory.CreateTarget<T>(type);
            AutoMocker.PartialMockTheClassUnderTest();
            ClassUnderTest = AutoMocker.Instance;
        }
    }
}