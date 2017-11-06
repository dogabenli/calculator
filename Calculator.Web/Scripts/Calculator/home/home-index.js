$(document).ready(function() {
    var btnUpload = $('#btn-upload');
    var calculationSection = $('.calculation-section');
    var calculationResult = $('.calculation-section .result');
    var errorMessageSection = $('.error-message');
    var errorMessage = $('.error-message p');
    var spinner = $('#spinner');
    var inpFile = $("#file");


    function pageLoad() {

        function showErrorMessage(message) {
            errorMessage.text(message);
            errorMessageSection.show();
        }

        function hideErrorMessage() {
            errorMessageSection.hide();
            errorMessage.text("");
        }

        function showCalculationResult(result) {
            calculationResult.text(result);
            calculationSection.slideDown();
        }

        function hideCalculationResult() {
            calculationSection.hide();
            calculationResult.text("");
        }

        btnUpload.click(function (e) {

            hideErrorMessage();
            hideCalculationResult();

            var url = $(this).data("url");

            var data = new FormData();

            var files = inpFile.get(0).files;

            if (files.length < 1) return;

            data.append("UploadedFile", files[0]);

            spinner.show();

            $.ajax({
                type: "POST",
                url: url,
                contentType: false,
                processData: false,
                data: data,
                error: function (err) {
                    //an unexpected error comes
                    spinner.hide();
                    showErrorMessage("Something went wrong, but don't worry our team already started working on it.");
                }
            }).done(function (res) {
                if (res.IsSuccess) {
                    showCalculationResult(res.Data.ResultAsString);

                } else {
                    showErrorMessage(res.ErrorMessage);
                }
                spinner.hide();
                inpFile.val("");

            });
        });

    }

    pageLoad();

});