$(document).ready(function () {
    $(".test").click(function () {
        showPrayerNeeded();
    });


    $(".conversions").on("change", function (changeEvent) {
        for (var i = 0; i < changeEvent.target.files.length; ++i) {
            (function (file) {               // Wrap current file in a closure.
                var loader = new FileReader();
                loader.onload = function (loadEvent) {
                    if (loadEvent.target.readyState != 2)
                        return;
                    if (loadEvent.target.error) {
                        alert("Error while reading file " + file.name + ": " + loadEvent.target.error);
                        return;
                    }
                    //console.log(loadEvent.target.result.length); // Your text is in loadEvent.target.result
                    $.post("AJAX/ImportConversions", { str: loadEvent.target.result }, function (data) {
                        if (data == "success") {
                            alert("yay!");
                        } else {
                            alert(data);
                        }
                    });
                };
                loader.readAsText(file);
            })(changeEvent.target.files[i]);
        }
    });

    $(".testData").on("change", function (changeEvent) {
        for (var i = 0; i < changeEvent.target.files.length; ++i) {
            (function (file) {               // Wrap current file in a closure.
                var loader = new FileReader();
                loader.onload = function (loadEvent) {
                    if (loadEvent.target.readyState != 2)
                        return;
                    if (loadEvent.target.error) {
                        alert("Error while reading file " + file.name + ": " + loadEvent.target.error);
                        return;
                    }
                    //console.log(loadEvent.target.result.length); // Your text is in loadEvent.target.result
                    $.post("AJAX/ImportData", { str: loadEvent.target.result }, function (data) {
                        if (data == "success") {
                            alert("yay!");
                        } else {
                            alert(data);
                        }
                    });
                };
                loader.readAsText(file);
            })(changeEvent.target.files[i]);
        }
    });
});


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

/*function showPrayerResource() {
    $.post("AJAX/GetAllCountries", {}, function (data) {
        var countries = JSON.parse(data);
        var renderData = $.map(countries, function (country, i) {
            return { id: country.Code, value: country.PrayerResource };
        });
        highlight(renderData);
    });
}*/