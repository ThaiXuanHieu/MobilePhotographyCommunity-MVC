$(document).ready(function () {
    $("#sort-post").on("change", function () {
        const type = $(this).val();
        console.log(type);
        $("#form-sort-post").submit();
    });
});