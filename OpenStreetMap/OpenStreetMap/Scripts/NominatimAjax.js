$(document).ready(function () {
    $("#SendQuery").click(function () {

        $.ajax({
            url: '/Api/Nominatim/Reverse/Query',
            type: 'POST',
            data: {
                Latitude: $("input[name='Latitude']").val(),
                Longitude: $("input[name='Longitude']").val(),
                Email: $("input[name='Email']").val()
            },
            dataType: 'json',

            error: function (xhr, textStatus, errorThrown) {
                var finalErrorsString = "";
                var errors = [];
                $('#Result').removeClass("label label-success");
                $('#Result').addClass("label label-danger");
                if (xhr.status == 400) {
                    response = JSON.parse(xhr.responseText);
                    var modelState = response.ModelState;
                    for (var key in modelState) {
                        if (modelState.hasOwnProperty(key)) {
                            finalErrorsString = (finalErrorsString == "" ? "" : finalErrorsString + "<br />") + modelState[key];
                            errors.push(modelState[key]);
                        }
                    }
                    $('#Result').html(finalErrorsString);
                }
                else {
                    $('#Result').html(xhr.responseText);
                }
            },
            success: function (data, textStatus, xhr) {
                $('#Result').removeClass("label label-danger");
                $('#Result').addClass("label label-success");
                $('#Result').html(data);
                $("INPUT").each(function () {
                    $(this).val("");
                })

            },
        });
    });
});