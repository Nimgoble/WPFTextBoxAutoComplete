WPFTextBoxAutoComplete
======================

An attached behavior for WPF's TextBox control that provides auto-completion suggestions from a given collection

## How to use this library:

1. Install the package via NuGet

	```
		PM> Install-Package WPFTextBoxAutoComplete
	```

2. Add a reference to the library in your view

	``` csharp
		xmlns:behaviors="clr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoComplete"
	```
	
3. Create a textbox and bind the "AutoCompleteItemsSource" to a collection of ```IEnumerable<String>```

	``` csharp
		<TextBox 
			Width="250"
			HorizontalAlignment="Center"
			Text="{Binding TestText, UpdateSourceTrigger=PropertyChanged}" 
			behaviors:AutoCompleteBehavior.AutoCompleteItemsSource="{Binding TestItems}" 
		/>
	```
	
4. (Optional) Set the "AutoCompleteStringComparison" property, which is of type <a href='https://msdn.microsoft.com/en-us/library/system.stringcomparison(v=vs.110).aspx'>StringComparison</a>

	``` csharp
		<TextBox 
			Width="250"
			HorizontalAlignment="Center"
			Text="{Binding TestText, UpdateSourceTrigger=PropertyChanged}" 
			behaviors:AutoCompleteBehavior.AutoCompleteItemsSource="{Binding TestItems}" 
			behaviors:AutoCompleteBehavior.AutoCompleteStringComparison="InvariantCultureIgnoreCase"
		/>
	```
	
5. (Optional) Set the "AutoCompleteIndicator" property, which is a String.  This is used to indicate to the behavior that it should start making auto-completion suggestions.

	``` csharp
		<TextBox 
			Width="250"
			HorizontalAlignment="Center"
			Text="{Binding TestText, UpdateSourceTrigger=PropertyChanged}" 
			behaviors:AutoCompleteBehavior.AutoCompleteItemsSource="{Binding TestItems}" 
			behaviors:AutoCompleteBehavior.AutoCompleteIndicator="@"
		/>
	```
    
Now, every time the "TestText" property of your datacontext is changed, WPFTextBoxAutoComplete will provide you with auto-completion suggestions.  To accept a suggestion, just hit "enter".

		
