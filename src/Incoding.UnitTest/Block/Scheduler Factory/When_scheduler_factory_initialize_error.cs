﻿namespace Incoding.UnitTest
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Incoding.Block;
    using Incoding.Block.IoC;
    using Incoding.CQRS;
    using Incoding.Extensions;
    using Incoding.MSpecContrib;
    using Machine.Specifications;
    using Moq;
    using It = Machine.Specifications.It;

    #endregion

    [Subject(typeof(SchedulerFactory))]
    public class When_scheduler_factory_initialize_error
    {
        #region Fake classes

        class FakeCommand : CommandBase
        {
            #region Properties

            public string Prop { get; set; }
           

            #endregion

            public override void Execute()
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Establish value

        static SchedulerFactory scheduler;

        static Mock<IDispatcher> dispatcher;

        static bool isStart = true;

        static Exception exception;

        static FakeCommand errorInstance;

        static FakeCommand successInstance;

        static ArgumentException expectedEx;

        #endregion

        Establish establish = () =>
                                  {
                                      var response = new Dictionary<string, List<DelayToScheduler>>();

                                      errorInstance = Pleasure.Generator.Invent<FakeCommand>(dsl => dsl.GenerateTo(r => r.Setting, factoryDsl => {}));
                                      successInstance = Pleasure.Generator.Invent<FakeCommand>(dsl => dsl.GenerateTo(r => r.Setting, factoryDsl => {}));
                                      response.Add(Pleasure.Generator.String(), new List<DelayToScheduler>
                                                                                    {
                                                                                            Pleasure.MockAsObject<DelayToScheduler>(mock =>
                                                                                                                                        {
                                                                                                                                            mock.SetupGet(r => r.Id).Returns(Pleasure.Generator.TheSameString());
                                                                                                                                            mock.SetupGet(r => r.Instance).Returns(errorInstance);
                                                                                                                                        }),
                                                                                    });

                                      response.Add(Pleasure.Generator.String(), new List<DelayToScheduler>
                                                                                    {
                                                                                            Pleasure.MockAsObject<DelayToScheduler>(mock =>
                                                                                                                                        {
                                                                                                                                            mock.SetupGet(r => r.Id).Returns(Pleasure.Generator.TheSameNumber().ToString());
                                                                                                                                            mock.SetupGet(r => r.Instance).Returns(successInstance);
                                                                                                                                        }),
                                                                                    });

                                      dispatcher = Pleasure.Mock<IDispatcher>();
                                      dispatcher.StubQuery(new GetExpectedDelayToSchedulerQuery { FetchSize = Pleasure.Generator.TheSameNumber() },
                                                           dsl => dsl.ForwardToAction(s => s.Date, r => r.Date.ShouldBeDate(DateTime.UtcNow)),
                                                           response);
                                      expectedEx = new ArgumentException(Pleasure.Generator.String());
                                      dispatcher.StubPushAsThrow(errorInstance, expectedEx);
                                      IoCFactory.Instance.StubTryResolve(dispatcher.Object);
                                  };

        Because of = () =>
                         {
                             exception = Catch.Exception(() => SchedulerFactory.Instance.Initialize(initScheduler =>
                                                                                                        {
                                                                                                            initScheduler.FetchSize = Pleasure.Generator.TheSameNumber();
                                                                                                            initScheduler.Conditional = () => isStart;
                                                                                                        }));
                             Thread.Sleep(3.Seconds());
                         };

        It should_be_not_stop = () => exception.ShouldBeNull();

        It should_be_push_instance_success = () => dispatcher.ShouldBePush(successInstance);

        It should_be_change_to_progress_on_instance_success = () => dispatcher.ShouldBePush(new ChangeDelayToSchedulerStatusCommand
                                                                                                {
                                                                                                        Ids = new[] { Pleasure.Generator.TheSameString() },
                                                                                                        Status = DelayOfStatus.InProgress
                                                                                                });

        It should_be_change_to_success_on_instance_success = () => dispatcher.ShouldBePush(new ChangeDelayToSchedulerStatusCommand
                                                                                               {
                                                                                                       Ids = new[] { Pleasure.Generator.TheSameString() },
                                                                                                       Status = DelayOfStatus.InProgress
                                                                                               });

        It should_be_change_to_progress_on_instance_error = () => dispatcher.ShouldBePush(new ChangeDelayToSchedulerStatusCommand
                                                                                              {
                                                                                                      Ids = new[] { Pleasure.Generator.TheSameNumber().ToString() },
                                                                                                      Status = DelayOfStatus.InProgress
                                                                                              });

        It should_be_change_to_error = () => dispatcher.ShouldBePush(new ChangeDelayToSchedulerStatusCommand
                                                                         {
                                                                                 Ids = new[] { Pleasure.Generator.TheSameString() },
                                                                                 Description = expectedEx.ToString(),
                                                                                 Status = DelayOfStatus.Error
                                                                         });

        Cleanup cleanup = () => isStart = false;
    }
}