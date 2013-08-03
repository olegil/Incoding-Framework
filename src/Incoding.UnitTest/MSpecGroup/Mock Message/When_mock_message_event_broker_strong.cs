namespace Incoding.UnitTest.MSpecGroup
{
    #region << Using >>

    using Machine.Specifications;using Incoding.MSpecContrib;

    #endregion

    [Subject(typeof(MockMessage<,>))]
    public class When_mock_message_event_broker_strong : Context_mock_message_event_broker
    {
        Establish establish = () =>
                                  {
                                      mockMessage = MockCommand<FakeCommand>
                                              .When(new FakeCommand())
                                              .StubPublish(new FakeEvent { Value = Pleasure.Generator.TheSameString() });
                                  };

        Because of = () => { exception = Catch.Exception(() => mockMessage.Original.Execute()); };

        It should_not_be_exception = () => exception.ShouldBeNull();
    }
}