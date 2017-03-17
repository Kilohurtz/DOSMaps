function showPrayerNeeded() {
    $.post("AJAX/GetAllCountries", {}, function (data) {
        var countries = JSON.parse(data);
        var renderData = $.map(countries, function(country, i){
                            return { id: '.' + country.Code, value: country.PrayerNeed };
        });
        highlight(renderData);
    });
}

function showPrayerResource() {
    $.post("AJAX/GetAllCountries", {}, function (data) {
        var countries = JSON.parse(data);
        var renderData = $.map(countries, function (country, i) {
            return { id: '.' + country.Code, value: country.PrayerResource };
        });
        highlight(renderData);
    });
}