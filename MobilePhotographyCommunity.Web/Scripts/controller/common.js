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
        var dropdownLiked = $("#dropdown-liked-" + postId).empty();
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
                    var likeCount = likes.length;
                    self.css("color", "#337ab7");
                    $("#like-count-" + postId).text(likeCount + " Thích");

                    if (dropdownLiked.length == 0) {
                        var listLiked = "<div class='dropup'>"
                            + "<a href='#' style='float: left' data-toggle='dropdown' data-id='" + postId + "' id='like-count-" + postId + "'>" + likeCount + " Thích</a>"
                            + "<ul class='dropdown-menu' id='dropdown-liked-" + postId + "' data-id='" + postId + "'>"
                        $.each(likes, function (index, value) {
                            listLiked += "<li>"
                                + "<a href = '/Account/UserProfile/" + value.User.UserId + "'>"
                                + "<img class='user-avt mr-3' src='/UploadImage/Avatar/" + value.User.Avatar + "' alt='' style=' width:40px; height:40px'>"
                                + "<span class='fullname' style='display: inline;'>" + value.User.FirstName + " " + value.User.LastName + "</span > "
                                + "</a>"
                                + "</li>"
                        })

                        listLiked += "</ul>"
                            + "</div> ";
                        $("#count-liked-commented-" + postId).prepend(listLiked);
                    } else {
                        var listLiked = "";
                        $.each(likes, function (index, value) {
                            listLiked += "<li>"
                                + "<a href = '/Account/UserProfile/" + value.User.UserId + "'>"
                                + "<img class='user-avt mr-3' src='/UploadImage/Avatar/" + value.User.Avatar + "' alt='' style=' width:40px; height:40px'>"
                                + "<span class='fullname' style='display: inline;'>" + value.User.FirstName + " " + value.User.LastName + "</span > "
                                + "</a>"
                                + "</li>"
                        })
                        dropdownLiked.append(listLiked);
                    }
                } else {
                    var likes = response.data;
                    var likeCount = likes.length;
                    if (likeCount == 0) {
                        self.css("color", "");
                        $("#count-liked-commented-" + postId).children(".dropup").remove();
                    } else {
                        self.css("color", "");
                        $("#like-count-" + postId).text(likeCount + " Thích");
                        var listLiked = "";
                        $.each(likes, function (index, value) {
                            listLiked += "<li>"
                                + "<a href = '/Account/UserProfile/" + value.User.UserId + "'>"
                                + "<img class='user-avt mr-3' src='/UploadImage/Avatar/" + value.User.Avatar + "' alt='' style=' width:40px; height:40px'>"
                                + "<span class='fullname' style='display: inline;'>" + value.User.FirstName + " " + value.User.LastName + "</span > "
                                + "</a>"
                                + "</li>"
                        })
                        dropdownLiked.append(listLiked);
                    }
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    $(".btn-send-comment").on("click", function () {
        const postId = $(this).data("id");
        const commentId = $(this).attr("data-commentId");
        console.log(commentId);
        var contentComment = $(".rg-comment").find("[data-id = " + postId + "]").val().trim();
        if (contentComment == "") {
            console.log("Bình luận không được để trống");
            return;
        }
        if (commentId == "0") {
            $.ajax({
                type: "POST",
                url: "/Post/Comment",
                data: {
                    commentId: 0,
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
                            + "<li><a href='javascript:void(0)' class='btn-edit-comment' data-id='" + data.CommentId + "'><i class='fal fa-edit'></i> Chỉnh sửa</a></li>"
                            + "<li><a href='javascript:void(0)' class='btn-delete-comment' data-id='" + data.CommentId + "'><i class='fal fa-trash-alt'></i> Xóa</a></li>"
                            + "</ul>"
                            + "</div>"
                            + "</div>"
                            + "</div>";

                        $(".btn-send-comment[data-id = " + data.PostId + "]").attr("data-commentId", "0");
                        $(".all-comment[data-id = " + postId + "]").prepend(otherComment);
                        $(".comment-content-inp[data-id = " + postId + "]").val("");
                        if ($(".commentCount[data-id=" + postId + "]").length > 0) {
                            $(".commentCount[data-id=" + postId + "]").text(parseInt($(".commentCount[data-id=" + postId + "]").text().charAt(0)) + 1 + " Bình luận");
                        } else {
                            $("#count-liked-commented-" + postId).append("<a href='#' class='commentCount' data-id='" + postId + "' style='float: right'>1 Bình luận</a>");
                        }

                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        } else {
            $.ajax({
                type: "POST",
                url: "/Post/Comment",
                data: {
                    commentId: commentId,
                    postId: postId,
                    content: contentComment
                },
                dataType: "json",
                success: function (response) {
                    if (response.status) {
                        const comment = response.data;
                        $("span[data-id=" + commentId + "]").text(comment.Content);
                        $(".comment-content-inp[data-id = " + postId + "]").val("");
                        $(".btn-send-comment[data-id = " + comment.PostId + "]").attr("data-commentId", "0");
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });
        }
    });

    $(".btn-edit-comment").on("click", function (e) {
        e.preventDefault();
        const commentId = $(this).data("id");
        $.ajax({
            type: "GET",
            url: "/Post/GetComment",
            data: {
                id: commentId,
            },
            dataType: "json",
            success: function (response) {
                if (response.status) {
                    const comment = response.data;
                    console.log(comment);
                    $(".comment-content-inp[data-id = " + comment.PostId + "]").val(comment.Content);
                    $(".btn-send-comment[data-id = " + comment.PostId + "]").attr("data-commentId", commentId);
                }
            }
        });
        
    });

    $(".btn-delete-comment").on("click", function () {
        const commentId = $(this).data("id");
        $.ajax({
            type: "GET",
            url: "/Post/DeleteComment",
            data: {
                id: commentId,
            },
            dataType: "json",
            success: function (response) {
                if (response.status) {
                    const commentId = response.data;
                    $(".other-comment[data-id=" + commentId + "]").remove();
                }
            }
        });
    });

});