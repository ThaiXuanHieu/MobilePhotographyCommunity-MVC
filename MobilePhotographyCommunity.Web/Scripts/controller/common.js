$(document).ready(function () {

    $(".btn-delete-post").on("click", function () {
        var postId = $(this).data("id");
        $.ajax({
            type: "POST",
            url: "/Post/DeletePost",
            data: {
                postId: postId,
            },
            dataType: "json",
            success: function (response) {
                if (response.status) {
                    window.location.reload();
                } else {
                    console.log("Lỗi");
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    $(".btn-like").on("click", function () {
        const postId = $(this).data("id");
        var self = $(this);
        $.ajax({
            type: "POST",
            url: "/Post/LikePost",
            data: {
                postId: postId,
            },
            dataType: "json",
            success: function (response) {
                if (response.status) {
                    var likes = response.data;
                    var likeCount = likes.length + 1;
                    self.css("color", "#337ab7");
                    $(".like-count").each(function (index) {
                        if ($(this).data("id") == postId) {
                            $(this).text(likeCount + " Thích");
                        }
                    });
                    window.location.reload();

                } else {
                    var likes = response.data;
                    var likeCount = likes.length - 1;
                    self.css("color", "");
                    $(".like-count").each(function (index) {
                        if ($(this).data("id") == postId) {
                            if (likeCount <= 0) {
                                $(this).text("");
                            } else {
                                $(this).text(likeCount + " Thích");
                            }
                        }
                    });
                    window.location.reload();
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    $(".btn-send-comment").on("click", function () {
        const postId = $(this).data("id");
        var contentComment = $(".rg-comment").find("[data-id = " + postId + "]").val().trim();
        if (contentComment == "") {
            console.log("Bình luận không được để trống");
            return;
        }
        $.ajax({
            type: "POST",
            url: "/Post/Comment",
            data: {
                postId: postId,
                content: contentComment
            },
            dataType: "json",
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    var otherComment = "<div class='other-comment'>"
                        + "<div class='detail-comment'> "
                        + "<div class='commentedby'>"
                        + "<a href='/Account/UserProfile/'" + data.User.UserId + ">"
                        + "<img class='user-avt' src='/UploadImage/Avatar/" + data.User.Avatar + "' alt=''>"
                        + "</a>"
                        + "</div>"
                        + "<div class='comment-content'>"
                        + "<a href='" + data.User.UserId + "'><h4 class='name'>" + " " + data.User.FirstName + " " + data.User.LastName + "</h4></a>"
                        + "<span>" + data.Content + "</span>"
                        + "</div>"
                        + "</div>"
                        + "<div class='action-comment'>"
                        + "<span>Thích</span>"
                        + "<span>&nbsp;·&nbsp;Trả lời</span>"
                        + "<span>&nbsp;·&nbsp;" + GetDate(data.CreatedTime) + "</span>"
                        + "</div>"
                        + "<div class='comment-option' style='position: absolute; right: 0px; top: 15px;'>"
                        + "<div class='dropdown post-option' style='float: right;'>"
                        + "<a class='dropdown-toggle' data-toggle='dropdown' style='color:black'>"
                        + "<i class='fal fa-ellipsis-v fa-2x'></i>"
                        + "</a>"
                        + "<ul class='dropdown-menu dropdown-menu-right'>"
                        + "<li><a href='#'><i class='fal fa-edit'></i> Chỉnh sửa</a></li>"
                        + "<li><a href='#'><i class='fal fa-trash-alt'></i> Xóa</a></li>"
                        + "</ul>"
                        + "</div>"
                        + "</div>"
                        + "</div>";

                    $(".all-comment[data-id = " + postId + "]").prepend(otherComment);
                    $(".rg-comment").find("[data-id = " + postId + "]").val("");
                    $(".commentCount[data-id=" + postId + "]").text(parseInt($(".commentCount[data-id=" + postId + "]").text().charAt(0)) + 1 + " Bình luận");
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

});