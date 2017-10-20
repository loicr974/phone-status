function actionClickUrl() {

    $("[data-actionclick]").each(function (index, value) {
        $(this).on("click",function () {
            var link = $(this).data("actionclick");
            console.log(link);
            window.location = link;
        });
    });
}