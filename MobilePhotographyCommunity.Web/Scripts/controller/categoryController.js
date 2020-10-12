﻿$(document).ready(function () {
    $(".btn-up").on("click", function () {
        var photos = $("#icon-input").get(0).files;
        var captionPost = $("#post-caption-input").val();
        var postId = $("#postId").val();
        var categoryId = $("#categoryId").val();

        if (photos.length == 0) {
            $(".err-msg").text("Bạn chưa chọn ảnh");
            return;
        }

        var formData = new FormData();

        for (var i = 0; i < photos.length; i++) {
            formData.append("Image", photos[i]);
        }

        formData.append("PostId", postId);
        formData.append("Caption", captionPost);
        formData.append("CategoryId", categoryId);

        $.ajax({
            type: "POST",
            url: "/Category/SavePost",
            dataType: "json",
            processData: false,
            contentType: false,
            data: formData,
            success: function (response) {
                if (response.status) {
                    window.location.reload();
                } else {
                    console.log("Lỗi!");
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    $(".btn-edit-post").on("click", function () {
        var postId = $(this).data("id");
        $.ajax({
            type: "GET",
            url: "/Post/LoadDetailPost",
            data: {
                postId: postId,
            },
            dataType: "json",
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    $(window).scrollTop(0);
                    $("#postId").val(data.PostId);
                    $("#categoryId").val(data.CategoryId);
                    $("#post-caption-input").val(data.Caption);
                    $("#img-preview").attr("src", "/UploadImage/Photo/" + data.Image);
                    $(".region-img-preview").css("display", "block");
                    $(".btn-up").text("Lưu");
                } else {
                    console.log("Lỗi!");
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

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

});