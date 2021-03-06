namespace Incoding.UnitTest.Block
{
    #region << Using >>

    using Incoding.Block.Caching;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(CachingPolicy))]
    public class When_caching_policy_never
    {
        It should_be_never_expires = () => Pleasure.Do10((i) => new CachingPolicy().ForAll().NeverExpires().IsExpires(new FakeCacheKey()).ShouldBeFalse());

        It should_be_always_expires = () => Pleasure.Do10((i) => new CachingPolicy().ForAll().AlwaysExpires().IsExpires(new FakeCacheKey()).ShouldBeTrue());
    }
}