﻿namespace Incoding.MvcContrib
{
    #region << Using >>

    using System;
    using Incoding.Extensions;

    #endregion

    public static class JquerySelectorExtendTreeTraversalExtensions
    {
        #region Factory constructors

        /// <summary>
        ///     Add elements to the set of matched elements.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend Add(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "add");
        }

        /// <summary>
        ///     Add elements to the set of matched elements.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="selector">
        ///     selector to match elements against.
        /// </param>
        public static JquerySelectorExtend Add(this JquerySelectorExtend original, JquerySelectorExtend selector)
        {
            return AddTree(original, jquerySelector => selector, "add");
        }

        /// <summary>
        ///     Get the children of each element in the set of matched elements, optionally filtered by a action.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend Children(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "children");
        }

        /// <summary>
        ///     Get the children of each element in the set of tag, optionally filtered by a action.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="tag">
        ///     Html tag
        /// </param>
        public static JquerySelectorExtend Children(this JquerySelectorExtend original, HtmlTag tag)
        {
            return original.Children(selector => selector.Tag(tag));
        }

        /// <summary>
        ///     Get the children of each element
        /// </summary>
        /// <param name="original"></param>
        public static JquerySelectorExtend Children(this JquerySelectorExtend original)
        {
            return original.Children(null);
        }

        /// <summary>
        ///     For each element in the set, get the first element that matches the action by testing the element itself and traversing up through its ancestors in the DOM tree.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend Closest(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "closest");
        }

        /// <summary>
        ///     For each element in the set, get the first element that tag the action by testing the element itself and traversing up through its ancestors in the DOM tree.
        /// </summary>
        /// <param name="original">
        /// </param>
        /// <param name="tag">
        ///     Html tag
        /// </param>
        public static JquerySelectorExtend Closest(this JquerySelectorExtend original, HtmlTag tag)
        {
            return original.Closest(selector => selector.Tag(tag));
        }


        /// <summary>
        ///     For each element in the set, get the first element that expression the action by testing the element itself and traversing up through its ancestors in the DOM tree.
        /// </summary>
        /// <param name="original">
        /// </param>
        /// <param name="expression">
        ///     Jquery expression
        /// </param>
        public static JquerySelectorExtend Closest(this JquerySelectorExtend original, JqueryExpression expression)
        {
            return original.Closest(selector => selector.Expression(expression));
        }

        /// <summary>
        ///     Reduce the set of matched elements to those that match the action or pass the function's test.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend Filter(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "filter");
        }

        /// <summary>
        ///     Reduce the set of tag to those that match the action or pass the function's test.
        /// </summary>
        public static JquerySelectorExtend Filter(this JquerySelectorExtend original, HtmlTag tag)
        {
            return original.Filter(selector => selector.Tag(tag));
        }


        /// <summary>
        ///     Reduce the set of expression to those that match the action or pass the function's test.
        /// </summary>
        public static JquerySelectorExtend Filter(this JquerySelectorExtend original, JqueryExpression expression)
        {
            return original.Filter(selector => selector.Expression(expression));
        }

        /// <summary>
        ///     Get the descendants of each element in the current set of matched elements, filtered by a action, jQuery object, or element
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend Find(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "find");
        }

        /// <summary>
        ///     Get the descendants of each element in the current set of tag, filtered by a action, jQuery object, or element
        /// </summary>
        /// <param name="original"></param>
        /// <param name="tag">
        ///     Html tag
        /// </param>
        public static JquerySelectorExtend Find(this JquerySelectorExtend original, HtmlTag tag)
        {
            return original.Find(selector => selector.Tag(tag));
        }

        /// <summary>
        ///     Get the descendants of each element in the current set of tag, filtered by a action, jQuery object, or element
        /// </summary>
        /// <param name="original"></param>
        /// <param name="expression">
        ///     Jquery expression
        /// </param>
        public static JquerySelectorExtend Find(this JquerySelectorExtend original, JqueryExpression expression)
        {
            return original.Find(selector => selector.Expression(expression));
        }

        /// <summary>
        ///     Get the descendants of each element in the current set of matched elements, filtered by a action, jQuery object, or element
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend Next(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "next");
        }

        /// <summary>
        ///     Get the descendants of each element in the current set of matched elements, filtered by a action, jQuery object, or element
        /// </summary>
        public static JquerySelectorExtend Next(this JquerySelectorExtend original)
        {
            return original.Next(null);
        }

        /// <summary>
        ///     Get all following siblings of each element in the set of matched elements, optionally filtered by a action.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend NextAll(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "nextAll");
        }

        /// <summary>
        ///     Get all following siblings of each element in the set of matched elements, optionally filtered by a action.
        /// </summary>
        public static JquerySelectorExtend NextAll(this JquerySelectorExtend original)
        {
            return original.NextAll(null);
        }

        /// <summary>
        ///     Get all following siblings of each element up to but not including the element matched by the action, DOM node, or jQuery object passed.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend NextUntil(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "nextUntil");
        }

        /// <summary>
        ///     Get all following siblings of each element up to but not including the element matched by the action, DOM node, or jQuery object passed.
        /// </summary>
        public static JquerySelectorExtend NextUntil(this JquerySelectorExtend original)
        {
            return original.NextUntil(null);
        }

        /// <summary>
        ///     Get the closest ancestor element that is positioned.
        /// </summary>
        public static JquerySelectorExtend OffsetParent(this JquerySelectorExtend original)
        {
            return AddTree(original, null, "offsetParent");
        }

        /// <summary>
        ///     Get the parent of each element in the current set of matched elements, optionally filtered by a action.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend Parent(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "parent");
        }

        /// <summary>
        ///     Get the parent of each element in the current set of matched elements, optionally filtered by a action.
        /// </summary>
        /// <param name="original">
        /// </param>
        public static JquerySelectorExtend Parent(this JquerySelectorExtend original)
        {
            return AddTree(original, null, "parent");
        }

        /// <summary>
        ///     Get the parent of each element in the current set of tag, optionally filtered by a action.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="tag">
        ///     Tag
        /// </param>
        public static JquerySelectorExtend Parent(this JquerySelectorExtend original, HtmlTag tag)
        {
            return original.Parent(selector => selector.Tag(tag));
        }

        /// <summary>
        ///     Get the parents of each element in the current set of tag, optionally filtered by a action.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="tag">
        ///     Tag
        /// </param>
        public static JquerySelectorExtend Parents(this JquerySelectorExtend original, HtmlTag tag)
        {
            return original.Parents(selector => selector.Tag(tag));
        }

        /// <summary>
        ///     Get the parents of each element in the current set of matched elements, optionally filtered by a action.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend Parents(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "parents");
        }

        /// <summary>
        ///     Get the parents of each element in the current set of matched elements, optionally filtered by a action.
        /// </summary>
        /// <param name="original"></param>
        public static JquerySelectorExtend Parents(this JquerySelectorExtend original)
        {
            return AddTree(original, null, "parents");
        }

        /// <summary>
        ///     Get the ancestors of each element in the current set of matched elements, up to but not including the element matched by the action, DOM node, or jQuery object
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend ParentsUntil(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "parentsUntil");
        }

        /// <summary>
        ///     Get the ancestors of each element in the current set of matched elements, up to but not including the element matched by the action, DOM node, or jQuery object
        /// </summary>
        public static JquerySelectorExtend ParentsUntil(this JquerySelectorExtend original)
        {
            return original.ParentsUntil(null);
        }

        /// <summary>
        ///     Get the immediately preceding sibling of each element in the set of matched elements, optionally filtered by a action.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend Prev(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "prev");
        }

        /// <summary>
        ///     Get the immediately preceding sibling of each element in the set of matched elements, optionally filtered by a action.
        /// </summary>
        public static JquerySelectorExtend Prev(this JquerySelectorExtend original)
        {
            return original.Prev(null);
        }

        /// <summary>
        ///     Get all preceding siblings of each element in the set of matched elements, optionally filtered by a action.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend PrevAll(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "prevAll");
        }

        /// <summary>
        ///     Get all preceding siblings of each element in the set of matched elements, optionally filtered by a action.
        /// </summary>
        public static JquerySelectorExtend PrevAll(this JquerySelectorExtend original)
        {
            return original.PrevAll(null);
        }

        /// <summary>
        ///     Get all preceding siblings of each element up to but not including the element matched by the action, DOM node, or jQuery object.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     Action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend PrevUntil(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "prevUntil");
        }

        /// <summary>
        ///     Get all preceding siblings of each element up to but not including the element matched by the action, DOM node, or jQuery object.
        /// </summary>
        public static JquerySelectorExtend PrevUntil(this JquerySelectorExtend original)
        {
            return original.PrevUntil(null);
        }

        /// <summary>
        ///     Get the siblings of each element in the set of matched elements, optionally filtered by a action
        /// </summary>
        /// <param name="original"></param>
        /// <param name="action">
        ///     Action expression to match elements against.
        /// </param>
        public static JquerySelectorExtend Siblings(this JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action)
        {
            return AddTree(original, action, "siblings");
        }

        /// <summary>
        ///     Get the siblings of each element in the set of matched elements, optionally filtered by a action
        /// </summary>
        public static JquerySelectorExtend Siblings(this JquerySelectorExtend original)
        {
            return original.Siblings(null);
        }

        /// <summary>
        ///     Reduce the set of matched elements to a subset specified by a range of indices.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="start">
        ///     An integer indicating the 0-based position at which the elements begin to be selected. If negative, it indicates an offset from the end of the set.
        /// </param>
        /// <param name="end">
        ///     An integer indicating the 0-based position at which the elements stop being selected. If negative, it indicates an offset from the end of the set. If omitted, the range continues until the end of the set.
        /// </param>
        public static JquerySelectorExtend Slice(this JquerySelectorExtend original, Selector start, Selector end = null)
        {
            return original.Method("slice", new object[] { start, end ?? 0 });
        }

        #endregion

        static JquerySelectorExtend AddTree(JquerySelectorExtend original, Func<JquerySelector, JquerySelector> action, string type)
        {
            if (action == null)
                original.AddMethod("{0}".F(type));
            else
            {
                var selector = action(Selector.Jquery);
                if (selector.IsSimple)
                    original.AddMethod(type, selector.ToSelector());
                else
                    original.AddMethod(type, selector);
            }

            return new JquerySelectorExtend(original);
        }
    }
}