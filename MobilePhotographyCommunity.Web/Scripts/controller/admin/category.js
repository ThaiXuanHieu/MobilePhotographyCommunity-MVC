$(".switch-input").on("click", function () {
    var self = $(this);
    var checked = $(this).prop("checked");
    var status = 0;
    if (checked) {
        status = true;
    } else {
        status = false;
    }
    swal({
        title: "Hiển thị ngoài trang chủ?",
        text: "",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Đồng ý!",
        closeOnConfirm: false,
        cancelButtonText: "Hủy bỏ",
    }, function (isConfirm) {
        if (isConfirm) {
            $.ajax({
                url: "/Admin/Category/UpdateStatus",
                data: {
                    id: self.data("id"),
                    status: status
                },
                type: "POST",
                dataType: "json",
                success: function (response) {
                    if (response.status) {
                        self.prop("checked", checked);
                        swal("Cập nhật thành công!", "", "success");
                    } else {
                        self.prop("checked", !checked);
                        swal("Cập nhật thành công!", "", "success");
                    }
                },
                error: function (err) {
                    console.log(err);
                }
            });

        } else {
            if (checked) {
                $(self).prop("checked", false);
            } else {
                $(self).prop("checked", true);
            }
        }
    });
});
