var img = $(".img-modal")
$(".photo").each(function (index) {
    $(this).off("click").on("click", function () {
        $("#myModal").mikesModal();
        img.attr("src", $(this).attr("src"));
        var postId = $(this).data("id");
        $.ajax({
            type: "GET",
            url: "/Post/ShowPost",
            data: {
                postId: postId,
            },
            dataType: "json",
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    $(".auth-name").text(data.User.FirstName + " " + data.User.LastName);
                    $(".user-avt").text("~/UploadImage/Avatar/" + data.User.Avatar);

                    console.log(data);
                }
            }
        });
    });
});