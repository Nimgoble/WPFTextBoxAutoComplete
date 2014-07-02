using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFTextBoxAutoComplete
{
    public static class AutoCompleteBehavior
    {
        private static TextChangedEventHandler onTextChanged = new TextChangedEventHandler(OnTextChanged);
        private static KeyEventHandler onKeyDown = new KeyEventHandler(OnPreviewKeyDown);
        public static readonly DependencyProperty AutoCompleteItemsSource =
            DependencyProperty.RegisterAttached
            (
                "AutoCompleteItemsSource",
                typeof(IEnumerable<String>),
                typeof(AutoCompleteBehavior),
                new UIPropertyMetadata(null, OnAutoCompleteItemsSource)
            );

        public static IEnumerable<String> GetAutoCompleteItemsSource(DependencyObject obj)
        {
            object objRtn = obj.GetValue(AutoCompleteItemsSource);
            if (objRtn is IEnumerable<String>)
                return (objRtn as IEnumerable<String>);

            return null;
        }

        public static void SetAutoCompleteItemsSource(DependencyObject obj, IEnumerable<String> value)
        {
            obj.SetValue(AutoCompleteItemsSource, value);
        }

        private static void OnAutoCompleteItemsSource(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (sender == null)
                return;

            if (e.NewValue == null)
            {
                tb.TextChanged -= onTextChanged;
                tb.PreviewKeyDown -= onKeyDown;
            }
            else
            {
                tb.TextChanged += onTextChanged;
                tb.PreviewKeyDown += onKeyDown;
            }

        }

        static void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            TextBox tb = e.OriginalSource as TextBox;
            if (tb == null)
                return;

            //If we pressed enter and if the selected text goes all the way to the end, move our caret position to the end
            if (tb.SelectionLength > 0 && (tb.SelectionStart + tb.SelectionLength == tb.Text.Length))
            {
                tb.SelectionStart = tb.CaretIndex = tb.Text.Length;
                tb.SelectionLength = 0;
            }
        }

        static void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if
            (
                (from change in e.Changes where change.RemovedLength > 0 select change).Count() > 0 &&
                (from change in e.Changes where change.AddedLength > 0 select change).Count() <= 0
            )
                return;

            TextBox tb = e.OriginalSource as TextBox;
            if (sender == null)
                return;

            IEnumerable<String> values = GetAutoCompleteItemsSource(tb);
            //No reason to search if we don't have any values.
            if (values == null)
                return;

            //No reason to search if there's nothing there.
            if (String.IsNullOrEmpty(tb.Text))
                return;

            Int32 textLength = tb.Text.Length;

            //Do search and changes here.
            IEnumerable<String> matches =
                from
                    value
                in
                    (
                        from subvalue
                        in values
                        where subvalue.Length >= textLength
                        select subvalue
                    )
                where value.Substring(0, textLength) == tb.Text
                select value;

            //Nothing.  Leave 'em alone
            if (matches.Count() == 0)
                return;

            String match = matches.ElementAt(0);
            //String remainder = match.Substring(textLength, (match.Length - textLength));
            tb.TextChanged -= onTextChanged;
            tb.Text = match;
            tb.CaretIndex = textLength;
            tb.SelectionStart = textLength;
            tb.SelectionLength = (match.Length - textLength);
            tb.TextChanged += onTextChanged;
        }
    }
}
