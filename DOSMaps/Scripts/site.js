$(document).ready(function () {
    $(".test").click(function () {
        alert("clicked!");
        showPrayerNeeded();
    });
});


function showPrayerNeeded() {
    $.post("AJAX/GetAllCountries", {}, function (data) {
        alert("returned!");
        $(".test-text").html(data);
    });
}