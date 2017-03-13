$(document).ready(function () {
    $(".test").click(function () {
        alert("clicked!");
        updateCountrySelected("US");
    });
});


function updateCountrySelected(id) {
    $.post("AJAX/UpdateSelectedCountry", { ID: id }, function (data) {
        alert("returned!");
        $(".test-text").html(data);
    });
}