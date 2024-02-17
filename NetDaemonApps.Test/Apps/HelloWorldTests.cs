namespace NetDaemonApps.Test.Apps;

public class HelloWorldTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var mock = new Mock<IHaContext>();
        var helloWorld = new HelloWorldApp(mock.Object);

        var expected = new { message = "Notify me", title = "Hello world!" };

        mock.Verify(x => x.CallService("notify", "persistent_notification", It.IsAny<ServiceTarget>(), It.Is<object>(y => y.GetHashCode() == expected.GetHashCode())), Times.Once());
    }
}