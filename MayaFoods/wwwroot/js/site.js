       $(document).ready(function () {
            $('.create-review').submit(function (event) {
                event.preventDefault();
                $.ajax({
                    url: '@Url.Action("CreateReview", "Reviews")',
                    type: 'POST',
                    dataType: 'json',
                    data: $(this).serialize(),
                    success: function (result) {
                        var resultMessage = 'Your new review added to the database!';
                        resultMessage += '<br> Author: ' + result.reviewid + ' ';
                        resultMessage += '<br> Content: ' + result.author + ' ';
                        resultMessage += '<br> Rating: ' + result.contentbody + ' ';
                        resultMessage += '<br> Product Id: ' + result.productid;
                        $('#newProductReviewResult').html(resultMessage);
                    }
                });
            });
        });
