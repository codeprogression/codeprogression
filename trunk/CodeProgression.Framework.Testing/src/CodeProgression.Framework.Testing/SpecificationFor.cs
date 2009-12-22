namespace CodeProgression.Framework.Testing
{
    public abstract class SpecificationFor<T> where T: class
    {
        protected static ClassUnderTest<T> AutoMocker;
        protected static T ClassUnderTest { get { return AutoMocker.Instance; } }

        protected SpecificationFor()
        {
            AutoMocker = AutoMockFactory.CreateTarget<T>();
        }

        protected SpecificationFor(AutoMockType type)
        {
            AutoMocker = AutoMockFactory.CreateTarget<T>(type);
        }
    }
}