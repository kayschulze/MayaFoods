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

            $('#edit-review').submit(function (event) {
                event.preventDefault();   
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    data: $(this).serialize(),
                    success: function(result) {
                        console.log(result.author);
                        $("#author").html("Edit review by: " + result.author);
                    }
    
                });
            });

            $('.display-last-three-products').click(function() {
                $.ajax({
                    url: '@Url.Action("DisplayLastThreeProducts")'
                    type: 'GET',
                    data: $(this).serialize(),
                    dataType: 'html',

                    success: function(result) {
                        var stringResult = '<ul>';
                        for (var i = 0; i < result.length; i++) {
                            stringResult += '<li>' + result.name + '</li>';
                        }
                        stringResult += '</ul>';

                        $('#lastThreeProductsResult').html(stringResult);
                    }
                }
            });
        });
