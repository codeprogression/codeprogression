namespace CodeProgression.Framework.Testing
{
    public abstract class SpecificationFor<T> where T: class
    {
        protected static ClassUnderTest<T> Factory;
        protected static T ClassUnderTest;


        protected SpecificationFor()
        {
            Factory = AutoMockFactory.CreateTarget<T>();
            ClassUnderTest = Factory.Instance;
        }

        protected SpecificationFor(AutoMockType type)
        {
            Factory = AutoMockFactory.CreateTarget<T>(type);
            ClassUnderTest = Factory.Instance;
        }
    }
}