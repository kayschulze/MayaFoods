       $(document).ready(function () {
            $('#create-review').submit(function (event) {
                event.preventDefault();
                $.ajax({
                    url: '@Url.Action("CreateReview", "Reviews")',
                    type: 'POST',
                    dataType: 'json',
                    data: $(this).serialize(),
                    success: function (result) {
                        console.log("hey");
                        
                        $('#newProductReviewResult').html("cool!");
                    }
                });
            });
        });
