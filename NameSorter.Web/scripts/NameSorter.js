var validator = (function () {
    var sortedNames = "";
    function initEvent() {
        $('#namesorter').submit(function (e) {
            e.preventDefault();
            reset();

            var data = new FormData();
            var files = $("#fileUpload").get(0).files;
            // Add the uploaded image content to the form data collection
            if (files.length > 0) {
                data.append("UploadedImage", files[0]);
                sortNamesFromFile(data);
            } else {
                alert("Please upload a text file with names.");
            }


        });

        $('#link').click(function () {
            $('#link').href = "data:text/plain;charset=utf-8," + encodeURIComponent(sortedNames);
        });
    };

    function reset() {
        $('.form-group').removeClass('has-success');
        $('.form-group').removeClass('has-error');
        $('#result').removeClass('bg-success');
        $('#result').removeClass('bg-danger');
    }

    function doError(message) {
        $('.form-group').addClass('has-error');
        $('#result').addClass('bg-danger').text(message).show();
        return false;
    };

    function doSuccess(message) {
        $('.form-group').addClass('has-success');
        sortedNames = message;
        $('#result').addClass('bg-success').html(message.replace(/\n/g, "<br/>")).show();
        $('#link').show();
        return true;
    }

    
   

    function sortNamesFromFile(data) {
        debugger;
        var url = 'http://localhost:61702/api/NameSorter/Post/';
        var userIp = '';

        $.getJSON("https://api.ipify.org/?format=json", function (e) {
            userIp = e.ip;
            

            $.ajax({
                url: url,
                async: false,
                data: data,
                type: "POST",
                contentType: false,
                processData: false,
                success: function (jdata) {
                    if (jdata.ErrorCode === "1") {

                        doSuccess(jdata.SortedNameList);
                    } else {
                        doError(jdata.ErrorMessage);
                    }
                    u.log('Success: ' + url);

                },
                error: function (err) {
                    u.log('Error' + ' (' + err.status + '-' + err.statusText + ': ' + url + ') - ' + err.responseText);
                }
            });
        });
    }
    
    return {
        Start: function () {
            initEvent();
        }
    }

})();

$(document).ready(function () {
    validator.Start();
});