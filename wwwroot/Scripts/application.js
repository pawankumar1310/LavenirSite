function preback()
{
    window.history.forward();
}
setTimeout("preback()", 0);
window.onunload = function ()
{
    null;
}

$(document).ready(function () {
    $("#divCurrentEvents").attr("hidden", false);
    $('#lbSchools').click(function () {
        var lst = $(this);
        var selected = new Array();
        lst.find("option").each(function () {
            if ($(this).is(":selected")) {
                selected.push($(this));
                $(this).remove();
            }
            $(selected).each(function () {
                lst.prepend($(this));
            });
        });
    });

    $('.eventLink').click(function () {
        event.preventDefault();
        saveEventSeenInformation(($(this).attr('event_id')), (document.getElementById('hiddenUserID').value));
        window.open(($(this).attr('event_link')), '_blank');
    });

    $('.descriptionLink').click(function () {
        event.preventDefault();
        window.open(($(this).attr('description_link')), '_blank');
    });

    $("#ddlCountry").change(function () {
        var stateDropDownList = $('#ddlState');
        var districtDropDownList = $('#ddlDistrict');

        $(stateDropDownList).empty();
        $(districtDropDownList).empty();

        var OptionValue = "0";
        var OptionText = "Select District / City";
        var option = $("<option>" + OptionText + "</option>");
        option.attr("value", OptionValue);

        districtDropDownList.append(option);

        $.ajax({
            type: "POST",
            url: "HomeWebForm.aspx/displayStates",
            data: "{ 'countryID': '" + ($('#ddlCountry').val()) + "' }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data)
            {
                $(data.d).find('States').each(function () {
                    var OptionValue = $(this).find('stateID').text();
                    var OptionText = $(this).find('stateName').text();
                    var option = $("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    stateDropDownList.append(option);
                });
            },
            failure: function () {
                alert("Failed!");
            }
        });
    });

    $("#ddlState").change(function () {
        var districtDropDownList = $('#ddlDistrict');
        $(districtDropDownList).empty();

        $.ajax({
            type: "POST",
            url: "HomeWebForm.aspx/displayDistricts",
            data: "{ 'stateID': '" + ($('#ddlState').val()) + "' }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $(data.d).find('Districts').each(function () {
                    var OptionValue = $(this).find('districtID').text();
                    var OptionText = $(this).find('districtName').text();
                    var option = $("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    districtDropDownList.append(option);
                });
            },
            failure: function () {
                alert("Failed!");
            }
        });
    });

    $("#ddlSchoolCountry").change(function () {
        var stateDropDownList = $('#ddlSchoolState');
        var districtDropDownList = $('#ddlSchoolCity');
        
        $(stateDropDownList).empty();
        $(districtDropDownList).empty();

        var OptionValue = "0";
        var OptionText = "Select District / City";
        var option = $("<option>" + OptionText + "</option>");
        option.attr("value", OptionValue);

        districtDropDownList.append(option);

        $.ajax({
            type: "POST",
            url: "HomeWebForm.aspx/displayStates",
            data: "{ 'countryID': '" + ($('#ddlSchoolCountry').val()) + "' }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $(data.d).find('States').each(function () {
                    var OptionValue = $(this).find('stateID').text();
                    var OptionText = $(this).find('stateName').text();
                    var option = $("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    stateDropDownList.append(option);
                });
            },
            failure: function () {
                alert("Failed!");
            }
        });
    });

    $("#ddlSchoolState").change(function () {
        var districtDropDownList = $('#ddlSchoolCity');
        $(districtDropDownList).empty();

        $.ajax({
            type: "POST",
            url: "HomeWebForm.aspx/displayDistricts",
            data: "{ 'stateID': '" + ($('#ddlSchoolState').val()) + "' }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $(data.d).find('Districts').each(function () {
                    var OptionValue = $(this).find('districtID').text();
                    var OptionText = $(this).find('districtName').text();
                    var option = $("<option>" + OptionText + "</option>");
                    option.attr("value", OptionValue);

                    districtDropDownList.append(option);
                });
            },
            failure: function () {
                alert("Failed!");
            }
        });
    });

    $("#ddlAchievementsType").change(function () {
        if (($('#ddlAchievementsType').val()) == "1") {
            $("#lblAchievementUpload").empty();
            $("#lblAchievementUpload").append("Upload Badge");
        }
        else if (($('#ddlAchievementsType').val()) == "2") {
            $("#lblAchievementUpload").empty();
            $("#lblAchievementUpload").append("Upload Certificate");
        }
    });
});

function saveEventSeenInformation(eventID, userID) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "HomeWebForm.aspx/saveUserEventSeenInformation",
        data: "{ 'userID': '" + userID + "', 'eventID': '" + eventID + "' }",
            
        success: function () {},
        error: function () {}
    });
}

function searchSchool() {
    $("#txtSchoolName").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "HomeWebForm.aspx/GetSchoolName",
                data: "{'schoolName':'" + document.getElementById('txtSchoolName').value + "'}",
                dataType: "json",
                success: function (data) {
                    if (data.d == '') {
                        response("No Schools Found");
                    }
                    else {
                        response(data.d);
                    }
                },
                error: function (result) {
                    alert("No Match");
                }
            });
        }
    });
}

function displayUserPhoto(input) {
    if (input.files && input.files[0]) {
        var ImageDir = new FileReader();
        ImageDir.onload = function (e) {
            $('#userPhotoDisplay').attr('src', e.target.result);
        }
        ImageDir.readAsDataURL(input.files[0]);
    }
}