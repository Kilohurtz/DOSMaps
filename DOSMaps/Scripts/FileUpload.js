$(document).ready(function () {

    $(".plus").click(function (target) {
        $(target.currentTarget).parent().append('<input placeholder="Country Name" class="country-name" />');
    });

    $(".save-multi").click(function (target) {
        var multi = $(target.currentTarget).parent();
        var countryNames = "";
        multi.children(".country-name").each(function(i, obj){
            countryNames += $(obj).val() + ",";
        })
        $.post("/AJAX/UpdateMulti", { id: multi.attr("id"), countryNames: countryNames }, function (data) {
            if (data == "success!") {
                location.reload();
            } else {
                alert(data);
            }
        });
    });

    $(".save-country-name").click(function (target) {
        var country = $(target.currentTarget).parent();
        $.post("/AJAX/UpdateCountryName", { id: country.attr("id"), countryName: country.children(".country-name").val() }, function (data) {
            if (data == "success!") {
                location.reload();
            } else {
                alert(data);
            }
        });
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
                    $.post("/AJAX/ImportConversions", { str: loadEvent.target.result }, function (data) {
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

    $(".prayers-for").on("change", function (changeEvent) {
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
                    $.post("/AJAX/ImportPrayersFor", { str: loadEvent.target.result }, function (data) {
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
                    $.post("/AJAX/ImportData", { str: loadEvent.target.result }, function (data) {
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