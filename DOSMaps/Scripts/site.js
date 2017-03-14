$(document).ready(function () {
    $(".test").click(function () {
        showPrayerNeeded();
    });
});


function showPrayerNeeded() {
    $.post("AJAX/GetAllCountries", {}, function (data) {
        var countries = JSON.parse(data);
        var renderData = $.map(countries, function(country, i){
                            return { id: country.Code, value: country.PrayerNeed };
        });
        //RENDER FUNCTION
    });
}

function showPrayerResource() {
    $.post("AJAX/GetAllCountries", {}, function (data) {
        var countries = JSON.parse(data);
        var renderData = $.map(countries, function (country, i) {
            return { id: country.Code, value: country.PrayerResource };
        });
        //RENDER FUNCTION
    });
}