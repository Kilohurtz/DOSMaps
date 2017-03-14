//This function changes the view when the user selects an item in the dropdown menu.
$(document).ready(function(){
	$("#continents").change(function(){
		$("#perspective").removeClass().addClass($(this).val());
	});
});